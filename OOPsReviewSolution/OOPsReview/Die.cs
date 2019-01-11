using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
	public class Die
	{
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
		private int mSize;
		private string mColour;

		//properties
		//a property is an external interface between the user
		//and a single piece of data within the instance
		//a property has two abilities
		//1.the ability to assign a value to the internal
		// data member
		//2.return an internal data member value to the user

		//fully implemented property
		public int Size
		{
			get
			{
				//takes internal value and returns it to the user
				return mSize;
			}
			set
			{
				//takes the supplied user value and places it into
				//the internal private data member
				//the incomin piece of data is placed into a special 
				//variable that is called: value
				//optionally, you may place validation on the incoming
				//value
				if (value >= 6 && value <=20)
				{
					mSize = value;
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
		public int FaceValue { get; set; }


		//constructor


		//behaviours (methods)
	}
}
