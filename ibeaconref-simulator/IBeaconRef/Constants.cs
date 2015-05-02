//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//


namespace IBeaconRef
{
    /// <summary>
    /// Represents the parameters of the simulation
    /// </summary>
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
