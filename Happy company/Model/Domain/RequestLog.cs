namespace Happy_company.Model.Domain
{
    public class RequestLog
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
