//using = identifies the namespaces containing the datatypes that we want to use 
//(or reference) in the code in this file.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//namespace = Declares an "area" or named-space in which we can
// place our programmer-defined data types
namespace CSharp.Language.Review
{
    //The namespace plus the class name is what's called a 
    // "fully-qualified" class name.
    // The fully-quallified class name for Program is 
    //      CSharp.Language.Review.Program
    public class Program
    {
        //A static field 
        //Format of a static field : -accessModifier- -static- -dataType- -FieldName- = expression;
        // example below:
        private static Random rnd = new Random();       //this is a static field initialized o a new Random Object

        //Main() is the entry point
        public static void Main(string[] args)
        {
            Student topStudent = new Student("Dan Gilleland", null);
            Student secondBestStudent = new Student("Don Welch", null);
            // new ... will tell the operating system to allocate enough memory for a Student Object 
            // , run the appropriate constructor and return the memory address of the newly created object

            //The body of the Main() method 
            //acts as the "driver" of my application.
            Program app = new Program(args);
            app.AssignMarks(30, 80);
            foreach (Student person in app.Students)
            {
                System.Console.WriteLine("Name : " + person.Name);
                foreach (EarnedMark item in person.Marks)
                    System.Console.WriteLine("\t" + item);
            }
        }

        //this field is acting as a "backing store" B
        // for the students property.
        private List<Student> _students = new List<Student>();


        //this property procides "controlled" access to the
        //data in the backing store (the field).
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        //This is a constructor
        // The job of the constructor is to ensure
        // that all the fields/properties
        //have "meaningful" values.
        public Program(string[] studentNames)
        {
            WeightedMark[] CourseMarks = new WeightedMark[4];
            CourseMarks[0] = new WeightedMark("Quiz 1", 20);
            CourseMarks[1] = new WeightedMark("Quiz 2", 20);
            CourseMarks[2] = new WeightedMark("Exercises", 25);
            CourseMarks[3] = new WeightedMark("Lab", 35);
            int[] possibleMarks = new int[4] { 25, 50, 12, 35 };

            foreach (string name in studentNames)
            {
                EarnedMark[] marks = new EarnedMark[4];
                for (int i = 0; i < possibleMarks.Length; i++)
                    marks[i] = new EarnedMark(CourseMarks[i], possibleMarks[i], 0);
                Students.Add(new Student(name, marks));
            }
        }
        /// <summary>
        /// This assigns a random mark to each student
        /// in the <see cref="Students"/> property.
        /// </summary>
        /// <param name="min">The minimum possible earned value for the student's mark</param>
        /// <param name="max">The maximum possible earned value for the student's mark</param>
        public void AssignMarks(int min, int max)
        {
            foreach (Student person in Students)
                foreach (EarnedMark item in person.Marks)
                    item.Earned = (rnd.Next(min, max) / 100.0) * item.Possible;
        }
    }
}
