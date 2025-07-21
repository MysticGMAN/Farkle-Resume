using Farkle.Classes;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Farkle.Models
{
    public class FarkleModel
    {
        public Player P = new Player();

        /*public static FarkleModel fm = new FarkleModel();*/

        public static readonly List<string> _dicePath = new List<string>()
        {
            "../images/one.png",
            "../images/two.png",
            "../images/three.png",
            "../images/four.png",
            "../images/five.png",
            "../images/six.png"

        };

        public const string player = "player";
        public const string daveAI = "dave";
        public static string? currentPlayer { get; set; }
        public static bool turnOver = false;
        public static bool TurnOver { get { return turnOver; } set { turnOver = value; } }



        public List<int> DiceRoll { get; set; } = new List<int>();

        public List<string> _diceImg = new List<string>(new string[6]);

        public List<string> DiceImg { get { return _diceImg; } set { _diceImg = value; } }

        public List<string> DicePath { get { return _dicePath; } }


    }
}
