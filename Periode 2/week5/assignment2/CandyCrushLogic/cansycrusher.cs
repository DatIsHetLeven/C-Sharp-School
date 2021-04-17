using System;

namespace CandyCrushLogic
{
    public class CandyCrusher
    {
        /*
         * This function  receives the 2-dim array as a parameter.
         * This method returns true if there are 3 (or more) symbols next to each other in one row,
         * otherwise it returns false.
         */
        public static bool ScoreRowPresent(RegularCandies[,] playingField)
        {
            int counter = 1;
            for (int rows = 0; rows < playingField.GetLength(1); rows++)
            {
                counter = 1;

                // to keep current candy color in memory
                RegularCandies current_candy = RegularCandies.None;
                // to keep next candy's color in memory
                RegularCandies next_candy = RegularCandies.None;

                for (int cols = 0; cols < playingField.GetLength(0); cols++)
                {
                    next_candy = playingField[cols, rows];

                    //if color is matching then we increase the counter
                    if (next_candy == current_candy)
                    {
                        counter++;
                    }
                    else //reset the counter
                    {
                        counter = 1;
                    }

                    //update the value of current candy so that we can compare in the next iteration
                    current_candy = next_candy;

                    //if we have found three consecutive candy matches we return true
                    if (counter == 3)
                    {
                        Console.WriteLine("\nrow score in row {0}\n", rows);
                        return true;
                    }
                }
            }
            //if we have found not three consecutive candy matches we return false
            Console.WriteLine("\nno row score");
            return false;
        }


        public static bool ScoreColumnPresent(RegularCandies[,] playingField)
        {
            int counter = 1;

            /*
             * Same as ScoreRowPresent, however, now in outer loop we traverse columns
             * and in the inner loop we traverse the rows
             */
            for (int cols = 0; cols < playingField.GetLength(0); cols++)
            {
                //Console.WriteLine("\nrow {0}\n", cols);
                counter = 1;
                RegularCandies current_candy = RegularCandies.None;
                RegularCandies next_candy = RegularCandies.None;

                for (int rows = 0; rows < playingField.GetLength(1); rows++)
                {
                    next_candy = playingField[cols, rows];
                    if (next_candy == current_candy)
                    {
                        //Console.Write("{0}\t", counter);
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                    }
                    current_candy = next_candy;
                    if (counter == 3)
                    {
                        Console.WriteLine("\ncolumn score in col {0}\n", cols);
                        return true;
                    }
                }
            }
            Console.WriteLine("\nno column score");
            return false;
        }
    }
}
