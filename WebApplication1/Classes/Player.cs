using Farkle;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Farkle
{
    public class Player : Dice
    {
        private int count = 0;

        private Dictionary<int, int> sortedSelection = new Dictionary<int, int>()
        {
            [1] = 0,
            [2] = 0,
            [3] = 0,
            [4] = 0,
            [5] = 0,
            [6] = 0

        };

        private List<int> selection = new List<int>();

        private int bankPoints;

        private int points;

        public int Points { get { return this.points; } set { this.points = value; } }

        public int BankPoints { get { return this.bankPoints; } set { this.bankPoints = value; } }

        public Dictionary<int, int> GetSortedSelection { get { return this.sortedSelection; } }

        public void AddSelection(int die)
        {
            selection.Add(die);
        }

        public List<int> GetSelection()
        {
            return Sort(this.selection);
        }

        public void SetSelection(List<int> selection)
        {
            this.selection = selection;
        }

        public Player(List<int> selection) : base()
        {

            SetSelection(selection);
        }

        public Player() : base()
        {

        }

        private List<int> Sort(List<int> selection)
        {
            int temp;

            for (int i = 0; i < selection.Count - 1; i++)
            {
                for (int j = 0; j < selection.Count - 1; j++)
                {
                    if (selection[j] >= selection[j + 1])
                    {
                        temp = selection[j];
                        selection[j] = selection[j + 1];
                        selection[j + 1] = temp;
                    }
                }
            }
            return selection;
        }

        private void SortSelection()
        {
            sortedSelection = SortReset;
            for (int i = 0; i < selection.Count - 1; i++)
            {
                for (int j = 1; j <= selection.Count; j++)
                {
                    if (selection[i] == j)
                    {
                        this.sortedSelection[j] += 1;
                    }

                }
            }

        }


        public int PickDice(string input)
        {
            int tempPoints = 0;
            this.count = 0;
            foreach (char c in input)
            {
                this.count++;
                int x = c - '0';
                x = x - 1;
                //selection[count] = DiceRoll[count];
                this.selection.Add(GetDiceValueAtIndex(x));

            }
            this.SortSelection();
            tempPoints = Rules.FindCombos(this.sortedSelection, this.count);
            if (tempPoints == 0)
            {
                //invalid selection
                return 0;
            }
            if (tempPoints > 0)
            {
                Points = tempPoints;
            }
            return 1;
        }

        public void Selection(List<int> selection)
        {

        }

    }
}
