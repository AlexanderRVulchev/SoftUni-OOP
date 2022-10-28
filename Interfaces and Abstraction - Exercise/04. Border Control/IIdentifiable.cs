using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Border_Control
{
    public interface IIdentifiable
    {
        string Name { get; }
        string Id { get; }

        void CheckId(string fakeSubstring);
    }
}
