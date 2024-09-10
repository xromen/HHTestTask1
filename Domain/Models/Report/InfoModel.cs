using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Report
{
    public class InfoModel
    {
        public Guid Query { get; set; }
        public double Percent { get; set; }
        public InfoResult? Result { get; set; }
    }

    public class InfoResult
    {
        public Guid User_Id { get; set; }
        public int Count_Sign_In { get; set; }

        public static implicit operator InfoResult(Result res)
        {
            return new InfoResult
            {
                User_Id = res.User.Id,
                Count_Sign_In = res.Count_Sign_In
            };
        }
    }
}
