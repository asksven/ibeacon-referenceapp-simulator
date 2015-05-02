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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using IBeaconRef.Data;
using IBeaconRef.EventHub;
using Microsoft.ServiceBus.Messaging;

namespace IBeaconRef.EventHub
{
    ///<summary>
    ///This is a /singleton) helper for sending messages to an Azure Event Hub
    ///</summary>
    class EventHubHelper
    {
        static EventHubClient m_client = null;
        static EventHubHelper m_singleton = null;

        private EventHubHelper()
        { }

        public static EventHubHelper GetInstance()
        {
            if (m_singleton == null)
            {
                m_singleton = new EventHubHelper();
                m_client = EventHubClient.CreateFromConnectionString(AzureConstants.EVENT_HUB_CS, AzureConstants.EVENTHUB_NAME);
            }

            return m_singleton;
        }

        public void SendEnterDepartment(Customer customer, Department department)
        {
            BeaconData payload = new BeaconData();
            payload.DeviceId = "Device-" + customer.m_name;
            payload.Action = "enter-beacon-proximity";
            payload.Region = "Department-" + department.m_name;

            DateTime saveUtcNow = DateTime.UtcNow;
            string datePatt = @"yyyy-MM-dd HH:mm:ss";
            payload.TimeUTC = saveUtcNow.ToString(datePatt);

            Send(payload);
        }

        public void SendLeaveDepartment(Customer customer, Department department)
        {
            BeaconData payload = new BeaconData();
            payload.DeviceId = "Device-" + customer.m_name;
            payload.Action = "leave-beacon-proximity";
            payload.Region = "Department-" + department.m_name;

            DateTime saveUtcNow = DateTime.UtcNow;
            string datePatt = @"yyyy-MM-dd HH:mm:ss";
            payload.TimeUTC = saveUtcNow.ToString(datePatt); ;

            Send(payload);
        }

        private void Send(BeaconData payload)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BeaconData));
            EventData data = new EventData(payload, serializer);

            m_client.Send(data);
        }
    }

    [DataContract]
    public class BeaconData
    {
        [DataMember(Name="DeviceId")]
        public string DeviceId { get; set; }

        [DataMember(Name="TimeUTC")]
        public string TimeUTC { get; set; }

        [DataMember(Name="Region")]
        public string Region { get; set; }

        [DataMember(Name = "Action")]
        public string Action { get; set; }
    }
}
