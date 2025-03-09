namespace LeetCodeSolutions.Utils
{
    public static class ListNodeExtensions
    {
        public static ListNode ToListNode(this int[] nums)
        {
            var node = Build(nums, 0, new ListNode());
            return node;
        }

        private static ListNode Build(int[] nums, int index, ListNode node)
        {
            if (nums.Length > index)
            {
                node = new ListNode(nums[index]);
                node.next = Build(nums, index + 1, node.next);
            }

            return node;
        }
        
        public static int[] ToArray(this ListNode head)
        {
            if (head == null)
                return new int[0];

            List<int> values = new List<int>();
            ListNode current = head;

            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }

            return values.ToArray();
        }
    }
}
