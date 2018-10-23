using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Now we can enter eny ID we want
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTube.Models
{
    public class Mood
    {
        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MoodID { get; set; }
        public ICollection <Song> Songs { get; set; }
    }
}
