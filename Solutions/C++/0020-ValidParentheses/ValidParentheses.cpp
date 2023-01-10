#include <vector>
#include <string>
#include <stack>
using namespace std;


class Solution {
public:
    bool isValid(string s) {
        stack<char> match;
        for(int i = 0; i < s.size(); i++) {
            if(s[i] == '(' || s[i] == '[' || s[i] == '{')
            {
                match.push(s[i]);
                continue;
            }

            if(match.empty())
                return false;

            if(s[i] == ')' && match.top() != '(')
                return false;
            if(s[i] == '}' && match.top() != '{')
                return false;
            if(s[i] == ']' && match.top() != '[')
                return false;

            match.pop();
        }

        return match.empty();
    }
};