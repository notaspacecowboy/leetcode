#include <iostream>
#include <vector>
#include "TreeNode.h"
using namespace std;

class Solution {
public:
    //the most important thing to aware here is that count(left, right) = count(0, right - left)
    //so we do not need a 2D dp table to get the correct answer
    int numTrees(int n) {
        vector<int> dp(n + 1, 0);
        dp[0] = dp[1] = 1;

        for(int i = 2; i <= n; i++)
            for(int j = 1; j <= i; j++)
                dp[i] += (dp[i - 1] * dp[j - i]);


        return dp[n];
    }
};