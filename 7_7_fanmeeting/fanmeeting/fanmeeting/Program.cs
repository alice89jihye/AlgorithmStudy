using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fanmeeting
{
    class Program
    {
        static int gresult = 0;

        static void Main(string[] args)
        {
            string[] HyperS = {"FFFMMM","FFFFF","FFFFM","MFMFMFFFMMMFMF"};
            string[] Fan = {"MMMFFF","FFFFFFFFFF","FFFFFMMMMF","MMFFFFFMFFFMFFFFFFMFFFMFFFFMFMMFFFFFFF"};

            // 남성멤버는 여성멤버만 포옹한다.
            // 하이퍼시니어 모든 멤버가 동시에 포옹하는 일이 몇번인가?

            int result = 0;

            Console.WriteLine(HyperS.Length);

            for (int i = 0; i < HyperS.Length; i++)
            {
                Console.WriteLine(HyperS[i]);
                Console.WriteLine(Fan[i]);
                result = hugCount(HyperS[i], Fan[i]);
                Console.WriteLine(result);
                gresult = 0;
            }       
        }

        static int hugCount(string HyperS, string Fan)
        {
            //if (HyperS.Length == Fan.Length && HyperS.Contains('M') && HyperS.Equals(Fan))
            //  return 0;

            if (HyperS.Length > Fan.Length)
                return gresult;

            int mid = HyperS.Length;

            int temp = 0;
            for (int i = 0; i < mid; i++)
            {
                if (HyperS[i] == 'M' && Fan[i] == 'M')
                {
                    Fan = Fan.Remove(0, 1);
                    return hugCount(HyperS, Fan);
                }
                else
                {
                    temp++;
                }
            }

            if (temp == mid)
                gresult++;

            if (HyperS.Length == Fan.Length)
                return gresult;
            else
            {
                Fan = Fan.Remove(0, 1);
                return hugCount(HyperS, Fan);
            }
        }
    }
}
/*
abcd
0123 45
123 4 5
234 5
2345


abcdef
0123456789
012345 6789
12345 6 789
23456 7 89
*/