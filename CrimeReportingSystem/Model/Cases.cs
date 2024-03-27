namespace CrimeReportingSystem.Model
{
    public class Cases
    {
        public int CaseId { get; set; }
        public string CaseDescription { get; set; }
        public Incidents Incident { get; set; }
        public Cases()
        {
        }

        public Cases(int CaseId, string CaseDescription, Incidents Incident)
        {
            this.CaseId = CaseId;
            this.CaseDescription = CaseDescription;
            this.Incident = Incident;
        }
        public override string ToString()
        {
            return $"{CaseId}\t{CaseDescription}\t{Incident}\t";
        }
    }
}

