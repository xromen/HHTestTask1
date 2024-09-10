using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Result
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required User User { get; set; }
        public int Count_Sign_In { get; set; } = 0;
    }
}
