using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clocksync_6_8
{
    class Program
    {

        // 스위치 번호와 연결된 시계들
        public static List<List<int>> switchLinkClocks = new List<List<int>>
        {   new List<int>(){0, 1, 2},
            new List<int>(){3, 7, 9, 11},
            new List<int>(){4, 10, 14, 15},
            new List<int>(){0, 4, 5, 6, 7},
            new List<int>(){6, 7, 8, 10, 12},
            new List<int>(){0, 2, 14, 15},
            new List<int>(){3, 14, 15},
            new List<int>(){4, 5, 7, 14, 15},
            new List<int>(){1, 2, 3, 4, 5},
            new List<int>(){3, 4, 5, 9, 13},
        };

        // 한 스위치를 누를때마다, 해당 스위치와 연결된 시계들은 3시간씩 앞으로 이동.(12->3,3->6...)
        const int findMaxCount = 9999;
        public static void Main(string[] args)
        {
            // 주어진 시계 예제
            int[] case1_clocks = {12, 6, 6, 6,
                                6, 6, 12, 12,
                                12, 12, 12, 12,
                                12, 12, 12, 12};

            int[] case2_clocks = {12, 9, 3, 12,
                                 6, 6, 9, 3,
                                 12, 9, 12, 9,
                                 12, 12, 6, 6};

            int[][] caseNum = { case1_clocks, case2_clocks };

            // 예제 입력
            Console.WriteLine(caseNum.Length);
            for (int i = 0; i < caseNum.Length; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(caseNum[i][j] + " ");
                }
                Console.WriteLine();
            }

            // 예제 출력
            for (int i = 0; i < caseNum.Length; i++)
            {
                Console.WriteLine(GetMinCount(ref caseNum[i]));
            }
        }



        public static Dictionary<int, List<int>> notTwelve = new Dictionary<int, List<int>>();
        public static List<int> switchProcedure = new List<int>();
        public static void ClockSync(ref int[] _caseNumClocks, ref int resultCount)
        {
            resultCount += 1;

            if (resultCount == -1 || resultCount == findMaxCount)
            {
                resultCount = -1;
                return;
            }

            // 1. 12시가 아닌 시계가 연결된 스위치를 찾는다.
            // 2. 연결된 스위치 수가 가장 작은 스위치 부터 누른 후 없애기.
            notTwelve.Clear();
            for (int clockNum = 0; clockNum < _caseNumClocks.Length; clockNum++)
            {
                // 1-1. 시계의 숫자가 12시가 아닌것을 찾는다.
                if (_caseNumClocks[clockNum] == 12)
                    continue;

                // 1-2. 연결된 스위치 수를 저장
                for (int switchNum = 0; switchNum < switchLinkClocks.Count; switchNum++)
                {
                    if (switchLinkClocks[switchNum].Contains(clockNum))
                    {
                        List<int> infoList = new List<int>();
                        infoList.Add(switchNum);
                        if (notTwelve.ContainsKey(clockNum))
                        {
                            notTwelve[clockNum] = infoList;
                        }
                        else
                        {
                            notTwelve.Add(clockNum, infoList);
                        }
                    }
                }
            }

            // 2-1. 연결된 스위치가 가장 작은 스위치 찾기
             List<int> turnSwitch = new List<int>();
             int maxSwithNum = 16;
            foreach (KeyValuePair<int, List<int>> info in notTwelve)
            {
                if (switchProcedure.Contains() == false && info.Value.Count < maxSwithNum)
                {
                    turnSwitch = info.Value;
                    maxSwithNum = info.Value.Count;
                }
            }

            // 2-2. 스위치 하기
            foreach (int num in turnSwitch)
            {
                switchProcedure.Add(num);
                foreach (int clockInfo in switchLinkClocks[num])
                {
                    _caseNumClocks[clockInfo] += 3;
                }
            }        

            // 3. 모든 시계가 12시 인가?
            bool isAllTwelve = true;
            for (int i = 0; i < _caseNumClocks.Length; i++)
            {
                if (_caseNumClocks[i] % 12 != 0)
                {
                    isAllTwelve = false;
                    break;
                }
            }

            if (isAllTwelve == false && resultCount < findMaxCount)
            {
                ClockSync(ref _caseNumClocks, ref resultCount);
            }
            else if (isAllTwelve == true)
            {
                return;
            }
            else
            {
                resultCount = -1;
                return;
            }
        }

        public static int GetMinCount(ref int[] _caseNumClocks)
        {
            int resultCount = 0; // 불가능할 경우 -1

            // 최소 횟수
            ClockSync(ref _caseNumClocks, ref resultCount);

            return resultCount;
        }
    }
}
