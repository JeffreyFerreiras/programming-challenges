namespace BinarySearch;

public class Solution
{
    public int Search2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }

    public int Search(int[] nums, int target)
    {
        int low = 0, high = nums.Length - 1;

        while(low < high)
        {
            int mid = (low + high) / 2 - 1;
            
            if(nums[mid] > target)
                low = mid;
            else if (nums[mid] < target) 
                high = mid;
            else return mid; 
        }

        return -1;
    }
}
