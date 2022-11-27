#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class ProductLink
    {
        public ProductLink(string label, string url)
        {
            Label= label;
            Url= url;
        }
        public long Id { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
    }
}
