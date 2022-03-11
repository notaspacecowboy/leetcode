using System.Collections.Generic;

int[] TwoSum(int[] nums, int target)
{
    var numDic = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        int secondNum = target - nums[i];
        if (numDic.TryGetValue(secondNum, out int index))
        {
            return new int[] {index, i};
        }
        else if(!numDic.ContainsKey(nums[i]))
        {
            numDic.Add(nums[i], i);
        }
    }

    return new int[] {-1, -1};      //should never get to here
}