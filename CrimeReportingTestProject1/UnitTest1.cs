using CrimeReportingSystem.Model;
using CrimeReportingSystem.Exceptions;
using CrimeReportingSystem.Repositories;
using CrimeReportingSystem.Service;

namespace CrimeReportingTestProject1
{
    public class Tests
    {
        CrimeAnalysisService crimeaAnalysisManagement;

        [SetUp]
        public void Setup()
        {
            crimeaAnalysisManagement=new CrimeAnalysisService();
        }

        [Test]

        public void createIncident()
        {
            Incidents incidents = new Incidents()
            {

                IncidentType = "Homicide",
                Description = "Murder case",
                Location = "Bihar",
                IncidentDate = DateTime.Now,
                Status = "open",
                VictimID = 3,
                SuspectID = 4
            };

            bool success = crimeaAnalysisManagement.CreateIncident(incidents);


            Assert.AreEqual(true, success);
        }
        [Test]

        
        public void UpdateStatus()
        {
            
                int incidentid = 6;
                string status = "closed";
                bool value = crimeaAnalysisManagement.UpdateIncidentStatus(status, incidentid);
                
               //assert
            Assert.AreEqual(true, value);
        }

        [Test]
        
        public void UpdateInvalidStatus()
        {
            try
            {
                int incidentid = 4;
                string status = "finished";

                //assert
                InvalidStatusUpdateException.InvalidIncidentStatus(status);
                crimeaAnalysisManagement.UpdateIncidentStatus( status,incidentid);
                Assert.Fail();
            }
            catch (Exception ex) { Assert.IsTrue(ex.Message.Contains("Invalid Status.....")); }

        }
        
    }
}