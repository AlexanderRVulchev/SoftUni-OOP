using _08._Collection_Hierarchy.Interfaces;
using System.Collections.Generic;


namespace _08._Collection_Hierarchy
{
    public class AddCollection : IAdder
    {
        private List<string> collection;               

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
