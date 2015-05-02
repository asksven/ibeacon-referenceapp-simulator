using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibaeconref_simulator
{
    class Store
    {
        Department[] m_departments = new Department[Constants.NUMBER_OF_DEPARTMENTS];

        public Store()
        {
            for (int i=0; i<Constants.NUMBER_OF_DEPARTMENTS; i++)
            {
                m_departments[i] = new Department(i);
            }
        }

        public void SendCustomerToDepartment(Customer customer, int department)
        {
            if (department >= 0)
            {
                m_departments[department].CustomerEnters(customer);
            }
        }

        public void ProcessDeliveries()
        {
            List<Customer> enRoute = new List<Customer>();

            // deliver the customers waiting their articles
            for (int i = 0; i < Constants.NUMBER_OF_DEPARTMENTS; i++)
            {
                Customer comingOutofLine = m_departments[i].ProcessQueue();
                
                if (comingOutofLine != null)
                {
                    enRoute.Add(comingOutofLine);
                }
            }

            // send the customers to the next station
            for (int i = 0; i < enRoute.Count(); i++)
            {
                Customer customer = enRoute.ElementAt(i);
                SendCustomerToDepartment( customer, customer.NextArticleInList());
            }

        }

        public void Print()
        {
            // go through all departments and print the number of customers in line
            for (int i = 0; i < Constants.NUMBER_OF_DEPARTMENTS; i++)
            {
                Console.WriteLine("Department " + i + ":" + m_departments[i].ToString());
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < Constants.NUMBER_OF_DEPARTMENTS; i++)
            {
                Console.WriteLine("Department " + i + " customers:");
                m_departments[i].PrintWaitingLine();
            }
        }

        public int GetWaitingCustomers()
        {
            int ret = 0;
            for (int i = 0; i < Constants.NUMBER_OF_DEPARTMENTS; i++)
            {
                ret += m_departments[i].GetNumberWaiting();
            }

            return ret;
        }
    }
}
