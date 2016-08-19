using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LottoApplication
{
    class LottoApplication
    {
        private LottoCoupon lottoCoupon = new LottoCoupon();
        public const int LottoSet = 7;
        public const int LottoMax = 35;
        public const int NumberOfRows = 10;

        public LottoApplication()
        {
            bool loop = true;
            while (loop)
            {
                PrintMenuOptions();
                loop = HandleMenuOptions(loop);
            }
        }

        private bool HandleMenuOptions(bool loop)
        {
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                AddRow();
            }
            if (input.Equals("2"))
            {
                AddRandomRow();
            }
            if (input.Equals("3"))
            {
                PrintCoupon();
            }
            if (input.Equals("4"))
            {
                CorrectCoupon();
            }
            if (input.Equals("5"))
            {
                PlayAndWin();
            }
            if (input.Equals("0"))
            {
                loop = false;
            }
            return loop;
        }

        private void PlayAndWin()
        {
            bool loosing = true;
            int looseNrTimes = 0;
            while (loosing)
            {
                loosing = CorrectCoupon();
                looseNrTimes++;
            }
            Console.WriteLine("\nDu spelade: {0} kuponger/veckor", looseNrTimes);
            Console.WriteLine("Det tog: {0} år att vinna.", looseNrTimes / 52);

        }

        private void AddRow()
        {
            if (LottoRow.Counter <= NumberOfRows)
            {
                lottoCoupon.AddNewRow();
            }
        }

        private void AddRandomRow()
        {
            var lott = new LottoRow();
            lott.RandomRow();
            lottoCoupon.AddNewRow(lott);
            if (LottoRow.Counter <= NumberOfRows)
            {
                lott.PrintRow();
            }
        }

        private bool CorrectCoupon()
        {
            var correctRow = new LottoRow();
            correctRow.RandomRow();
            Console.Write("\nRätt rad: ");
            correctRow.PrintRow();
            foreach (var item in lottoCoupon.LottoRows)
            {
                int correctNumbers = 0;
                for (int i = 0; i < LottoSet; i++)
                {
                    if (correctRow.SelectedNumbers.Find(x => x.Equals(item.SelectedNumbers[i])) > 0)
                    {
                        correctNumbers++;
                    }
                }
                item.PrintRow();
                Console.Write("\t({0} rätt)",  correctNumbers);
                PrintStat(correctNumbers);
                if (correctNumbers == LottoSet)
	            {
                    Console.Write("  < Högvinst!");
                    return false;
	            }
            }
            return true;
        }

        private void PrintStat(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(" |");
            }
        }

        private void PrintCoupon()
        {
            lottoCoupon.PrintCoupon();
        }
        
        private void PrintMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Tippa en rad");
            Console.WriteLine("2. Slumpa en rad");
            Console.WriteLine("3. Skriv ut kupongen");
            Console.WriteLine("4. Rätta raderna på kupongen");
            Console.WriteLine("5. Spela tills du får alla rätt.");
            Console.WriteLine("0. Avsluta");
        }
    }
}

