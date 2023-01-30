#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;


class Solution {
public:
    vector<int> getRow(int rowIndex) {
        vector<int> res(rowIndex + 1, 1);
        if(rowIndex <= 1)
            return res;

        vector<int> lookup(rowIndex - 1, 0);
        for(int i = 1; i < rowIndex; i++) {
            for(int j = 0; j < i; j++)
                lookup[j] = res[j] + res[j + 1];

            for(int j = 0; j < i; j++)
                res[j + 1] = lookup[j];
        }

        return res;
    }
};