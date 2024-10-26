using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;

namespace InGreed_API.Services.ReportService
{
    public interface IReportService
    {
        Task<ResultBase> AddReport(AddReportRequest request);
        Task<List<ReportResponse>> GetReports();
        Task<ResultBase> DeleteReport(int ReportId);
    }
}
