using Domain;
using HHTestTask1;
using Microsoft.EntityFrameworkCore;

namespace HHTestTask1
{
    public static class QueryManager
    {
        private readonly static ApplicationContext _db = new ApplicationContext();
        private static List<TaskModel> _taskPool = new List<TaskModel>();
        private readonly static int WAIT_SECONDS = 60;
        public async static Task<Guid> Add(Guid userId, DateTime from, DateTime to)
        {
            User user = await _db.Users.SingleAsync(c => c.Id.Equals(userId));

            Query q = new Query()
            {
                User = user,
                From = from,
                To = to
            };

            await _db.Queries.AddAsync(q);

            await _db.SaveChangesAsync();

            await StartTask(q);

            return q.Id;
        }

        public async static Task<double?> GetPercentage(Guid query)
        {
            var task = await _taskPool.ToAsyncEnumerable().FirstOrDefaultAsync(c => c.Query.Id.Equals(query));

            if (task == null || task.Task.Status != TaskStatus.WaitingForActivation)
                return null;

            int secondsPassed = (int)(DateTime.UtcNow - task.Query.StartTime).TotalSeconds;

            return ((double)secondsPassed / WAIT_SECONDS) * 100;
        }

        public async static Task StartUncompleatedQueries()
        {
            var queries = await _db.Queries.Include(c => c.Result).Include(c => c.User).Where(c => c.Result == null).ToListAsync();

            foreach (var query in queries)
            {
                await StartTask(query);
            }

        }

        private async static Task StartTask(Query q)
        {
            q.StartTime = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            _taskPool.Add(new TaskModel()
            {
                Query = q,
                Task = Task.Run(async () =>
                {
                    await TaskFunction(q);
                })
            });
        }

        private async static Task TaskFunction(Query q)
        {
            await Task.Delay(WAIT_SECONDS * 1000);
            Result r = new Result()
            {
                User = q.User,
                Count_Sign_In = await _db.SignInHistory.CountAsync(c => c.User.Equals(q.User) && q.From <= c.Login && c.Login <= q.To )
            };

            await _db.Results.AddAsync(r);

            q.Result = r;

            await _db.SaveChangesAsync();
        }
    }
}
