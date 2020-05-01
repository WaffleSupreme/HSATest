using System;
using System.IO;
using System.Collections.Generic;

namespace HSATest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BusinessEnrollment> enrollmentList = new List<BusinessEnrollment>(); 
            StreamReader reader = new StreamReader(@"C:\test\enrollment.csv");

            string file = reader.ReadLine();
            string[] values = file.Split(',');
            BusinessEnrollment data;
            for (int i = 0; i < values.Length; i = i + 5)
            {
                data = new BusinessEnrollment(values[i], values[i+1], values[i+2], values[i+3], values[i+4]);
                if (data.validEntry())
                {
                    data.determineStatus();
                    if (data.getStatus().Equals("Accepted"))
                    {
                        enrollmentList.Add(data);
                    }
                }
            }
            Console.Write("The following are valid entries for enrollment:\n\n");
            
            for(int i = 0; i < enrollmentList.Count; i++)
            {
                Console.WriteLine(enrollmentList[i].getFirstName() + "\t" + enrollmentList[i].getLastName() + "\t" + enrollmentList[i].getBirthDate() + "\t" + enrollmentList[i].getPlanType() + "\t" + enrollmentList[i].getEffectiveDate());
            }
        }
    }
}
