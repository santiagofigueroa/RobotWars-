using System;
using System.Collections.Generic;


namespace RobotWar.Models
{
	public interface IRepository
	{
		string getRobotInstructions(string key);
		Robot GetRobot(string key);
		
	}
}
