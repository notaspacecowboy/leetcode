//
// Created by 14389 on 2/4/2023.
//

#ifndef C___GRAPH_H
#define C___GRAPH_H

#include <vector>

// Definition for a Node.
class Node {
public:
    int val;
    std::vector<Node*> neighbors;
    Node() {
        val = 0;
        neighbors = std::vector<Node*>();
    }
    Node(int _val) {
        val = _val;
        neighbors = std::vector<Node*>();
    }
    Node(int _val, std::vector<Node*> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
};

#endif //C___GRAPH_H
