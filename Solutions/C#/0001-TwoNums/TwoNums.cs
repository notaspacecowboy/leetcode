using System.Collections.Generic;

int[] TwoSum(int[] nums, int target)
{
    var numDic = new Dictionary<int, int>();
    int index = -1, secondNum = -1;
    for (int i = 0; i < nums.Length; i++)
    {
        secondNum = target - nums[i];
        if (numDic.TryGetValue(secondNum, out index))
        {
            return new int[] {index, i};
        }
        else
        {
            numDic.Add(nums[i], i);
        }
    }

    return new int[] {-1, -1};      //should never get to here
}
