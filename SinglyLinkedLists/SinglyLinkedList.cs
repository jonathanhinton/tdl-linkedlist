using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode FirstLocation { get; set; }
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                string newItem = values[i].ToString();
                this.AddLast(newItem);
            }

        }

        // READ: 
        public string this[ int i]
        {
            get { return ElementAt(i) ; }
            set
            {
                int rectified = i - 1;
                string current = ElementAt(rectified);
                this.AddAfter(value, current);
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            SinglyLinkedListNode node = FirstLocation;
            if (node == null)
            {
                node = newNode;
            }
            else
            {
                while (node.Value != existingValue)
                {
                    if (node.Next == null)
                    {
                        throw new ArgumentException();
                    }
                    node = node.Next;
                }
                newNode.Next = node.Next;
                node.Next = newNode;
            }
        }
        
        public void AddFirst(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            SinglyLinkedListNode pointer;
            if (this.First() == null)
            {
                FirstLocation = newNode;
            }
            else
            {
                pointer = FirstLocation;
                FirstLocation = newNode;
                newNode.Next = pointer;
            }
        }
        
        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);

            if (FirstLocation == null)
            {
                FirstLocation = newNode;
            } else
            {
                SinglyLinkedListNode node = FirstLocation;

                while (!node.IsLast())
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
        }
        
        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int counter = 1;
            SinglyLinkedListNode location = FirstLocation;
            if (location == null)
            {
                return counter;
            }
            else
            {
                while (!location.IsLast())
                {
                    counter++;
                    location = location.Next;
                }
                return counter;
            }
        }

        public string ElementAt(int index)
        {

            //create node reference
            SinglyLinkedListNode location = FirstLocation;
            SinglyLinkedListNode mutableLocation = FirstLocation;

            //check to see if first location is null, if so throw exception and end method
            if (location == null)
            {
                throw new ArgumentOutOfRangeException("no known nodes");
            }

            //check to see if index is 0, if so return first location to string
            if (index == 0)
            {
                return mutableLocation.ToString();
            }

            //check for negative indices, if so increment count to accomodate offset.
            if (index < 0)
            {
                int count = 1;
                while (!location.IsLast())
                {
                    count++;
                    location = location.Next;
                }
                index = index + count;
            }
            
            for (int i = 0; i < index; i++)
            {
                mutableLocation = mutableLocation.Next;
            }
            return mutableLocation.ToString();

        }
        
        public string First()
        {        
            return FirstLocation?.ToString();
        }
        
        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        private SinglyLinkedListNode LastNode()
        {
            SinglyLinkedListNode node = FirstLocation;
            while (!node.IsLast())
            {
                node = node.Next;
            }
            return node;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            SinglyLinkedListNode node = FirstLocation;
            if (node == null)
            {
                return null;                
            }
            node = this.LastNode();
            return node?.ToString();
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            SinglyLinkedListNode node = FirstLocation;
            List<string> nodeList = new List<string>();
            if (node == null)
            {
                string[] result = { };
                return result;
            }
            while (node != null)
            {
                nodeList.Add(node.Value);
                node = node.Next;
            }
            string[] hammerTime = nodeList.ToArray();
            return hammerTime;
        }

        public override string ToString()
        {
            SinglyLinkedListNode node = FirstLocation;
            StringBuilder sb = new StringBuilder();
            if (node == null)
            {
                return "{ }";
            }
            sb.Append("{ ");
            while (node != null)
            {
                sb.Append( "\"" + node.ToString() + "\"");
                node = node.Next;
                if (node != null)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
