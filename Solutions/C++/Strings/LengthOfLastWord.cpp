#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    int lengthOfLastWord(string s) {
        int len = 0;
        int i = s.size() - 1;
        while(i >= 0) {
            if(s[i] == ' ')
                i--;
            else
                break;
        }

        while(i >= 0 && s[i] != ' ') {
            i--;
            len++;
        }

        return len;
    }
};