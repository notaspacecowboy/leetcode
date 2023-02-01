#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    bool isPalindrome(string s) {
        int left = 0, right = s.size() - 1;
        while(left < right) {
            if(!isalnum(s[left])) {
                left++;
                continue;
            }

            if(!isalnum(s[right])) {
                right--;
                continue;
            }

            if(isupper(s[left]))
                s[left] = tolower(s[left]);

            if(isupper(s[right]))
                s[right] = tolower(s[right]);

            if(s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
};