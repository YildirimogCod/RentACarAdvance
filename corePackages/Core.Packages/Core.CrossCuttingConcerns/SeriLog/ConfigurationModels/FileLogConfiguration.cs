namespace Core.CrossCuttingConcerns.SeriLog.ConfigurationModels
{
    public class FileLogConfiguration
    {
        public string FilePath { get; set; }

        public FileLogConfiguration()
        {
            FilePath = string.Empty;
        }
        public FileLogConfiguration(string filePath)
        {
            FilePath = filePath;
        }
    }
}
