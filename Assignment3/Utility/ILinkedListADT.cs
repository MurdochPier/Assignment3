using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public interface ILinkedListADT
    {
        /// Checks if the list is empty.
        bool IsEmpty();
        
        /// Clears the list.
        void Clear();
        
        /// Adds to the end of the list.
        void AddLast(User value);
        
        /// Prepends (adds to beginning) value to the list.
        void AddFirst(User value);

        /// Adds a new element at a specific position.
        void Add(User value, int index);

        /// Replaces the value  at index.
        void Replace(User value, int index);

        /// Gets the number of elements in the list.
        int Count();

        /// Removes first element from list
        void RemoveFirst();

        /// Removes last element from list
        void RemoveLast();

        /// Removes element at index from list, reducing the size.
        void Remove(int index);

        /// Gets the value at the specified index.
        User GetValue(int index);

        /// Gets the first index of element containing value.
        int IndexOf(User value);

        /// Go through nodes and check if one has value.
        bool Contains(User value);
    }
}
