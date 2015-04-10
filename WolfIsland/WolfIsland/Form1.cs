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
		public List<Rabbit> rList = new List<Rabbit>();
		public List<Wolf> wList = new List<Wolf>();

		Timer upField = new Timer();

		Panel[,] panels = new Panel[Island.height, Island.width];

		Island island;

		private int StepNum;
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
				island = new Island((int)rNum.Value, (int)wNum.Value, rList, wList);
				upField.Start();
			}else
			{
				action = false;
				Pause_Button.Enabled = false;
				Start_Button.Text = "Старт!";
				rNum.Enabled = true;
				wNum.Enabled = true;
				island.Clear();
				upField.Stop();
				upField.Dispose();
			}
		}

		private void Pause_Button_Click(object sender, EventArgs e)
		{
			if (pause)
			{
				pause = false;
				upField.Start();
			}
			else
				pause = true;
		}

		private void UpdateGame()
		{
			if (pause)
			upField.Stop();
			SetInfText();
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

		private void SetInfText()
		{
			if (InvokeRequired)
			{
				this.BeginInvoke(new Action<string>((s) => { rAlive.Text = "Количество кроликов: " + rList.Count.ToString(); }));
				this.BeginInvoke(new Action<string>((s) => { wAlive.Text = "Количество волков: " + wList.Count.ToString(); }));
				this.BeginInvoke(new Action<string>((s) => { Step_Label.Text = "Времени прошло: " + StepNum.ToString(); }));
			}
			else
			{
				rAlive.Text = "Количество кроликов: " + rList.Count.ToString();
				wAlive.Text = "Количество волков: " + wList.Count.ToString();
				Step_Label.Text = "Времени прошло: " + StepNum.ToString();
			}
		}
	}
}
