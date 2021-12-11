using System;
using System.Threading.Channels;

namespace Koza
{
    class Program
    {
        static void Main(string[] args)
        { ;
            int nExperiments = 10000;
            var experiment1 = new ExperimentSet(nExperiments, new KeepSelectionBehavior());
            var experiment1Outcome = experiment1.RunExperiment();
            Console.WriteLine($"KeepSelectionBehavior, iterations {nExperiments}, Winnings: {experiment1Outcome}");

            var experiment2 = new ExperimentSet(nExperiments, new ChangeSelectionBehavior());
            var experiment2Outcome = experiment2.RunExperiment(); 
            Console.WriteLine($"ChangeSelectionBehavior, iterations {nExperiments}, Winnings: {experiment2Outcome}");

        }
    }
}
