using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ibaeconref_simulator
{
    class Program
    {
        static Random m_rnd = new Random();
        static Store m_store = new Store();
        static List<Customer> m_population = new List<Customer>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the store simulation");

            // create a population
            for (int i = 0; i < Constants.POPULATION_SIZE; i++)
            {
                Customer customer = new Customer("C" + i);
                Console.WriteLine(customer.ToString());
                m_population.Add(customer);

            }

            int time = 0;
            while( (m_population.Count()+m_store.GetWaitingCustomers()) > 0 )
            {
                // deliver articles
                m_store.Print();
                m_store.ProcessDeliveries();
               

                // decide how many people enter the store
                int number = m_rnd.Next(0, Constants.GROUPS_ENTERING_MAX_SIZE+1);
                for (int i=0; i < number; i++)
                {
                    if (m_population.Count > 0)
                    {
                        // remove the customer from the population
                        Customer newCustomer = m_population.First();
                        m_population.Remove(newCustomer);
                        // and send him into the store
                        m_store.SendCustomerToDepartment(newCustomer, newCustomer.NextArticleInList());
                    }
                }

                Console.WriteLine("Store at time " + time);
                //Print();
                Console.ReadLine();
                time++;
            }




        }

        static void Print()
        {
            Console.WriteLine("Population");
            String gauge = "";
            for (int i = 0; i < m_population.Count; i++)
            {
                gauge += "+";
            }
            Console.WriteLine(gauge);

            Console.WriteLine("Store");
            m_store.Print();
        }
    }
}
