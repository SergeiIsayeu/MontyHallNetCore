using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace Koza
{
    public class ChangeSelectionBehavior: ISelectionBehavior
    {
        protected static Random Rnd = new Random((int)DateTime.Now.Ticks);

        private int _selection;

        public int MakeFirstSelection(int[] options)
        {
            int selection = Rnd.Next(options.Length - 1);
            _selection = selection;
            return _selection;
        }

        public int MakeSecondSelection(int[] options)
        {
            var selection = options.Where(_ => _ != _selection).Single();
            //Console.WriteLine($"First Selection {_selection}, second Selection {selection}");

            return selection;
        }
    }
}
