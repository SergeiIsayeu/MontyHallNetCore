using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Koza
{
    public class ExperimentSet
    {
        private readonly int _iterations;
        private readonly ISelectionBehavior _behavior;

        public ExperimentSet(int iterations, ISelectionBehavior behavior)
        {
            _iterations = iterations;
            _behavior = behavior;
        }
        /// <summary>
        /// Returns n winnings out of all experiments 
        /// </summary>
        /// <returns></returns>
        public int RunExperiment()
        {
            // create experiment
            // run experiment
            // get outcome - did the player win or not
            // aggregate outcome
            var winnings = 0;
            for (int i = 0; i < _iterations; i++)
            {
                var experiment = new Experiment(_behavior);
                if (experiment.RunGame())
                    winnings++;
            }

            return winnings;
        }
    }
}
