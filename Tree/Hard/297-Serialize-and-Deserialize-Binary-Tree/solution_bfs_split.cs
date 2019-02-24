/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    // bfs: level order serialization
    // tc:O(n); sc:O(n)
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) {
            return string.Empty;
        }
        StringBuilder str = new StringBuilder();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        str.Append(root.val);
        str.Append(' ');
        while(queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            if(node.left != null) {
                queue.Enqueue(node.left);
                str.Append(node.left.val);
                str.Append(' ');
            }
            else {
                str.Append("# ");
            }
            if(node.right != null) {
                queue.Enqueue(node.right);
                str.Append(node.right.val);
                str.Append(' ');
            }
            else {
                str.Append("# ");
            }
        }
        return str.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data == null || data == string.Empty) {
            return null;
        }
        string[] arr = data.Split(' ');
        int cur = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();  
        TreeNode root = FetchNode(arr, ref cur);
        
        queue.Enqueue(root);
        while(queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            TreeNode leftNode = FetchNode(arr, ref cur);
            TreeNode rightNode = FetchNode(arr, ref cur);
            node.left = leftNode;
            node.right = rightNode;
            if(leftNode != null) {
                queue.Enqueue(leftNode);
            }
            if(rightNode != null) {
                queue.Enqueue(rightNode);
            }
        }
        return root;
    }
    
    private TreeNode FetchNode(string[] arr, ref int cur) {
        if(arr[cur] == "#") {
            cur++;
            return null;
        }
        TreeNode newNode = new TreeNode(Int32.Parse(arr[cur]));
        cur++;
        return newNode;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));