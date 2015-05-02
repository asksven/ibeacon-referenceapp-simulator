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

using System;
using System.Collections.Generic;
using System.Linq;

namespace IBeaconRef.Data
{
    /// <summary>
    /// A customer comes to the Store with a shopping list and retrieves goods from Departements into his shopping cart
    /// </summary>
    class Customer
    {
        public String m_name { get; } = "";
        List<int> m_shoppingList = new List<int>();
        List<int> m_shoppingCart = new List<int>();
        static Random m_ramdomizer = new Random();

        int m_currentLocation = -1;
         

        // initilaize the shopping list
        public Customer(String name)
        {
            m_name = name;
            // randomize shopping cart size
            int items = m_ramdomizer.Next(2, Constants.SHOPPING_LIST_MAX_ITEMS+1); // creates a number between 1 and 12
            for (int i=1; i <= items; i++)
            {
                int item = m_ramdomizer.Next(1, Constants.NUMBER_OF_DEPARTMENTS);
                m_shoppingList.Add(item);
            }
        }

        public override string ToString()
        {
            return "Name=" + m_name + "; ShoppingList=" + string.Join(",", m_shoppingList) + "; ShoppingCart=" + string.Join(",", m_shoppingCart);

        }


        public void TakeArticle(int article)
        {
            // collect the article (if not 0) into the shoppting cart
            if (article != 0)
            {
                m_shoppingCart.Add(article);

                // cross it from the shopping list
                m_shoppingList.Remove(article);
            }
        }

        public int NextArticleInList()
        {
            if (m_shoppingList.Count() > 0)
            {
                return m_shoppingList.ElementAt(0);
            }
            else
            {
                return -1;
            }
        }




    }
}
