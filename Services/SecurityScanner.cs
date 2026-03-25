using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class SecurityScanner : IScanner
    {
        public bool Scanner(FileToProcess file)
        {
            return !file.IsEncrypted;
        }
    }
}
