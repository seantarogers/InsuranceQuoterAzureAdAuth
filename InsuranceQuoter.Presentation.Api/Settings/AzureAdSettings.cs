namespace InsuranceQuoter.Presentation.Api.Settings
{
    public class AzureAdSettings
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string Scope { get; set; }
    }
}