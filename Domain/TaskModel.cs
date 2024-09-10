using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TaskModel
    {
        public required Query Query { get; set; }
        public required Task Task { get; set; }
    }
}
