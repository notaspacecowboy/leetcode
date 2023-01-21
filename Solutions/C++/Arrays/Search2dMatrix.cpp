#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        int m = matrix.size(), n = matrix[0].size();

        if(target < matrix[0][0] || target > matrix[m - 1][n - 1])
            return false;

        int left = 0, right = m * n - 1;

        while(left <= right) {
            int middle = left + (right - left) / 2;
            int row = middle / n;
            int col = middle % n;
            if(target == matrix[row][col])
                return true;
            else if(target < matrix[row][col])
                right = middle - 1;
            else
                left = middle + 1;
        }

        return false;
    }
};