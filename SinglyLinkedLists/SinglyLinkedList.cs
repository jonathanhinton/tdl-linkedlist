﻿using System;
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
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }
        
        public void AddFirst(string value)
        {
            throw new NotImplementedException();
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
                while (location.Next != null)
                {
                    counter++;
                }
                return counter;
            }
        }

        public string ElementAt(int index)
        {
            //set counter to compare to index
            //int counter = 0;

            //create node reference
            SinglyLinkedListNode location = FirstLocation;
            SinglyLinkedListNode mutableLocation = FirstLocation;
            if (location == null)
            {
                throw new ArgumentOutOfRangeException("no known nodes");
            }
            if (index == 0)
            {
                return mutableLocation.ToString();
            }
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
            //throw exception if first location is null
            
                for (int i = 0; i < index; i++)
                {
                    mutableLocation = mutableLocation.Next;
                }
                return mutableLocation.ToString();
            
            //If the first location is not null and counter matches index
            /*if (location != null && counter == index)
            {
                return location.ToString();
            } else
            {
                //set up a loop to find the location based on the counter and index value matching
                while (counter != index)
                {
                    location = location.Next;
                    counter++;
                    if (counter < index && location == null)
                    {
                        throw new ArgumentOutOfRangeException("no known node");
                    }
                }
                return location.ToString();
            }*/
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

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
