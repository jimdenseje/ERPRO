using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.SalesNS;
using ERPRO.AddressNS;
using GrapeCity.Documents.Imaging;
using ERPRO.Functions.Print;

int[,] car =
{
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,3,3,3,3,0,0,0,0,0,0,0,2,0,0,0,0,0},
    {0,0,0,3,3,3,3,0,0,1,1,1,1,1,1,1,1,1,0,0},
    {0,0,0,3,3,3,0,0,0,1,1,1,1,1,1,1,1,1,0,0},
    {0,0,3,3,0,3,3,0,0,0,0,2,0,0,0,2,0,0,0,0},
};

Console.Clear();
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.WriteLine(intro);
Console.ForegroundColor = ConsoleColor.White;

//Read frames from the GIF image
GcGifReader reader = new GcGifReader("intro.gif");
var framesz = reader.Frames;

var posision = Console.GetCursorPosition();
Console.CursorVisible = false;

using (var bmp = new GcBitmap())
{
    //Loading GIF frames as individual images
    for (var loop = 0; loop < 1; loop++)
    {
        for (var i = 0; i < framesz.Count; i++)
        {
            framesz[i].ToGcBitmap(bmp, i - 1);

            Console.SetCursorPosition(posision.Left, posision.Top);
            Console.CursorVisible = false;

            System.Threading.Thread.Sleep(10);
            //Console.Clear();

            for (var x = 0; x < bmp.PixelHeight; x++)
            {
                for (var y = 0; y < bmp.PixelWidth; y++)
                {
                    ConsoleColor temp = animation.ClosestConsoleColorFromUInt(bmp[y, x]);
                    Console.ForegroundColor = temp;
                    Console.BackgroundColor = temp;
                    Console.Write("*");

                }

                Console.WriteLine();
            }

            for (var x = 0; x < 7; x++)
            {

                //own drawing
                int startpos = 0;
                int endpos = 20;
                if (i * 2 > 55)
                {
                    Console.Write("".PadLeft(i * 2 - 9));
                    endpos = endpos - (i - 25);
                    if (endpos < 0) {
                        endpos = 0;
                    }
                }
                else if (9 - (i * 2) > 0)
                {
                    startpos = 9 - (i * 2);
                }
                else
                {
                    Console.Write("".PadLeft((i * 2) -9));
                    startpos = 0;
                }

                for (var y = startpos; y < endpos; y++)
                {
                    switch (car[x, y])
                    {
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("**");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("**");
                            break;
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("**");
                            break;
                        default:
                            Console.Write("  ");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine("");
            }
            //stop own drawing

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n           -- Made by GRP4 - Jim, Marcus & Tobias");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}


Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
System.Threading.Thread.Sleep(100);
//Console.ReadKey();
Console.SetCursorPosition(0, 0);
Console.Clear();
Console.CursorVisible = false; //fix for rezising

Screen.Display(new Mainmenu());