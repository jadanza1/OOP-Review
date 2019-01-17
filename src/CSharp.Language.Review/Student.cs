using System;
using System.Collections.Generic;

namespace CSharp.Language.Review
{
    public class Student // by default inherit from the built-in class called Object
                        //Object class provides some basic abilities.
    {
        public string Name { get; private set; }
        public EarnedMark[] Marks { get; private set; }

        public Student(string name, EarnedMark[] marks)
        {
            Name = name;
            Marks = marks;
        }
    }
}
