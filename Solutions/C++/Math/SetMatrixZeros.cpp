#include <string>
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

class Solution {
public:
    void setZeroes(vector<vector<int>>& matrix) {
        bool shouldSetRow0 = false, shouldSetCol0 = false;
        int m = matrix.size(), n = matrix[0].size();
        for(int i = 0; i < m; i++) {
            if(matrix[i][0] == 0)
            {
                shouldSetCol0 = true;
                break;
            }
        }

        for(int i = 0; i < n; i++) {
            if(matrix[0][i] == 0)
            {
                shouldSetRow0 = true;
                break;
            }
        }

        for(int i = 1; i < m; i++) {
            for(int j = 1; j < n; j++) {
                if(matrix[i][j] == 0) {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }


        for(int i = 1; i < m; i++) {
            if(matrix[i][0] != 0)
                continue;

            for(int j = 1; j < n; j++) {
                matrix[i][j] = 0;
            }
        }

        for(int j = 1; j < n; j++) {
            if(matrix[0][j] != 0)
                continue;

            for(int i = 1; i < m; i++) {
                matrix[i][j] = 0;
            }
        }

        if(shouldSetRow0) {
            for(int i = 0; i < n; i++)
                matrix[0][i] = 0;
        }

        if(shouldSetCol0) {
            for(int i = 0; i < m; i++)
                matrix[i][0] = 0;
        }

    }
};