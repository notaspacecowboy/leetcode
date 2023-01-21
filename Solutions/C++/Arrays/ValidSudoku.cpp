#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool isValidSudoku(vector<vector<char>>& board) {
        vector<string> rows {9, "........." };
        vector<string> columns {9, "........." };
        vector<string> boxes {9, "........." };

        for(int i = 0; i < 9; i++) {
            for(int j = 0; j < 9; j++) {
                if(board[i][j] == '.')
                    continue;

                int valueIndex = board[i][j] - '0' - 1;
                int boxIndex = i / 3 * 3 + (j / 3);
                if(rows[i][valueIndex] != '.' || columns[j][valueIndex] != '.' || boxes[boxIndex][valueIndex] != '.')
                    return false;

                rows[i][valueIndex] = '*';
                columns[j][valueIndex] = '*';
                boxes[boxIndex][valueIndex] = '*';
            }
        }

        return true;
    }
};