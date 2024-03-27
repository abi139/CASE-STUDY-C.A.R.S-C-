using CrimeReportingSystem.Model;
using CrimeReportingSystem.Repositories;

namespace CrimeReportingSystem.Service
{
    internal class OfficersService
    {
        OfficersRepository officersRepository;

        public OfficersService()
        {
            officersRepository = new OfficersRepository();
        }

        public void AddOfficers(Officers officers)
        {
            try
            {
                officersRepository.AddOfficers(officers);
                Console.WriteLine("Officer added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding officer: {ex.Message}");

            }
        }

        public void UpdateOfficers(Officers officers)
        {
            try
            {
                officersRepository.UpdateOfficers(officers);
                Console.WriteLine("Officer updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating officer: {ex.Message}");

            }
        }

        public void DeleteOfficers(int officerID)
        {
            try
            {
                officersRepository.DeleteOfficers(officerID);
                Console.WriteLine("Officer deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting officer: {ex.Message}");

            }
        }

        public List<Officers> DisplayOfficersInfo()
        {
            try
            {
                List<Officers> officersList = officersRepository.DisplayOfficersInfo();
                if (officersList.Count == 0)
                {
                    Console.WriteLine("No officers found.");
                }
                else
                {
                    foreach (var officer in officersList)
                    {
                        Console.WriteLine($"Officer ID: {officer.OfficerID}");
                        Console.WriteLine($"First Name: {officer.FirstName}");
                        Console.WriteLine($"Last Name: {officer.LastName}");
                        Console.WriteLine($"Badge Number: {officer.BadgeNumber}");
                        Console.WriteLine($"Rank: {officer.Rank}");
                        Console.WriteLine($"Phone: {officer.Phone}");
                        Console.WriteLine($"Agency ID: {officer.AgencyID}");
                        Console.WriteLine();
                    }
                }
                return officersList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying officers: {ex.Message}");
                throw;
            }
        }
        public void OfficersMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Officers Service Menu:");
                Console.WriteLine("1. Add Officer");
                Console.WriteLine("2. Update Officer");
                Console.WriteLine("3. Delete Officer");
                Console.WriteLine("4. Display Officers");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding New Officer:");


                        Console.Write("Enter First Name: ");
                        string addFirstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string addLastName = Console.ReadLine();
                        Console.Write("Enter Badge Number: ");
                        string addBadgeNumber = Console.ReadLine();
                        Console.Write("Enter Rank: ");
                        string addRank = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string addPhone = Console.ReadLine();
                        Console.Write("Enter Agency ID: ");
                        int addAgencyID = int.Parse(Console.ReadLine());

                        Officers newOfficer = new Officers(0, addFirstName, addLastName, addBadgeNumber, addRank, addPhone, addAgencyID);
                        AddOfficers(newOfficer);
                        break;

                    case 2:
                        Console.WriteLine("Updating Officer:");

                        Console.Write("Enter Officer ID to update: ");
                        int updateOfficerID = int.Parse(Console.ReadLine());
                        Console.Write("Enter First Name: ");
                        string updateFirstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string updateLastName = Console.ReadLine();
                        Console.Write("Enter Badge Number: ");
                        string updateBadgeNumber = Console.ReadLine();
                        Console.Write("Enter Rank: ");
                        string updateRank = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string updatePhone = Console.ReadLine();
                        Console.Write("Enter Agency ID: ");
                        int updateAgencyID = int.Parse(Console.ReadLine());

                        Officers updatedOfficer = new Officers(updateOfficerID, updateFirstName, updateLastName, updateBadgeNumber, updateRank, updatePhone, updateAgencyID);
                        UpdateOfficers(updatedOfficer);
                        break;

                    case 3:
                        Console.WriteLine("Deleting Officer:");
                        Console.Write("Enter Officer ID to delete: ");
                        int deleteOfficerID = int.Parse(Console.ReadLine());
                        DeleteOfficers(deleteOfficerID);
                        break;

                    case 4:
                        Console.WriteLine("Displaying Officers:");
                        DisplayOfficersInfo();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Officers Service.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            } while (choice != 5);
        }
    }
}

