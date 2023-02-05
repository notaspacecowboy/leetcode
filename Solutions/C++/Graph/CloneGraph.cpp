#include <Graph.h>
#include <list>
#include <vector>
#include <iostream>
#include <unordered_map>
#include <unordered_set>

using namespace std;

class Solution {
public:
    void help(unordered_map<int, Node*> &nodes, unordered_set<int> &visited, Node* newNode, const Node* oldNode) {
        if(visited.find(oldNode->val) != visited.end())
            return;

        //mark node as visited
        visited.insert(oldNode->val);

        //fill neighbours
        for(auto node: oldNode->neighbors) {
            auto found = nodes.find(node->val);
            if(found == nodes.end())
                nodes.insert(std::make_pair(node->val, new Node(node->val)));

            newNode->neighbors.push_back(nodes[node->val]);
        }

        for(int i = 0; i < newNode->neighbors.size(); i++)
            help(nodes, visited, newNode->neighbors[i], oldNode->neighbors[i]);
    }

    Node* cloneGraph(Node* node) {
        if(node == nullptr)
            return nullptr;

        unordered_map<int, Node*> nodes;
        unordered_set<int> visited;

        auto res = new Node(node->val);
        nodes.insert(std::make_pair(res->val, res));
        help(nodes, visited, res, node);
        return res;
    }
};