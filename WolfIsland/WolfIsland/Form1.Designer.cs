namespace WolfIsland
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rNum = new System.Windows.Forms.NumericUpDown();
			this.wNum = new System.Windows.Forms.NumericUpDown();
			this.StepDuration = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.rPut = new System.Windows.Forms.RadioButton();
			this.wPut = new System.Windows.Forms.RadioButton();
			this.Field = new System.Windows.Forms.Panel();
			this.LogTBox = new System.Windows.Forms.RichTextBox();
			this.Start_Button = new System.Windows.Forms.Button();
			this.Pause_Button = new System.Windows.Forms.Button();
			this.wAlive = new System.Windows.Forms.Label();
			this.rAlive = new System.Windows.Forms.Label();
			this.Step_Label = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.rNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StepDuration)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Кроликов:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Волков:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Шаг времени";
			// 
			// rNum
			// 
			this.rNum.Location = new System.Drawing.Point(109, 17);
			this.rNum.Name = "rNum";
			this.rNum.ReadOnly = true;
			this.rNum.Size = new System.Drawing.Size(51, 20);
			this.rNum.TabIndex = 3;
			this.rNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// wNum
			// 
			this.wNum.Location = new System.Drawing.Point(109, 42);
			this.wNum.Name = "wNum";
			this.wNum.ReadOnly = true;
			this.wNum.Size = new System.Drawing.Size(51, 20);
			this.wNum.TabIndex = 4;
			this.wNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// StepDuration
			// 
			this.StepDuration.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.StepDuration.Location = new System.Drawing.Point(109, 66);
			this.StepDuration.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.StepDuration.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.StepDuration.Name = "StepDuration";
			this.StepDuration.Size = new System.Drawing.Size(51, 20);
			this.StepDuration.TabIndex = 5;
			this.StepDuration.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Поставить:";
			// 
			// rPut
			// 
			this.rPut.AutoSize = true;
			this.rPut.Checked = true;
			this.rPut.Location = new System.Drawing.Point(15, 121);
			this.rPut.Name = "rPut";
			this.rPut.Size = new System.Drawing.Size(68, 17);
			this.rPut.TabIndex = 7;
			this.rPut.TabStop = true;
			this.rPut.Text = "Кролика";
			this.rPut.UseVisualStyleBackColor = true;
			// 
			// wPut
			// 
			this.wPut.AutoSize = true;
			this.wPut.Location = new System.Drawing.Point(15, 144);
			this.wPut.Name = "wPut";
			this.wPut.Size = new System.Drawing.Size(56, 17);
			this.wPut.TabIndex = 8;
			this.wPut.Text = "Волка";
			this.wPut.UseVisualStyleBackColor = true;
			// 
			// Field
			// 
			this.Field.BackColor = System.Drawing.Color.White;
			this.Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Field.Location = new System.Drawing.Point(182, 12);
			this.Field.Name = "Field";
			this.Field.Size = new System.Drawing.Size(400, 400);
			this.Field.TabIndex = 9;
			// 
			// LogTBox
			// 
			this.LogTBox.Location = new System.Drawing.Point(607, 12);
			this.LogTBox.Name = "LogTBox";
			this.LogTBox.ReadOnly = true;
			this.LogTBox.Size = new System.Drawing.Size(195, 400);
			this.LogTBox.TabIndex = 10;
			this.LogTBox.Text = "";
			// 
			// Start_Button
			// 
			this.Start_Button.Location = new System.Drawing.Point(15, 379);
			this.Start_Button.Name = "Start_Button";
			this.Start_Button.Size = new System.Drawing.Size(122, 33);
			this.Start_Button.TabIndex = 11;
			this.Start_Button.Text = "Старт!";
			this.Start_Button.UseVisualStyleBackColor = true;
			this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
			// 
			// Pause_Button
			// 
			this.Pause_Button.Enabled = false;
			this.Pause_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Pause_Button.Location = new System.Drawing.Point(143, 379);
			this.Pause_Button.Name = "Pause_Button";
			this.Pause_Button.Size = new System.Drawing.Size(32, 33);
			this.Pause_Button.TabIndex = 12;
			this.Pause_Button.Text = "II";
			this.Pause_Button.UseVisualStyleBackColor = true;
			this.Pause_Button.Click += new System.EventHandler(this.Pause_Button_Click);
			// 
			// wAlive
			// 
			this.wAlive.AutoSize = true;
			this.wAlive.Location = new System.Drawing.Point(12, 329);
			this.wAlive.Name = "wAlive";
			this.wAlive.Size = new System.Drawing.Size(108, 13);
			this.wAlive.TabIndex = 13;
			this.wAlive.Text = "Количество волков:";
			// 
			// rAlive
			// 
			this.rAlive.AutoSize = true;
			this.rAlive.Location = new System.Drawing.Point(12, 307);
			this.rAlive.Name = "rAlive";
			this.rAlive.Size = new System.Drawing.Size(120, 13);
			this.rAlive.TabIndex = 14;
			this.rAlive.Text = "Количество кроликов:";
			// 
			// Step_Label
			// 
			this.Step_Label.AutoSize = true;
			this.Step_Label.Location = new System.Drawing.Point(12, 352);
			this.Step_Label.Name = "Step_Label";
			this.Step_Label.Size = new System.Drawing.Size(96, 13);
			this.Step_Label.TabIndex = 15;
			this.Step_Label.Text = "Времени прошло:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 421);
			this.Controls.Add(this.Step_Label);
			this.Controls.Add(this.rAlive);
			this.Controls.Add(this.wAlive);
			this.Controls.Add(this.Pause_Button);
			this.Controls.Add(this.Start_Button);
			this.Controls.Add(this.LogTBox);
			this.Controls.Add(this.Field);
			this.Controls.Add(this.wPut);
			this.Controls.Add(this.rPut);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.StepDuration);
			this.Controls.Add(this.wNum);
			this.Controls.Add(this.rNum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "WolfIsland";
			((System.ComponentModel.ISupportInitialize)(this.rNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StepDuration)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown rNum;
		private System.Windows.Forms.NumericUpDown wNum;
		private System.Windows.Forms.NumericUpDown StepDuration;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rPut;
		private System.Windows.Forms.RadioButton wPut;
		private System.Windows.Forms.Panel Field;
		private System.Windows.Forms.RichTextBox LogTBox;
		private System.Windows.Forms.Button Start_Button;
		private System.Windows.Forms.Button Pause_Button;
		private System.Windows.Forms.Label wAlive;
		private System.Windows.Forms.Label rAlive;
		private System.Windows.Forms.Label Step_Label;
	}
}

