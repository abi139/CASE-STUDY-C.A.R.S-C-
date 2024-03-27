using CrimeReportingSystem.Service;

namespace CrimeReportingSystem.CrimeAnalysisandReportingApp
{
    internal class CrimeanalysisandReporting
    {
        CaseService caseService;
        CrimeaAnalysisManagementService crimereportingService;
        EvidenceService evidenceService;
        IncidentService incidentService;
        LawEnforcementAgenciesService lawEnforcementAgenciesService;
        OfficersService officersService;
        ReportsService reportsService;
        SuspectsService suspectsService;
        VictimService victimService;

        public CrimeanalysisandReporting()
        {
            caseService = new CaseService();
            crimereportingService = new CrimeaAnalysisManagementService();
            evidenceService = new EvidenceService();
            incidentService = new IncidentService();
            lawEnforcementAgenciesService = new LawEnforcementAgenciesService();
            officersService = new OfficersService();
            reportsService = new ReportsService();
            suspectsService = new SuspectsService();
            victimService = new VictimService();
        }

        public void CARSMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("WELCOME TO CRIME ANALYSIS AND REPORTING SYSTEM");
                Console.WriteLine();
                Console.WriteLine("**********************MAIN MENU***********************");
                Console.WriteLine();
                Console.WriteLine("1.Incidents\n2.Victims\n3.Suspects \n4.Officers \n5.Evidence \n6.LawEnforcementAgencies \n7.Reports \n8.Cases \n9. CrimeAnalysisService \n10.Exit");
                Console.WriteLine("Enter your choice");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("---------Incidents------------");
                        incidentService.IncidentsMenu();
                        break;

                    case 2:
                        Console.WriteLine("-------------Victims-----------");
                        victimService.VictimsMenu();
                        break;

                    case 3:
                        Console.WriteLine("--------------Suspects----------------");
                        suspectsService.SuspectsMenu();
                        break;

                    case 4:
                        Console.WriteLine("----------------Officers----------------------");
                        officersService.OfficersMenu();
                        break;

                    case 5:
                        Console.WriteLine("-----------------Evidence------------------");
                        evidenceService.EvidenceMenu();
                        break;

                    case 6:
                        Console.WriteLine("--------------------LawEnforcementAgencies------------------");
                        lawEnforcementAgenciesService.LawEnforcementAgenciesMenu();
                        break;

                    case 7:
                        Console.WriteLine("----------------------Reports------------------------");
                        reportsService.ReportsMenu();
                        break;

                    case 8:
                        Console.WriteLine("-----------------Cases------------------");
                        caseService.CaseMenu();
                        break;

                    case 9:
                        Console.WriteLine("----------------CrimeAnalysisService-------------------");
                        crimereportingService.CrimeAnalysisServiceMenu();
                        break;

                    case 10:
                        Console.WriteLine("Existing from the page.........");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            } while (choice != 10);


        }
    }
}



