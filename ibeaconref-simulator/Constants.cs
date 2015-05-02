using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibaeconref_simulator
{
    class Constants
    {
        public const int POPULATION_SIZE = 100;
        public const int GROUPS_ENTERING_MAX_SIZE = 5;

        // Shopping list size
        public const int SHOPPING_LIST_MIN_ITEMS = 2;
        public const int SHOPPING_LIST_MAX_ITEMS = 5;

        // Number of department / queues
        public const int NUMBER_OF_DEPARTMENTS = 12;
        public const int THRESHOLD_FOR_GLITCH = 6;          // 4 means glitch one time our of 4
    }
}
