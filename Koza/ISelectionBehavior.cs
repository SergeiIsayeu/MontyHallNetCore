using System;
using System.Collections.Generic;
using System.Text;

namespace Koza
{
    public interface ISelectionBehavior
    {
        public int MakeFirstSelection(int[] options);
        public int MakeSecondSelection(int[] options);
    }
}
