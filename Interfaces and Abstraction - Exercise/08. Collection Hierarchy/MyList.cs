using _08._Collection_Hierarchy.Interfaces;
using System.Collections.Generic;


namespace _08._Collection_Hierarchy
{
    public class MyList : IMyList
    {
        private List<string> collection;
                
        public int Used => this.collection.Count;

        public MyList()
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
            string itemValue = this.collection[0];
            this.collection.RemoveAt(0);
            return itemValue;
        }
    }
}
