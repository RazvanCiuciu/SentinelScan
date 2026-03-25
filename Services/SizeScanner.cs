using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class SizeScanner : IScanner
    {
        public async Task<bool> ScanAsync(FileToProcess file)
        {
            return await Task.Run(() =>
            {
                if (file.SizeInMB > 10 || file.SizeInMB <= 0)
                    return false;
                return true;
            });
        }
    }
}
    