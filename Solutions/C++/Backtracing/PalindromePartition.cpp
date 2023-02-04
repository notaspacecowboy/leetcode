#include <iostream>
#include <vector>
#include "TreeNode.h"
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<vector<bool>> dp;
    vector<vector<string>> res;
    void help(vector<string> &current, const string &s, int left, int right) {
        if (right == s.length()) {
            if (left == right)
                res.emplace_back(vector<string>(current));
            return;
        }

        help(current, s, left, right + 1);

        //if(s[left, right]) is a valid string
        if(dp[left][right]) {
            current.emplace_back(s.substr(left, right - left + 1));
            help(current, s, right + 1, right + 1);
            current.pop_back();
        }
    }

    vector<vector<string>> partition(string s) {
        int n = s.length();
        dp.resize(n, vector<bool>(n, false));

        for(int i = 0; i < s.length(); i++) {
            dp[i][i] = true;

            if(i != s.length() - 1)
                dp[i][i + 1] = (s[i] == s[i + 1]);
        }

        for(int j = 2; j < s.length(); j++) {
            for(int i = j - 2; i >= 0; i--) {
                dp[i][j] = s[i] == s[j] && dp[i + 1][j - 1];
            }
        }

        vector<string> current;
        help(current, s, 0, 0);
        return res;
    }
};