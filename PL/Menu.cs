using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Menu
    {
        public static void StartMenu()
        {
            var input = string.Empty;
            var help = "Available actions: \n" +
                       "1. Add menu \n" +
                       "2. Edit menu \n" +
                       "3. Show menu \n" +
                       "4. Delete menu \n" +
                       "5. Show info about entity \n" +
                       "6. Show search options" ;

            do
            {
                Console.WriteLine(help);
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        MenuCommands.AddMenu();
                        break;
                    case "2":
                        MenuCommands.EditMenu();
                        break;
                    case "3":
                        MenuCommands.ShowMenu();
                        break;
                    case "4":
                        MenuCommands.DeleteMenu();
                        break;
                    case "5":
                        MenuCommands.ShowInfo();
                        break;
                    case "6":
                        MenuCommands.SearchMenu();
                        break;
                }
            } while (input != "9" || input != "x");
        }
    }
}
