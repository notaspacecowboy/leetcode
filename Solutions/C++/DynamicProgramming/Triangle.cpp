#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    int minimumTotal(vector<vector<int>>& triangle) {
        int minPath = INT_MAX, n = triangle.size();
        vector<vector<int>> dp(n, vector<int>(n, INT_MAX));

        for(int i = 0; i < n; i++)
            dp[n - 1][i] = triangle[n - 1][i];

        for(int i = n - 2; i >= 0; i--) {
            for(int j = 0; j < triangle[i].size(); j++)
                dp[i][j] = triangle[i][j] + min(dp[i + 1][j], dp[i + 1][j + 1]);
        }

        return dp[0][0];
    }
};