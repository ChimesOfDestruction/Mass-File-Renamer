using Ambiance;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Renamer_By_Yung_Kira_Ely
{
	public class Form1 : Form
	{
		private IContainer components = null;

		private Ambiance_ThemeContainer ambiance_ThemeContainer1;

		private GroupBox groupBox1;

		private Label label3;

		private GroupBox groupBox2;

		private ListBox listBox1;

		private Label label2;

		private System.Windows.Forms.Timer timer1;

		private Ambiance_ProgressBar ambiance_ProgressBar1;

		private Label label1;

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Label label4;
        private Ambiance_TextBox ambiance_TextBox1;
        private Ambiance_Button_1 ambiance_Button_11;
        private Ambiance_Button_1 ambiance_Button_13;
        private Ambiance_Button_1 ambiance_Button_14;
        private Label label5;
        private Ambiance_TextBox ambiance_TextBox2;
        private Ambiance_Button_2 ambiance_Button_21;

		public Form1()
		{
			this.InitializeComponent();
		}

		private void ambiance_Button_11_Click(object sender, EventArgs e)
		{
		}

		private void ambiance_Button_21_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
	
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			try
			{
				this.listBox1.Items.Remove(this.listBox1.SelectedItems[0]);
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ambiance_ThemeContainer1 = new Ambiance.Ambiance_ThemeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.ambiance_TextBox2 = new Ambiance.Ambiance_TextBox();
            this.ambiance_Button_14 = new Ambiance.Ambiance_Button_1();
            this.ambiance_Button_13 = new Ambiance.Ambiance_Button_1();
            this.label4 = new System.Windows.Forms.Label();
            this.ambiance_ProgressBar1 = new Ambiance.Ambiance_ProgressBar();
            this.ambiance_Button_21 = new Ambiance.Ambiance_Button_2();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ambiance_Button_11 = new Ambiance.Ambiance_Button_1();
            this.ambiance_TextBox1 = new Ambiance.Ambiance_TextBox();
            this.ambiance_ThemeContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ambiance_ThemeContainer1
            // 
            this.ambiance_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.ambiance_ThemeContainer1.Controls.Add(this.label5);
            this.ambiance_ThemeContainer1.Controls.Add(this.ambiance_TextBox2);
            this.ambiance_ThemeContainer1.Controls.Add(this.ambiance_Button_14);
            this.ambiance_ThemeContainer1.Controls.Add(this.ambiance_Button_13);
            this.ambiance_ThemeContainer1.Controls.Add(this.label4);
            this.ambiance_ThemeContainer1.Controls.Add(this.ambiance_ProgressBar1);
            this.ambiance_ThemeContainer1.Controls.Add(this.ambiance_Button_21);
            this.ambiance_ThemeContainer1.Controls.Add(this.label1);
            this.ambiance_ThemeContainer1.Controls.Add(this.label3);
            this.ambiance_ThemeContainer1.Controls.Add(this.groupBox2);
            this.ambiance_ThemeContainer1.Controls.Add(this.label2);
            this.ambiance_ThemeContainer1.Controls.Add(this.groupBox1);
            this.ambiance_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ambiance_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ambiance_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.ambiance_ThemeContainer1.Name = "ambiance_ThemeContainer1";
            this.ambiance_ThemeContainer1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.ambiance_ThemeContainer1.RoundCorners = true;
            this.ambiance_ThemeContainer1.Sizable = true;
            this.ambiance_ThemeContainer1.Size = new System.Drawing.Size(623, 352);
            this.ambiance_ThemeContainer1.SmartBounds = true;
            this.ambiance_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.ambiance_ThemeContainer1.TabIndex = 0;
            this.ambiance_ThemeContainer1.Text = "File Renamer | Extract SRC + MOD by ChimesOfDestruction";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(424, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Extension:";
            // 
            // ambiance_TextBox2
            // 
            this.ambiance_TextBox2.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_TextBox2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ambiance_TextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.ambiance_TextBox2.Location = new System.Drawing.Point(428, 220);
            this.ambiance_TextBox2.MaxLength = 32767;
            this.ambiance_TextBox2.Multiline = false;
            this.ambiance_TextBox2.Name = "ambiance_TextBox2";
            this.ambiance_TextBox2.ReadOnly = false;
            this.ambiance_TextBox2.Size = new System.Drawing.Size(171, 28);
            this.ambiance_TextBox2.TabIndex = 22;
            this.ambiance_TextBox2.Text = ".zip";
            this.ambiance_TextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.ambiance_TextBox2.UseSystemPasswordChar = false;
            // 
            // ambiance_Button_14
            // 
            this.ambiance_Button_14.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Button_14.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ambiance_Button_14.Image = null;
            this.ambiance_Button_14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ambiance_Button_14.Location = new System.Drawing.Point(428, 277);
            this.ambiance_Button_14.Name = "ambiance_Button_14";
            this.ambiance_Button_14.Size = new System.Drawing.Size(171, 30);
            this.ambiance_Button_14.TabIndex = 21;
            this.ambiance_Button_14.Text = "Start Renaming";
            this.ambiance_Button_14.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ambiance_Button_14.Click += new System.EventHandler(this.ambiance_Button_14_Click);
            // 
            // ambiance_Button_13
            // 
            this.ambiance_Button_13.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Button_13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ambiance_Button_13.Image = null;
            this.ambiance_Button_13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ambiance_Button_13.Location = new System.Drawing.Point(428, 127);
            this.ambiance_Button_13.Name = "ambiance_Button_13";
            this.ambiance_Button_13.Size = new System.Drawing.Size(171, 30);
            this.ambiance_Button_13.TabIndex = 20;
            this.ambiance_Button_13.Text = "Load .TXT File";
            this.ambiance_Button_13.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ambiance_Button_13.Click += new System.EventHandler(this.ambiance_Button_13_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // ambiance_ProgressBar1
            // 
            this.ambiance_ProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_ProgressBar1.DrawHatch = true;
            this.ambiance_ProgressBar1.Location = new System.Drawing.Point(85, 313);
            this.ambiance_ProgressBar1.Maximum = 100;
            this.ambiance_ProgressBar1.Minimum = 0;
            this.ambiance_ProgressBar1.MinimumSize = new System.Drawing.Size(58, 20);
            this.ambiance_ProgressBar1.Name = "ambiance_ProgressBar1";
            this.ambiance_ProgressBar1.ShowPercentage = true;
            this.ambiance_ProgressBar1.Size = new System.Drawing.Size(514, 20);
            this.ambiance_ProgressBar1.TabIndex = 13;
            this.ambiance_ProgressBar1.Text = "ambiance_ProgressBar1";
            this.ambiance_ProgressBar1.Value = 0;
            this.ambiance_ProgressBar1.ValueAlignment = Ambiance.Ambiance_ProgressBar.Alignment.Right;
            // 
            // ambiance_Button_21
            // 
            this.ambiance_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Button_21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ambiance_Button_21.Image = null;
            this.ambiance_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ambiance_Button_21.Location = new System.Drawing.Point(579, 8);
            this.ambiance_Button_21.Name = "ambiance_Button_21";
            this.ambiance_Button_21.Size = new System.Drawing.Size(32, 30);
            this.ambiance_Button_21.TabIndex = 17;
            this.ambiance_Button_21.Text = "X";
            this.ambiance_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ambiance_Button_21.Click += new System.EventHandler(this.ambiance_Button_21_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Copying:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(424, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Count :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(23, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 180);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filename List";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(7, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(381, 144);
            this.listBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(481, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ambiance_Button_11);
            this.groupBox1.Controls.Add(this.ambiance_TextBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 62);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path";
            // 
            // ambiance_Button_11
            // 
            this.ambiance_Button_11.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Button_11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ambiance_Button_11.Image = null;
            this.ambiance_Button_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ambiance_Button_11.Location = new System.Drawing.Point(464, 21);
            this.ambiance_Button_11.Name = "ambiance_Button_11";
            this.ambiance_Button_11.Size = new System.Drawing.Size(106, 28);
            this.ambiance_Button_11.TabIndex = 7;
            this.ambiance_Button_11.Text = "Load File";
            this.ambiance_Button_11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ambiance_Button_11.Click += new System.EventHandler(this.ambiance_Button_11_Click_1);
            // 
            // ambiance_TextBox1
            // 
            this.ambiance_TextBox1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_TextBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ambiance_TextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.ambiance_TextBox1.Location = new System.Drawing.Point(7, 21);
            this.ambiance_TextBox1.MaxLength = 32767;
            this.ambiance_TextBox1.Multiline = false;
            this.ambiance_TextBox1.Name = "ambiance_TextBox1";
            this.ambiance_TextBox1.ReadOnly = false;
            this.ambiance_TextBox1.Size = new System.Drawing.Size(451, 28);
            this.ambiance_TextBox1.TabIndex = 6;
            this.ambiance_TextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.ambiance_TextBox1.UseSystemPasswordChar = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 352);
            this.Controls.Add(this.ambiance_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "Form1";
            this.Text = "File Renamer | Extract SRC + MOD by ChimesOfDestruction";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.ambiance_ThemeContainer1.ResumeLayout(false);
            this.ambiance_ThemeContainer1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string directoryName = Path.GetDirectoryName(this.ambiance_TextBox1.Text);
				Process.Start("explorer.exe", directoryName);
			}
			catch
			{
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			int count = this.listBox1.Items.Count;
			this.label2.Text = count.ToString();
		}

        private void ambiance_Button_11_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "File you want to spread |*.*"
            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ambiance_TextBox1.Text = openFileDialog.FileName;
            }
        }

        private void ambiance_Button_13_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "text file |*.txt"
            };
            this.timer1.Start();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] strArrays = File.ReadAllLines(openFileDialog.FileName);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string str = strArrays[i];
                    this.listBox1.Items.Add(str);
                }
            }
        }

        private void ambiance_Button_14_Click(object sender, EventArgs e)
        {
            if (this.ambiance_TextBox1.Text == "Directory")
            {
                MessageBox.Show("No File Loaded!", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.listBox1.Items.Count != 0)
            {
                this.groupBox2.Enabled = true;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Thread.CurrentThread.IsBackground = true;
                    this.ambiance_ProgressBar1.Maximum = this.listBox1.Items.Count;
                    foreach (string item in this.listBox1.Items)
                    {
                        this.label4.Text = item;
                        this.label4.Update();
                        if (!File.Exists(string.Concat(folderBrowserDialog.SelectedPath, "\\", item, ambiance_TextBox2.Text)))
                        {
                            try
                            {
                                File.Copy(this.ambiance_TextBox1.Text, string.Concat(folderBrowserDialog.SelectedPath, "\\", item, ambiance_TextBox2.Text));
                            }
                            catch
                            {
                            }
                            this.ambiance_ProgressBar1.Value = this.ambiance_ProgressBar1.Value + 4;
                            Thread.Sleep(100);
                        }
                        else
                        {
                            this.ambiance_ProgressBar1.Value = this.ambiance_ProgressBar1.Value + 1;
                        }
                    }
                    this.groupBox2.Enabled = false;
                    System.Windows.Forms.DialogResult dialogResult = MessageBox.Show(string.Concat("Files Cloned To :\n", folderBrowserDialog.SelectedPath, "\n \n Open Selected Folder ?"), "Done!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", folderBrowserDialog.SelectedPath);
                    }
                    else if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty List!", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}