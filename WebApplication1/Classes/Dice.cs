using Farkle;
using Farkle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Farkle
{
    public class Dice
    {
        /*public  List<int>*/



        private readonly Dictionary<int, int> _sortReset = new Dictionary<int, int>()
        {
            [1] = 0,
            [2] = 0,
            [3] = 0,
            [4] = 0,
            [5] = 0,
            [6] = 0
        };

        private int _diceLeft = 6;

        private List<int> _diceRoll = new List<int>();

        private Dictionary<int, int> sortedRoll = new Dictionary<int, int>()
        {
            [1] = 0,
            [2] = 0,
            [3] = 0,
            [4] = 0,
            [5] = 0,
            [6] = 0

        };

        public Dictionary<int, int> SortReset { get { return _sortReset; } }

        public List<int> DiceRoll
        {
            get
            {
                return _diceRoll;
            }
            set
            {
                _diceRoll = value;
            }

        }

        public int DiceLeft { get; set; }

        public int GetDiceValueAtIndex(int index)
        {
            return _diceRoll[index];
        }

        public void setDiceLeft(int num)
        {
            this._diceLeft = num;
        }

        public void addToRoll(int die)
        {
            this._diceRoll.Add(die);
        }

        public int getDiceLeft()
        {
            return this._diceLeft;
        }

        public Dice(int diceLeft)
        {
            setDiceLeft(diceLeft);
            Roll(diceLeft);
        }

        public Dice()
        {
            if (DiceLeft == 0)
            {
                DiceLeft = 6;
            }
            Roll(this._diceLeft);
        }


        public void Roll(int diceLeft)
        {
            Random rand = new Random();
            for (int i = 1; i <= diceLeft; i++)
            {
                addToRoll(rand.Next(1, diceLeft));

            }

            PlayableRoll();
        }



        private void SortRoll()
        {

            for (int i = 0; i < DiceRoll.Count - 1; i++)
            {
                for (int j = 1; j <= DiceRoll.Count; j++)
                {
                    if (DiceRoll[i] == j)
                    {
                        this.sortedRoll[j] += 1;
                    }

                }
            }

        }

        public void PlayableRoll()
        {
            sortedRoll = SortReset;
            SortRoll();
            if (Rules.FindCombos(this.sortedRoll, this.DiceLeft) > 0)
            {

            }
        }


        /*public */
        /*public String RollToString ()
        {
            
        }*/

    }
}
