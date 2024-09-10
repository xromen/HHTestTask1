using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SignInHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required User User { get; set; }
        public DateTime Login { get; set; }
    }
}
