using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _21_WCF_Assignment_1_DOTNET
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string TodayProgram(string name);

        [OperationContract]
        List<Jobs> OpeningJobs();

        [OperationContract]
        List<Jobs> OpeningJobsByRole(string role);

        [OperationContract]
        int Addition(int num, int num2);

        [OperationContract]
        int Subtraction(int num, int num2);



    } 
   
    [DataContract]
    public class Jobs
    {
        string role = "";
        string jobTitle = "Hello ";
        [DataMember]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        [DataMember]
        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public List<Jobs> GetJobByRole(string role)
        {
            List<Jobs> job = GetAllJob().Where(u => u.Role == role).ToList();
            return job;
        }
        public List<Jobs> GetAllJob()
        {
            return new List<Jobs>(){ new Jobs() {JobTitle=".Net Developer",Role="Junior Developer" },
                new Jobs() { JobTitle = ".Net Developer", Role = "Senior Developer" },
                 new Jobs() { JobTitle = ".Java Developer", Role = "Junior Developer" },
                  new Jobs() { JobTitle = "Java Developer", Role = "Senior Developer" },
                    new Jobs() { JobTitle = "Manager", Role = "Manager" },
                      new Jobs() { JobTitle = "Manager", Role = "Director" }
            };
        }
    }
}
