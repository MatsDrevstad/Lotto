using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LottoApplication
{
    class LottoRow
    {
        public List<int> SelectedNumbers { get; private set; }
        private static int counter;

        public LottoRow()
        {
            SelectedNumbers = new List<int>();
            counter = ++counter;
        }

        public static int Counter
        {
            get { return counter; }
        }

        public void AddNumber(int num)
        {
            SelectedNumbers.Add(num);
        }

        public void PrintRow()
        {
            Console.WriteLine();
            SelectedNumbers.Sort();
            foreach (var item in SelectedNumbers)
            {
                Console.Write(item + " ");    
            }
        }
        
        public void RandomRow()
        {
            int lottoSet = LottoApplication.LottoSet;
            var rand = new Random();

            while (SelectedNumbers.Count < lottoSet)
            {
                var rndNumber = rand.Next(1, LottoApplication.LottoMax + 1);
                if (! SelectedNumbers.Contains(rndNumber))
                {
                    SelectedNumbers.Add(rndNumber);
                }
            }
        }
    }
}
