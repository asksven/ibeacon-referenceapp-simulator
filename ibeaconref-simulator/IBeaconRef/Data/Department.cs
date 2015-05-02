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
using IBeaconRef.EventHub;

namespace IBeaconRef.Data
{
    /// <summary>
    /// Implements the logic of departments, managing Customers waiting in queues and delivering them goods
    /// </summary>
    class Department
    {
        public int m_name { get; } = -1;
        List<Customer> m_waitingLine = new List<Customer>();
        static Random m_glitch = new Random();
        Boolean m_stalling = false;

        public Department(int name)
        {
            m_name = name;
        }
        override public String ToString()
        {
            String waitingLine = "";
            if (m_stalling)
            {
                waitingLine += "(*)";
            }
            for (int i=0; i< m_waitingLine.Count; i++)
            {
                
                //waitingLine += "+";
                Customer customer = m_waitingLine.ElementAt(i);
                waitingLine += customer.m_name + "-";
            }
            return waitingLine;
        }

        public int GetNumberWaiting()
        {
            return m_waitingLine.Count();
        }
        public void PrintWaitingLine()
        {
            for (int i = 0; i < m_waitingLine.Count; i++)
            {
                Customer customer = m_waitingLine.ElementAt(i);
                Console.WriteLine(customer.ToString());
            }

        }
        public Customer ProcessQueue()
        {
            Customer nextInLine = null;

            // randomize a glitch: one time out of five the delivery does not occur
            if (m_waitingLine.Count > 0)
            {
                int number = m_glitch.Next(1, 11);
                if (number <= Constants.THRESHOLD_FOR_GLITCH)
                {
                    m_stalling = true;
                }
                else
                {
                    m_stalling = false;
                }

                if (m_stalling)
                {
                    return nextInLine;
                }
            }

            // if no glitch process
            if (m_waitingLine.Count > 0)
            {
                nextInLine = m_waitingLine.First();
                m_waitingLine.Remove(nextInLine);
                nextInLine.TakeArticle(m_name);

                // send the customer away with the item he got
                return nextInLine;
            }
            else
            {
                // there are no customers in the line
                return null;
            }
        }
        public void CustomerEnters(Customer customer)
        {
            m_waitingLine.Add(customer);
            EventHubHelper.GetInstance().SendLeaveDepartment(customer, this);
        }

    }
}
