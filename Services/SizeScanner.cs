using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class SizeScanner : IScanner
    {
        private const long maxAllowedSize = 10 * 1024 * 1024;
        public async Task<bool> ScanAsync(FileToProcess file)
        {
            return await Task.Run(() =>
            {
                if (file.SizeInBytes > maxAllowedSize || file.SizeInBytes <= 0)
                    return false;
                return true;
            });
        }
    }
}
    