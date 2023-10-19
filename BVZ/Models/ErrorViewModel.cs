namespace BVZ.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ValidationErrorMessage { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}