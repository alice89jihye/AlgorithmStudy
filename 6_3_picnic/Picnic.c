#include <stdio.h>

int C, c; // Num of Cases
int n, m, m_idx; // Num of students, num of pairs
int f[10][10]; // i, j�� ģ�� ���̸� f[i][j] == f[j][i] == 0
int matched[10]; // ¦�� ������ ����� 1, �����̸� 0
int way;

int func(int cnt, int total, int *way)
{
	int ret = 0, i, j;
	if (cnt == total) return 1; // All matched
	// ��Ī ��ų �༮�� ������: i
	for (i = 0; i < n; i++)
		if (matched[i] == 0)

			break;
	for (j = i + 1; j < n; j++)
	{
		if (matched[j] == 1) continue; // �̹� ¦�� �ִ� ����� ����
		if (f[i][j] == 1 && f[j][i] == 1) // i�� j�� ģ���� ���
		{
			// ��Ī �Ǿ��ٰ� ǥ���� ��, �� ���� ������ �������� ����
			// func() �Լ� ȣ���Ͽ� ¦���� �� �ִ� ����� ���� �ݿ��Ѵ�.
			matched[i] = matched[j] = 1;
			if (1 == func(cnt + 2, total, way))
				(*way)++;
			// i�� ¦�� �ٸ� ����� ��쵵 ���� �����ϹǷ�, �ٽ� ��Ī���� �ʾҴٰ� ǥ�� �� ���� ����� ���� for������ �Ѿ
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