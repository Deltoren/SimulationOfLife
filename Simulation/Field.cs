using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Simulation
{
	public enum TypeOfCell
	{ 
		Grass = 1,
		Mob = 2
	}
	class Field
	{
		class Cell
		{
			public Cell(int _X, int _Y, TypeOfCell _TypeOfCell)
			{
				X = _X;
				Y = _Y;
				TypeOfCell = _TypeOfCell;
			}

			public int X, Y;
			public TypeOfCell TypeOfCell;
		}

		public Field(int _Width, int _Height)
		{
			Width = _Width;
			Height = _Height;
		}

		public int Width, Height;
		private Cell[,] Matrix;

		// Create Field
		public void Create(TypeOfCell TypeOfCell)
		{
			Matrix = new Cell[Width, Height];
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					Matrix[i, j] = new Cell(i, j, TypeOfCell);
				}
			}
		}

		// Draw Field
		public void Draw(Graphics PixelMap)
		{
			for(int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					Color PixelColor = Color.Green;
					switch (Matrix[i, j].TypeOfCell)
					{
						case TypeOfCell.Grass:
							PixelColor = Color.Green;
							break;
						case TypeOfCell.Mob:
							PixelColor = Color.Black;
							break;
					}
					PixelMap.FillRectangle(new SolidBrush(PixelColor), i, j, 1, 1);
				}
			}
		}

		// Set Mobs on Map
		public void SetMobs(Mob[] ListOfMobs)
		{
			Create(TypeOfCell.Grass);
			foreach (Mob _Mob in ListOfMobs)
			{
				Matrix[_Mob.X, _Mob.Y].TypeOfCell = TypeOfCell.Mob;
			}
		}
	}
}
