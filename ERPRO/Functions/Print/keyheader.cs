using System.Text.RegularExpressions;

namespace ERPRO.Functions.Print
{
    internal partial class keyheader //allowed to extent because partial is stated
    {
        public static void KeyHeader(string name) {
            Regex rx = new Regex(@"(?i)^[aeiou]");

            if (rx.IsMatch(name)){
                Console.WriteLine();
                Console.WriteLine($"Press F1 to add an {name}");
                Console.WriteLine($"Press F2 to edit an {name}");
                Console.WriteLine($"Press F5 to delete an {name}");
                Console.WriteLine();
            } else {
                Console.WriteLine();
                Console.WriteLine($"Press F1 to add a {name}");
                Console.WriteLine($"Press F2 to edit a {name}");
                Console.WriteLine($"Press F5 to delete a {name}");
                Console.WriteLine();
            }
        }
    }
}
