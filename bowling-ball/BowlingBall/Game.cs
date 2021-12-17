using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        int[] pinFallsAginstRolls = new int[21];
        int rollsCounter;
        public void Roll(int pins)
        {
            pinFallsAginstRolls[rollsCounter] = pins;
            rollsCounter++;
        }

        public int GetScore()
        {
            int score = 0;
            int i = 0;
            for(int frame=0;frame<10;frame++)
            {
                if (pinFallsAginstRolls[i]==10)// strike  condition
                {
                    score += 10 + pinFallsAginstRolls[i + 1] + pinFallsAginstRolls[i + 2];
                    
                    i = i + 1;
                }
                else if (pinFallsAginstRolls[i]+ pinFallsAginstRolls[i+1]==10)// spare condition
                {
                    score += 10 + pinFallsAginstRolls[i + 2];
                    i = i + 2;
                }
                else
                {
                    score += pinFallsAginstRolls[i] + pinFallsAginstRolls[i+1];
                    i = i + 2;

                }
            }
            return score;
        }
    }
}
