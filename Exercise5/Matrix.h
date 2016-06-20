#include <iostream>
#include <vector>

using namespace std;

const int N = 5;

template <class T> class Matrix {
	//declare a vector of vectors of type T


public:
	vector<vector<T> > s;
	//Initialize the size of s to ROWS by COLS
	Matrix() : s(N, vector<T>(N)) {}

	void printm();
	//declare the operators +,-,* as friends and with return type Matrix<T>
	friend Matrix<T> operator+=(const Matrix&, const Matrix&);
	friend Matrix<T> operator-=(const Matrix&, const Matrix&);
	friend Matrix<T> operator*=(const Matrix<T>&, const Matrix<T>&);
};

template <class T> void Matrix<T>::printm() {
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++)
			cout << this->s[i][j] << "\t";
		cout << endl;
	}
}

template <class T> Matrix<T> operator+(const Matrix<T>& a, const Matrix<T>& b) {
	//declare a Matrix temp of type T to store the result and return this Matrix
	Matrix<T> temp;
	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			temp.s[i][j] = a.s[i][j] + b.s[i][j];
	return temp;
}
template <class T> Matrix<T> operator-(const Matrix<T>& a, const Matrix<T>& b) {
	Matrix<T> temp;
	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			temp.s[i][j] = a.s[i][j] - b.s[i][j];
	return temp;
}

template <class T> Matrix<T> operator*(const Matrix<T>& a, const Matrix<T>& b) {
	Matrix<T> temp;
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++) {
			temp.s[i][j] = 0;
			for (int k = 0; k < N; k++)
				temp.s[i][j] += a.s[i][k] * b.s[k][j];
		}
	}
	return temp;
}
