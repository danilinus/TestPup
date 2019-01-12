#include <cstddef>
#include <string>
#include "stdafx.h"
#include <iostream>
#include <ctime>

extern "C"
{
	class Matrix
	{
	public:
		static const int rows = 3;
		static const int cols = 3;
		double data[rows][cols];

		Matrix(double init)
		{
			for (int i = 0; i < rows; ++i)
				for (int j = 0; j < cols; ++j)
					data[i][j] = init;
		}

		Matrix operator*(const Matrix & m) const
		{
			Matrix res(0);

			for (int i = 0; i < rows; i++)
				for (int j = 0; j < cols; j++)
					for (int k = 0; k < rows; k++)
						res.data[i][j] += data[i][k] * m.data[k][j];

			return res;
		}
	};

	__declspec(dllexport) void __stdcall math_add()
	{
		Matrix m1(4.0);
		Matrix m2(5.0);
		Matrix m3 = m1 * m2;
	}
}