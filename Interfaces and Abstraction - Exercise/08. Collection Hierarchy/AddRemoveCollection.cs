using _08._Collection_Hierarchy.Interfaces;
using System.Collections.Generic;


namespace _08._Collection_Hierarchy
{
    public class AddRemoveCollection : IAddRemover
    {
        private List<string> collection;               

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            int index = this.collection.Count - 1;
            string itemValue = this.collection[index];
            this.collection.RemoveAt(index);
            return itemValue;
        }
    }
}
