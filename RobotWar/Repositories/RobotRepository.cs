using System;
using System.Collections.Generic;
using System.Text;
using RobotWar.Models;
using RobotWar.Data;
using RobotWar.Model;

namespace RobotWar.Repositories
{
	public class RobotRepository
	{
        private readonly IRepository _mockRobotInstructions;

		public RobotRepository(MockRobotInstructions mockRobotInstructions)
		{
			_mockRobotInstructions = mockRobotInstructions;
		}

		public Robot GetRobot(string key)
		{
			var robot = _mockRobotInstructions.GetRobot(key);
			return robot;

		}

		public string getRobotInstructions(string key)
		{
			string charInstructList = _mockRobotInstructions.getRobotInstructions(key);
			return charInstructList; 
		}
	}
}
