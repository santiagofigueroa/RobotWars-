using System;
using System.Collections.Generic;
using System.Text;
using RobotWar.Models;

namespace RobotWar.Data
{
	public class  MockRobotInstructions : IRepository
	{

		public  Dictionary<string, string> instructions;
		public Dictionary<string, Robot> robotList; 

		public MockRobotInstructions(IRepository mockCurrencyService)
		{
			instructions = new Dictionary<string, string>();
			AddRobotInstructions();
			robotList =  new  Dictionary<string, Robot>();
			AddRobots();
	}

		public string getRobotInstructions(string key)
		{
			instructions.TryGetValue(key, out string value);
			return value;
		}


		private void AddRobotInstructions()
		{
			instructions = new Dictionary<string, string>
			{
				{ "r1", "MLMRMMMRMMRR" },
				{ "r2" ,"LMLLMMLMMMRMM" },
				{ "r3", "WMLMLMLMRMRMRMRM" },
				{ "r4", "NMMLMMLMMMMM"}

			};
		}

		private void AddRobots()
		{
			robotList = new Dictionary<string, Robot>
			{
				//  Initial values as shown in example. 
				{ "r1", new Robot(new Model.Location(0,2,'N'))},
				{ "r2" ,new Robot(new Model.Location(4,4,'S'))},
				{ "r3", new Robot(new Model.Location(2,2,'W'))},
				{ "r4", new Robot(new Model.Location(1,3,'N'))}

			};
		}

		public Robot GetRobot(string key)
		{
			robotList.TryGetValue(key, out Robot value);
			return value;
		}
	}
}
