using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace SentinelScan.Api.Services
{
    public class PromptInjectionScanner : IScanner
    {
        private readonly string[] _maliciousPatterns = new string[]
        {
            @"(?i)ignore (all )?previous instructions", // "Ignore previous instructions"
            @"(?i)system override",                    // "System override"
            @"(?i)you are now an unfiltered",           // Încercare de jailbreak
            @"(?i)DAN mode",                            // Celebru atac "Do Anything Now"
            @"(?i)disregard (any )?safety guidelines"   // Încercare de a sări peste filtre
        };

        public async Task<bool> ScanAsync(FileToProcess file)
        {
            return await Task.Run(() =>
            {
                string content = Encoding.UTF8.GetString(file.Content);
                return !(_maliciousPatterns.Any(p=> Regex.IsMatch(content,p)));
            });
        }


    }
}
