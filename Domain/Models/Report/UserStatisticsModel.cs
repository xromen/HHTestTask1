using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Report
{
    public class UserStatisticsModel
    {
        public Guid UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
