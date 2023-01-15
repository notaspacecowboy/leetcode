#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<vector<int>> merge(vector<vector<int>>& intervals) {
        sort(intervals.begin(), intervals.end(), [](const vector<int> &a, const vector<int> &b) -> bool {
            return a[0] < b[0];
        });

        vector<vector<int>> res;
        int left = intervals[0][0], right = intervals[0][1];

        for(int i = 1; i < intervals.size(); i++) {
            if(intervals[i][0] > right) {
                res.emplace_back(vector<int> {left, right});
                left = intervals[i][0];
                right = intervals[i][1];
                continue;
            }

            right = max(right, intervals[i][1]);
        }

        res.emplace_back(vector<int>{left, right});

        return res;
    }
};