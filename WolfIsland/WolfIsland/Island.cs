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

		public int[,] FieldArray = new int[height,width];

		public void PutRabbit(int x, int y, List<Rabbit> rList)
		{
			if (FieldArray[x, y] == 2)
			{
				DeleteWolf(x, y, Form1.wList);
				FieldArray[x, y] = 1;
				rList.Add(new Rabbit(x, y));
			}
			else if (FieldArray[x, y] == 0)
			{
				FieldArray[x, y] = 1;
				rList.Add(new Rabbit(x, y));
			}
		}

		public void PutWolf(int x, int y, List<Wolf> wList)
		{
			if (FieldArray[x, y] == 1)
			{
				DeleteRabbit(x, y, Form1.rList);
				FieldArray[x, y] = 2;
				wList.Add(new Wolf(x, y));
			}
			else if (FieldArray[x, y] == 0)
			{
				FieldArray[x, y] = 2;
				wList.Add(new Wolf(x, y));
			}
		}

		public void DeleteRabbit(int x, int y, List<Rabbit> rList)
		{
			int index = rList.FindIndex((r) => r.x == x && r.y == y);
			rList.RemoveAt(index);
		}

		public void DeleteWolf(int x, int y, List<Wolf> wList)
		{
			int index = wList.FindIndex((w) => w.x == x && w.y == y);
			wList.RemoveAt(index);
		}
		public void FindFreeCell()
		{

		}

		private void GetNearbyCells()
		{

		}

		public void Clear()
		{
			for(int i = 0; i<height; i++)
				for (int j = 0; j<width; j++)
				{
					FieldArray[i, j] = 0;
				}
		}

		public void  FillIsland(int rabbits, int wolfs, List<Rabbit> rList, List<Wolf> wList)
		{
			Random rand = new Random();
			while(rabbits>0)
			{
				int x = rand.Next(height);
				int y = rand.Next(width);
				if (FieldArray[x, y] == 0)
				{
					PutRabbit(x, y, rList);
					rabbits--;
				}
			}
			while (wolfs>0)
			{
				int x = rand.Next(height);
				int y = rand.Next(width);
				if (FieldArray[x, y] == 0)
				{
					PutWolf(x, y, wList);
					wolfs--;
				}
			}
		}
	}
}
