using System;
using System.Collections.Generic;
using System.Linq;

namespace WolfIsland
{
	/// <summary>
	/// Класс, отвечающий за внутриигровые действия
	/// </summary>
	public class Island
	{

		/// <summary>
		/// Высота игрового поля
		/// </summary>
		public static int Height = 20;
		/// <summary>
		/// Ширина игрового поля
		/// </summary>
		public static int Width = 20;
		/// <summary>
		/// Массив игрового поля
		/// </summary>
		public int[,] FieldArray = new int[Height, Width];

		/// <summary>
		/// Устанавливает в заданную клетку кролика
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <param name="rList">Список кроликов, в который добавляется новый</param>
		public void PutRabbit(int x, int y, List<Rabbit> rList)
		{
			if (FieldArray[x, y] == 2)
			{
				DeleteWolf(x, y, MainWindow.WList);
				FieldArray[x, y] = 1;
				rList.Add(new Rabbit(x, y));
			}
			else if (FieldArray[x, y] == 0)
			{
				FieldArray[x, y] = 1;
				rList.Add(new Rabbit(x, y));
			}
		}

		/// <summary>
		/// Устанавливает в заданную клетку волка
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <param name="wList">Список волков, в который добавляется новый</param>
		public void PutWolf(int x, int y, List<Wolf> wList)
		{
			if (FieldArray[x, y] == 1)
			{
				DeleteRabbit(x, y, MainWindow.RList);
				FieldArray[x, y] = 2;
				wList.Add(new Wolf(x, y));
			}
			else if (FieldArray[x, y] == 0)
			{
				FieldArray[x, y] = 2;
				wList.Add(new Wolf(x, y));
			}
		}

		/// <summary>
		/// Удаляет кролика с указанной позиции
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <param name="rList">Список, из которого удаляется кролик</param>
		public void DeleteRabbit(int x, int y, List<Rabbit> rList)
		{
			int index = rList.FindIndex(r => r.X == x && r.Y == y);
			rList.RemoveAt(index);
		}

		/// <summary>
		/// Удаляет волка с указанной позиции
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <param name="wList">Список, из которого удаляется волк</param>
		public void DeleteWolf(int x, int y, List<Wolf> wList)
		{
			int index = wList.FindIndex(w => w.X == x && w.Y == y);
			wList.RemoveAt(index);
		}

		/// <summary>
		/// Находит свободную клетку рядом с указанной
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <returns>Массив с координатами свободной клетки</returns>
		public int[] FindFreeCell(int x, int y)
		{
			for (int i = 0; i < GetNearbyCells(x, y).Count(); i++)
			{
				int[] freePos = GetNearbyCells(x, y)[i];
				if (FieldArray[freePos[0], freePos[1]] == 0)
					return freePos;
			}
			return new[] { -1, -1 };
		}

		/// <summary>
		/// Находит все соседние клетки рядом с указанной
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <returns>Список массивов с координатами соседних клеток</returns>
		private List<int[]> GetNearbyCells(int x, int y)
		{
			List<int[]> cellsList = new List<int[]>();
			if (x > 0 && y > 0)
				cellsList.Add(new[] { x - 1, y - 1 });
			if (x > 0)
				cellsList.Add(new[] { x - 1, y });
			if (x > 0 && y + 1 < Width)
				cellsList.Add(new[] { x - 1, y + 1 });
			if (y + 1 < Width)
				cellsList.Add(new[] { x, y + 1 });
			if (x + 1 < Height && y + 1 < Width)
				cellsList.Add(new[] { x + 1, y + 1 });
			if (x + 1 < Height)
				cellsList.Add(new[] { x + 1, y });
			if (x + 1 < Height && y > 0)
				cellsList.Add(new[] { x + 1, y - 1 });
			if (y > 0)
				cellsList.Add(new[] { x, y - 1 });
			return cellsList;
		}

		/// <summary>
		/// Очищает игровое поле
		/// </summary>
		public void ClearField()
		{
			for (int i = 0; i < Height; i++)
				for (int j = 0; j < Width; j++)
				{
					FieldArray[i, j] = 0;
				}
		}

		/// <summary>
		/// Обновляет информацию о позициях животных на игровом поле
		/// </summary>
		public void UpdateField()
		{
			ClearField();
			foreach (Rabbit r in MainWindow.RList)
				FieldArray[r.X, r.Y] = 1;
			foreach (Wolf w in MainWindow.WList)
				FieldArray[w.X, w.Y] = 2;
		}

