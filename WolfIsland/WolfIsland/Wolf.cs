namespace WolfIsland
{
	public class Wolf
	{
		public static int Chance = 20;		//Величина, обратная шансу размножения
		private int health = 10;		//Начальное здоровье волка
		public int X;			//Позиция по вертикали
		public int Y;			//Позиция по горизонтали
		/// <summary>
		/// Поедание кролика с указанным индексом
		/// </summary>
		/// <param name="index">Индекс кролика</param>
		public void EatRabbit(int index)
		{
			health += 10;
			X = Form1.RList[index].X;
			Y = Form1.RList[index].Y;
			Form1.RList[index].KillRabbit(index);
		}
		/// <summary>
		/// Рождение волка в указанной позиции
		/// </summary>
		/// <param name="freeCell">Массив с координатами позиции</param>
		public void BornWolf(int[] freeCell)
		{
			if(freeCell[0] >-1)
			{
				Form1.WList.Add(new Wolf(freeCell[0], freeCell[1]));
			}
		}
		/// <summary>
		/// Уменьшает здоровье волка, убивает если здоровья не осталось
		/// </summary>
		public void ReduceHealth()
		{
			if (health == 0)
				KillWolf();
			else
				health--;
		}
		/// <summary>
		/// Убивает данного волка
		/// </summary>
		public void KillWolf()
		{
			int index = Form1.WList.FindIndex(w => w.X==X && w.Y == Y);
			Form1.WList.RemoveAt(index);
		}
		/// <summary>
		/// Убивает волка с указанным в списке индексом
		/// </summary>
		/// <param name="index">Индекс</param>
		public void KillWolf(int index)
		{
			Form1.WList.RemoveAt(index);
		}
		/// <summary>
		/// Перемещает волка на новые координаты
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		public void NextStep(int x, int y)
		{
			X = x;
			Y = y;
		}
		/// <summary>
		/// Конструктор с заданием начальных координат
		/// </summary>
		/// <param name="x">Позиция по вертикали</param>
		/// <param name="y">Позиция по горизонтали</param>
		public Wolf(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
