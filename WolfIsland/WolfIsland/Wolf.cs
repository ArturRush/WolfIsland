namespace WolfIsland
{
	/// <summary>
	/// Класс отвечающий за действия волков
	/// </summary>
	public class Wolf
	{
		/// <summary>
		/// Величина, обратная шансу размножения
		/// </summary>
		public static int Chance = 20;
		/// <summary>
		/// Позиция по вертикали
		/// </summary>
		public int X;
		/// <summary>
		/// Позиция по горизонтали
		/// </summary>
		public int Y;
		/// <summary>
		/// Начальное здоровье волка
		/// </summary>
		public int health = 10;
		/// <summary>
		/// Поедание кролика с указанным индексом
		/// </summary>
		/// <param name="index">Индекс кролика</param>
		public void EatRabbit(int index)
		{
			health += 10;
			X = MainWindow.RList[index].X;
			Y = MainWindow.RList[index].Y;
			MainWindow.RList[index].KillRabbit(index);
		}
		/// <summary>
		/// Рождение волка в указанной позиции
		/// </summary>
		/// <param name="freeCell">Массив с координатами позиции</param>
		public void BornWolf(int[] freeCell)
		{
			if(freeCell[0] >-1)
			{
				MainWindow.WList.Add(new Wolf(freeCell[0], freeCell[1]));
			}
		}
		/// <summary>
		/// Уменьшает здоровье волка, убивает если здоровья не осталось
		/// </summary>
		public void ReduceHealth()
		{
			health--;
			if (health == 0)
				KillWolf();
		}
		/// <summary>
		/// Убивает данного волка
		/// </summary>
		public void KillWolf()
		{
			int index = MainWindow.WList.FindIndex(w => w.X==X && w.Y == Y);
			MainWindow.WList.RemoveAt(index);
		}
		/// <summary>
		/// Убивает волка с указанным в списке индексом
		/// </summary>
		/// <param name="index">Индекс</param>
		public void KillWolf(int index)
		{
			MainWindow.WList.RemoveAt(index);
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
