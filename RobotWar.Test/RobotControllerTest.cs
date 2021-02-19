using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWar.Controllers;
using RobotWar.Data;
using RobotWar.Model;
using RobotWar.Models;
using Moq;



namespace RobotWar.Test
{
	public class RobotControllerTest
	{
		

		[TestMethod]
		public void RobotControllerCommands()
		{
			
			var _repository =  new Mock<IRepository>();
			var robotController = new RobotController(
				_repository.Object
				);


			var data = new MockRobotInstructions();

			var result = data.getRobotInstructions("r1");

			 _repository.Verify(r => r.getRobotInstructions("r2"));	
			
			Assert.IsNotNull(result);

		}

	}
}
