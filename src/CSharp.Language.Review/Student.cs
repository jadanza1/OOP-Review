using System;
using System.Collections.Generic;

namespace CSharp.Language.Review
{
    public class Student
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
