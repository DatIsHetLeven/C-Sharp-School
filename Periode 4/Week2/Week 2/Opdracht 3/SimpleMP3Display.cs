using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3 {
    public class SimpleMP3Display:IObserver {
        public SimpleMP3Display(IObservable observable) => observable.addObserver(this);

        public void update(Song song) {
            Console.WriteLine($"Simple display: {song.author} - {song.title}");
        }
    }
}
