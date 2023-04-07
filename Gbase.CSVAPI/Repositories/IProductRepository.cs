using Gbase.CSVAPI.DTOs;
using Gbase.CSVAPI.Models;

namespace Gbase.CSVAPI.Repositories
{
    public interface IProductRepository
    {
        Task<ProductValidDto> ProcessFile(IFormFile file);
        List<ValidationResponse> ValidateProducts(List<ProductAddDto> dtos);
        List<string> GetFileHeaders();
    }
}
