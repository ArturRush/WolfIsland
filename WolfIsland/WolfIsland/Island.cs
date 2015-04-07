using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
	public class Island
	{
		public static int height = 20;
		public static int width = 20;

		private int[,] FieldArray = new int[height,width];

		public void PutAnimal()
		{

		}

		public void DeleteAnimal()
		{

		}

		public void FindFreeCell()
		{

		}

		private void GetNearbyCells()
		{

		}

		public Island(int rabbits, int wolfs, List<Rabbit> rList, List<Wolf> wList)
		{
			Random rand = new Random();
			while(rabbits>0)
			{
				int x = rand.Next(height);
				int y = rand.Next(width);
				if (FieldArray[x, y] == 0)
				{
					FieldArray[x, y] = 1;
					rList.Add(new Rabbit(x,y));
					rabbits--;
				}
			}
			while (wolfs>0)
			{
				int x = rand.Next(height);
				int y = rand.Next(width);
				if (FieldArray[x, y] == 0)
				{
					FieldArray[x, y] = 2;
					wList.Add(new Wolf(x,y));
					wolfs--;
				}
			}
		}
	}
}
