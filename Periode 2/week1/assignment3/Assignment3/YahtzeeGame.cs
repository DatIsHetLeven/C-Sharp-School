using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class YahtzeeGame
    {
        Dice []dice;

        public void Init()
        {
            dice = new Dice[5];
            for (int i = 0; i < 5; i++)
                dice[i] = new Dice();
        }

        public void Throw()
        {
            for (int i = 0; i < 5; i++)
                dice[i].Throw();
        }

        public void DisplayValues()
        {
            for (int i = 0; i < 5; i++)
            {
                dice[i].DisplayValue();
            }
            Console.WriteLine();

        }

        public bool Yahtzee()
        {
            for (int i = 0; i < 4; i++)
                if (dice[i].value != dice[i + 1].value)
                    return false;
            return true;
        }

    }


}
