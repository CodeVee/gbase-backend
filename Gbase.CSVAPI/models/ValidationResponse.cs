namespace Gbase.CSVAPI.Models
{
    public class ValidationResponse
    {
        public bool HasError { get; set; }
        public int LineNumber { get; set; }
        public List<ValidationError> Errors { get; set; } = new();
    }

    public class ValidationError
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
