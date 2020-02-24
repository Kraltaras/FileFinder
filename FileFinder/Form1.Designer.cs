namespace FileFinder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.textSymbols = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelSymbols = new System.Windows.Forms.Label();
            this.buttonChangeAddress = new System.Windows.Forms.Button();
            this.folderAddress = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelFound = new System.Windows.Forms.Label();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(140, 12);
            this.textAddress.Name = "textAddress";
            this.textAddress.ReadOnly = true;
            this.textAddress.Size = new System.Drawing.Size(431, 20);
            this.textAddress.TabIndex = 0;
            this.textAddress.Text = "Desktop";
            this.textAddress.TextChanged += new System.EventHandler(this.textAddress_TextChanged);
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(140, 38);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(431, 20);
            this.textFileName.TabIndex = 1;
            this.textFileName.TextChanged += new System.EventHandler(this.textFileName_TextChanged);
            // 
            // textSymbols
            // 
            this.textSymbols.Location = new System.Drawing.Point(140, 64);
            this.textSymbols.Name = "textSymbols";
            this.textSymbols.Size = new System.Drawing.Size(431, 20);
            this.textSymbols.TabIndex = 2;
            this.textSymbols.TextChanged += new System.EventHandler(this.textSymbols_TextChanged);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(12, 15);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(122, 13);
            this.labelAddress.TabIndex = 3;
            this.labelAddress.Text = "Стартовая директория";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(70, 41);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(64, 13);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "Имя файла";
            // 
            // labelSymbols
            // 
            this.labelSymbols.AutoSize = true;
            this.labelSymbols.Location = new System.Drawing.Point(36, 67);
            this.labelSymbols.Name = "labelSymbols";
            this.labelSymbols.Size = new System.Drawing.Size(98, 13);
            this.labelSymbols.TabIndex = 5;
            this.labelSymbols.Text = "Символы в файле";
            // 
            // buttonChangeAddress
            // 
            this.buttonChangeAddress.Location = new System.Drawing.Point(577, 10);
            this.buttonChangeAddress.Name = "buttonChangeAddress";
            this.buttonChangeAddress.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeAddress.TabIndex = 6;
            this.buttonChangeAddress.Text = "Изменить";
            this.buttonChangeAddress.UseVisualStyleBackColor = true;
            this.buttonChangeAddress.Click += new System.EventHandler(this.buttonChangeAddress_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(577, 180);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 70);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelFound
            // 
            this.labelFound.AutoSize = true;
            this.labelFound.Location = new System.Drawing.Point(12, 458);
            this.labelFound.Name = "labelFound";
            this.labelFound.Size = new System.Drawing.Size(211, 13);
            this.labelFound.TabIndex = 9;
            this.labelFound.Text = "Файлов обработано: ; Файлов найдено:";
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 487);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(87, 13);
            this.labelCurrentFile.TabIndex = 10;
            this.labelCurrentFile.Text = "Текущий файл: ";
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.Location = new System.Drawing.Point(15, 104);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.Size = new System.Drawing.Size(556, 338);
            this.treeViewFiles.TabIndex = 11;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(337, 458);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(138, 13);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Время с запуска поиска: ";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(577, 271);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 70);
            this.buttonPause.TabIndex = 13;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 514);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.treeViewFiles);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.labelFound);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonChangeAddress);
            this.Controls.Add(this.labelSymbols);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textSymbols);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.textAddress);
            this.Name = "MainForm";
            this.Text = "Поиск файлов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.TextBox textSymbols;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelSymbols;
        private System.Windows.Forms.Button buttonChangeAddress;
        private System.Windows.Forms.FolderBrowserDialog folderAddress;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelFound;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonPause;
    }
}

