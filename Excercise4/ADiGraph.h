#include <iostream>

using namespace std;

/*Inheritance of DiGraph*/
class ADiGraph :public DiGraph
{


public:
	ADiGraph();
	ADiGraph(int n, double real);
	void addArc(int i, int j, double w);
	void shortest_distances(double U[]);
	~ADiGraph();
};
