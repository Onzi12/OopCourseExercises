#include <iostream>

using namespace std;
/*
*The class DiGraph:
*N - Number of vertices in the graph
*Infinity - The greatest distance available between two vertices
*/
class DiGraph
{
private:
	int N;
	double Infinity;
	double **graph;

public:

	DiGraph();
	DiGraph(int, double);
	DiGraph(const DiGraph &ad);
	~DiGraph();
	int getN();
	double getInfinity();
	void addArc(int, int, double);
	double getArcDistance(int, int);
	void copy(const DiGraph &ad);
	void free();
	DiGraph& DiGraph::operator =(const DiGraph &src);

};

