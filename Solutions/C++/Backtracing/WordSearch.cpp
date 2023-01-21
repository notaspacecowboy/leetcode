#include <iostream>
#include <vector>
using namespace std;


class Solution {
public:
    bool btExist(vector<vector<char>> &board, string &word, vector<vector<bool>> &used, int index, int i, int j) {
        if(word[index] != board[i][j])
            return false;

        if(index >= word.size() - 1)
            return true;

        used[i][j] = true;
        bool found = false;
        if(i < board.size() - 1 && !used[i + 1][j])
            found = btExist(board, word, used, index + 1, i + 1, j);
        if(found)
            return true;

        if(i > 0 && !used[i - 1][j])
            found = btExist(board, word, used, index + 1, i - 1, j);
        if(found)
            return true;

        if(j < board[0].size() - 1 && !used[i][j + 1])
            found = btExist(board, word, used, index + 1, i, j + 1);
        if(found)
            return true;

        if(j > 0 && !used[i][j - 1])
            found = btExist(board, word, used, index + 1, i, j - 1);
        if(found)
            return true;
        used[i][j] = false;

        return false;
    }

    bool exist(vector<vector<char>>& board, string word) {
        vector<vector<bool>> used (board.size(), vector<bool>(board[0].size(), false));
        for(int i = 0; i < board.size(); i++) {
            for(int j = 0; j < board[0].size(); j++) {
                if(board[i][j] != word[0])
                    continue;
                if(btExist(board, word, used, 0, i, j))
                    return true;
            }
        }

        return false;
    }
};