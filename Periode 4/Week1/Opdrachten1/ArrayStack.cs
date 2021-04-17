using System;
using System.Linq;


namespace Opdrachten1
{
    class ArrayStack : IStack
    {
        private int[] stack;
        private int currentPosition = 0;

        public ArrayStack(int length)
        {
            stack = new int[length];
        }

        public void push(int value)
        {
            stack[currentPosition] = value;
            currentPosition++;
        }

        public int pop()
        {
            currentPosition--;

            int value = stack[currentPosition];
            stack[currentPosition] = 0;

            return value;
        }

        public bool contains(int value) => stack.Contains(value);
        public int count { get { return stack.Count(value => value != 0); } }
        public bool isEmpty { get { return count == 0; } }
    }
}
