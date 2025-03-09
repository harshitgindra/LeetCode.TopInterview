
namespace LeetCodeSolutions.Utils;

public static class TreeNodeExtensions
{
    public static TreeNode ToTreeNode(this int?[] arr)
    {
        if (arr == null || arr.Length == 0 || !arr[0].HasValue)
            return null;

        TreeNode root = new TreeNode(arr[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (int i = 1; i < arr.Length; i += 2)
        {
            TreeNode current = queue.Dequeue();

            if (arr[i].HasValue)
            {
                current.left = new TreeNode(arr[i].Value);
                queue.Enqueue(current.left);
            }

            if (i + 1 < arr.Length && arr[i + 1].HasValue)
            {
                current.right = new TreeNode(arr[i + 1].Value);
                queue.Enqueue(current.right);
            }
        }

        return root;
    }
}