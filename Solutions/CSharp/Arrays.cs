using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LeetCode;

public class Arrays
{
    #region 001 - two sum

    public int[] TwoSum(int[] nums, int target)
    {
        var lookup = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var toAdd = target - nums[i];
            if (lookup.ContainsKey(toAdd))
                return new int[] {i, lookup[toAdd]};
            else
                lookup[nums[i]] = i;
        }

        return new int[] { };
    }

    #endregion

    #region 011 - Container With Most Water

    public int MaxArea(int[] height)
    {
        int l = 0, r = height.Length - 1, max = 0;
        while (l < r)
        {
            var current = (r - l) * (height[l] > height[r] ? height[r] : height[l]);
            max = current > max ? current : max;
            if (height[l] > height[r])
                r--;
            else
                l++;
        }

        return max;
    }

    #endregion

    #region 0015 - 3Sum

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var i = 0;
        var result = new List<IList<int>>();
        while (i < nums.Length - 2)
        {
            TwoSum(nums, i, result);
            i++;
            while (i < nums.Length - 2 && nums[i] == nums[i - 1])
                i++;
        }

        return result;
    }

    public void TwoSum(int[] num, int startPos, List<IList<int>> result)
    {
        var target = -num[startPos];
        int left = startPos + 1, right = num.Length - 1;
        while (left < right)
            if (num[left] + num[right] == target)
            {
                result.Add(new List<int>() {num[startPos], num[left], num[right]});

                left++;
                right--;
                while (left < right && num[left] == num[left - 1])
                    left++;
                while (left < right && num[right] == num[right + 1])
                    right--;
            }
            else if (num[left] + num[right] < target)
            {
                left++;
            }
            else
            {
                right--;
            }
    }

    #endregion

    #region 0026 - Remove Duplicates from Sorted Array

    public int RemoveDuplicatesI(int[] nums)
    {
        if (nums.Length == 1)
            return 1;

        int left = 0, right = 1;
        while (right < nums.Length)
            if (nums[left] >= nums[right])
            {
                right++;
            }
            else
            {
                left++;
                nums[left] = nums[right];
            }

        return left + 1;
    }

    #endregion

    #region 0027 - Remove Elements

    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;

        int left = 0, right = nums.Length - 1;

        while (left < right)
            if (nums[right] == val)
                right--;
            else if (nums[left] == val)
                nums[left] = nums[right--];
            else
                left++;

        if (right == 0 && nums[0] == val)
            return 0;

        return right + 1;
    }

    #endregion

    #region 0031 - Next Permutation

    public void NextPermutation(int[] nums)
    {
        if (nums.Length == 1)
            return;

        var i = nums.Length - 2;
        while (i >= 0)
        {
            if (nums[i] < nums[i + 1])
                break;

            i--;
        }

        if (i == -1)
        {
            Transpose(nums, 0);
            return;
        }

        var j = nums.Length - 1;
        while (j > i)
        {
            if (nums[j] > nums[i])
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                Transpose(nums, i + 1);
                break;
            }

            j--;
        }
    }

    private void Transpose(int[] nums, int start)
    {
        int l = start, r = nums.Length - 1;
        while (l < r)
        {
            (nums[l], nums[r]) = (nums[r], nums[l]);
            l++;
            r--;
        }
    }

    #endregion

    #region 0033 - Search in Rotated Sorted Array

    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1, middle = 0;
        while (left < right)
        {
            middle = left + (right - left) / 2;
            if (nums[middle] == target)
                return middle;

            if (nums[left] < nums[middle])
            {
                if (target < nums[middle] && target >= nums[left])
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            else
            {
                if (target <= nums[right] && target > nums[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
        }

        if (target == nums[left])
            return left;

        return -1;
    }

    #endregion

    #region 0034 - Find First and Last Position of Element in Sorted Array

    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0)
            return new int[] {-1, -1};

        int leftMost = -1, rightMost = -1, left = 0, right = nums.Length - 1, middle = 0;
        while (left <= right)
        {
            middle = (left + right) / 2;
            if (nums[middle] == target)
            {
                leftMost = middle;
                right = middle - 1;
            }
            else if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        if (leftMost == -1)
            return new int[] {-1, -1};

        left = leftMost;
        rightMost = leftMost;
        right = nums.Length - 1;
        while (left <= right)
        {
            middle = (left + right) / 2;
            if (nums[middle] == target)
            {
                rightMost = middle;
                left = middle + 1;
            }
            else if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return new int[] {leftMost, rightMost};
    }

    #endregion

    #region 0035 - Search Insertion Position

    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1, middle = 0;
        while (left <= right)
        {
            middle = (left + right) / 2;
            if (nums[middle] >= target)
                right = middle - 1;
            else
                left = middle + 1;
        }

        return right + 1;
    }

    #endregion

    #region 0041 - First Missing Positive

    public int FirstMissingPositive(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
                (nums[nums[i] - 1], nums[i]) = (nums[i], nums[nums[i] - 1]);

        for (var i = 0; i < nums.Length; i++)
            if (nums[i] != i + 1)
                return i + 1;


        return nums.Length + 1;
    }

    #endregion

    #region 0042 - Trapping Rain Water

    public int Trap(int[] height)
    {
        int left = 0, right = height.Length - 1, maxLeft = 0, maxRight = 0, res = 0;
        while (left <= right)
            if (height[left] <= height[right])
            {
                if (height[left] >= maxLeft)
                    maxLeft = height[left];
                else
                    res += maxLeft - height[left];

                left++;
            }
            else
            {
                if (height[right] >= maxRight)
                    maxRight = height[right];
                else
                    res += maxRight - height[right];

                right--;
            }

        return res;
    }

    #endregion

    #region 0053 - Maximum Subarrary

    public int MaxSubArray(int[] nums)
    {
        int maximum = nums[0], current = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            current += nums[i];
            maximum = Math.Max(maximum, current);

            if (current < 0)
                current = 0;
        }

        return maximum;
    }

    #endregion

    #region 0056 - Merge Intervals
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (arr1, arr2) =>
        {
            if (arr1[0] == arr2[0])
                return 0;
            else if (arr1[0] < arr2[0])
                return -1;
            else
                return 1;
        });

        List<int[]> results = new();
        results.Add(intervals[0]);
        int current = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= results[current][1])
                results[current][1] = Math.Max(intervals[i][1], results[current][1]);
            else
            {
                results.Add(intervals[i]);
                current++;
            }
        }
        
        return results.ToArray();
    }

    #endregion

    #region 0057 - Insert Interval

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> results = new List<int[]>();
        bool hasAdded = false;
        for (int i = 0; i < intervals.Length; i++)
        {
            if(intervals[i][1] < newInterval[0])
                results.Add(intervals[i]);
            else if (intervals[i][0] > newInterval[1])
            {
                if (!hasAdded)
                {
                    hasAdded = true;
                    results.Add(newInterval);
                    results.Add(intervals[i]);
                }
                else
                    results.Add(intervals[i]);
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
        }

        if(!hasAdded)
            results.Add(newInterval);

        return results.ToArray();
    }

    #endregion

    #region 0066 - Plus One

    public int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            digits[i] = (digits[i] + 1);
            if (digits[i] == 10)
            {
                digits[i] = 0;
            }
            else
            {
                return digits;
            }
        }

        int[] results = new int[digits.Length + 1];
        results[0] = 1;
        Array.Copy(digits, 0, results, 1, digits.Length);
        return results;
    }

    #endregion

    #region 0067 - Add Binary

    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length)
            (a, b) = (b, a);

        int i = a.Length - 1, j = b.Length - 1, addOne = 0;
        string result = "";
        while (i >= 0 && j >= 0)
        {
            int res = (a[i] - '0') + (b[j] - '0') + addOne;
            addOne = (res > 1 ? 1 : 0);
            res %= 2;

            result = (char) (res + '0') + result;
            i--;
            j--;
        }

        while (i >= 0)
        {
            int res = (a[i] - '0') + addOne;
            addOne = (res > 1 ? 1 : 0);
            res %= 2;

            result = (char)(res + '0') + result;
            i--;
        }

        if (addOne == 1)
            return "1" + result;
        return result;
    }

    #endregion

    #region 0075 - Sort Colors

    public void SortColors(int[] nums)
    {
        int low = 0, high = nums.Length - 1;
        for (int i = low; i <= high;)
        {
            if (nums[i] == 1)
                i++;
            else if (nums[i] == 0)
            {
                (nums[low], nums[i]) = (nums[i], nums[low]);
                i++;
                low++;
            }
            else
            {
                (nums[high], nums[i]) = (nums[i], nums[high]);
                high--;
            }
        }
    }

    #endregion

    #region 0080 - Remove Duplicates from Sorted Array II

    public int RemoveDuplicates(int[] nums)
    {
        int shadowPos = 0, dupCount = 0, lastElem = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == lastElem)
                dupCount++;
            else
            {
                lastElem = nums[i];
                dupCount = 1;
            }

            if (dupCount <= 2)
            {
                nums[shadowPos++] = nums[i];
            }
        }

        return shadowPos;
    }

    #endregion
}