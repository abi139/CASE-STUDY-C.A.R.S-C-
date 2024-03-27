using CrimeReportingSystem.Model;

namespace CrimeReportingSystem.Repositories
{
    public interface ICrimeAnalysisService
    {
        bool CreateIncident(Incidents incidents);
        bool UpdateIncidentStatus(string newStatus, int incidentID);
        List<Incidents> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        List<Incidents> SearchIncidents(object criteria);
        Reports GenerateIncidentReport(Incidents incident);
        Cases CreateCase(string caseDescription, Incidents incidents);
        Cases GetCaseDetails(int CaseId);
        bool UpdateCaseDetails(Cases updatedCase);
        List<Cases> GetAllCases();
    }
}
