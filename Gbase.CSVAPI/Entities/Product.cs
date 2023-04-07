#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class Product
    {
        public Product(string uniqueId, string title, string make, string model, string color, string description, 
            string year, string price, string dealerKey, string @case, string type, string condition)
        {
            UniqueId = uniqueId;
            Title = title;
            Make = make;
            Model = model;
            Color = color;
            Description = description;
            Year = year;
            Price = price;
            DealerKey = dealerKey;
            DealerNotes = string.Empty;
            ProductCase = @case;
            ProductType = type;
            ProductCondition = condition;
        }

        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Title { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Price { get; set;}
        public string DealerKey { get; set; }
        public string DealerNotes { get; set; }
        public string ProductCase { get; set;}
        public string ProductType { get; set; }
        public string ProductCondition { get; set; }
        public List<ProductPicture> Pictures { get; set; } = new();
        public List<ProductLink> Links { get; set; } = new();

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
