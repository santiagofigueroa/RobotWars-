using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RobotWar.Models;
using RobotWar.Data;
using RobotWar.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RobotWar.Controllers
{
	public class RobotController : Controller
	{
		protected readonly IRepository _repository;
		protected  MockRobotInstructions mockRobotInstructions;

		public RobotController(IRepository repository)
		{
			_repository = repository; 
		}


		public void robotInstruction(string key)
		{
			mockRobotInstructions = new MockRobotInstructions(_repository);
			//Get Instructions 
			char[] charInstructList = mockRobotInstructions
				.getRobotInstructions(key)
				.ToCharArray();
			// 

			// Get Robot plus initial values.
			Console.WriteLine(charInstructList);
			var robotInitial = mockRobotInstructions.GetRobot(key);
			// Move Robot function.  
			MoveRobot(robotInitial, charInstructList);

		}


		public  Robot MoveRobot(Robot robot,char[] instructions)
		{
			//For each move instrcution move robot
			List<Robot> robotList = new List<Robot>();

			foreach (var instruction in instructions)
			{
				
				switch (instruction)
				{
					// Case when moving left or right.
					case 'R':
					case 'L':
						var newLocation = MoveLeftRight(robot.Rlocation, instruction);
						robot.Rlocation = newLocation;
						break;
						
					// Case when moving forward.
					case 'M':
						var newLocationXY = Move(robot.Rlocation,robot.Rlocation.currentDirection);
						robot.Rlocation = CheckArenaLimits(robot,newLocationXY);
						break;
				}
				robotList.Add(robot);
	

			}
			Print(robotList);
			return robot;

		}


		private Location Move(Location currentLocation, int direction)
		{
			
			// Pointing North 
			if (direction == 0)
			{
				var newLocation = new Location(currentLocation.X + 1, currentLocation.Y - 1, 'N');
				return newLocation;
			}
			// Poiting East 
			else if (direction == 1)
			{
				var newLocation = new Location(currentLocation.X -1, currentLocation.Y + 1, 'E');
				return newLocation;
			}
			// Pointing South 
			else if (direction == 3)
			{
				var newLocation = new Location(currentLocation.X + 1, currentLocation.Y - 1, 'S');
				return newLocation;
			}
			// Poiting West
			else if (direction == 4)
			{
				var newLocation = new Location(currentLocation.X - 1, currentLocation.Y + 1,'W');
				return newLocation;
			}
			else
			{
				return currentLocation;

			}
	
			
		}

		public Location CheckArenaLimits(Robot robot,Location newLocation)
		{
			if ((Enumerable.Range(0, 4).Contains(newLocation.X)) &&
				(Enumerable.Range(0, 4).Contains(newLocation.Y)))
			{
				// Return thew new location given. 
				return newLocation;
			}
			else
			{
				// Add the fault do not change the location.
				robot.setFault();
				return robot.Rlocation;
			}

		}


		private Location MoveLeftRight(Location currentLocation, char instruction) 
		{
			var newLocation = currentLocation;
			// Pointing North 
			if (currentLocation.currentDirection == 0)
			{
				
				if (instruction == 'R')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'E');
				} 
				else if (instruction == 'L')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'W');
				}

			}
			// Poiting East 
			else if (currentLocation.currentDirection == 1)
			{
				if (instruction == 'R')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'S');
				}
				else if (instruction == 'L')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'N');
				}
			}
			// Pointing South 
			else if (currentLocation.currentDirection == 3)
			{
				if (instruction == 'R')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'W');

				}
				else if (instruction == 'L')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'E');
				}
			}
			// Poiting West
			else if (currentLocation.currentDirection == 4)
			{
				if (instruction == 'R')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'N');
				}
				else if (instruction == 'L')
				{
					newLocation = new Location(currentLocation.X, currentLocation.Y, 'S');
				}
			}

			return newLocation;
		}
		

		public void Print(List<Robot> robotList)
		{

			foreach (Robot robot in robotList)
			{
				Console.WriteLine("Robot: X " + robot.Rlocation.X + " Y: " + robot.Rlocation.Y + " Direction: " + robot.Rlocation.currentDirection + "");
			}
		}

	}
}
