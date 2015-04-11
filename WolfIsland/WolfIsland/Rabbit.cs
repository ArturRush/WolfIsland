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

		public void BornRabbit()
		{

		}

		public void KillRabbit()
		{
			int index = Form1.rList.FindIndex((r) => r.x == this.x && r.y == this.y);
			Form1.rList.RemoveAt(index);
		}

		public void KillRabbit(int index)
		{
			Form1.rList.RemoveAt(index);
		}

		public Rabbit(int x, int y)
		{
			chance = 5;
			this.x = x;
			this.y = y;
		}
	}
}
