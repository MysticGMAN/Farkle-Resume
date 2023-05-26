using Farkle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farkle
{
    public static class Rules
    {
        //static Dictionary<int, int> sortedSelection = new Dictionary<int, int>();



        static int count;

        static Dictionary<string, int> Combos = new Dictionary<string, int>()
        {
            ["singleOne"] = 1,

            ["singleFive"] = 5,

            ["pairs"] = 2,
            ["pairTwos"] = 4,
            ["pairThrees"] = 6,
            ["pairFours"] = 8,
            ["pairFives"] = 10,
            ["pairSixes"] = 12,

            ["threes"] = 3,
            ["threeTwos"] = 6,
            ["threeThrees"] = 9,
            ["threeFours"] = 12,
            ["threeFives"] = 15,
            ["threeSixes"] = 18,

            ["fours"] = 4,
            ["fourTwos"] = 8,
            ["fourThrees"] = 12,
            ["fourFours"] = 16,
            ["fourFives"] = 20,
            ["fourSixes"] = 24,

            ["fives"] = 5,
            ["fiveTwos"] = 10,
            ["fiveThrees"] = 15,
            ["fiveFours"] = 20,
            ["fiveFives"] = 25,
            ["fiveSixes"] = 30,

            ["sixes"] = 6,
            ["sixTwos"] = 222222,
            ["sixThrees"] = 333333,
            ["sixFours"] = 444444,
            ["sixFives"] = 555555,
            ["sixSixes"] = 666666,

            ["straight"] = 123456,

            ["threePairMin"] = 12,
            ["threePairMax"] = 30

        };

        static Dictionary<string, int> Points = new Dictionary<string, int>()
        {
            ["singleOne"] = 100,

            ["singleFives"] = 50,

            ["threeOnes"] = 1000,
            ["threeTwos"] = 200,
            ["threeThrees"] = 300,
            ["threeFours"] = 400,
            ["threeFives"] = 500,
            ["threeSixes"] = 600,

            ["fourOnes"] = 1200,
            ["quad"] = 1000,

            ["fiveOnes"] = 2200,
            ["quintuple"] = 2000,

            ["sixOnes"] = 3200,
            ["hexad"] = 3000,

            ["straight"] = 1500,

            ["threePair"] = 1500,

            ["FourOfAndPair"] = 1500,

            ["pairOfTrips"] = 2500

        };
        /*temp = selection[i];
                        selection[i] = selection[j];
                        selection[j] = temp;*/


        public static int FindCombos(Dictionary<int, int> sortedSelection, int count)
        {
            Rules.count = 0;
            Rules.count = count;
            /*Rules.sortedSelection.Clear();
            Rules.sortedSelection = sortedSelection;*/
            int tempPoints = 0;

            if (count == 6)
            {

                if (FindTwoTrips(sortedSelection))
                {
                    return Combos["pairOfTrips"];
                }

                if (FindFourAndPair(sortedSelection))
                {
                    return Combos["fourOfAndPair"];
                }

                if (FindThreePair(sortedSelection))
                {
                    return Combos["threePair"];
                }

                if (FindStraight(sortedSelection))
                {
                    return Combos["straight"];
                }

                if (FindHexad(sortedSelection))
                {
                    return Combos["hexad"];
                }
            }
            if (count == 5)
            {
                if (FindQuintuple(sortedSelection))
                {
                    tempPoints = Points["quintuple"];
                    count -= 5;
                }
            }
            if (count == 4)
            {
                if (FindFour(sortedSelection))
                {
                    tempPoints = Points["quintuple"];
                    count -= 4;
                }
            }
            if (count == 3)
            {
                if (FindThree(sortedSelection))
                {
                    tempPoints = FindThreeSpecific(sortedSelection);
                    count -= 3;
                }
            }
            if (count == 2)
            {
                if (FindSingleOne(sortedSelection) && FindSingleOne(sortedSelection))
                {
                    tempPoints = Points["singleOne"] * 2;
                    count -= 2;
                }
                if (FindSingleFive(sortedSelection) && FindSingleFive(sortedSelection))
                {
                    tempPoints = Points["singleFive"] * 2;
                    count -= 2;
                }
                if (FindSingleOne(sortedSelection) && FindSingleFive(sortedSelection))
                {
                    tempPoints = Points["singleOne"] + Points["singleFive"];
                    count -= 2;
                }
            }
            if (count == 1)
            {
                if (FindSingleOne(sortedSelection))
                {
                    tempPoints = Points["singleOne"];
                    count -= 1;
                }
                if (FindSingleFive(sortedSelection))
                {
                    tempPoints = Points["singleFive"];
                    count -= 1;
                }
            }
            if (count == 0)
            {
                return tempPoints;
            }
            else if (count > 0)
            {
                return 0;
            }
            //return -1 but very bad means big oopsie has happened
            return -1;
        }

        private static Boolean FindTwoTrips(Dictionary<int, int> sortedSelection)
        {
            for (int i = 1; i <= count; i++)
            {
                if (sortedSelection[i] == Combos["threes"])
                {
                    sortedSelection[i] = 0;
                    for (int j = 1; j <= count; j++)
                    {
                        if (sortedSelection[j] == Combos["threes"])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;


        }

        private static Boolean FindFourAndPair(Dictionary<int, int> sortedSelection)
        {

            if (FindFour(sortedSelection) && FindPairs(sortedSelection))
            {
                return true;
            }

            return false;

        }

        private static Boolean FindThreePair(Dictionary<int, int> sortedSelection)
        {

            for (int i = 1; i <= count; i++)
            {
                if (sortedSelection[i] == Combos["pairs"])
                {
                    sortedSelection[i] = 0;
                    for (int j = 1; j <= count; j++)
                    {
                        if (sortedSelection[j] == Combos["pairs"])
                        {
                            sortedSelection[j] = 0;
                            for (int x = 1; x <= count; x++)
                            {
                                if (sortedSelection[x] == Combos["pairs"])
                                {

                                    return true;
                                }
                            }

                        }
                    }
                }
            }

            return false;

        }

        private static Boolean FindStraight(Dictionary<int, int> sortedSelection)
        {

            if (sortedSelection[1] == Combos["singleOne"] && sortedSelection[2] == Combos["singleOne"] && sortedSelection[3] == Combos["singleOne"]
                && sortedSelection[4] == Combos["singleOne"] && sortedSelection[5] == Combos["singleOne"] && sortedSelection[6] == Combos["singleOne"])
            {
                return true;
            }

            return false;

        }

        private static Boolean FindHexad(Dictionary<int, int> sortedSelection)
        {

            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["sixes"])
                {
                    return true;
                }
            }
            return false;


        }

        private static Boolean FindQuintuple(Dictionary<int, int> sortedSelection)
        {

            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["fives"])
                {
                    return true;
                }
            }
            return false;


        }

        private static int FindThreeSpecific(Dictionary<int, int> sortedSelection)
        {
            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["threes"])
                {
                    return j * 100;
                }
            }
            return 0;
        }

        private static Boolean FindThree(Dictionary<int, int> sortedSelection)
        {

            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["threes"])
                {
                    return true;
                }
            }
            return false;
        }

        /*private static int FindFours(int selection)
        {
            if (selection == Combos["fourOnes"])
            {
                return 1;
            }
            if (selection == Combos["fourTwos"])
            {
                return 2;
            }
            if (selection == Combos["fourThrees"])
            {
                return 3;
            }
            if (selection == Combos["fourFours"])
            {
                return 4;
            }
            if (selection == Combos["fourFives"])
            {
                return 5;
            }
            if (selection == Combos["fourSixes"])
            {
                return 6;
            }
            return 0;
        }*/

        private static Boolean FindFour(Dictionary<int, int> sortedSelection)
        {

            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["fours"])
                {
                    return true;
                }
            }
            return false;

        }


        private static Boolean FindPairs(Dictionary<int, int> sortedSelection)
        {
            for (int j = 1; j <= count; j++)
            {
                if (sortedSelection[j] == Combos["pairs"])
                {
                    return true;
                }
            }
            return false;
        }

        private static Boolean FindSingleOne(Dictionary<int, int> sortedSelection)
        {

            if (sortedSelection[1] == Combos["ones"])
            {
                return true;
            }

            return false;
        }

        private static Boolean FindSingleFive(Dictionary<int, int> sortedSelection)
        {

            if (sortedSelection[1] == Combos["ones"])
            {
                return true;
            }

            return false;
        }

        /*private static Boolean TryFindPair(List<int> selection)
        {
            int temp;

            temp = Convert.ToInt32(string.Format($"{selection[4]}{selection[5]}"));

            if (temp == Combos["twoOnes"])
            {
                return true;
            }
            if (temp == Combos["twoTwos"])
            {
                return true;
            }
            if (temp == Combos["twoThrees"])
            {
                return true;
            }
            if (temp == Combos["twoFours"])
            {
                return true;
            }
            if (temp == Combos["twoFives"])
            {
                return true;
            }
            if (temp == Combos["twoSixes"])
            {
                return true;
            }
            return false;
        }*/

    }
}
