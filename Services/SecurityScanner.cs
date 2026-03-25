using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class SecurityScanner : IScanner
    {
        public async Task<bool> ScanAsync(FileToProcess file)
        {
            return await Task.Run(() => 
            { if (file.IsEncrypted)
                    return false;
                return true;
            });
        }
    }
}
