namespace UserManagement.WebAPI.Filters
{
    internal class ServiceStatus
    {
        public ServiceStatus()
        {
        }

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ReasonPhrase { get; set; }
    }
}