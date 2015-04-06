using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
	class Wolf : Animal
	{
		private int health = 10;
		public void EatRabbit()
		{
			
		}

		public void WolfDeath()
		{

		}

		public void ReduceHealth()
		{
			if (this.health == 0)
				WolfDeath();
			else
				this.health--;
		}

		public Wolf()
		{
			chance = 20;
		}
	}
}
