using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class ExtensionScanner :IScanner
    {
        public bool Scanner(FileToProcess file)
        {
            if (file.Extension == ".exe" || file.Extension == ".bat" || file.Extension == ".vbs")
                return false;
            return true;
        }
    }
}