		/// <summary>
		/// Движение животных
		/// </summary>
		public void MoveAnimals()
		{
			Random rand = new Random();
			for (int i = 0; i < MainWindow.RList.Count; i++)
			{
				int born = rand.Next(Rabbit.Chance);
				if (born == 0)
				{
					int[] freePos = FindFreeCell(MainWindow.RList[i].X, MainWindow.RList[i].Y);
					if (freePos[0] > -1 && freePos[1] > -1)
					{
						MainWindow.RList[i].BornRabbit(freePos);
						FieldArray[freePos[0], freePos[1]] = 1;
					}
				}
				int current = rand.Next(9);
				switch (current)
				{
					case 1:
						{
							if (IsFree(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y - 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y - 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 2:
						{
							if (IsFree(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 3:
						{
							if (IsFree(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y + 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X - 1, MainWindow.RList[i].Y + 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 4:
						{
							if (IsFree(MainWindow.RList[i].X, MainWindow.RList[i].Y + 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X, MainWindow.RList[i].Y + 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 5:
						{
							if (IsFree(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y + 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y + 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 6:
						{
							if (IsFree(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 7:
						{
							if (IsFree(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y - 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X + 1, MainWindow.RList[i].Y - 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
					case 8:
						{
							if (IsFree(MainWindow.RList[i].X, MainWindow.RList[i].Y - 1))
							{
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 0;
								MainWindow.RList[i].NextStep(MainWindow.RList[i].X, MainWindow.RList[i].Y - 1);
								FieldArray[MainWindow.RList[i].X, MainWindow.RList[i].Y] = 1;
							}
						} break;
				}
			}
			UpdateField();
			for (int i = 0; i < MainWindow.WList.Count; i++)
			{
				if (MainWindow.WList[i].health == 1)
					FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
				MainWindow.WList[i].ReduceHealth();
				if (i >= MainWindow.WList.Count)
					break;
				int born = rand.Next(Wolf.Chance);
				if (born == 0)
					MainWindow.WList[i].BornWolf(FindFreeCell(MainWindow.WList[i].X, MainWindow.WList[i].Y));
				int[] pos = IsRabbitsHere(MainWindow.WList[i].X, MainWindow.WList[i].Y);
				if (pos[0] > -1 && pos[1] > -1)
				{
					int index = MainWindow.RList.FindIndex(r => r.X == pos[0] && r.Y == pos[1]);
					FieldArray[pos[0], pos[1]] = 2;
					MainWindow.WList[i].EatRabbit(index);

				}
				else
				{
					int current = rand.Next(9);
					switch (current)
					{
						case 1:
							{
								if (IsFree(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y - 1))
								{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y - 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 2:
							{
								if (IsFree(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 3:
							{
								if (IsFree(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y + 1))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X - 1, MainWindow.WList[i].Y + 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 4:
							{
								if (IsFree(MainWindow.WList[i].X, MainWindow.WList[i].Y + 1))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X, MainWindow.WList[i].Y + 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 5:
							{
								if (IsFree(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y + 1))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y + 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 6:
							{
								if (IsFree(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 7:
							{
								if (IsFree(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y - 1))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X + 1, MainWindow.WList[i].Y - 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
								}
							} break;
						case 8:
							{
								if (IsFree(MainWindow.WList[i].X, MainWindow.WList[i].Y - 1))
									{
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 0;
									MainWindow.WList[i].NextStep(MainWindow.WList[i].X, MainWindow.WList[i].Y - 1);
									FieldArray[MainWindow.WList[i].X, MainWindow.WList[i].Y] = 2;
									}
							} break;
					}
				}
			}
			UpdateField();
		}
		/// <summary>
		/// Ищет кролика на соседних от указанной клетках
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <returns>Координаты кролика, если найден, иначе {-1,-1}</returns>
		public int[] IsRabbitsHere(int x, int y)
		{
			List<int[]> nearCells = GetNearbyCells(x, y);
			for (int i = 0; i < nearCells.Count(); i++)
			{
				if (FieldArray[nearCells[i][0], nearCells[i][1]] == 1)
					return nearCells[i];
			}
			return new[] { -1, -1 };
		}
		/// <summary>
		/// Проверяет, свободна ли указанная клетка
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		/// <returns>True, если свободна, иначе false</returns>
		public bool IsFree(int x, int y)
		{
			if (x >= 0 && x < Height && y >= 0 && y < Width)
				if (FieldArray[x, y] == 0)
					return true;
			return false;
		}
		/// <summary>
		///	Ставит указанное количество кроликов и волков в случайные места, добавляет их в списки
		/// </summary>
		/// <param name="rabbits">Количество кроликов</param>
		/// <param name="wolfs">Количество волков</param>
		/// <param name="rList">Список кроликов</param>
		/// <param name="wList">Список волков</param>
		public void FillIsland(int rabbits, int wolfs, List<Rabbit> rList, List<Wolf> wList)
		{
			Random rand = new Random();
			while (rabbits > 0)
			{
				int x = rand.Next(Height);
				int y = rand.Next(Width);
				if (FieldArray[x, y] == 0)
				{
					PutRabbit(x, y, rList);
					rabbits--;
				}
			}
			while (wolfs > 0)
			{
				int x = rand.Next(Height);
				int y = rand.Next(Width);
				if (FieldArray[x, y] == 0)
				{
					PutWolf(x, y, wList);
					wolfs--;
				}
			}
		}
	}
}
