namespace ElectricityManagment.Models
{
    public class ManagementDatabaseSettings : IManagmentDatabaseSettings
    {
        public string ClientCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
