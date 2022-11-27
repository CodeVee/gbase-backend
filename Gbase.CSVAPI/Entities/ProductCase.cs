#nullable disable
namespace Gbase.CSVAPI.Entities
{
    public class ProductCase
    {
        public static readonly ProductCase None = new(1, "None");
        public static readonly ProductCase Hard = new(2, "Hard");
        public static readonly ProductCase Soft = new(3, "Soft");
        public static readonly ProductCase GigBag = new(4, "GigBag");
        public static readonly ProductCase OriginalHard = new(5, "Original Hard");
        public static readonly ProductCase OriginalSoft = new(6, "Original Soft");
        public static readonly ProductCase[] Cases = {
            None, Hard, Soft, GigBag, OriginalHard, OriginalSoft
        };
        public ProductCase(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public static ProductCase FromName(string name) =>
            Cases.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
    }
}
