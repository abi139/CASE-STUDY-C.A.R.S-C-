using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class SuspectsService
    {
        SuspectRepository suspectRepository;

        public SuspectsService()
        {
            suspectRepository = new SuspectRepository();
        }

        public void AddSuspect(Suspects suspect)
        {
            try
            {
                suspectRepository.AddSuspect(suspect);
                Console.WriteLine("Suspect added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding suspect: {ex.Message}");

            }
        }

        public List<Suspects> DisplaySuspectInfo()
        {
            try
            {
                List<Suspects> suspectsList = suspectRepository.DisplaySuspectInfo();
                if (suspectsList.Count == 0)
                {
                    Console.WriteLine("No suspects found.");
                }
                else
                {
                    foreach (var suspect in suspectsList)
                    {
                        Console.WriteLine($"Suspect ID: {suspect.SuspectID}");
                        Console.WriteLine($"First Name: {suspect.FirstName}");
                        Console.WriteLine($"Last Name: {suspect.LastName}");
                        Console.WriteLine($"Date of Birth: {suspect.DateOfBirth}");
                        Console.WriteLine($"Gender: {suspect.Gender}");
                        Console.WriteLine($"Address: {suspect.Address}");
                        Console.WriteLine($"Phone Number: {suspect.Phonenumber}");
                        Console.WriteLine();
                    }
                }
                return suspectsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying suspects: {ex.Message}");
                throw;
            }
        }

        public void RemoveSuspect(int suspectID)
        {
            try
            {
                suspectRepository.RemoveSuspect(suspectID);
                Console.WriteLine($"Suspect with ID '{suspectID}' removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while removing suspect: {ex.Message}");

            }
        }

        public Suspects GetSuspectByID(int suspectID)
        {
            try
            {
                Suspects suspect = suspectRepository.getSuspectsbyID(suspectID);
                if (suspect == null)
                {
                    Console.WriteLine($"Suspect with ID '{suspectID}' not found.");
                }
                else
                {
                    Console.WriteLine($"Suspect ID: {suspect.SuspectID}");
                    Console.WriteLine($"First Name: {suspect.FirstName}");
                    Console.WriteLine($"Last Name: {suspect.LastName}");
                    Console.WriteLine($"Date of Birth: {suspect.DateOfBirth}");
                    Console.WriteLine($"Gender: {suspect.Gender}");
                    Console.WriteLine($"Address: {suspect.Address}");
                    Console.WriteLine($"Phone Number: {suspect.Phonenumber}");
                }
                return suspect;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting suspect by ID: {ex.Message}");
                throw;
            }
        }
        public void SuspectsMenu()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("1. Adding New Suspect:");
                Console.WriteLine("2. Displaying Suspect Info:");
                Console.WriteLine("3. Removing Suspect:");
                Console.WriteLine("4. Getting Suspect by ID:");
                Console.WriteLine("Exit");
                Console.WriteLine("Enter your choice");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Adding New Suspect:");
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Date of Birth (MM/DD/YYYY): ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Gender: ");
                        string gender = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();

                        Suspects newSuspect = new Suspects(0, firstName, lastName, dateOfBirth, gender, address, phoneNumber);
                        AddSuspect(newSuspect);
                        break;

                    case 2:
                        Console.WriteLine("Displaying Suspect Info:");
                        DisplaySuspectInfo();
                        break;

                    case 3:
                        Console.WriteLine("Removing Suspect:");
                        Console.Write("Enter Suspect ID to remove: ");
                        int removeSuspectID = int.Parse(Console.ReadLine());
                        RemoveSuspect(removeSuspectID);
                        break;

                    case 4:
                        Console.WriteLine("Getting Suspect by ID:");
                        Console.Write("Enter Suspect ID to get details: ");
                        int getSuspectID = int.Parse(Console.ReadLine());
                        GetSuspectByID(getSuspectID);
                        break;

                    case 5:
                        Console.WriteLine("Exiting Suspects Service.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            } while (choice != 5);

        }
    }
}
