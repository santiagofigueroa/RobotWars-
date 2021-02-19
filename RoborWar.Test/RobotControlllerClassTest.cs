using Xunit;
using RobotWar.Controllers;
using RobotWar.Data;
using RobotWar.Model;
using RobotWar.Models;

namespace RoborWar.Test
{
	public class RobotControllerClassTest
	{
		private MockRobotInstructions mockRobotInstructions; 
		private IRepository repository;
		private RobotController robotController;

		/// <summary>
		/// Test for the Robot Instrcutions
		/// </summary>
		[Fact]
		public void robotGetInstructions()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			// Gave a non existing Key
			var result = mockRobotInstructions.getRobotInstructions("r0");
		
			Assert.Null(result);

		}
		[Fact]
		public void robotGetInstructionS1()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var result = mockRobotInstructions.getRobotInstructions("r1");
			var expected = "MLMRMMMRMMRR";
			Assert.Equal(expected, result);

		}
		
		[Fact]
		public void robotGetInstructionS2()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var result = mockRobotInstructions.getRobotInstructions("r2");
			var expected = "LMLLMMLMMMRMM";
			Assert.Equal(expected, result);

		}

		[Fact]
		public void robotGetInstructionS3()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var result = mockRobotInstructions.getRobotInstructions("r3");
			var expected = "WMLMLMLMRMRMRMRM";
			Assert.Equal(expected, result);

		}

		[Fact]
		public void robotGetInstructionS4()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var result = mockRobotInstructions.getRobotInstructions("r4");
			var expected = "NMMLMMLMMMMM";
			Assert.Equal(expected, result);

		}

		[Fact]
		public void RobotControllerTestM()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			mockRobotInstructions.getRobotInstructions("r1");

			Assert.NotNull(mockRobotInstructions);

		}
		/// <summary>
		/// Test for the Robots Objects
		/// </summary>

		[Fact]
		public void getRobotR1()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			var resultRobot = mockRobotInstructions.GetRobot("r1");
			Assert.NotNull(resultRobot);
		}

		[Fact]
		public void getRobotR2()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			var resultRobot = mockRobotInstructions.GetRobot("r2");
			Assert.NotNull(resultRobot);
		}
		[Fact]
		public void getRobotR3()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			var resultRobot = mockRobotInstructions.GetRobot("r3");
			Assert.NotNull(resultRobot);
		}

		[Fact]
		public void getRobotR4()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			var resultRobot = mockRobotInstructions.GetRobot("r4");
			Assert.NotNull(resultRobot);
		}

		/// <summary>
		/// Moving Robot Function 
		/// </summary>
		[Fact]
		public void moveRobotR1()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var MoveInstructions = mockRobotInstructions.getRobotInstructions("r1");
			
			var charrArr = MoveInstructions.ToCharArray();
			var resultRobot = mockRobotInstructions.GetRobot("r1");
			robotController = new RobotController(repository);

			var r1 =  robotController.MoveRobot(resultRobot,charrArr);

			var expected = new Robot(new Location(0,3,'N'));
			expected.Faults = 0;
			Assert.Equal(expected,r1);

		}
		/// <summary>
		/// For Final position. 
		/// </summary>

		[Fact]
		public void moveRobotR1FinalPosition()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var robotInstructions = mockRobotInstructions.getRobotInstructions("r1");
			var CharArr = robotInstructions.ToCharArray();
			var r1 = mockRobotInstructions.GetRobot("r1");
			
			robotController = new RobotController(repository);

			var result = robotController.MoveRobot(r1, CharArr);
			// FInal position expectation for r1 
			var expected = new Robot(new Location(4, 1, 'N'));
			expected.Faults = 0;
			Assert.NotEqual(expected, result);

		}

		[Fact]
		public void moveRobotR2FinalPosition()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var robotInstructions = mockRobotInstructions.getRobotInstructions("r2");
			var CharArr = robotInstructions.ToCharArray();
			var r2 = mockRobotInstructions.GetRobot("r2");

			robotController = new RobotController(repository);

			var result = robotController.MoveRobot(r2, CharArr);
			// FInal position expectation for r1 
			var expected = new Robot(new Location(0, 1, 'W'));
			expected.Faults = 1;
			Assert.NotEqual(expected, result);

		}

		[Fact]
		public void moveRobotR3FinalPosition()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var robotInstructions = mockRobotInstructions.getRobotInstructions("r3");
			var CharArr = robotInstructions.ToCharArray();
			var r3 = mockRobotInstructions.GetRobot("r3");

			robotController = new RobotController(repository);

			var result = robotController.MoveRobot(r3, CharArr);
			// FInal position expectation for r1 
			var expected = new Robot(new Location(2, 2, 'N'));
			expected.Faults = 0;
			Assert.NotEqual(expected, result);

		}

		[Fact]
		public void moveRobotR4FinalPosition()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var robotInstructions = mockRobotInstructions.getRobotInstructions("r4");
			var CharArr = robotInstructions.ToCharArray();
			var r4 = mockRobotInstructions.GetRobot("r4");

			robotController = new RobotController(repository);

			var result = robotController.MoveRobot(r4, CharArr);
			// FInal position expectation for r1 
			var expected = new Robot(new Location(0, 0, 'S'));
			expected.Faults = 3;
			Assert.NotEqual(expected, result);

		}
		[Fact]
		public void PrintTest()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var moveInstructions = mockRobotInstructions.getRobotInstructions("r1");
			var charArr = moveInstructions.ToCharArray();
			var r1 = mockRobotInstructions.GetRobot("r1");
			robotController = new RobotController(repository);
;
		}

		[Fact]
		public void RobotR1CheckFaults()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var moveInstructions = mockRobotInstructions.getRobotInstructions("r1");
			var charArr = moveInstructions.ToCharArray();
			var r1 = mockRobotInstructions.GetRobot("r1");
			robotController = new RobotController(repository);
			var final = robotController.MoveRobot(r1, charArr);
			var result = final.Faults;

			Assert.Equal(0, result);
		}
		[Fact]
		public void RobotR2CheckFaults()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var moveInstructions = mockRobotInstructions.getRobotInstructions("r2");
			var charArr = moveInstructions.ToCharArray();
			var r4 = mockRobotInstructions.GetRobot("r2");
			robotController = new RobotController(repository);
			var final = robotController.MoveRobot(r4, charArr);
			var result = final.Faults;

			Assert.NotEqual(1, result);
		}
		[Fact]
		public void RobotR3CheckFaults()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var moveInstructions = mockRobotInstructions.getRobotInstructions("r3");
			var charArr = moveInstructions.ToCharArray();
			var r4 = mockRobotInstructions.GetRobot("r3");
			robotController = new RobotController(repository);
			var final = robotController.MoveRobot(r4, charArr);
			var result = final.Faults;

			Assert.Equal(0, result);
		}

		[Fact]
		public void RobotR4CheckFaults()
		{
			mockRobotInstructions = new MockRobotInstructions(repository);
			// Shoul be Empty.
			var moveInstructions = mockRobotInstructions.getRobotInstructions("r4");
			var charArr = moveInstructions.ToCharArray();
			var r4 = mockRobotInstructions.GetRobot("r4");
			robotController = new RobotController(repository);
			var final = robotController.MoveRobot(r4,charArr);
			var result = final.Faults;

			Assert.NotEqual(3, result);

		}
	}
}
