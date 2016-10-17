#include <iostream>

using namespace std;

class Picnic{
	int count;
	int friendNum, pairNum;
	bool areFriends[10][10];
	bool taken[10];
	int result;

public:
	void inputCount(){
		cin >> count;
		result = 0;
	}
	void inputNum(){
		cin >> friendNum >> pairNum;

		for(int i=0;i<friendNum;i++){
			for(int j=0;j<friendNum;j++){
				areFriends[i][j] = false;
			}

			taken[i] = false;
		}
	}
	void inputPairing(){
		int friend1, friend2;
		for(int i=0;i<pairNum;i++){
			cin >> friend1 >> friend2;
			areFriends[friend1][friend2] = true;
			areFriends[friend2][friend1] = true;
		}
	}
	void countPairings(int pos){
		bool finished = true;
		for(int i=0;i<friendNum;i++) if(!taken[i]) finished = false;
		if(finished) {
			result++;
			return;
		}

		int count = 0;
		for(int i=pos;i<friendNum;i++){
			for(int j=i+1;j<friendNum;j++){
				if(!taken[i] & !taken[j] & areFriends[i][j]){
					taken[i] = taken[j] = true;
					countPairings(i);
					taken[i] = taken[j] = false;
				}
			}
		}
	}
	void print(){
		cout << result << endl;
		result = 0;
	}

	void Run(){
		inputCount();
		for(int i=0;i<count;i++){
			inputNum();
			inputPairing();
			countPairings(0);
			print();

		}
	}
	
};

int main(){
	Picnic test;
	test.Run();

	return 0;
}