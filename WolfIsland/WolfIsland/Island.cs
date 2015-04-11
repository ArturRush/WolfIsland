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

		public int[] FindFreeCell(int x, int y)
		{
			for (int i = 0; i< GetNearbyCells(x,y).Count(); i++)
			{
				if (FieldArray[GetNearbyCells(x, y)[i][0], GetNearbyCells(x, y)[i][1]] == 0)
					return new int[] { GetNearbyCells(x, y)[i][0], GetNearbyCells(x, y)[i][1] };
			}
			return new int[] { -1};
		}

		private List<int[]> GetNearbyCells(int x, int y)
		{
			List<int[]> CellsList = new List<int[]>();
			if (x > 0 && y > 0)
				CellsList.Add(new int[] { x - 1, y - 1 });
			if (x > 0)
				CellsList.Add(new int[] { x - 1, y });
			if (x > 0 && y + 1 < width)
				CellsList.Add(new int[] { x - 1, y + 1 });
			if (y + 1 < width)
				CellsList.Add(new int[] { x, y + 1 });
			if (x + 1 < height && y + 1 < width)
				CellsList.Add(new int[] { x + 1, y + 1 });
			if (x + 1 < height)
				CellsList.Add(new int[] { x + 1, y });
			if (x + 1 < height && y > 0)
				CellsList.Add(new int[] { x + 1, y - 1 });
			if (y > 0)
				CellsList.Add(new int[] { x, y - 1 });
			return CellsList;
		}

		public void Clear()
		{
			for(int i = 0; i<height; i++)
				for (int j = 0; j<width; j++)
				{
					FieldArray[i, j] = 0;
				}
		}

		public void MoveAnimals()
		{
			Random rand = new Random();
			foreach (Rabbit r in Form1.rList)
			{
				int Born = rand.Next(r.chance);
				if (Born == 0)
					r.BornRabbit();
				int current = rand.Next(9);
				switch (current)
				{
					case 1:
						{
							if (isFree(r.x - 1, r.y - 1))
								r.NextStep(r.x - 1, r.y - 1);
						}break;
					case 2:
						{
							if (isFree(r.x - 1, r.y))
								r.NextStep(r.x - 1, r.y);
						} break;
					case 3:
						{
							if (isFree(r.x - 1, r.y + 1))
								r.NextStep(r.x - 1, r.y + 1);
						} break;
					case 4:
						{
							if (isFree(r.x, r.y + 1))
								r.NextStep(r.x, r.y + 1);
						} break;
					case 5:
						{
							if (isFree(r.x + 1, r.y + 1))
								r.NextStep(r.x + 1, r.y + 1);
						} break;
					case 6:
						{
							if (isFree(r.x + 1, r.y))
								r.NextStep(r.x + 1, r.y);
						} break;
					case 7:
						{
							if (isFree(r.x + 1, r.y - 1))
								r.NextStep(r.x + 1, r.y - 1);
						} break;
					case 8:
						{
							if (isFree(r.x, r.y - 1))
								r.NextStep(r.x, r.y - 1);
						} break;
				}
			}
		}

		public bool isFree(int x, int y)
		{
			if (x >= 0 && x < height && y >= 0 && y < width)
				if (FieldArray[x, y] == 0)
					return true;
			return false;
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
