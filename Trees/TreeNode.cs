
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        private List<TreeNode<T>> Children;

    

        

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>>();
            
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
            
            return null;
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> node = new TreeNode<T>(value);
            Children.Add(node);
            return node;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int cont = 1;
            foreach (TreeNode<T> Child in Children)
            {
                cont += Child.Count();   
            }
            return cont;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree

            //Si no hay hijos
            if (Children.Count() == 0)
            {
                return 0;
            }

            //Si hay Hijos
            int maxChildHeight = 0;
            foreach (TreeNode<T> Child in Children)
            {
                int childHeight = Child.Height();
                if(childHeight > maxChildHeight)
                {
                    maxChildHeight = childHeight;
                }
            }
            return 1 + maxChildHeight;        
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            
        }
    }
}