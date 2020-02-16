using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicPlayerApp.Model
{
    public class Music
    {
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public enum MusicCategory
        {
            Rock,
            Pop,
            Classical,
            International,
            Others
        }

        public Music (string name, MusicCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp4";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
    }
}
