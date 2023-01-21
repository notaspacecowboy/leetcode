#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    void FindCombinationRec(vector<vector<int>>& res, vector<int>& candidates, vector<int>& current, int index, int target) {
        for(int i = index; i < candidates.size(); i++) {
            if(i > index && candidates[i] == candidates[i - 1])
                continue;

            if(candidates[i] > target)
                break;

            if(candidates[i] == target) {
                vector<int> newRes {current};
                newRes.emplace_back(candidates[i]);
                res.emplace_back(newRes);
                break;
            }

            current.emplace_back(candidates[i]);
            FindCombinationRec(res, candidates, current, i, target - candidates[i]);
            current.pop_back();
        }
    }

    vector<vector<int>> combinationSum2(vector<int>& candidates, int target) {
        sort(candidates.begin(), candidates.end());

        vector<vector<int>> res;
        vector<int> current;
        FindCombinationRec(res, candidates, current, 0, target);

        return res;
    }
};