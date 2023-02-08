#include <unordered_map>
#include <iostream>
#include "ListNodeWithRandom.h"


using namespace std;

class Solution {
public:
    Node* copyRandomList(Node* head) {
        if(head == nullptr)
            return nullptr;

        unordered_map<Node*, Node*> nodes;
        nodes.insert(std::make_pair(head, new Node(head->val)));
        nodes.insert(std::make_pair(nullptr, nullptr));

        auto current = head;
        while(current != nullptr) {
            auto newNode = nodes[current];
            if(nodes.find(current->next) == nodes.end())
                    nodes.insert(std::make_pair(current->next, new Node(current->next->val)));
            newNode->next = nodes[current->next];

            if(nodes.find(current->random) == nodes.end())
                    nodes.insert(std::make_pair(current->random, new Node(current->random->val)));
                newNode->random = nodes[current->random];

            current = current->next;
        }

        return nodes[head];
    }
};