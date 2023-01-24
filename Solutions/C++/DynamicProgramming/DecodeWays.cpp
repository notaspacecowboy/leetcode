#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int numDecodings(string s) {
        int len = s.length();
        vector<int> dp (len + 1, 0);
        dp[len] = 1;
        dp[len - 1] = s[len - 1] == '0' ? 0 : 1;

        string tmp = "00";
        for(int i = len - 2; i >= 0; i--) {
            if(i == 0) {
                dp[i] = 0;
                continue;
            }

            tmp[0] = s[i];
            tmp[1] = s[i + 1];
            if(tmp > "26")  //member-wise compare
                dp[i] = dp[i + 1];
            else
                dp[i] = dp[i + 1] + dp[i + 2];
        }

        return dp[0];
    }
};