#include <stdio.h>

int C, c; // Num of Cases
int n, m, m_idx; // Num of students, num of pairs
int f[10][10]; // i, j가 친구 사이면 f[i][j] == f[j][i] == 0
int matched[10]; // 짝이 지어진 사람은 1, 아직이면 0
int way;

int func(int cnt, int total, int *way)
{
	int ret = 0, i, j;
	if (cnt == total) return 1; // All matched
	// 매칭 시킬 녀석을 선택함: i
	for (i = 0; i < n; i++)
		if (matched[i] == 0)

			break;
	for (j = i + 1; j < n; j++)
	{
		if (matched[j] == 1) continue; // 이미 짝이 있는 사람은 무시
		if (f[i][j] == 1 && f[j][i] == 1) // i와 j가 친구인 경우
		{
			// 매칭 되었다고 표시한 뒤, 이 둘을 제외한 나머지에 대해
			// func() 함수 호출하여 짝지을 수 있는 경우의 수를 반영한다.
			matched[i] = matched[j] = 1;
			if (1 == func(cnt + 2, total, way))
				(*way)++;
			// i의 짝이 다른 사람인 경우도 세어 봐야하므로, 다시 매칭되지 않았다고 표시 후 다음 사람에 대한 for문으로 넘어감
			matched[i] = matched[j] = 0;
		}
	}
	return 0;
}

int main(void)
{
	int i, j;
	scanf_s("%d", &C);
	
	for (c = 0; c < C; c++)
	{
		scanf_s("%d %d", &n, &m);
		// Reset Friend Info
		for (i = 0; i < n; i++)
			for (j = i + 1; j < n; j++)
				f[i][j] = f[j][i] = 0;

		for (m_idx = 0; m_idx < m; m_idx++)
		{
			int i, j;
			scanf_s("%d %d", &i, &j);
			f[i][j] = f[j][i] = 1;
		}
		// Reset Matching Info
		for (i = 0; i < 10; i++)
			matched[i] = 0;

		way = 0;
		func(0, n, &way);
		printf("%d\n", way);
	}

	return 0;
}