using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3 {
    class Program {
        static void Main(string[] args) {
            Program program = new Program();
            program.start();
        }

        void start() {
            MP3Player player = new MP3Player();
            MP3Player player1 = new MP3Player();
            MP3Player player2 = new MP3Player();

            player.addSong(new Song(
                title: "Billionaire",
                author: "Bruno Mars",
                playTimeInSeconds: 211
            ));

            player1.addSong(new Song(
                title: "Wish You Were Here",
                author: "Pink Floyd",
                playTimeInSeconds: 339
            ));

            player2.addSong(new Song(
                title: "Papillon",
                author: "Editors ",
                playTimeInSeconds: 324
            ));

            SimpleMP3Display mp3Display1 = new SimpleMP3Display(player);
            FancyMP3Display mp3Display2 = new FancyMP3Display(player);

            SimpleMP3Display mp3Display = new SimpleMP3Display(player1);
            FancyMP3Display mp3Display3 = new FancyMP3Display(player1);

            SimpleMP3Display mp3Displa = new SimpleMP3Display(player2);
            FancyMP3Display mp3Display4 = new FancyMP3Display(player2);

            player.nextSong();
            player1.nextSong();
            player2.nextSong();

            Console.ReadKey();
        }
    }
}
