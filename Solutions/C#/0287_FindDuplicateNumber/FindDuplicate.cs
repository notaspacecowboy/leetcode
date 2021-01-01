public class Solution {
    public int FindDuplicate(int[] nums) {
        int n = nums.Length;
        bool[] exist = new bool[n];
        
        int i = 0;
        while(i < n)
        {
            if(exist[nums[i]])
                return nums[i];
                
            exist[nums[i]] = true;
            
            i++;
        }
        
        return -1;
    }
}