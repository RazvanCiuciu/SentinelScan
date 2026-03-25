using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Models;

namespace SentinelScan.Api.Services
{
    public class ScannerOrchestrator
    {
        public IEnumerable<IScanner> _scanners;

        public ScannerOrchestrator(IEnumerable<IScanner> scanners)
        {
            _scanners = scanners;
        }
        
        private ScanReport GenerateReport(FileToProcess file)
        {
            ScanReport report = new ScanReport();
            report.IsSafe = true;
            report.Name = file.Name;
            report.ScanTime = DateTime.Now;

            foreach (var scanners in _scanners)
            {
                if(scanners.Scanner(file) is false)
                {
                    report.IsSafe = false;
                    report.FoundIssues.Add($"{file.Name} has failled the {_scanners.GetType()}");
                }
                
            }
            return report;
        }


        //task e ca un quest pe care il dau compilatorul pe care poate sa il faca doar ca are resursele necesare sau indeplineste anumita conditie
        //basicly eu ii dau lui task ul de a citii lista cu Scan reports
        public async Task<List<ScanReport>> ExecuteBatchAsync(List<FileToProcess> files)
        {
            //aici vac o lista cu taskuri care ma ajuta sa fac paralelism
            List<Task<ScanReport>> scanTasks = new List<Task<ScanReport>>();

            foreach (var file in files) 
            { 
                //aici creez lista cu taskuri
                Task <ScanReport> task = Task.Run(() => GenerateReport(file));
                scanTasks.Add(task);
            }
            //aici fac programul sa astepte sa se termine toate takurile
            ScanReport[] arrayResults = await Task.WhenAll(scanTasks);

            List<ScanReport> finalReports = new List<ScanReport>();
            foreach (var report in arrayResults)
            {
                finalReports.Add(report);
            }


            //aici desi returnez o lista de scan reports, programul imi trimite mai departe sub forma de task
            return finalReports;
        }
    }
}
