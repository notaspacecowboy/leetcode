#include <iostream>
#include <unordered_map>
using namespace std;

class LRUCache {
private:
    struct Node {
        Node(int key, int val, Node* prev = nullptr, Node* next = nullptr)
        : key(key)
        , val(val)
        , prev(prev)
        , next(next) {
        }

        int key;
        int val;
        Node* prev;
        Node* next;
    };

public:
    LRUCache(int capacity)
    : mCount(0)
    , mCapacity(capacity)
    , mDummyHead(new Node(INT_MIN, INT_MIN))
    , mDummyTail(new Node(INT_MAX, INT_MAX))
    , mKeyNodeMapping() {
        mDummyHead->next = mDummyTail;
        mDummyTail->prev = mDummyHead;
    }

    int get(int key) {
        auto found = mKeyNodeMapping.find(key);
        if(found == mKeyNodeMapping.end())
            return -1;

        auto node = found->second;
        node->prev->next = node->next;
        node->next->prev = node->prev;
        node->prev = mDummyHead;
        node->next = mDummyHead->next;
        mDummyHead->next->prev = node;
        mDummyHead->next = node;

        return node->val;
    }

    void put(int key, int value) {
        auto found = mKeyNodeMapping.find(key);
        if(found != mKeyNodeMapping.end()) {
            auto node = found->second;
            node->val = value;
            get(key);
            return;
        }

        if(mCount == mCapacity) {
            int keyToRemove = mDummyTail->key;
            mDummyTail->prev = mDummyTail->prev->prev;
            mDummyTail->prev->next = mDummyTail;
            mKeyNodeMapping.erase(keyToRemove);
            mCount -= 1;
        }
        Node* node = new Node(key, value, mDummyHead, mDummyHead->next);
        node->next->prev = node;
        node->prev->next = node;
        mKeyNodeMapping.emplace(key, node);
        mCount += 1;
    }

private:
    int mCount;
    int mCapacity;
    Node* mDummyHead;
    Node* mDummyTail;
    unordered_map<int, Node*> mKeyNodeMapping;
};