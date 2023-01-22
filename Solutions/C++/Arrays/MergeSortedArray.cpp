#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) {
        if(n == 0)
            return;

        int i = m - 1, j = n - 1;
        while(i >= 0 && j >= 0) {
            if(nums1[i] >= nums2[j])
                nums1[i + j + 1] = nums1[i--];

            else
                nums1[i + j + 1] = nums2[j--];
        }

        while(j >= 0)
            nums1[j] = nums2[j--];

    }
};