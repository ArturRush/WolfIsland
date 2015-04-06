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
		Island island = new Island();
		List<int[,]> rList;
		List<int[,]> wList;
		private int StepNum;
		public Form1()
		{
			InitializeComponent();
			InitGame();
		}

		private void InitGame()
		{

		}

		private void Start_Button_Click(object sender, EventArgs e)
		{
			Pause_Button.Enabled = true;
			rNum.Enabled = false;
			wNum.Enabled = false;

			island.FillField((int)rNum.Value, (int)wNum.Value);
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
