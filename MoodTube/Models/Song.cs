using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Now we can enter eny ID we want
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTube.Models
{
    public class Song
    {

        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SongID { get; set; }
        public string SongName { get; set; }
        public string SingerID { get; set; }
        public string MoodID { get; set; }
        public string Genre { get; set; }
        public  virtual Singer Singer{ get; set; }
        public virtual Mood Mood{ get; set; }

    }
}
