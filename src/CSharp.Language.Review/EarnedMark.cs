
using System;
using System.Collections.Generic;


namespace CSharp.Language.Review
{
    public class EarnedMark : WeightedMark

    {
        //this is an example of an auto-implemented property 
        //Properties provice a controlled access to information
        // Auto-implemeted property - have a "hidden" backing store
        public int Possible { get; private set; }

        //this is a field
        private double _Earned;

        //this is an explicitly implemented property
        public double Earned
        {
            // We are using the _Earned field as a "backing store"
            get { return _Earned; }
            set
            {
                if (value < 0 || value > Possible)
                    throw new Exception("Invalid earned mark assigned");
                _Earned = value;
            }
        }
        public double Percent // An example of a property that derives it values from other data
        {  get { return(Earned / Possible) * 100; } }
        
        public double WeightedPercent
        { get { return Percent * Weight / 100; } }

        //This constructor calls another constructor BEFORE it runs  it's own body of instructions/code.
        //Hooking up constructors in this fashion is known as "daisy-chaining" your constructor calls.
        public EarnedMark(WeightedMark markableItem, int possible, double earned): 
            this(markableItem.Name, markableItem.Weight,  possible, earned)
        {

        }
       
        public EarnedMark(string name, int weight , int possible, double earned) : base(name, weight)
        {
            if (possible <= 0)
                throw new Exception("Invalid Possible Marks");
            Possible = possible;
            Earned = earned;
        }

        //Chaning the behavior ofthe base class by overriding some method
        // is one way that we can accomplish Polymorphism
        public override string ToString()
        {
            return string.Format("{0} ({1})\t - {2}% ({3}/{4}) \t-Weighted Mark {5}%",
                            Name,
                            Weight,
                            Percent,
                            Earned,
                            Possible,
                            WeightedPercent);
            //CSharp.Language.Review\bin\Debug > CSharp.Language.Review.exe Bob
        }
    }
}
