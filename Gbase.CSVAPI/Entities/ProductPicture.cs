#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class ProductPicture
    {
        public ProductPicture(string url)
        {
            Url = url;
        }

        public long Id { get; set; }
        public string Url { get; set; }
    }
}
