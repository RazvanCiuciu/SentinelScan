namespace SentinelScan.Api.Models
{
    public class FileToProcess
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long SizeInBytes {  get; set; }
        public bool IsEncrypted { get; set; }
        public byte[] Content { get; set; } 

    }
}
