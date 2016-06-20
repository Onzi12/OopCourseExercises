#include <iostream>
#include "DiGraph.h"
#include "ADiGraph.h"

using namespace std;

/*Empty constructor*/
ADiGraph::ADiGraph() : DiGraph() {

}

/*Constructor*/
ADiGraph::ADiGraph(int n, double infinity) : DiGraph(n, infinity) {

}


void ADiGraph::addArc(int i, int j, double w) {

	if (i > j) {	//if i is greater than j impossible add the edge...
		cout << "Impossible to add edge!" << endl;
		return;
	}

	DiGraph::addArc(i, j, w);
}


/*Bellman'matrix algorithm -
*finds the shortest path from vertex 0 to the rest of the vertices
*/
void ADiGraph::shortest_distances(double U[]) {

	double min, sum = 0;
	int j = 0;
	U[0] = 0;	//Initialize distances from src to all other vertices

	for (int i = 1; i < getN(); i++) {
		U[i] = 0;
		min = getArcDistance(j, i);	//set the minimum distance between vertices j and i

		while (j < i) {
			sum = U[j] + getArcDistance(j, i);	//set the sum with the weight(j) + distance

			if (sum < min)
				min = sum;	//set a new minimum if min is Greater than the sum

			j++;
		}
		U[i] = min;	//set minimum distance in the current index
		j = 0;
	}
}

ADiGraph::~ADiGraph() {

}
