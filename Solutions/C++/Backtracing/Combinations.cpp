#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void findCombine(vector<vector<int>> &res, vector<int> &current, int n, int k, int index) {
        if(current.size() == k)
        {
            res.emplace_back(vector<int> {current});
            return;
        }

        for(int i = index; i <= n; i++) {
            current.emplace_back(i);
            findCombine(res, current, n, k, i + 1);
            current.pop_back();
        }
    }

    vector<vector<int>> combine(int n, int k) {
        vector<vector<int>> res;
        vector<int> current;
        findCombine(res, current, n, k, 1);

        return res;
    }
};