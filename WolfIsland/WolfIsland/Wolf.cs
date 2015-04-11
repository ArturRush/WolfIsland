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
		public void EatRabbit(Rabbit r)
		{
			this.health += 10;
			r.KillRabbit();
		}

		public void BornWolf()
		{

		}

		public void ReduceHealth(int index)
		{
			if (this.health == 0)
				this.KillWolf(index);
			else
				this.health--;
		}

		public void KillWolf()
		{
			int index = Form1.wList.FindIndex((w) => w.x==this.x && w.y == this.y);
			Form1.wList.RemoveAt(index);
		}

		public void KillWolf(int index)
		{
			Form1.wList.RemoveAt(index);
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
