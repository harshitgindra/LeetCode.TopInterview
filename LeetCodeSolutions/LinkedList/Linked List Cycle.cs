namespace LeetCodeSolutions.LinkedList
{
    class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head, slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/linked-list-cycle/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Linked List Cycle")]
        [TestCaseSource(nameof(Input))]
        [Category("LinkedList")]
        [Category("TopInterview")]
        public void Test1((bool Output, int[] Input) item)
        {
            HasCycle(item.Input.ToListNode());
        }

        public static IEnumerable<(bool Output, int[] Input)> Input
        {
            get
            {
                return new List<(bool Output, int[] Input)>()
                {

                    (true, [3,2,0,4,2]),
                };
            }
        }
    }
}
