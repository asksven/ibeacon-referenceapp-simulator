using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibaeconref_simulator
{
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
