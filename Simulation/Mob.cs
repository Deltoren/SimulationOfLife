using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation
{
	class Mob
	{
		public Mob(Field Matrix)
		{
			var rand = new Random();
			X = rand.Next(Matrix.Width);
			Y = rand.Next(Matrix.Height);
		}

		public void Moving(Field Matrix)
		{
			var rand = new Random();
			switch (rand.Next(4))
			{
				case 0:
					if (Y > 0) Y--;
					else Y++;
					break;
				case 1:
					if (X < Matrix.Width - 1) X++;
					else X--;
					break;
				case 2:
					if (Y < Matrix.Height - 1) Y++;
					else Y--;
					break;
				case 3:
					if (X > 0) X--;
					else X++;
					break;
			}
		}

		public int X, Y;
	}
}
