using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Simulation
{
	public partial class Form1 : Form
	{
		private Graphics PixelMap;
		private int Width, Height;
		private Field MainField;
		private Mob[] ListOfMobs;
		private bool Test = true;

		public Form1()
		{
			InitializeComponent();
		}

		private void StartSimulation()
		{
			if (timer1.Enabled)
			{
				return;
			}
			nudCountOfMobs.Enabled = false;
			int CountOfMobs = (int)nudCountOfMobs.Value;

			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			var graphics = Graphics.FromImage(pictureBox1.Image);

			MainField = new Field(1000, 1000);
			MainField.Create(TypeOfCell.Grass);

			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			PixelMap = Graphics.FromImage(pictureBox1.Image);
			MainField.Draw(PixelMap);

			ListOfMobs = new Mob[CountOfMobs];
			for (int i = 0; i < CountOfMobs; i++)
			{
				ListOfMobs[i] = new Mob(MainField);
			}

			MainField.SetMobs(ListOfMobs);
			MainField.Draw(PixelMap);

			timer1.Start();
		}

		private void NextStep()
		{
			PixelMap.Clear(Color.Green);
			foreach (Mob _Mob in ListOfMobs)
			{
				_Mob.Moving(MainField);
			}
			MainField.SetMobs(ListOfMobs);
			MainField.Draw(PixelMap);
			pictureBox1.Refresh();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			NextStep();
		}

		private void bStart_Click(object sender, EventArgs e)
		{
			StartSimulation();
		}

		private void bStop_Click(object sender, EventArgs e)
		{
			if (!timer1.Enabled)
				return;
			timer1.Stop();
			nudCountOfMobs.Enabled = true;
		}
	}
}
