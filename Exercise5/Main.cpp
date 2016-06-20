#include "Matrix.h"

void main()
{
	int i, j;

	Matrix<double> M1d, M2d, M3d; //we can also declare matrices of type int,float,double etc.

	for (i = 0; i < N; i++)
		for (j = 0; j < N; j++)
		{
			M1d.s[i][j] = 1.1*i + j;
			M2d.s[i][j] = 10.1*i + 1.1*j;
		} // for

	cout << "M1d:" << endl;
	M1d.printm();
	cout << "M2d:" << endl;
	M2d.printm();
	M3d = M1d + M2d;
	cout << endl << "M1d + M2d:" << endl;
	M3d.printm();
	M3d = M1d * M2d;
	cout << endl << "M1d * M2d:" << endl;
	M3d.printm();

	Matrix<int> M1i, M2i, M3i;


	for (i = 0; i < N; i++)
		for (j = 0; j <N; j++)
		{
			M1i.s[i][j] = i + 10 * j;
			M2i.s[i][j] = 100 * i + 10 * j;
		} // for

	cout << "M1i:" << endl;
	M1i.printm();
	cout << "M2i:" << endl;
	M2i.printm();

	cout << endl << "M1i + M2i:" << endl;
	M3i = M1i + M2i;
	M3i.printm();
	M3i = M1i*M2i;
	cout << endl << "M1i * M2i:" << endl;
	M3i.printm();

	std::cin.get();
}