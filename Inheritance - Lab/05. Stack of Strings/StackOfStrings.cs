using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
            => this.Count == 0;

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (string item in collection)
                this.Push(item);
        }
    }
}
