namespace WolfIsland
{
	public class Rabbit
	{
		public static int Chance = 5;
		public int X;
		public int Y;

		public void BornRabbit(int[] freeCell)
		{
				Form1.RList.Add(new Rabbit(freeCell[0], freeCell[1]));
		}

		public void KillRabbit()
		{
			int index = Form1.RList.FindIndex(r => r.X == X && r.Y == Y);
			Form1.RList.RemoveAt(index);
		}

		public void KillRabbit(int index)
		{
			Form1.RList.RemoveAt(index);
		}

		public void NextStep(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Rabbit(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
