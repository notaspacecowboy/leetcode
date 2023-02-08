#include <string>
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:

    //a more intuitive, 2-dimensional dp solution
//    bool wordBreak(string s, vector<string>& wordDict) {
//        int n = s.length();
//        vector<vector<bool>> dp(n, vector<bool>(n, false));
//
//        for(int j = 0; j < n; j++) {
//            for(int i = j; i >= 0; i--) {
//                string current = s.substr(i, j - i + 1);
//                if(std::count(wordDict.begin(), wordDict.end(), current)) {
//                    dp[i][j] = true;
//                    continue;
//                }
//
//                for(int w = i; w < j; w++) {
//                    if (dp[i][w] && dp[w + 1][j]) {
//                        dp[i][j] = true;
//                        break;
//                    }
//                }
//            }
//        }
//
//        return dp[0][n - 1];
//    }

    //a more efficient, less intuitive dp solution
    bool wordBreak(string s, vector<string>& wordDict) {
        int n = s.length();
        vector<bool> dp(n + 1, false);
        dp[0] = true;

        //assume s[0:i] can be segmented, check if s[i + 1 : j] is in the dictionary
        //if it is, then s[0:j] can be segmented
        for(int i = 0; i < n; i++) {
            if(!dp[i])
                continue;

            for(int j = i + 1; j <= n; j++) {
                if(dp[j])
                    continue;
                if(std::count(wordDict.begin(), wordDict.end(), s.substr(i, j - i)))
                    dp[j] = true;
            }

            if(dp[n])
                return true;
        }

        return false;
    }
};