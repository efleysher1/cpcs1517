using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
	public class Turn
	{
		//data members
		//store results for both players
		//access the die class?
		private int mPlayerOne;
		private int mPlayerTwo;
		private string Winner;

		//constructor(s)
		public Turn()
		{
		}

		public Turn(int playerOne, int playerTwo)
		{
			PlayerOneRoll = playerOne;
			PlayerTwoRoll = playerTwo;
		}

		//properties
		public int PlayerOneRoll
		{
			get { return mPlayerOne; }
			set
			{
				mPlayerOne = value;
			}
		}

		public int PlayerTwoRoll
		{
			get { return mPlayerTwo; }
			set
			{
				mPlayerTwo = value;
			}
		}

		public int PlayerTwo { get; set; }
		//methods?
		//FindRollResults()
		//{ return null;
		//}

	}
}
