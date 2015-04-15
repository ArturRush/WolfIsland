using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WolfIsland
{
	public partial class Form1 : Form
	{
		public static List<Rabbit> RList = new List<Rabbit>();		//Хранит список кроликов
		public static List<Wolf> WList = new List<Wolf>();			//Хранит список волков

		Timer upField = new Timer();								//Поток для обновления и работы поля

		Panel[,] panels = new Panel[Island.Height, Island.Width];	//Хранит массив панелей для отображения движения животных

		Island island = new Island();					//Экземпляр острова, с которым происходит все действие

		private int stepNum;						//Номер шага
		private bool action;			
		private bool pause;
		public Form1()
		{
			InitializeComponent();
			InitGame();
		}

		private void InitGame()
		{
			for(int i = 0; i<Island.Height; i++)
				for (int j = 0; j<Island.Width; j++)
				{
					panels[i, j] = new Panel
					{
						Parent = Field,
						BackColor = Color.White,
						BorderStyle = BorderStyle.FixedSingle,	
						Width = Island.Width,
						Height = Island.Height,
						Top = i * Island.Height,
						Left = j * Island.Width,
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
				int x = ((Panel)sender).Top / Island.Height;
				int y = ((Panel)sender).Left / Island.Width;
				island.PutRabbit(x,y,RList);
			}
			else if (wPut.Checked)
			{
				int x = ((Panel)sender).Top / Island.Height;
				int y = ((Panel)sender).Left / Island.Width;
				island.PutWolf(x, y, WList);
			}
			UpdatePanels();
		}

		private void Start_Button_Click(object sender, EventArgs e)
		{
			if (!action)
			{
				action = true;
				Pause_Button.Enabled = true;
				Start_Button.Text = @"Стоп!";
				rNum.Enabled = false;
				wNum.Enabled = false;
				island.FillIsland((int)rNum.Value, (int)wNum.Value, RList, WList);
				if (DoLog.Checked)
					LogTBox.Text = @"Игра началась!
";
				upField.Start();
			}else
			{
				action = false;
				pause = false;
				Pause_Button.BackColor = Color.Gainsboro;
				Pause_Button.Enabled = false;
				Start_Button.Text = @"Старт!";
				rNum.Enabled = true;
				wNum.Enabled = true;
				stepNum = 0;
				LogTBox.Text = "";
				island.ClearField();
				RList.Clear();
				WList.Clear();
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
			stepNum++;
			if (DoLog.Checked && action)
				UpdateLog();
			island.MoveAnimals();
			UpdatePanels();
			upField.Interval = (int)StepDuration.Value;

		}

		private void UpdatePanels()
		{
			for (int i = 0; i < Island.Height; i++)
				for (int j = 0; j < Island.Width; j++)
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
			LogTBox.Text += @"===========================" + @"
";
			LogTBox.Text += @"Шаг " + stepNum.ToString() + @"
";
			LogTBox.Text += @"Количество кроликов: " + RList.Count.ToString() + @"
";
			LogTBox.Text += @"Количество волков: " + WList.Count.ToString() + @"
";
			LogTBox.Text += @"Сделано ходов: " + stepNum.ToString() + @"
";
		}

		private void SetInfText()
		{
				rAlive.Text = @"Количество кроликов: " + RList.Count.ToString();
				wAlive.Text = @"Количество волков: " + WList.Count.ToString();
				Step_Label.Text = @"Сделано ходов: " + stepNum.ToString();
		}
	}
}
