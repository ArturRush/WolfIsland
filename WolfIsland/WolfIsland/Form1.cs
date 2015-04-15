using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfIsland
{
	public partial class Form1 : Form
	{
		public static List<Rabbit> rList = new List<Rabbit>();
		public static List<Wolf> wList = new List<Wolf>();

		Timer upField = new Timer();

		Panel[,] panels = new Panel[Island.height, Island.width];

		Island island = new Island();

		private int StepNum = 0;
		private bool action = false;
		private bool pause = false;
		public Form1()
		{
			InitializeComponent();
			InitGame();
		}

		private void InitGame()
		{
			for(int i = 0; i<Island.height; i++)
				for (int j = 0; j<Island.width; j++)
				{
					panels[i, j] = new Panel
					{
						Parent = Field,
						BackColor = Color.White,
						BorderStyle = BorderStyle.FixedSingle,	
						Width = Island.width,
						Height = Island.height,
						Top = i * Island.height,
						Left = j * Island.width,
					};
					panels[i,j].MouseClick += panel_MouseClick;
				}
			upField.Interval = (int)StepDuration.Value;
			upField.Tick += upField_Tick;
		}

		void upField_Tick(object sender, EventArgs e)
		{
			UpdateGame();
		}

		void panel_MouseClick(object sender, MouseEventArgs e)
		{
			if(rPut.Checked)
			{
				int x = (int)(((Panel)sender).Top / Island.height);
				int y = (int)(((Panel)sender).Left / Island.width);
				island.PutRabbit(x,y,rList);
			}
			else if (wPut.Checked)
			{
				int x = (int)(((Panel)sender).Top / Island.height);
				int y = (int)(((Panel)sender).Left / Island.width);
				island.PutWolf(x, y, wList);
			}
			UpdatePanels();
		}

		private void Start_Button_Click(object sender, EventArgs e)
		{
			if (!action)
			{
				action = true;
				Pause_Button.Enabled = true;
				Start_Button.Text = "Стоп!";
				rNum.Enabled = false;
				wNum.Enabled = false;
				island.FillIsland((int)rNum.Value, (int)wNum.Value, rList, wList);
				if (DoLog.Checked)
					LogTBox.Text = "Игра началась!\n";
				upField.Start();
			}else
			{
				action = false;
				pause = false;
				Pause_Button.BackColor = Color.Gainsboro;
				Pause_Button.Enabled = false;
				Start_Button.Text = "Старт!";
				rNum.Enabled = true;
				wNum.Enabled = true;
				StepNum = 0;
				LogTBox.Text = "";
				island.ClearField();
				rList.Clear();
				wList.Clear();
				upField.Stop();
				upField.Dispose();
				UpdateGame();
			}
		}

		private void Pause_Button_Click(object sender, EventArgs e)
		{
			if (pause)
			{
				pause = false;
				Pause_Button.BackColor = Color.Gainsboro;
				upField.Start();
			}
			else
			{
				pause = true;
				Pause_Button.BackColor = Color.Yellow;
			}
		}

		private void UpdateGame()
		{
			if (pause)
				upField.Stop();
			SetInfText();
			StepNum++;
			if (DoLog.Checked && action)
				UpdateLog();
			island.MoveAnimals();
			UpdatePanels();
			upField.Interval = (int)StepDuration.Value;

		}

		private void UpdatePanels()
		{
			for (int i = 0; i < Island.height; i++)
				for (int j = 0; j < Island.width; j++)
				{
					if (island.FieldArray[i, j] == 0)
						panels[i, j].BackColor = Color.White;
					else if (island.FieldArray[i, j] == 1)
						panels[i, j].BackColor = Color.Green;
					else if (island.FieldArray[i, j] == 2)
						panels[i, j].BackColor = Color.Red;
				}
		}

		private void UpdateLog()
		{
			LogTBox.Text += "===========================" + "\n";
			LogTBox.Text += "Шаг " + StepNum.ToString() + "\n";
			LogTBox.Text += "Количество кроликов: " + rList.Count.ToString() + "\n";
			LogTBox.Text += "Количество волков: " + wList.Count.ToString() + "\n";
			LogTBox.Text += "Сделано ходов: " + StepNum.ToString() + "\n";
		}

		private void SetInfText()
		{
				rAlive.Text = "Количество кроликов: " + rList.Count.ToString();
				wAlive.Text = "Количество волков: " + wList.Count.ToString();
				Step_Label.Text = "Сделано ходов: " + StepNum.ToString();
		}
	}
}
