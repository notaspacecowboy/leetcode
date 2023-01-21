#include <vector>
#include <string>
#include <iostream>
using namespace std;

class Solution {
public:
    int strStr(string haystack, string needle) {
        vector<int> next(needle.size(), 0);
        next[0] = -1;
        int x = -1, i = 0;
        while(i < needle.size()) {
            if(x == -1 || needle[x] == needle[i]) {
                x++;
                i++;
                next[i] = x;
            }
            else {
                x = next[x];
            }
        }


        x = 0;
        i = 0;
        while(i < haystack.size() && x < static_cast<int>(needle.size())) {  //prevent comparison between signed and unsigned
            if(x == -1 || needle[x] == haystack[i]) {
                x++;
                i++;
            }
            else {
                x = next[x];
            }
        }

        if(x == needle.size())
            return i - x;

        return -1;
    }
};