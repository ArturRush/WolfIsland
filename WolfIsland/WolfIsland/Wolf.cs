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
		public void EatRabbit(int index)
		{
			this.health += 10;
			Form1.rList[index].KillRabbit(index);
		}

		public void BornWolf(int[] freeCell)
		{
			if(freeCell[0] >-1)
			{
				Form1.wList.Add(new Wolf(freeCell[0], freeCell[1]));
			}
		}

		public void ReduceHealth()
		{
			if (this.health == 0)
				this.KillWolf();
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

		public void NextStep(int x, int y)
		{
			this.x = x;
			this.y = y;
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
