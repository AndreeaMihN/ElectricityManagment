namespace ElectricityManagment.Models
{
    public interface IManagmentDatabaseSettings
    {
        string ClientCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
