using Domain;
using Domain.Models.Report;
using HHTestTask1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HHTestTask1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ApplicationContext _db;

        public ReportController(ILogger<ReportController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<Guid> User_Statistics([FromBody] UserStatisticsModel model)
        {
            Guid query = await QueryManager.Add(model.UserId, model.From, model.To);
            return query;
        }

        [HttpGet]
        public async Task<InfoModel?> Info(Guid queryId)
        {
            Query? q = await _db.Queries.Include(c => c.Result).ThenInclude(c => c.User).FirstOrDefaultAsync(c => c.Id.Equals(queryId));

            if (q == null)
                throw new Exception("Запроса с таким Id не существует");

            if (q.Result != null)
            {
                return new InfoModel()
                {
                    Query = queryId,
                    Percent = 100,
                    Result = q.Result
                };
            }

            double? percent = await QueryManager.GetPercentage(queryId);

            if (!percent.HasValue)
                throw new Exception("Произошла ошибка. Данный запрос создан но не выполняется");

            return new InfoModel()
            {
                Query = queryId,
                Percent = percent.Value
            };
        }
    }
}
