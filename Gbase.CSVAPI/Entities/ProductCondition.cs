#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class ProductCondition
    {
        public static readonly ProductCondition BrandNew = new(1, "Brand New");
        public static readonly ProductCondition Mint = new(2, "Mint");
        public static readonly ProductCondition NearMint = new(3, "Near Mint");
        public static readonly ProductCondition Excellent = new(4, "Excellent");
        public static readonly ProductCondition VeryGood = new(5, "Very Good");
        public static readonly ProductCondition Good = new(6, "Good");
        public static readonly ProductCondition Fair = new(7, "Fair");
        public static readonly ProductCondition Poor = new(8, "Poor");
        public static readonly ProductCondition[] Conditions = { 
            BrandNew, Mint, NearMint, Excellent,
            VeryGood, Good,Fair, Poor 
        };
        public ProductCondition(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public static ProductCondition FromName(string name) =>
            Conditions.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
    }
}
