using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HikingTrails.Models
{
    public class Trail
    {
        public int Id { get; set; }

        [Display(Name = "Trail Name")]
        public string trailName { get; set; }

        [Display(Name = "Rating")]
        public int rating { get; set; }

        [Display(Name = "Review")]
        public string review { get; set; }

        public Trail()
        {

        }

    }
}
