#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
using namespace std;


class Solution {
public:
    ListNode* rotateRight(ListNode* head, int k) {
        if(k == 0 || head == nullptr || head->next == nullptr)
            return head;

        auto dummyHead = new ListNode(0, head), current = dummyHead, prev = dummyHead;
        int count = k, len = 0;
        while(count > 0) {
            current = current->next;
            if(current == nullptr) {
                count = k % len;
                current = dummyHead;
            }
            else {
                len++;
                count--;
            }
        }

        if(current->next == nullptr)
            return head;

        while(current->next != nullptr) {
            current = current->next;
            prev = prev->next;
        }

        current->next = dummyHead->next;
        dummyHead->next = prev->next;
        prev->next = nullptr;

        return dummyHead->next;
    }


    vector<string> getOpenApplications(vector<string> commands) {
        for(auto& command: commands) {
            switch (command) {
                command.substr()
            }
        }
    }

};