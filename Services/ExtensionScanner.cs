using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class ExtensionScanner :IScanner
    {
        public async Task<bool> ScanAsync(FileToProcess file)
        {
            return await Task.Run(() =>
            {
                if (file.Extension == ".md" || file.Extension == ".json" || file.Extension == ".yaml" || file.Extension == ".yml" || file.Extension == ".txt" || file.Extension == ".py")
                    return true;
                return false;
            });
        }
    }
}
