using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class ExtensionScanner :IScanner
    {
        private readonly HashSet<string> _allowedExtensions = new()
        {
            ".md", ".json", ".txt", ".yaml", ".py"
        };
        public async Task<bool> ScanAsync(FileToProcess file)
        {

            return await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(file.Extension))
                    return false;

                string extension = file.Extension.ToLower().Trim();
                return _allowedExtensions.Contains(extension);
            });


        }
    }
}
