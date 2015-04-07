using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
	public class Rabbit : Animal
	{
		public Rabbit()
		{
			chance = 5;
		}

		public Rabbit(int x, int y)
		{
			chance = 5;
			this.x = x;
			this.y = y;
		}
	}
}
