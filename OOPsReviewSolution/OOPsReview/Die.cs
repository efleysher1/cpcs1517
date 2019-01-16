using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
	public class Die
	{
		//create a new instance of the math class Random
		// this instance(occurence, object) will be shared by each
		// instance of the class Die
		//this instance will be created when the first instance
		// of Die is created
		private static Random mRandom = new Random();

		//this is the definition of a object
		//it's a conceptual view of the data
		//that will be held by a physical
		//instance (object) of this class

		//Data members
		//is an internal private data storage item
		//private data members cannot be reached directly
		//by the user
		//public data members can be reached directly by 
		//the user
		private int mSides;
		private string mColour;

		//properties
		//a property is an external interface between the user
		//and a single piece of data within the instance
		//a property has two abilities
		//1.the ability to assign a value to the internal
		// data member
		//2.return an internal data member value to the user

		//fully implemented property
		public int Sides
		{
			get
			{
				//takes internal value and returns it to the user
				return mSides;
			}
			set
			{
				//takes the supplied user value and places it into
				//the internal private data member
				//the incoming piece of data is placed into a special 
				//variable that is called: value
				//optionally, you may place validation on the incoming
				//value
				if (value >= 6 && value <=20)
				{
					mSides = value;
					Roll();
					//consider placing this method within the property
					// if the set is public, and not private
					//if private, then the method SetSides solves this problem
				}
				else
				{
					throw new Exception("Die cannot be " + value.ToString() + "sides. Die must have between six and twenty sides.");
				}
			}
		}

		public string Colour
		{
			get
			{
				return mColour;
			}
			set
			{
				//(value == null) this will fail for an empty string
				//(value == "") this will fail for a null value
				if(string.IsNullOrEmpty(value))
				{
					throw new Exception("Colour has no value");
				}
				else
				{
					mColour = value;
				}
			}
		}
		//another version of Sides using a private set and auto implemented property
		//in this version, you would need to code a method like SetSides()
		//public int Sides { get; private set; }

		//Auto implemented property
		//public
		//it has a data type
		//it has a name
		//IT DOES NOT HAVE AN INTERNAL DATA MEMBER THAT YOU CAN DIRECTLY ACCESS
		
		//the system will create, internally, a data storage of the appropriate
		// data type and manage the area
		//the only way to access the data of the an auto-implemented property is via
		// the property
		
		//usually used when there is no need for any internal validation or other 
		// property logic
		public int FaceValue { get; private set; }


		//constructor
		//optional; if not supplied, the system default constructor
		// is used which will assign a value to each data member/auto 
		// implemented property according to its data type
		
		//you can have any number of constructors within your class
		// as soon as you code a constructor, your program is responsible 
		// for all constructors

		//Syntax: public classname([list of parameters]){code stuff}
		//typical constructors
		//	default constructor
		//  this is similar to the system default constructor
		public Die ()
		{
			//you could leave this constructor empty and the system would
			// assign the normal default values to your data members and
			// auto implemented properties
			//you can directly access a private data member anywhere within
			// your class
			mSides = 6;

			//you can access any property anywhere within your class
			mColour = "White";

			//you can use a class method to generate a value for 
			// a data member/ auto property
			Roll();
		}

		//Greedy Constructor
		//typically has a parameter for each data memnber and 
		// auto implemented property within your class
		// parameter order is not important
		//this constructor allows the outside user to create and assign
		// their own values to the data members/auto properties at the time
		// of instance creation
		public Die (int sides, string colour)
		{
			//since this data is coming from an outside source, it is best
			// to use your property to save the values; especially if
			// the property has validation
			Sides = sides;
			Colour = colour;
			Roll();
		}

		//behaviours (methods)
		//These are actions that the class can perform
		// the actions may or may not alter data members/auto
		// implemented property values
		//the actions could simply take a value(s) from the user
		// and perform some logical operations against the values

		//Methods can be public or private
		// create a method that allows a user to change the number of 
		// sides on a die
		public void SetSides(int sides)
		{
			if(sides >= 6 && sides <= 20)
			{
				Sides = sides;
			}
			else
			{
				//optionally:
				//a) throw a new exception
				throw new Exception("Invalid value for die sides");
				//b) set mSides to a default value
				//Sides = 6;
			}
			Roll();
		}

		public void Roll()
		{
			//no parameters are required for this method since it will be using
			// the internal data values to complete its functionality

			//randomly generate a value for the die depending on the maximum sides
			FaceValue = mRandom.Next(1, Sides + 1);
		}
	}
}
