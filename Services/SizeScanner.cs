using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class SizeScanner : IScanner
    {
        public bool Scanner(FileToProcess file)
        {
            if (file.SizeInMB > 100)
                return false;
            return true;
        }
    }
}
