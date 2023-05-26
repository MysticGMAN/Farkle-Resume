/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Player p1 = new Player();
            //p1.getRoll().ForEach(Console.WriteLine);
            List<int> p1Dice = p1.DiceRoll;
            foreach (int d in p1Dice)
            {
                i++;
                Console.WriteLine("Die " + i + ": " + d.ToString());
            }
            Console.WriteLine("Please enter the dice you want: ");
            string str = Console.ReadLine();
            Console.WriteLine(p1.PickDice(str).ToString());
            //Dice d1 = new Dice();
            //d1.getRoll().ForEach(Console.WriteLine);


        }
    }
}*/
