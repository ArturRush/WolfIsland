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

		Panel[,] panels = new Panel[Island.height, Island.width];

		Island island;

		private int StepNum;
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
		}

		void panel_MouseClick(object sender, MouseEventArgs e)
		{
			
		}

		private void Start_Button_Click(object sender, EventArgs e)
		{
			Pause_Button.Enabled = true;
			Start_Button.Text = "Стоп!";
			rNum.Enabled = false;
			wNum.Enabled = false;
			island = new Island((int)rNum.Value, (int)wNum.Value, rList, wList);
		}

		private void Pause_Button_Click(object sender, EventArgs e)
		{

		}

		private void UpdateField()
		{

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
