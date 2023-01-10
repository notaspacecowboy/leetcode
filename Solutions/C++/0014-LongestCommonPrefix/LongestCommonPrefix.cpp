#include <vector>
#include <string>

using namespace std;

class Solution {
public:
    string longestCommonPrefix(vector<string>& strs) {
        string res;
        for(int i = 0; i < strs[0].length(); i++) {
            char toCompare = strs[0][i];
            for(int j = 1; j < strs.size(); j++) {
                if(i >= strs[j].length() || strs[j][i] != toCompare )
                    return res;
            }

            res += toCompare;
        }

        return res;
    }
};