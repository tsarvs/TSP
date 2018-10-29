using System;
using System.Linq;
namespace TSPConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TSPUserConsole console = new TSPUserConsole();
            //console.Run();

            TSPGUI form = new TSPGUI();
            form.ShowDialog();
        }
    }
}