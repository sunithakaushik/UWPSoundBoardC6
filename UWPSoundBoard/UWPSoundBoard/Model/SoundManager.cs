using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UWPSoundBoard.Model
{
    public class SoundManager
    {
        private List<Sound> getSounds()
        {
            var sounds = new List<Sound>();
            sounds.Add(new Sound("Cow", Sound.SoundCategory.Animals));
            sounds.Add(new Sound("Cat", Sound.SoundCategory.Animals));

            sounds.Add(new Sound("Gun", Sound.SoundCategory.Cartoons));
            sounds.Add(new Sound("Spring", Sound.SoundCategory.Cartoons));

            sounds.Add(new Sound("Clock", Sound.SoundCategory.Taunts));
            sounds.Add(new Sound("LOL", Sound.SoundCategory.Taunts));

            sounds.Add(new Sound("Ship", Sound.SoundCategory.Warnings));
            sounds.Add(new Sound("Siren", Sound.SoundCategory.Warnings));

            return sounds;
        }

    }
}
