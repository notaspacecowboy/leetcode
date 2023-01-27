#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    //s[i][j] indicates if the first i chars in s1 and first j chars in s2 can interleaving the first i + j chars in s3
    bool isInterleave(string s1, string s2, string s3) {
        int m = s1.length(), n = s2.length(), k = s3.length();
        if(m + n != k)
            return false;

        vector<vector<bool>> dp(m + 1, vector<bool>(n + 1, false));
        for(int i = 0; i <= m; i++) {
            for(int j = 0; j <= n; j++) {
                if(i == 0 && j == 0)
                    dp[i][j] = true;
                else if(i == 0)
                    dp[i][j] = (dp[i][j - 1] && s3[i + j - 1] == s2[j - 1]);
                else if(j == 0)
                    dp[i][j] = (dp[i - 1][j] && s3[i + j - 1] == s1[i - 1]);
                else
                    dp[i][j] = (dp[i - 1][j] && s3[i + j - 1] == s1[i - 1]) || (dp[i][j - 1] && s3[i + j - 1] == s2[j - 1]);
            }
        }

        return dp[m][n];
    }
};