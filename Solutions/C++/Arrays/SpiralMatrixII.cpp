#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<vector<int>> generateMatrix(int n) {
        int leftBound = 0, rightBound = n - 1, topBound = 0, botBound = n - 1;
        vector<vector<int>> res ( n, vector<int>(n, 0) );

        int count = 0;
        while(leftBound <= rightBound && topBound <= botBound) {
            for(int i = leftBound; i <= rightBound; i++)
                res[topBound][i] = ++count;
            topBound++;

            for(int i = topBound; i <= botBound; i++)
                res[i][rightBound] = ++count;
            rightBound--;

            for(int i = rightBound; i >= leftBound; i--)
                res[botBound][i] = ++count;
            botBound--;

            for(int i = botBound; i >= topBound; i--)
                res[i][leftBound] = ++count;
            leftBound++;
        }

        return res;
    }
};