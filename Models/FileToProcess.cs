namespace SentinelScan.Api.Models
{
    public class FileToProcess
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public int SizeInMB {  get; set; }
        public bool IsEncrypted { get; set; }

    }
}
