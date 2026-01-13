namespace Nasa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            calendar = new MonthCalendar();
            labelImport = new Label();
            labelEksport = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            listViewSpace = new ListView();
            labelReturnSpace = new Label();
            labelReturnEarth = new Label();
            listViewEarth = new ListView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(364, 13);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(320, 302);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // calendar
            // 
            calendar.Location = new Point(43, 13);
            calendar.Margin = new Padding(6, 5, 6, 5);
            calendar.MaxSelectionCount = 1;
            calendar.Name = "calendar";
            calendar.TabIndex = 1;
            calendar.DateChanged += monthCalendar1_DateChanged;
            // 
            // labelImport
            // 
            labelImport.AutoSize = true;
            labelImport.Location = new Point(43, 181);
            labelImport.Margin = new Padding(2, 0, 2, 0);
            labelImport.Name = "labelImport";
            labelImport.Size = new Size(43, 15);
            labelImport.TabIndex = 2;
            labelImport.Text = "Import";
            // 
            // labelEksport
            // 
            labelEksport.AutoSize = true;
            labelEksport.Location = new Point(237, 181);
            labelEksport.Margin = new Padding(2, 0, 2, 0);
            labelEksport.Name = "labelEksport";
            labelEksport.Size = new Size(46, 15);
            labelEksport.TabIndex = 3;
            labelEksport.Text = "Eksport";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(43, 204);
            checkBox1.Margin = new Padding(2, 2, 2, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(50, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "XML";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(43, 225);
            checkBox2.Margin = new Padding(2, 2, 2, 2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(54, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "JSON";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(43, 246);
            checkBox3.Margin = new Padding(2, 2, 2, 2);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(92, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Baza danych";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(228, 204);
            checkBox4.Margin = new Padding(2, 2, 2, 2);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(50, 19);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "XML";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(228, 225);
            checkBox5.Margin = new Padding(2, 2, 2, 2);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(54, 19);
            checkBox5.TabIndex = 8;
            checkBox5.Text = "JSON";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(228, 246);
            checkBox6.Margin = new Padding(2, 2, 2, 2);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(92, 19);
            checkBox6.TabIndex = 9;
            checkBox6.Text = "Baza danych";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(43, 273);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(116, 21);
            button1.TabIndex = 10;
            button1.Text = "Wybierz plik";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(207, 273);
            button2.Margin = new Padding(2, 2, 2, 2);
            button2.Name = "button2";
            button2.Size = new Size(116, 21);
            button2.TabIndex = 11;
            button2.Text = "Eksportuj";
            button2.UseVisualStyleBackColor = true;
            // 
            // listViewSpace
            // 
            listViewSpace.Location = new Point(43, 389);
            listViewSpace.Name = "listViewSpace";
            listViewSpace.Size = new Size(641, 185);
            listViewSpace.TabIndex = 12;
            listViewSpace.UseCompatibleStateImageBehavior = false;
            // 
            // labelReturnSpace
            // 
            labelReturnSpace.AutoSize = true;
            labelReturnSpace.Location = new Point(43, 371);
            labelReturnSpace.Margin = new Padding(2, 0, 2, 0);
            labelReturnSpace.Name = "labelReturnSpace";
            labelReturnSpace.Size = new Size(168, 15);
            labelReturnSpace.TabIndex = 13;
            labelReturnSpace.Text = "Pogoda kosmiczna z tego dnia";
            // 
            // labelReturnEarth
            // 
            labelReturnEarth.AutoSize = true;
            labelReturnEarth.Location = new Point(43, 604);
            labelReturnEarth.Margin = new Padding(2, 0, 2, 0);
            labelReturnEarth.Name = "labelReturnEarth";
            labelReturnEarth.Size = new Size(154, 15);
            labelReturnEarth.TabIndex = 15;
            labelReturnEarth.Text = "Pogoda ziemska z tego dnia";
            // 
            // listViewEarth
            // 
            listViewEarth.Location = new Point(43, 622);
            listViewEarth.Name = "listViewEarth";
            listViewEarth.Size = new Size(641, 185);
            listViewEarth.TabIndex = 14;
            listViewEarth.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 840);
            Controls.Add(labelReturnEarth);
            Controls.Add(listViewEarth);
            Controls.Add(labelReturnSpace);
            Controls.Add(listViewSpace);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(labelEksport);
            Controls.Add(labelImport);
            Controls.Add(calendar);
            Controls.Add(pictureBox1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MonthCalendar calendar;
        private Label labelImport;
        private Label labelEksport;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Button button1;
        private Button button2;
        private ListView listViewSpace;
        private Label labelReturnSpace;
        private Label labelReturnEarth;
        private ListView listViewEarth;
    }
}
