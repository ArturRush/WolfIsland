using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfIsland
{
	class Island
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

		public void FillField(int r, int w)
		{
			Random rand = new Random();
			while(r>0)
			{
				int a = rand.Next(height);
				int b = rand.Next(width);
				//if (FieldArray[a,b] == 0)
					//List
			}
			while (w>0)
			{

			}
		}
	}
}
