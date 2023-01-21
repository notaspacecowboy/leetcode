#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<int> spiralOrder(vector<vector<int>>& matrix) {
        vector<int> res;
        int leftBound = 0, rightBound = matrix[0].size() - 1, botBound = matrix.size() - 1, topBound = 0;
        while(topBound <= botBound && leftBound <= rightBound) {
            for(int j = leftBound; j <= rightBound; j++)
                res.push_back(matrix[topBound][j]);
            topBound++;
            if(topBound > botBound)
                break;

            for(int j = topBound; j <= botBound; j++)
                res.push_back(matrix[j][rightBound]);
            rightBound--;
            if(leftBound > rightBound)
                break;

            for(int j = rightBound; j >= leftBound; j--)
                res.push_back(matrix[botBound][j]);
            botBound--;
            if(topBound > botBound)
                break;

            for(int j = botBound; j >= topBound; j--)
                res.push_back(matrix[j][leftBound]);
            leftBound++;
            if(leftBound > rightBound)
                break;
        }

        return res;
    }
};

// 1  2  3  4
// 5  6  7  8
// 9  10 11 12
// 13 14 15 16