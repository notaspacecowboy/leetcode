#include <iostream>
#include <unordered_map>
using namespace std;

class LRUCache {
    struct Node {
        Node(int key, int val, Node* prev = nullptr, Node* next = nullptr)
        : key(key)
        , val(val)
        , prev(prev)
        , next(next) {}

        Node* prev;
        Node* next;
        int key;
        int val;
    };

public:
    LRUCache(int capacity)
    : mKeyIndexMapping()
    , mHead(nullptr)
    , mTail(nullptr)
    , mCapacity(capacity)
    , mCount(0) {}

    int get(int key) {
        auto found = mKeyIndexMapping.find(key);
        if(found == mKeyIndexMapping.end())
            return -1;

        auto current = found->second;
        if(current == mTail)
            return current->val;


        if(current == mHead) {
            mHead = mHead->next;
            mHead->prev = nullptr;
        }
        else {
            current->prev->next = current->next;
            current->next->prev = current->prev;
        }

        mTail->next = current;
        current->prev = mTail;
        current->next = nullptr;
        mTail = current;

        return current->val;
    }

    void put(int key, int value) {
        auto found = mKeyIndexMapping.find(key);
        if(found != mKeyIndexMapping.end()) {
            mKeyIndexMapping[key]->val = value;
            get(key);
            return;
        }

        if(mCount == mCapacity) {
            mKeyIndexMapping.erase(mHead->key);
            mHead = mHead->next;
        }
        else
            mCount++;

        if(mHead == nullptr) {
            mHead = new Node(key, value, nullptr, nullptr);
            mTail = mHead;
        }
        else {
            mTail->next = new Node(key, value, mTail, nullptr);
            mTail = mTail->next;
        }

        mKeyIndexMapping.insert(make_pair(key, mTail));
    }

private:
    unordered_map<int, Node*> mKeyIndexMapping;
    Node* mHead;
    Node* mTail;
    int mCapacity;
    int mCount;
};