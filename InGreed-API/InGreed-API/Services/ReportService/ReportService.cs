using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InGreed_API.Services.ReportService
{
    public class ReportService(
        InGreedDataContext context) : IReportService
    {
        public async Task<ResultBase> AddReport(AddReportRequest request)
        {
            var report = await context.Reports.SingleOrDefaultAsync(rep => rep.ProductId == request.ProductId && rep.ReporterId == request.ReporterId && rep.OpinionCreatorId == request.OpinionCreatorId); 
            if(report != null) 
            {
                return new ResultBase(false, $"User {request.ReporterId} has already reported opinion on {request.ProductId} created by {request.OpinionCreatorId}!");
            }

            Report NewReport = new Report
            {
                ReporterId = request.ReporterId,
                OpinionCreatorId = request.OpinionCreatorId,
                ProductId = request.ProductId,
                Reason = request.Reason
            };
            await context.Reports.AddAsync(NewReport);
            await context.SaveChangesAsync();
            return new ResultBase(true);
        }

        public async Task<ResultBase> DeleteReport(int ReportId)
        {
            var report = await context.Reports.SingleOrDefaultAsync(rep => rep.Id == ReportId);
            if(report == null)
            {
                return new ResultBase(false, $"Report with id {ReportId} doesn't exist!");
            }

            context.Reports.Remove(report);
            await context.SaveChangesAsync();
            return new ResultBase(true);
        }

        public async Task<List<ReportResponse>> GetReports()
        {
            var reportList = await context.Reports
                .Select(rep => new ReportResponse { Id = rep.Id, ReporterId = rep.ReporterId, OpinionCreatorId = rep.OpinionCreatorId, ProductId = rep.ProductId, Reason = rep.Reason})
                .ToListAsync();

            return reportList;
        }
    }
}
