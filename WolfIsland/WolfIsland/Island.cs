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

		public int[,] FieldArray = new int[height, width];

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
			for (int i = 0; i < GetNearbyCells(x, y).Count(); i++)
			{
				if (FieldArray[GetNearbyCells(x, y)[i][0], GetNearbyCells(x, y)[i][1]] == 0)
					return GetNearbyCells(x, y)[i];
			}
			return new int[] { -1 };
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
			for (int i = 0; i < height; i++)
				for (int j = 0; j < width; j++)
				{
					FieldArray[i, j] = 0;
				}
		}

		public void UpdateField()
		{
			MoveAnimals();
			Clear();
			foreach (Rabbit r in Form1.rList)
				FieldArray[r.x,r.y] = 1;
			foreach (Wolf w in Form1.wList)
				FieldArray[w.x, w.y] = 2;
		}

		public void MoveAnimals()
		{
			Random rand = new Random();
			for (int i = 0; i < Form1.rList.Count; i++)
			{
				int Born = rand.Next(Form1.rList[i].chance);
				if (Born == 0)
					Form1.rList[i].BornRabbit(FindFreeCell(Form1.rList[i].x, Form1.rList[i].y));
				int current = rand.Next(9);
				switch (current)
				{
					case 1:
						{
							if (isFree(Form1.rList[i].x - 1, Form1.rList[i].y - 1))
								Form1.rList[i].NextStep(Form1.rList[i].x - 1, Form1.rList[i].y - 1);
						} break;
					case 2:
						{
							if (isFree(Form1.rList[i].x - 1, Form1.rList[i].y))
								Form1.rList[i].NextStep(Form1.rList[i].x - 1, Form1.rList[i].y);
						} break;
					case 3:
						{
							if (isFree(Form1.rList[i].x - 1, Form1.rList[i].y + 1))
								Form1.rList[i].NextStep(Form1.rList[i].x - 1, Form1.rList[i].y + 1);
						} break;
					case 4:
						{
							if (isFree(Form1.rList[i].x, Form1.rList[i].y + 1))
								Form1.rList[i].NextStep(Form1.rList[i].x, Form1.rList[i].y + 1);
						} break;
					case 5:
						{
							if (isFree(Form1.rList[i].x + 1, Form1.rList[i].y + 1))
								Form1.rList[i].NextStep(Form1.rList[i].x + 1, Form1.rList[i].y + 1);
						} break;
					case 6:
						{
							if (isFree(Form1.rList[i].x + 1, Form1.rList[i].y))
								Form1.rList[i].NextStep(Form1.rList[i].x + 1, Form1.rList[i].y);
						} break;
					case 7:
						{
							if (isFree(Form1.rList[i].x + 1, Form1.rList[i].y - 1))
								Form1.rList[i].NextStep(Form1.rList[i].x + 1, Form1.rList[i].y - 1);
						} break;
					case 8:
						{
							if (isFree(Form1.rList[i].x, Form1.rList[i].y - 1))
								Form1.rList[i].NextStep(Form1.rList[i].x, Form1.rList[i].y - 1);
						} break;
				}
			}
			for (int i = 0; i < Form1.wList.Count; i++ )
			{
				Form1.wList[i].ReduceHealth();
				if (i >= Form1.wList.Count)
					break;
				int Born = rand.Next(Form1.wList[i].chance);
				if (Born == 0)
					Form1.wList[i].BornWolf(FindFreeCell(Form1.wList[i].x, Form1.wList[i].y));
				if (isRabbitsHere(Form1.wList[i].x, Form1.wList[i].y)[0] > -1)
				{
					int rx = isRabbitsHere(Form1.wList[i].x, Form1.wList[i].y)[0];
					int ry = isRabbitsHere(Form1.wList[i].x, Form1.wList[i].y)[1];
					int index = Form1.rList.FindIndex((r) => r.x == rx && r.y == ry);
					if (index >= 0)
						Form1.wList[i].EatRabbit(index);
				}
				else
				{
					int current = rand.Next(9);
					switch (current)
					{
						case 1:
							{
								if (isFree(Form1.wList[i].x - 1, Form1.wList[i].y - 1))
									Form1.wList[i].NextStep(Form1.wList[i].x - 1, Form1.wList[i].y - 1);
							} break;
						case 2:
							{
								if (isFree(Form1.wList[i].x - 1, Form1.wList[i].y))
									Form1.wList[i].NextStep(Form1.wList[i].x - 1, Form1.wList[i].y);
							} break;
						case 3:
							{
								if (isFree(Form1.wList[i].x - 1, Form1.wList[i].y + 1))
									Form1.wList[i].NextStep(Form1.wList[i].x - 1, Form1.wList[i].y + 1);
							} break;
						case 4:
							{
								if (isFree(Form1.wList[i].x, Form1.wList[i].y + 1))
									Form1.wList[i].NextStep(Form1.wList[i].x, Form1.wList[i].y + 1);
							} break;
						case 5:
							{
								if (isFree(Form1.wList[i].x + 1, Form1.wList[i].y + 1))
									Form1.wList[i].NextStep(Form1.wList[i].x + 1, Form1.wList[i].y + 1);
							} break;
						case 6:
							{
								if (isFree(Form1.wList[i].x + 1, Form1.wList[i].y))
									Form1.wList[i].NextStep(Form1.wList[i].x + 1, Form1.wList[i].y);
							} break;
						case 7:
							{
								if (isFree(Form1.wList[i].x + 1, Form1.wList[i].y - 1))
									Form1.wList[i].NextStep(Form1.wList[i].x + 1, Form1.wList[i].y - 1);
							} break;
						case 8:
							{
								if (isFree(Form1.wList[i].x, Form1.wList[i].y - 1))
									Form1.wList[i].NextStep(Form1.wList[i].x, Form1.wList[i].y - 1);
							} break;
					}
				}
			}
		}

		public int[] isRabbitsHere(int x, int y)
		{
			List<int[]> NearCells = GetNearbyCells(x, y);
			for (int i = 0; i < NearCells.Count(); i++)
			{
				if (FieldArray[NearCells[i][0], NearCells[i][1]] == 1)
					return NearCells[i];
			}
			return new int[] { -1 };
		}

		public bool isFree(int x, int y)
		{
			if (x >= 0 && x < height && y >= 0 && y < width)
				if (FieldArray[x, y] == 0)
					return true;
			return false;
		}

		public void FillIsland(int rabbits, int wolfs, List<Rabbit> rList, List<Wolf> wList)
		{
			Random rand = new Random();
			while (rabbits > 0)
			{
				int x = rand.Next(height);
				int y = rand.Next(width);
				if (FieldArray[x, y] == 0)
				{
					PutRabbit(x, y, rList);
					rabbits--;
				}
			}
			while (wolfs > 0)
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
