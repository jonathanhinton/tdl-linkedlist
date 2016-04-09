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
                if (i <= 0)
                {
                    AddFirst(value);
                }
                else
                {
                    AddAt(i, value);
                    
                }
            }
        }

        public void AddAt(int index, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            SinglyLinkedListNode node = FirstLocation;

            for (int i = 1; i < index; i++)
            {
                node = node.Next;
            }

            node.Next = newNode;

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
                    //if node.next == null then we've gone too far.
                    if (node.Next == null)
                    {
                        throw new ArgumentException();
                    } else
                    {
                        node = node.Next;

                    }

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
            int counter = 0;
            SinglyLinkedListNode location = FirstLocation;
            if (location == null)
            {
                return counter;
            }
            else
            {
                counter = 1;
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
                if (mutableLocation.IsLast())
                {
                    throw new ArgumentOutOfRangeException();
                }
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
            //declare index variable and assign value of 0
            int index = 0;

            //declare reference node to itterate through linked list
            SinglyLinkedListNode node = FirstLocation;

            //check to see if the first location is null, if so throw argument exception
            if (node == null)
            {
                index = -1;
                return index;
            }

            while(node.Value != value)
            {
                if (node.IsLast())
                {
                    index = -1;
                    return index;
                }

                index++;
                node = node.Next;
            }

            return index;
        }

        public bool IsSorted()
        {
            string[] myList = ToArray();
            int listSize = Count();
            for (int i = 1; i < listSize; i++)
            {
                string strA = myList[i - 1];
                string strB = myList[1];
                if (string.Compare(strA, strB) > 0)
                {
                    return false;
                }
            }
            return true;
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
            SinglyLinkedListNode node = FirstLocation;

            if (node.Value == value)
            {
                FirstLocation = node.Next;
            }
            else
            {
                //find index of node to terminate
                int nodeToTerminate = IndexOf(value);
                if (nodeToTerminate == -1)
                {
                    FirstLocation = FirstLocation;
                }
                else
                {

                    //rectify the index to grab previous node in order to orphan the node to be removed
                    int previousNode = nodeToTerminate - 1;

                    //assign new value to find that previous node
                    string newValue = ElementAt(previousNode);


                    //itterate through list to get the node
                    while (node.Value != newValue)
                    {
                        node = node.Next;
                    }

                    node.Next = node.Next.Next;
                }

            }
        }

        public void Sort()
        {
            int listSize = Count();
            for (int i = 0; i < listSize; i++)
            {
                for (int j = 0; j < listSize; j++)
                {

                }
            }
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
