using NUnit.Framework.Legacy;

namespace LeetCodeSolutions.Utils;

public class TreeNodeBuilder
{
    public static TreeNode ArrayToTreeNode(int?[] arr)
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
    
    public static void AssertTreeNodeAgainstArray(TreeNode root, int?[] array)
    {
        if (root == null && (array == null || array.Length == 0))
        {
            return;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 0;

        while (queue.Count > 0 && index < array.Length)
        {
            TreeNode node = queue.Dequeue();

            if (node == null)
            {
                ClassicAssert.IsNull(array[index], $"Node at index {index} should be null");
            }
            else
            {
                ClassicAssert.IsNotNull(array[index], $"Expected non-null value at index {index}");
                ClassicAssert.AreEqual(array[index].Value, node.val, $"Mismatch at index {index}");

                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            index++;
        }

        ClassicAssert.AreEqual(array.Length, index, "Array length does not match tree size");
    }
}