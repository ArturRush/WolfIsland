using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
	public class Wolf : Animal
	{
		private int health = 10;
		public void EatRabbit()
		{
			
		}

		public void ReduceHealth()
		{
			if (this.health == 0)
				KillAnimal();
			else
				this.health--;
		}

		public Wolf()
		{
			chance = 20;
		}
		
		public Wolf(int x, int y)
		{
			chance = 20;
			this.x = x;
			this.y = y;
		}
	}
}
