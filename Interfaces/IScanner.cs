using SentinelScan.Api.Models;

namespace SentinelScan.Api.Interfaces
{
    public interface IScanner
    {
        public bool Scanner(FileToProcess file);
    }
}
