#ifndef C___LISTNODEWITHRANDOM_H
#define C___LISTNODEWITHRANDOM_H

class Node {
public:
    int val;
    Node* next;
    Node* random;

    Node(int _val) {
        val = _val;
        next = nullptr;
        random = nullptr;
    }
};

#endif //C___LISTNODEWITHRANDOM_H
