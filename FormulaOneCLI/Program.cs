using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using FormulaOneDll;

namespace FormulaOneCLI
{
    class Program
    {
        private static FormulaOneDll.Database.Tools DB = new FormulaOneDll.Database.Tools();



        static void Main(string[] args)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var productVersion = versionInfo.ProductVersion;
            var companyName = versionInfo.CompanyName;

            Console.WriteLine(@"  _____        ___    _   _   _____      ____   _       ___  ");
            Console.WriteLine(@" |  ___|      / _ \  | \ | | | ____|    / ___| | |     |_ _| ");
            Console.WriteLine(@" | |_        | | | | |  \| | |  _|     | |     | |      | |  ");
            Console.WriteLine(@" |  _|    _  | |_| | | |\  | | |___    | |___  | |___   | |  ");
            Console.WriteLine(@" |_|     (_)  \___/  |_| \_| |_____|    \____| |_____| |___| ");

            Console.WriteLine($"\nVERSION: {productVersion}");
            Console.WriteLine($"AUTHOR: {companyName}");


            Menu__Main();

            Console.WriteLine("Bye (press any key to close)");
            Console.ReadKey();
        }


        static void Menu__Main()
        {
            char selection;
            do
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine("*** MAIN MENU ***");
                Console.WriteLine("1 - CREATE SOME TABLES");
                Console.WriteLine("2 - DROP SOME TABLES");
                Console.WriteLine("3 - RESET DB");
                Console.WriteLine("X - EXIT CLI\n");
                selection = Console.ReadKey(true).KeyChar;

                switch (selection)
                {
                    case '1':
                        Menu__Create();
                        break;

                    case '2':
                        Menu__Drop();
                        break;

                    case '3':
                        Call__ResetDb();
                        break;

                    case 'x':
                    case 'X':
                        break;

                    default:
                            Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (selection != 'X' && selection != 'x');
        }

        static void Menu__Create()
        {
            char selection;
            do
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine("*** CREATION MENU ***");
                Console.WriteLine("1 - CREATE Countries");
                Console.WriteLine("2 - CREATE Drivers");
                Console.WriteLine("3 - CREATE Teams");
                Console.WriteLine("X - BACK\n");
                selection = Console.ReadKey(true).KeyChar;

                switch (selection)
                {
                    case '1':
                        Call__ExecuteSqlScript("Countries");
                        break;

                    case '2':
                        Call__ExecuteSqlScript("Drivers");
                        break;

                    case '3':
                        Call__ExecuteSqlScript("Teams");
                        break;

                    case 'x':
                    case 'X':
                        break;

                    default:
                        Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (selection != 'X' && selection != 'x');
        }

        static void Menu__Drop()
        {
            char selection;
            do
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine("*** DROP MENU ***");
                Console.WriteLine("1 - DROP Countries");
                Console.WriteLine("2 - DROP Drivers");
                Console.WriteLine("3 - DROP Teams");
                Console.WriteLine("X - BACK\n");
                selection = Console.ReadKey(true).KeyChar;

                switch (selection)
                {
                    case '1':
                        Call__DropTable("Countries");
                        break;

                    case '2':
                        Call__DropTable("Drivers");
                        break;

                    case '3':
                        Call__DropTable("Teams");
                        break;

                    case 'x':
                    case 'X':
                        break;

                    default:
                        Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (selection != 'X' && selection != 'x');
        }



        static bool Call__ExecuteSqlScript(string scriptName)
        {
            try
            {
                DB.ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine("\n" + scriptName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + scriptName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        static bool Call__DropTable(string tableName)
        {
            try
            {
                DB.DropTable(tableName);
                Console.WriteLine("\nDROP " + tableName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDROP " + tableName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        static void Call__ResetDb()
        {
            Console.Write("WARNING!!! This script will completely destroy and recreate the DB! Are you sure (s/n)? ");
            char selection = Console.ReadKey().KeyChar;
            if (selection != 's' && selection != 'S')
            {
                return;
            }

            try
            {
                bool isOk;
                isOk = Call__DropTable("Teams");
                if (isOk) isOk = Call__DropTable("Drivers");
                if (isOk) isOk = Call__DropTable("Countries");
                if (isOk) isOk = Call__ExecuteSqlScript("Countries");
                if (isOk) isOk = Call__ExecuteSqlScript("Drivers");
                if (isOk) isOk = Call__ExecuteSqlScript("Teams");
                if (isOk) isOk = Call__ExecuteSqlScript("SetConstraints");
                if (isOk) Console.WriteLine("DB correctly resetted!");
                else throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SORRY: something went wrong!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
