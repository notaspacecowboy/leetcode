#include <vector>

using namespace std;

class Solution {
public:
    int maxArea(vector<int>& height) {
        int left = 0, right = height.size() - 1, maxLen = 0, current = 0;
        while(left < right) {
            current = (right - left) * min(height[left], height[right]);
            if(current > maxLen)
                maxLen = current;

            if(height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxLen;
    }
};
