namespace FixWithCustomSerialization.Models
{
    public class MediaStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MediaCollectionName { get; set; } = null!;
    }
}
