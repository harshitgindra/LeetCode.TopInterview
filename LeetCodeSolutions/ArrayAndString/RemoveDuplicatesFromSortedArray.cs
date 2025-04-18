using NUnit.Framework;

namespace LeetCodeSolutions.ArrayAndString;

public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums)
    {
        int uniquePointer = 1;
        int returnValue = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[uniquePointer] = nums[i];
                uniquePointer++;
                returnValue++;
            }
        }

        return returnValue;
    }
    
    [Test(Description = "https://leetcode.com/problems/remove-duplicates-from-sorted-array/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Array/String")]
    [Category("TopInterview")]
    [Category("Remove Duplicates From Sorted Array")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = RemoveDuplicates(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {

            (5, [0,0,1,1,1,2,2,3,3,4]),
        };
}