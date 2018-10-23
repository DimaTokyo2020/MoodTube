using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Now we can enter eny ID we want
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTube.Models
{
    public class Singer
    {
        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SingerID { get; set; }
        public string SingerName { get; set; }
        public ICollection <Song> Songs { get; set; }
    }
}
