#nullable disable
using Gbase.CSVAPI.DTOs;
using Gbase.CSVAPI.Models;
using Gbase.CSVAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gbase.CSVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repository;

        public ProductController(ILogger<ProductController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("validate")]
        [ProducesResponseType(typeof(ApiResponse<List<ValidationResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromForm] ProductUploadDto request)
        {
            var validateResult = await _repository.ProcessFile(request.File);

            if (!validateResult.Valid) 
            {
                _logger.LogError("{{0}}", validateResult.ErrorMessage);
                return BadRequest(new ErrorResponse { Message = validateResult.ErrorMessage });
            }

            _logger.LogInformation("Valid Result");

            var validations = _repository.ValidateProducts(validateResult.Dtos);
            var invalidProductsCount = validations.Count(v => v.HasError);
            var response = new ApiResponse<List<ValidationResponse>>
            {
                Data = validations,
                Message = $"{invalidProductsCount} Product(s) has errors"
            };
            return Ok(response);
        }

        [HttpPost("store")]
        [ProducesResponseType(typeof(ApiResponse<List<ValidationResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Store([FromForm] ProductUploadDto request)
        {
            var validateResult = await _repository.ProcessFile(request.File);

            if (!validateResult.Valid)
            {
                _logger.LogError("{{0}}", validateResult.ErrorMessage);
                return BadRequest(new ErrorResponse { Message = validateResult.ErrorMessage });
            }

            _logger.LogInformation("Valid Result");

            var validations = _repository.ValidateProducts(validateResult.Dtos);
            var invalidProductsCount = validations.Count(v => v.HasError);
            var validProductsCount = validations.Count - invalidProductsCount;
            var response = new ApiResponse<List<ValidationResponse>>
            {
                Data = validations,
                Message = $"{validProductsCount} Product(s) saved. {invalidProductsCount} Product(s) has errors"
            };
            return Ok(response);
        }

        [HttpGet("fileheaders")]
        [ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFileHeaders()
        {
            var result = await Task.FromResult(_repository.GetFileHeaders());
            var response = new ApiResponse<List<string>>
            {
                Message = "Valid Headers",
                Data = result
            };

            return Ok(response);
        }

    }
}
