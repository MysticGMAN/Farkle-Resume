namespace Farkle.Classes
{
    public class AI
    {
        public List<int> rolled = new List<int>();
        public List<int> rolledtemp = new List<int>();
        public List<int> held = new List<int>();
        public List<int> dupes2 = new List<int>();
        public List<int> dupes3 = new List<int>();
        public List<int> dupes4 = new List<int>();
        public List<int> dupes6 = new List<int>();
        public int amountLeft = 6;
        public int sameValue = 0;
        public int currentI = 0;

        Random rand = new Random();
        public AI() { }
        public AI(int id) { }

        public int random()
        {
            return rand.Next(6) + 1;
        }

        public void rollset()
        {
            for (int i = 0; i < amountLeft; i++)
            {
                rolled.Add(random());
            }
        }

        public void addToDupes(int index)
        {
            if (index == 2) { dupes2.Add(2); }
            else if (index == 3) { dupes3.Add(3); }
            else if (index == 4) { dupes4.Add(4); }
            else if (index == 6) { dupes6.Add(6); }
        }

        public int samenumbers()
        {
            for (int i = 0; i < amountLeft; i++)
            {
                for (int b = i; b < amountLeft; b++)
                {
                    if (rolled[i] == rolled[b])
                    {
                        if (b != i)
                        {
                            addToDupes(rolled[b]);
                            sameValue++;
                        }
                    }
                }
                rolled[i] = 0;
            }
            rolled = rolledtemp;
            return sameValue;

        }

        public void processRolls()
        {
            for (int i = 0; i < amountLeft; i++)
            {
                currentI = rolled[i];
                if (currentI == 1)
                {
                    held.Add(currentI);
                }
                else if (currentI == 5)
                {
                    held.Add(currentI);
                }
                else
                {
                    rolledtemp.Add(currentI);
                }
            }

            rolled = rolledtemp;

            amountLeft = rolled.Count;


            samenumbers();

            if (dupes2.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    held.Add(2);

                }
                amountLeft = -3;
            }
            if (dupes3.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    held.Add(3);

                }
                amountLeft = -3;
            }
            if (dupes4.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    held.Add(4);

                }
                amountLeft = -3;
            }
            if (dupes6.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    held.Add(6);

                }
                amountLeft = -3;
            }

        }
    }
}
