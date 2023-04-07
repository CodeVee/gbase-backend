using Gbase.CSVAPI.DTOs;
using Gbase.CSVAPI.Models;
using Gbase.CSVAPI.Validators;

namespace Gbase.CSVAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }
        public async Task<ProductValidDto> ProcessFile(IFormFile file)
        {
            try
            {
                using var reader = new StreamReader(file.OpenReadStream());
                var csvData = await reader.ReadToEndAsync();
                var rows = csvData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                var headers = rows.First().Split(",");
                if (!ValidateHeaders(headers))
                {
                    return ProductValidDto.Invalidate("Invalid CSV headers");
                }

                var dataRows = rows.Skip(1).Select(row => ParseCsvRow(row)).ToList();

                if (dataRows.Count > 100)
                {
                    return ProductValidDto.Invalidate("Maximum number of data rows exceeded");
                }

                var productDtos = new List<ProductAddDto>();
                foreach (var dataRow in dataRows)
                {
                    if (dataRow.Length != headers.Length)
                    {
                        return ProductValidDto.Invalidate("Invalid number of values in a row");
                    }
                    var row = new ProductAddDto();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var prop = typeof(ProductAddDto).GetProperty(headers[i]);
                        if (prop != null)
                        {
                            try
                            {
                                var value = Convert.ChangeType(dataRow[i], prop.PropertyType);
                                prop.SetValue(row, value);
                            }
                            catch (FormatException)
                            {
                                // Set the property value to its default value
                                prop.SetValue(row, prop.PropertyType.IsValueType ? Activator.CreateInstance(prop.PropertyType) : null);
                            }
                        }
                    }
                    productDtos.Add(row);
                }

                return ProductValidDto.Validate(productDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing CSV file");
                return ProductValidDto.Invalidate("Error parsing CSV file");
            }
        }

        public List<ValidationResponse> ValidateProducts(List<ProductAddDto> dtos)
        {
            var vrList = new List<ValidationResponse>();
            for (int i = 0; i < dtos.Count; i++)
            {
                var item = dtos[i];
                var lineNumber = i + 1;
                ValidationResponse vr = ValidateProduct(item, lineNumber);
                vrList.Add(vr);
            }

            return vrList;
        }

        public List<string> GetFileHeaders()
        {
            var properties = typeof(ProductAddDto).GetProperties();
            return properties.Select(p => p.Name).ToList();
        }

        private static string[] ParseCsvRow(string row)
        {
            var result = new List<string>();
            var inQuote = false;
            var currentCell = "";

            foreach (var c in row)
            {
                if (c == '"')
                {
                    inQuote = !inQuote;
                }
                else if (c == ',' && !inQuote)
                {
                    result.Add(currentCell.Trim());
                    currentCell = "";
                }
                else
                {
                    currentCell += c;
                }
            }

            result.Add(currentCell.Trim());

            return result.ToArray();
        }

        private static bool ValidateHeaders(string[] headers)
        {
            var properties = typeof(ProductAddDto).GetProperties();
            var expectedHeaders = properties.Select(p => p.Name).ToArray();
            return headers.SequenceEqual(expectedHeaders);
        }

        private static ValidationResponse ValidateProduct(ProductAddDto item, int lineNumber)
        {
            var validator = new ProductAddValidator();
            var validationResult = validator.Validate(item);

            var vr = new ValidationResponse
            {
                LineNumber = lineNumber
            };
            if (!validationResult.IsValid)
            {
                vr.HasError = true;

                foreach (var failure in validationResult.Errors)
                {
                    var ve = new ValidationError
                    {
                        PropertyName = failure.PropertyName,
                        ErrorMessage = failure.ErrorMessage
                    };
                    vr.Errors.Add(ve);
                }
            }

            return vr;
        }
    }
}
