using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class ScannerOrchestrator
    {
        private readonly IScanner[] _scanners;

        public ScannerOrchestrator(IEnumerable<IScanner> scanners)
        {
            _scanners = scanners.ToArray();
        }

        private async Task<ScanReport> ScanSingleFileAsync(FileToProcess file)
        {
            ScanReport report = new ScanReport();
            report.Name = file.Name;
            report.ScanTime = DateTime.Now;
            report.IsSafe = true;

            List<Task<bool>> scannerTasks = new List<Task<bool>>();
            foreach (var scanner in _scanners)
            {
                scannerTasks.Add(scanner.ScanAsync(file));
            }

            bool[] results = await Task.WhenAll(scannerTasks);

            for (int i = 0; i < results.Length; i++)
            {
                if (!results[i])
                {
                    report.IsSafe = false;
                    string scannerName = _scanners[i].GetType().Name;
                    report.FoundIssues.Add($"Security check failled at {scannerName}\n");
                }
            }
            return report;
        }


        public async Task<List<ScanReport>> ExecuteBatchAsync(List<FileToProcess> files)
        {
            List<Task<ScanReport>> scanTasks = new List<Task<ScanReport>>();

            foreach (var file in files)
            {
                Task<ScanReport> task = ScanSingleFileAsync(file);
                scanTasks.Add(task);
            }

            ScanReport[] resultsArray = await Task.WhenAll(scanTasks);

            List<ScanReport> finalResults = new List<ScanReport>();
            foreach (ScanReport scanReport in resultsArray)
            {
                finalResults.Add(scanReport);
            }

            return finalResults;
        }

    }

}

