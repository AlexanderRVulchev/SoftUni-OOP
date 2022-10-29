using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Collection_Hierarchy.Interfaces
{
    public interface IMyList : IAddRemover
    {
        int Used { get; }
    }
}
