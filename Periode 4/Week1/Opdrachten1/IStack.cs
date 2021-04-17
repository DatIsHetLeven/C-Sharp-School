using System;
using System.Collections.Generic;
using System.Text;

namespace Opdrachten1
{
     interface IStack
    {
        void push(int value);
        int pop();
        bool contains(int value);
        int count { get; }
        bool isEmpty { get; }
    }
}
