using Microsoft.AspNetCore.Mvc;
using SentinelScan.Api.Models;
using SentinelScan.Api.Services;

namespace SentinelScan.Api.Controllers
{
    [ApiController]//ii transmit .NET-ului ca asta e poarta de intrare pentru date 
    [Route("api/[controller]")]//ii am poarta de iesire /api/scanner
    public class ScannerController : Controller
    {
        private readonly ScannerOrchestrator _scannerOrchestrator;
       
        public ScannerController(ScannerOrchestrator scannerOrchestrator)
        {
            _scannerOrchestrator = scannerOrchestrator;
        }

        [HttpPost("scan")]//functia asta ma face sa fiu redirectat spre functia de mai jos in momentul in care acesez /api/scanner/scan
        //IAction Result imi da un cod HTTP care imi poate transmite daca pusca cv
        //[FromBody] asta imi spune de unde i au fisierele (mai uitate ce face asta ca nu e f clar)
        public async Task<IActionResult> ScanFiles([FromBody] List<FileToProcess> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("There were no files sent.");
            }

            var reports = await _scannerOrchestrator.ExecuteBatchAsync(files);

            //ok imi trimite un cod HTTP cum am spus mai sus si pune in BODY un json format din ce am in reports.
            return Ok(reports);
        }

        public IActionResult Index()
        {
            return View(); 
        }
    }
}
