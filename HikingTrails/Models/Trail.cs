using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingTrails.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string trailName { get; set; }
        public int rating { get; set; }
        public string review { get; set; }

        public Trail()
        {

        }

    }
}
