using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LottoApplication
{
    class LottoCoupon
    {
        public List<LottoRow> LottoRows { get; private set; }

        public LottoCoupon()
        {
            LottoRows = new List<LottoRow>();
        }

        public void AddNewRow(LottoRow row)
        {
            if (LottoRows.Count < LottoApplication.NumberOfRows)
            {
                LottoRows.Add(row);
            }
        }
            
        public void AddNewRow()
        {
            Console.WriteLine();
            int lottoSet = LottoApplication.LottoSet;
            List<int> lottoNumbers = GetMax();
            var row = new LottoRow();
            for (int i = 0; i < lottoSet; i++)
            {
                int input = -1;
                do
                {
                    Console.Write("Nummer {0}: ", i + 1);
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (lottoNumbers.Find(x => x.Equals(input)) == 0);
                row.AddNumber(input);
                lottoNumbers.Remove(input);
            }
            LottoRows.Add(row);    
        }

        private static List<int> GetMax()
        {
            int lottoMax = LottoApplication.LottoMax;
            var lottoNumbers = new List<int>();
            for (int i = 0; i < lottoMax; i++)
            {
                lottoNumbers.Add(i + 1);
            }
            return lottoNumbers;
        }


        public void PrintCoupon()
        {
            foreach (var item in LottoRows)
	        {
                item.PrintRow();
	        }        
        }
    }
}
