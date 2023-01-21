#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
using namespace std;


class Solution {
public:
    //similar to unique path I, but need to take into account the obstacles
    //the basic idea is that when standing at a obstacle, the total numbers of paths from this point to the to the
    //destination is *0*
    //therefore, if (i, j) is an obstacle, then dp[i][j] = 0
    int uniquePathsWithObstacles(vector<vector<int>>& obstacleGrid) {
        int m = obstacleGrid.size();
        int n = obstacleGrid[0].size();

        if(obstacleGrid[m - 1][n - 1] == 1)
            return 0;

        vector<vector<int>> dp(m, vector<int>(n, 0));

        dp[m - 1][n - 1] = 1;
        for(int i = n - 2; i >= 0; i--) {
            if(dp[m - 1][i + 1] == 0 || obstacleGrid[m - 1][i] == 1)
                dp[m - 1][i] = 0;
            else
                dp[m - 1][i] = 1;
        }

        for(int i = m - 2; i >= 0; i--) {
            if(dp[i + 1][n - 1] == 0 || obstacleGrid[i][n - 1] == 1)
                dp[i][n - 1] = 0;
            else
                dp[i][n - 1] = 1;
        }

        for(int i = m - 2; i >= 0; i--) {
            for(int j = n - 2; j >= 0; j--) {
                if(obstacleGrid[i][j] == 1)
                    dp[i][j] = 0;
                else
                    dp[i][j] = dp[i + 1][j] + dp[i][j + 1];
            }
        }

        return dp[0][0];
    }
};