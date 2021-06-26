using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3 {
    public class Song {
        public int playTimeInSeconds;

        public string title { get; set; }
        public string author { get; set; }
        public string playTimeString {
            get {
                int minutes = playTimeInSeconds / 60;
                int seconds = playTimeInSeconds % 60;

                return "0" + minutes + ":" + seconds;
            }
        }

        public Song(string title, string author, int playTimeInSeconds) {
            this.title = title;
            this.author = author;
            this.playTimeInSeconds = playTimeInSeconds;
        }
    }
}
