#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int pos = 0, currentHoldPrice = prices[0], maxProfit = 0;

        for(int i = 1; i < prices.size(); i++) {
            if(currentHoldPrice > prices[i])
                currentHoldPrice = prices[i];
            else {
                maxProfit += (prices[i] - currentHoldPrice);
                currentHoldPrice = prices[i];
            }
        }

        return maxProfit;
    }
};