using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Koza
{
    public class Experiment
    {
        private readonly ISelectionBehavior _behavior;

        public Experiment(ISelectionBehavior behavior)
        {
            _behavior = behavior;
        }

        public bool RunGame()
        {
            //Console.WriteLine($"Playing game");

            // do iteration 1
            var carPosition = RandomNumberGenerator.GetInt32(0, 3);
            List<bool> field = new List<bool>()
            {
                false, false, false
            };
            field[carPosition] = true;
            //Console.WriteLine($"Car position {carPosition}");
            var playerSelection = _behavior.MakeFirstSelection(new int[]{0,1,2});
            // do iteration 2
            var newOptions = NewSelectionOption(field, playerSelection);
            var newPlayerSelection = _behavior.MakeSecondSelection(newOptions);
            if (newPlayerSelection == carPosition)
            {
                //Console.WriteLine($"Car Index {carPosition}, Player Selection: {newPlayerSelection}");
                return true;
            }
            else
            {   
                //Console.WriteLine($"Car Index {carPosition}, Player Selection: {newPlayerSelection}");
                return false;
            }
        }

        /// <summary>
        /// returns position selection options with one excluded non-koza index
        /// </summary>
        /// <param name="originalSelection"></param>
        /// <param name="playerSelection"></param>
        /// <returns></returns>
        int[] NewSelectionOption(List<bool> field, int playerSelection)
        {
            // another element from index that is not first koza and not player selection. 
            int indexOfFirstNonSelectedKoza = 0;
            for (int i = 0; i < field.Count; i++)
            {
                if (i != playerSelection && field[i] == false)
                {
                    indexOfFirstNonSelectedKoza = i;
                    break;
                }
            }


            int optionIndex = 0;
            for (int i = 0; i < field.Count; i++)
            {
                if (i != playerSelection && i != indexOfFirstNonSelectedKoza)
                {
                    optionIndex = i;

                }

            } 
            if (optionIndex == playerSelection)
                throw new InvalidOperationException("Both options are of player selection option");
            return new int[] {playerSelection, optionIndex};
        }
    }
}