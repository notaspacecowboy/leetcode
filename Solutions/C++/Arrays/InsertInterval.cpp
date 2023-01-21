#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;


class Solution {
public:
    vector<vector<int>> insert(vector<vector<int>>& intervals, vector<int>& newInterval) {
        if(intervals.size() == 0 || newInterval[0] > intervals[intervals.size() - 1][1]) {
            intervals.emplace_back(newInterval);
            return intervals;
        }

        if(newInterval[1] < intervals[0][0]) {
            intervals.insert(intervals.begin(), newInterval);
            return intervals;
        }

        int left = 0, right = intervals.size() - 1, leftMost = left, rightMost = right;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(newInterval[0] >= intervals[middle][0] && newInterval[0] <= intervals[middle][1])
            {
                leftMost = middle;
                break;
            }
            else if(newInterval[0] < intervals[middle][0])
                right = middle - 1;
            else
                left = middle + 1;
        }
        if(newInterval[0] > intervals[leftMost][1])
            leftMost++;

        left = 0;
        right = intervals.size() - 1;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(newInterval[1] >= intervals[middle][0] && newInterval[1] <= intervals[middle][1])
            {
                cout << "yes" << endl;
                rightMost = middle;
                break;
            }
            else if(newInterval[1] < intervals[middle][0])
                right = middle - 1;
            else
                left = middle + 1;
        }
        if(newInterval[1] < intervals[rightMost][0])
            rightMost--;

        newInterval[0] = min(newInterval[0], intervals[leftMost][0]);
        newInterval[1] = max(newInterval[1], intervals[rightMost][1]);

        intervals.erase(intervals.begin() + leftMost, intervals.begin() + rightMost);
        intervals.insert(intervals.begin() + leftMost, newInterval);

        return intervals;
    }
};