using Api.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.DatabaseContext;

namespace Api.Controllers;

[Route("api/v1/data")]
[ApiController]
public class DataController
{
    private readonly DataContext _context;

    public DataController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("exportData")]
    [Authorize(Roles = "Administrator")]
    [FileDownload(FileName = "Data.xlsx")]
    public async Task<IActionResult> ExportData()
    {
        var gyms = _context.Gyms.ToList();
        var gymEnrollmentRequests = _context.GymEnrollmentRequests.ToList();
        var measurements = _context.Measurements.ToList();
        var members = _context.Members.ToList();
        

        using (var workbook = new XLWorkbook())
        {
            AddWorksheet(workbook, "Gyms", gyms);
            AddWorksheet(workbook, "GymEnrollmentRequests", gymEnrollmentRequests);
            AddWorksheet(workbook, "Measurements", measurements);
            AddWorksheet(workbook, "Members", members);

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return new FileContentResult(content, "application/vnd.ms-excel");
            }
        }
    }

    private void AddWorksheet<T>(IXLWorkbook workbook, string worksheetName, IList<T> data)
    {
        var worksheet = workbook.Worksheets.Add(worksheetName);
        worksheet.Cell(1, 1).InsertTable(data);
    }
}