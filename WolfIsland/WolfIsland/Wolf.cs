namespace WolfIsland
{
	public class Wolf
	{
		public static int Chance = 20;
		private int health = 10;
		public int X;
		public int Y;
		public void EatRabbit(int index)
		{
			health += 10;
			X = Form1.RList[index].X;
			Y = Form1.RList[index].Y;
			Form1.RList[index].KillRabbit(index);
		}

		public void BornWolf(int[] freeCell)
		{
			if(freeCell[0] >-1)
			{
				Form1.WList.Add(new Wolf(freeCell[0], freeCell[1]));
			}
		}

		public void ReduceHealth()
		{
			if (health == 0)
				KillWolf();
			else
				health--;
		}

		public void KillWolf()
		{
			int index = Form1.WList.FindIndex(w => w.X==X && w.Y == Y);
			Form1.WList.RemoveAt(index);
		}

		public void KillWolf(int index)
		{
			Form1.WList.RemoveAt(index);
		}

		public void NextStep(int x, int y)
		{
			X = x;
			Y = y;
		}

		//public Wolf()
		//{
		//	chance = 20;
		//}
		
		public Wolf(int x, int y)
		{
		//	chance = 20;
			X = x;
			Y = y;
		}
	}
}
