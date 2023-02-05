#include <Graph.h>
#include <vector>
#include <iostream>

using namespace std;

class Solution {
public:
    int canCompleteCircuit(vector<int>& gas, vector<int>& cost) {
        int totalBalance = 0, currentBalance = 0, startPos = 0;
        for(int i = 0; i < gas.size(); i++) {
            totalBalance += (gas[i] - cost[i]);
            currentBalance += (gas[i] - cost[i]);
            if(currentBalance < 0) {
                startPos = i + 1;
                currentBalance = 0;
            }
        }

        return totalBalance >= 0 ? startPos : -1;
    }
};