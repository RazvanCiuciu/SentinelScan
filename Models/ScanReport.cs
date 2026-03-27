namespace SentinelScan.Api.Models
{
    public class ScanReport
    {
        public string Name {  get; set; }
        public bool IsSafe { get; set; } 
        public DateTime ScanTime  {  get; set; }
        public List<string> FoundIssues { get; set; }

        public ScanReport()
        {
            FoundIssues = new List<string>();
            IsSafe = true;
        }

    }
}
