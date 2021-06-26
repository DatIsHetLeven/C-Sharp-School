using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3 {
    public class MP3Player: IObservable {
        private List<Song> songs = new List<Song>();
        private int currentSongIndex = 0;
        private List<IObserver> observers = new List<IObserver>();

        public Song currentSong {
            get {
                if (songs.Count == 0) throw new Exception("Player has no songs queued");

                return songs[currentSongIndex];
            }
        }

        public void addSong(Song song) => songs.Add(song);

        public void nextSong() {
            Random random = new Random();
            currentSongIndex = random.Next(0, songs.Count);

            updateObsersers();
        }

        private void updateObsersers() {
            foreach (IObserver observer in observers) {
                observer.update(currentSong);
            }
        }

        public void addObserver(IObserver observer) => observers.Add(observer);
        public void removeObserver(IObserver observer) => observers.Remove(observer);
    }
}
