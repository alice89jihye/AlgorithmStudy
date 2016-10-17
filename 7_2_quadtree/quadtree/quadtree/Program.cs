using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
전체 그림의 압축 결과는 
x(왼쪽 위 부분의 압축 결과)(오른쪽 위 부분의 압축 결과)(왼쪽 아래 부분의 압축 결과)(오른쪽 아래 부분의 압축 결과)
12
34
쿼드 트리로 압축된 흑백 그림이 주어졌을 때, 이 그림을 상하로 뒤집은 그림 을 쿼드 트리 압축해서 출력하는 프로그램
34
12
[입력]
4
w
xbwwb
xbwxwbbwb
xxwwwbxwxwbbbwwxxxwwbbbwwwwbb

[출력]
w
xwbbw
xxbwwbbbw
xxwbxwwxbbwwbwbxwbwwxwwwxbbwb
*/

namespace quadtree
{
    class Program
    {
        public static void Main()
        {
            string[] caseStr = 
            {
                "w",
                "xbwwb",
                "xbwxwbbwb",
                "xxwwwbxwxwbbbwwxxxwwbbbwwwwbb"
            };

            // 첫 줄에 테스트 케이스의 개수 C (C≤50)가 주어집니다. 
            // 그 후 C줄에 하나씩 쿼드 트리로 압축한 그림이 주어집니다.
            // 모든 문자열의 길이는 1,000 이하이며, 원본 그림의 크기는 220 × 220 을 넘지 않습니다.
            // 입력
            Console.WriteLine(caseStr.Length);
            for (int i = 0; i < caseStr.Length; i++ )
            {
                Console.WriteLine(caseStr[i]);
            }

            // 출력
            for (int i = 0; i < caseStr.Length; i++)
            {
                Console.WriteLine(reverse(caseStr[i]));
            }
        }

        public static string reverse(string str)
        {
            if( str.ToCharArray()[0] != 'x' )
            return str.ToCharArray()[0] + "";
         
            // reverseQuadTree
            String[] rqt = new String[1000];
         
            // 왼쪽 위 조각
            int beginIndex = 1;
            rqt[0] = reverse(str.Substring(beginIndex));
         
            // 오른쪽 위 조각
            beginIndex += rqt[0].Length;
            rqt[1] = reverse(str.Substring(beginIndex));
         
            // 왼쪽 아래 조각
            beginIndex += rqt[1].Length;
            rqt[2] = reverse(str.Substring(beginIndex));
         
            // 오른쪽 아래 조각
            beginIndex += rqt[2].Length;
            rqt[3] = reverse(str.Substring(beginIndex));
         
            return 'x' + rqt[2] + rqt[3] + rqt[0] + rqt[1];
        }
    }
}
