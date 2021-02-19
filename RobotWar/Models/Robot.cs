using RobotWar.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Models
{
	public class Robot 
	{
		public Location Rlocation;
		public int Faults {
			get; 
			set; 
		} 

		public Robot(Location location)
		{
			Rlocation = location;
			Faults = 0; 
		}

		public Location getCurrentLocation()
		{
			return	this.Rlocation;
		}


		public void setFault()
		{
			this.Faults++;	
		}
	}
}
