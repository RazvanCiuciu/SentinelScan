using SentinelScan.Api.Models;

namespace SentinelScan.Api.Interfaces
{
    public interface IScanner
    {
        Task<bool> ScanAsync(FileToProcess file);
    }
}
