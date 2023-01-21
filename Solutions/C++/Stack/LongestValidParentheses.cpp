#include <string>
#include <iostream>
#include <stack>
using namespace std;

class Solution {
public:
    int longestValidParentheses(string s) {
        stack<int> match;
        match.push(-1);

        int max_length = 0;
        for(int i = 0; i < s.length(); i++) {
            if(s[i] == '(') {
                match.push(i);
                continue;
            }

            //invalid, new valid parentheses pairs can only start from i + 1
            if(match.top() == -1 || s[match.top()] == ')') {
                match.push(i);
                continue;
            }

            match.pop();
            //we've found a valid parentheses pair from index match.top() + 1 to i, update max length
            int currentLength = i - match.top();
            max_length = (max_length > currentLength? max_length : currentLength);
        }

        return max_length;
    }
};