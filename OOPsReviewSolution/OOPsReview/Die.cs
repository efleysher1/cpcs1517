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
				//takes internal values and returns it to the user
				return mSize;
			}
			set
			{
				//takes the supplied user value and places it into
				//the internal private data member
				//the incomin piece of data is placed into a special 
				//variable that is called: value
				mSize = value;
			}
		}


		//constructor


		//behaviours (methods)
	}
}
