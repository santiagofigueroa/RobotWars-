using RobotWar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Model
{
	public class Location : ILocation
	{
		public int X { 
			get; 
			set; 
		}
		public int Y { 
			get; 
			set;
		}

		private Dictionary<char, int> heading
		{
			get;
			set;
		}

		public int currentDirection; 

		public Location(int x , int y, char direction)
		{
			X = x;
			Y = y;

			heading = new Dictionary<char, int>
			{
				{ 'N', 0 },
				{ 'E', 1 },
				{ 'S', 2 },
				{ 'W', 3 }
			};

			var tmpDirection = getHeading(direction);
			currentDirection = tmpDirection;
		}

		public Tuple<int, int> getLocation()
		{
			var location = Tuple.Create(X,Y);

			return location; 
		}
		//  When the command get comes from the Robot class we will be able. 
		//  to call in the value of the 
		public int  getHeading(char key)
		{
			heading.TryGetValue(key, out int value);
			return value;
		}
	}
}
