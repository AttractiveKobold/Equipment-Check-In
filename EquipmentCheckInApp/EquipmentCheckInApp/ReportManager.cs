using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EquipmentCheckInApp
{
    class ReportManager
    {

        public ReportManager() { }
        
        public Dictionary<string, string> getReports()
        {
            Dictionary<string, string> reports = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader("Reports.txt"))
            {
                if (sr.Peek() != -1)
                { 
                    string text = sr.ReadLine();

                    string[] reportArray = text.Split('$');

                    for (int i = 1; i < reportArray.Length; i += 2)
                    {
                        reports.Add(reportArray[i], reportArray[i + 1]);
                    }
                }
            }

            return reports;
        }

        public void removeReport(Dictionary<string, string> reports)
        {
            using (StreamWriter sw = new StreamWriter("Reports.txt", false))
            {
                foreach (var r in reports)
                {
                    sw.Write("$" + r.Key + "$" + r.Value);
                }
            }
        }

    }
}
