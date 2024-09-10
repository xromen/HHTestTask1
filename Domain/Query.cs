using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Query
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required User User { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime StartTime { get; set; }
        public Result? Result { get; set; }
    }
}
