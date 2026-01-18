namespace Nasa
{
    partial class WeatherForm
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
            APODPicture = new PictureBox();
            calendar = new MonthCalendar();
            buttonImport = new Button();
            buttonExport = new Button();
            listViewSpace = new ListView();
            labelReturnSpace = new Label();
            labelReturnEarth = new Label();
            listViewEarth = new ListView();
            labelFilter = new Label();
            labelActivities = new Label();
            groupBoxImport = new GroupBox();
            radioButtonImportJSON = new RadioButton();
            radioButtonImportXML = new RadioButton();
            groupBoxExport = new GroupBox();
            radioButtonExportJSON = new RadioButton();
            radioButtonExportXML = new RadioButton();
            buttonPurgeDatabase = new Button();
            labelManageDatabase = new Label();
            buttonCreateDatabase = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)APODPicture).BeginInit();
            groupBoxImport.SuspendLayout();
            groupBoxExport.SuspendLayout();
            SuspendLayout();
            // 
            // APODPicture
            // 
            APODPicture.Location = new Point(43, 691);
            APODPicture.Margin = new Padding(2);
            APODPicture.MinimumSize = new Size(320, 320);
            APODPicture.Name = "APODPicture";
            APODPicture.Size = new Size(641, 519);
            APODPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            APODPicture.TabIndex = 0;
            APODPicture.TabStop = false;
            APODPicture.Click += APODPicture_Click;
            // 
            // calendar
            // 
            calendar.Location = new Point(43, 44);
            calendar.Margin = new Padding(6, 5, 6, 5);
            calendar.MaxDate = new DateTime(2025, 7, 11, 0, 0, 0, 0);
            calendar.MaxSelectionCount = 1;
            calendar.MinDate = new DateTime(2023, 7, 11, 0, 0, 0, 0);
            calendar.Name = "calendar";
            calendar.TabIndex = 1;
            calendar.DateChanged += monthCalendar1_DateChanged;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(44, 89);
            buttonImport.Margin = new Padding(2);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(116, 34);
            buttonImport.TabIndex = 10;
            buttonImport.Text = "Importuj";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(44, 89);
            buttonExport.Margin = new Padding(2);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(116, 34);
            buttonExport.TabIndex = 11;
            buttonExport.Text = "Eksportuj";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // listViewSpace
            // 
            listViewSpace.Location = new Point(43, 250);
            listViewSpace.Name = "listViewSpace";
            listViewSpace.Size = new Size(641, 185);
            listViewSpace.TabIndex = 12;
            listViewSpace.UseCompatibleStateImageBehavior = false;
            // 
            // labelReturnSpace
            // 
            labelReturnSpace.AutoSize = true;
            labelReturnSpace.Location = new Point(43, 232);
            labelReturnSpace.Margin = new Padding(2, 0, 2, 0);
            labelReturnSpace.Name = "labelReturnSpace";
            labelReturnSpace.Size = new Size(168, 15);
            labelReturnSpace.TabIndex = 13;
            labelReturnSpace.Text = "Pogoda kosmiczna z tego dnia";
            // 
            // labelReturnEarth
            // 
            labelReturnEarth.AutoSize = true;
            labelReturnEarth.Location = new Point(43, 465);
            labelReturnEarth.Margin = new Padding(2, 0, 2, 0);
            labelReturnEarth.Name = "labelReturnEarth";
            labelReturnEarth.Size = new Size(154, 15);
            labelReturnEarth.TabIndex = 15;
            labelReturnEarth.Text = "Pogoda ziemska z tego dnia";
            // 
            // listViewEarth
            // 
            listViewEarth.Location = new Point(43, 483);
            listViewEarth.Name = "listViewEarth";
            listViewEarth.Size = new Size(641, 185);
            listViewEarth.TabIndex = 14;
            listViewEarth.UseCompatibleStateImageBehavior = false;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(43, 24);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(130, 15);
            labelFilter.TabIndex = 16;
            labelFilter.Text = "Przeszukaj bazę danych";
            // 
            // labelActivities
            // 
            labelActivities.AutoSize = true;
            labelActivities.Location = new Point(784, 24);
            labelActivities.Name = "labelActivities";
            labelActivities.Size = new Size(107, 15);
            labelActivities.TabIndex = 17;
            labelActivities.Text = "Importuj/Eksportuj";
            // 
            // groupBoxImport
            // 
            groupBoxImport.Controls.Add(radioButtonImportJSON);
            groupBoxImport.Controls.Add(radioButtonImportXML);
            groupBoxImport.Controls.Add(buttonImport);
            groupBoxImport.Location = new Point(837, 67);
            groupBoxImport.Name = "groupBoxImport";
            groupBoxImport.Size = new Size(200, 157);
            groupBoxImport.TabIndex = 18;
            groupBoxImport.TabStop = false;
            groupBoxImport.Text = "Importuj z formatu";
            // 
            // radioButtonImportJSON
            // 
            radioButtonImportJSON.AutoSize = true;
            radioButtonImportJSON.Location = new Point(21, 55);
            radioButtonImportJSON.Name = "radioButtonImportJSON";
            radioButtonImportJSON.Size = new Size(53, 19);
            radioButtonImportJSON.TabIndex = 1;
            radioButtonImportJSON.TabStop = true;
            radioButtonImportJSON.Text = "JSON";
            radioButtonImportJSON.TextImageRelation = TextImageRelation.TextBeforeImage;
            radioButtonImportJSON.UseVisualStyleBackColor = true;
            // 
            // radioButtonImportXML
            // 
            radioButtonImportXML.AutoSize = true;
            radioButtonImportXML.Location = new Point(22, 27);
            radioButtonImportXML.Name = "radioButtonImportXML";
            radioButtonImportXML.Size = new Size(49, 19);
            radioButtonImportXML.TabIndex = 0;
            radioButtonImportXML.TabStop = true;
            radioButtonImportXML.Text = "XML";
            radioButtonImportXML.UseVisualStyleBackColor = true;
            // 
            // groupBoxExport
            // 
            groupBoxExport.Controls.Add(radioButtonExportJSON);
            groupBoxExport.Controls.Add(radioButtonExportXML);
            groupBoxExport.Controls.Add(buttonExport);
            groupBoxExport.Location = new Point(837, 250);
            groupBoxExport.Name = "groupBoxExport";
            groupBoxExport.Size = new Size(200, 157);
            groupBoxExport.TabIndex = 19;
            groupBoxExport.TabStop = false;
            groupBoxExport.Text = "Eksportuj do formatu";
            // 
            // radioButtonExportJSON
            // 
            radioButtonExportJSON.AutoSize = true;
            radioButtonExportJSON.Location = new Point(21, 55);
            radioButtonExportJSON.Name = "radioButtonExportJSON";
            radioButtonExportJSON.Size = new Size(53, 19);
            radioButtonExportJSON.TabIndex = 1;
            radioButtonExportJSON.TabStop = true;
            radioButtonExportJSON.Text = "JSON";
            radioButtonExportJSON.UseVisualStyleBackColor = true;
            // 
            // radioButtonExportXML
            // 
            radioButtonExportXML.AutoSize = true;
            radioButtonExportXML.Location = new Point(22, 27);
            radioButtonExportXML.Name = "radioButtonExportXML";
            radioButtonExportXML.Size = new Size(49, 19);
            radioButtonExportXML.TabIndex = 0;
            radioButtonExportXML.TabStop = true;
            radioButtonExportXML.Text = "XML";
            radioButtonExportXML.UseVisualStyleBackColor = true;
            // 
            // buttonPurgeDatabase
            // 
            buttonPurgeDatabase.Location = new Point(837, 565);
            buttonPurgeDatabase.Margin = new Padding(2);
            buttonPurgeDatabase.Name = "buttonPurgeDatabase";
            buttonPurgeDatabase.Size = new Size(116, 54);
            buttonPurgeDatabase.TabIndex = 20;
            buttonPurgeDatabase.Text = "Usuń zawartość bazy danych";
            buttonPurgeDatabase.UseVisualStyleBackColor = true;
            buttonPurgeDatabase.Click += buttonPurgeDatabase_Click;
            // 
            // labelManageDatabase
            // 
            labelManageDatabase.AutoSize = true;
            labelManageDatabase.Location = new Point(784, 517);
            labelManageDatabase.Name = "labelManageDatabase";
            labelManageDatabase.Size = new Size(125, 15);
            labelManageDatabase.TabIndex = 21;
            labelManageDatabase.Text = "Zarządzaj bazą danych";
            // 
            // buttonCreateDatabase
            // 
            buttonCreateDatabase.Location = new Point(837, 633);
            buttonCreateDatabase.Margin = new Padding(2);
            buttonCreateDatabase.Name = "buttonCreateDatabase";
            buttonCreateDatabase.Size = new Size(116, 54);
            buttonCreateDatabase.TabIndex = 22;
            buttonCreateDatabase.Text = "Utwórz bazę danych";
            buttonCreateDatabase.UseVisualStyleBackColor = true;
            buttonCreateDatabase.Click += buttonCreateDatabase_Click;
            // 
            // button1
            // 
            button1.Location = new Point(445, 67);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(116, 34);
            button1.TabIndex = 23;
            button1.Text = "Filtruj";
            button1.UseVisualStyleBackColor = true;
            // 
            // WeatherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1341, 1242);
            Controls.Add(button1);
            Controls.Add(buttonCreateDatabase);
            Controls.Add(labelManageDatabase);
            Controls.Add(buttonPurgeDatabase);
            Controls.Add(groupBoxExport);
            Controls.Add(groupBoxImport);
            Controls.Add(labelActivities);
            Controls.Add(labelFilter);
            Controls.Add(labelReturnEarth);
            Controls.Add(listViewEarth);
            Controls.Add(labelReturnSpace);
            Controls.Add(listViewSpace);
            Controls.Add(calendar);
            Controls.Add(APODPicture);
            Margin = new Padding(2);
            Name = "WeatherForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)APODPicture).EndInit();
            groupBoxImport.ResumeLayout(false);
            groupBoxImport.PerformLayout();
            groupBoxExport.ResumeLayout(false);
            groupBoxExport.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox APODPicture;
        private MonthCalendar calendar;
        private Button buttonImport;
        private Button buttonExport;
        private ListView listViewSpace;
        private Label labelReturnSpace;
        private Label labelReturnEarth;
        private ListView listViewEarth;
        private Label labelFilter;
        private Label labelActivities;
        private GroupBox groupBoxImport;
        private RadioButton radioButtonImportJSON;
        private RadioButton radioButtonImportXML;
        private GroupBox groupBoxExport;
        private RadioButton radioButtonExportJSON;
        private RadioButton radioButtonExportXML;
        private Button buttonPurgeDatabase;
        private Label labelManageDatabase;
        private Button buttonCreateDatabase;
        private Button button1;
    }
}
