#include <iostream>
#include "DiGraph.h"

using namespace std;

/*Empty constructor*/
DiGraph::DiGraph() {
	N = 0;
	graph = NULL;
}

/*Constructor*/
DiGraph::DiGraph(int n, double infinity) {
	N = n;
	Infinity = infinity;

	graph = new double*[N];	//Make a new Graph

	for (int i = 0; i < N; i++) graph[i] = new double[N];

	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			graph[i][j] = Infinity;	//Restart the graph
}
/*Get the N*/
int DiGraph::getN() {
	return N;
}
/*Get Infinity...*/
double DiGraph::getInfinity() {
	return Infinity;
}

/*Get Arc Distance...*/
double DiGraph::getArcDistance(int i, int j) {
	return graph[i][j];
}

void DiGraph::addArc(int i, int j, double w) {

	if (graph[i][j] != Infinity) {
		cout << "Edge exists!" << endl;
		return;
	}
	graph[i][j] = w;//Setting the distance

}

/*Copy the Graph*/
void DiGraph::copy(const DiGraph &ad) {

	N = ad.N;
	Infinity = ad.Infinity;

	graph = new double*[N];	//Make new graph

	for (int i = 0; i < N; i++)
		graph[i] = new double[N];

	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			graph[i][j] = ad.graph[i][j];//Deep replica
}

void DiGraph::free() {
	if (graph) {
		for (int i = 0; i < N; i++)
			delete[] graph[i];	//Delete

		delete[] graph;
	}
}

DiGraph::DiGraph(const DiGraph &src) {
	copy(src);
}

/*Operator*/
DiGraph& DiGraph::operator =(const DiGraph &src) {
	if (this == &src) return *this;
	free();
	copy(src);
	return *this;
}

/*Distructor*/
DiGraph::~DiGraph()
{
	free();
}
