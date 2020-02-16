using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UWPSoundBoard.Model.Sound;

namespace UWPSoundBoard.Model
{
    public class MenuItem
    {
        public string IconFile { get; set; }
        public SoundCategory  Category { get; set; }
    }
}
