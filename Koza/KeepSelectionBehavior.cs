using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Koza
{
    public class KeepSelectionBehavior: ISelectionBehavior
    {
        private int _selection = 0;
        public int MakeFirstSelection(int[] options)
        {
            int selection = RandomNumberGenerator.GetInt32(0, options.Length - 1);
            _selection = options[selection];
            return _selection;
        }

        public int MakeSecondSelection(int[] options)
        {
            if (!options.Contains(_selection))
                throw new InvalidOperationException($"Options should contain selection {_selection}");
            return _selection;
        }
    }
}
