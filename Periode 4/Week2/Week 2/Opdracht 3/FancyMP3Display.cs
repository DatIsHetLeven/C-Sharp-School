using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3 {
    public class FancyMP3Display:IObserver {
        public FancyMP3Display(IObservable observable) => observable.addObserver(this);

        public void update(Song song) {
            Console.WriteLine($"Fancy display: {song.title} by {song.author} ({song.playTimeString})");
        }
    }
}
