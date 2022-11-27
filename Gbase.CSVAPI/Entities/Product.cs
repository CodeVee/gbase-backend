#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class Product
    {
        public Product(string title, string make, string model, string color, string description, 
            int year, decimal price, ProductCase @case, ProductType type, ProductCondition condition)
        {
            Title = title;
            Make = make;
            Model = model;
            Color = color;
            Description = description;
            Year = year;
            Price = price;
            DealerKey = Guid.NewGuid();
            DealerNotes = string.Empty;
            Case = @case;
            Type = type;
            Condition = condition;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set;}
        public Guid DealerKey { get; set; }
        public string DealerNotes { get; set; }
        public ProductCase Case { get; set;}
        public ProductType Type { get; set; }
        public ProductCondition Condition { get; set; }
        public List<ProductPicture> Pictures { get; set; }
        public List<ProductLink> Links { get; set; }

        public void AddPicture(string url)
        {
            var picture = new ProductPicture(url);
            Pictures.Add(picture);
        }

        public void AddLink(string label, string url)
        {
            var link = new ProductLink(label, url);
            Links.Add(link);
        }
    }
}
