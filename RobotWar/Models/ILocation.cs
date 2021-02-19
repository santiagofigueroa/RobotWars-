using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Models
{
	public interface ILocation
	{
		 Tuple<int, int> getLocation();
		 int getHeading(char key);

	}
}
