#include <vector>
using namespace std;


class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2)
    {
        int m = nums1.size(), n = nums2.size();
    	if(m == 0)
    	{
            if (n % 2)
                return 1.0 * nums2[n / 2];

    		return (nums2[n / 2 - 1] + nums2[n / 2]) / 2.0;
    	}

    	if(n == 0)
    	{
            if (m % 2)
                return 1.0 * nums1[m / 2];

    		return (nums1[m / 2 - 1] + nums1[m / 2]) / 2.0;
    	}

    	if ((m + n) % 2)
            return findKthNbr(nums1, 0, nums2, 0, (m + n) / 2 + 1);
           
        return (findKthNbr(nums1, 0, nums2, 0, (m + n) / 2) +
                findKthNbr(nums1, 0, nums2, 0, (m + n) / 2 + 1)) / 2.0;

    }       

    int findKthNbr(vector<int>& nums1, int i, vector<int>& nums2, int j, int k)
    {
        if (i >= nums1.size())
            return nums2[j + k - 1];

        if (j >= nums2.size())
            return nums1[i + k - 1];

        if (k == 1)
        {
            if (nums1[i] < nums2[j])
                return nums1[i];
            else
                return nums2[j];
        }

        int k1 = INT_MAX, k2 = INT_MAX;
        if (i + k / 2 - 1 < nums1.size())
            k1 = nums1[i + k / 2 - 1];
        if (j + k / 2 - 1 < nums2.size())
            k2 = nums2[j + k / 2 - 1];

        if (k1 < k2)
            return findKthNbr(nums1, i + k / 2, nums2, j, k - k / 2);

        return findKthNbr(nums1, i, nums2, j + k / 2, k - k / 2);
    }
};