using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;

namespace ERPRO.SalesNS
{
    public class SalesProductQty
    {
        

        public static decimal get(string Productname, decimal instokproductqty)
        {

            Console.Clear();
            Console.WriteLine($"Your Choosen Product is: {Productname}");
            Console.Write("Choose Qty Of Products: ");

            decimal qty =0;
            bool Accepted = false;
            while (Accepted == false) { 
                try
                {
                    Console.CursorVisible = true;
                    qty = Convert.ToInt32(Console.ReadLine());
                    if (qty < 0)
                    {
                        Console.WriteLine("\nYou can´t write a number below zero");
                        Console.Write("Choose Qty Of Products: ");
                        throw new Exception();
                    }
                    else if (qty > instokproductqty)
                    {
                        Console.WriteLine("\nYou choose more then we have in stok");
                        Console.Write("Choose Qty Of Products: ");
                        throw new Exception();
                    }
                    Accepted = true;
                    Console.CursorVisible = false;
                }
                catch (Exception ex) // when () 
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        //e.GetBaseException();
                        Console.WriteLine("\nYou didn´t write a valid number");
                        Console.Write("Choose Qty Of Products: ");
                    }
                    
                }
            }
            return qty;
        }
        
    }
}
