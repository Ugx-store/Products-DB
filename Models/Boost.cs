using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Boost
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Username { get; set; }
        public bool Boosted { get; set; } 
        public int BoostPrice { get; set; }
        public DateTime BoostStartTime { get; set; }
        public DateTime BoostEndTime { get; set; }
    }
}
