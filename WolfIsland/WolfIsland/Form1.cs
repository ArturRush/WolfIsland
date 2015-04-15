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

		private int stepNum;			//Номер шага
		private bool action;			//Запущена ли игра
		private bool pause;				//Поставлена ли на паузу
		public Form1()
		{
			InitializeComponent();
			InitGame();			//Инициализация компонентов
		}

		/// <summary>
		/// Создает массив панелей на поле, задает свойства таймера
		/// </summary>
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

		/// <summary>
		/// Тик таймера
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void upField_Tick(object sender, EventArgs e)
		{
			UpdateGame();
		}

		/// <summary>
		/// По клику мыши на панель создается волк или кролик в зависимости от условий
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Запускает или останавливает игру
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Включает/выключает паузу
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		///	Совершает следующий игровой шаг
		/// </summary>
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

		/// <summary>
		/// Обновляет позиции животных на поле
		/// </summary>
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

		/// <summary>
		/// Обновляет лог игры
		/// </summary>
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

		/// <summary>
		/// Обновляет игровую информацию
		/// </summary>
		private void SetInfText()
		{
				rAlive.Text = @"Количество кроликов: " + RList.Count.ToString();
				wAlive.Text = @"Количество волков: " + WList.Count.ToString();
				Step_Label.Text = @"Сделано ходов: " + stepNum.ToString();
		}
	}
}
