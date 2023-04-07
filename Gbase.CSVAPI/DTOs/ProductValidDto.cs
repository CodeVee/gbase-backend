namespace Gbase.CSVAPI.DTOs
{
    public class ProductValidDto
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public bool Valid { get; set; }
        public List<ProductAddDto> Dtos { get; set; } = new();

        public static ProductValidDto Invalidate(string errorMessage) 
        { 
            return new ProductValidDto { ErrorMessage = errorMessage };
        }

        public static ProductValidDto Validate(List<ProductAddDto> dtos) 
        { 
            return new ProductValidDto {  Dtos = dtos }; 
        }
    }
}
