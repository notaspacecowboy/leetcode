#include <vector>
using namespace std;

class Solution {
public:
    int maxProduct(vector<int>& nums) {
        int globalMax = INT32_MIN;
        int currentProduct = 1;
        for(int i = 0; i < nums.size(); i++)
        {
            currentProduct *= nums[i];
            globalMax = currentProduct > globalMax ? currentProduct : globalMax;
            if (currentProduct == 0)
                currentProduct = 1;
        }

        currentProduct = 1;
        for(int i = nums.size() - 1; i >= 0; i--)
        {
            currentProduct *= nums[i];
            globalMax = currentProduct > globalMax ? currentProduct : globalMax;
            if (currentProduct == 0)
                currentProduct = 1;
        }

        return globalMax;
    }
};