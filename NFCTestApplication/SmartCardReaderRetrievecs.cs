using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NFCTestApplication
{
    class SmartCardReaderRetrievecs
    {
        public static List<string> RetrieveSmartReader() {
            List<string> smartReaderName = new List<string>();

            //setting up the   ManagementObjectCollection 
            ManagementObjectCollection collection;

            //query in the Management ObjectSearcher
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_PNPEntity where Description Like ""%Smart Card Reader%"""))
                collection = searcher.Get();

            foreach (ManagementObject smartReader in collection) {
                smartReaderName.Add((string)smartReader["Description"]);
            }
            collection.Dispose();

            return smartReaderName;

        }

    }
}
