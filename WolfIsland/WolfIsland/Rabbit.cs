namespace WolfIsland
{
	/// <summary>
	/// Класс, отвечающий за действия кроликов
	/// </summary>
	public class Rabbit
	{
		/// <summary>
		/// Величина, обратная шансу размножения
		/// </summary>
		public static int Chance = 5;		
		/// <summary>
		/// Позиция по вертикали
		/// </summary>
		public int X;			
		/// <summary>
		/// Позиция по горизонтали
		/// </summary>
		public int Y;			
		/// <summary>
		/// Рождение кролика в указанной позиции
		/// </summary>
		/// <param name="freeCell">Массив с координатами позиции</param>
		public void BornRabbit(int[] freeCell)
		{
				MainWindow.RList.Add(new Rabbit(freeCell[0], freeCell[1]));
		}
		/// <summary>
		/// Убивает данного кролика
		/// </summary>
		public void KillRabbit()
		{
			int index = MainWindow.RList.FindIndex(r => r.X == X && r.Y == Y);
			MainWindow.RList.RemoveAt(index);
		}
		/// <summary>
		/// Убивает кролика с указанным в списке индексом
		/// </summary>
		/// <param name="index">Индекс</param>
		public void KillRabbit(int index)
		{
			MainWindow.RList.RemoveAt(index);
		}
		/// <summary>
		/// Перемещает кролика на новые координаты
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
		public Rabbit(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
