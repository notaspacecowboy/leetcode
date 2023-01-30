#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<vector<int>> generate(int numRows) {
        vector<vector<int>> res;
        res.emplace_back(vector<int>(1, 1));

        for(int i = 1; i < numRows; i++) {
            vector<int> current(res[i - 1].size() + 1, 1);

            const auto &prev = res[i - 1];
            for(int j = 0; j < prev.size() - 1; j++)
                current[j + 1] = prev[j] + prev[j + 1];

            res.emplace_back(current);


        }

        return res;
    }
};