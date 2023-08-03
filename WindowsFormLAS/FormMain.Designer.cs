namespace WindowsFormLAS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnEntrustOperation = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnAddReader = new System.Windows.Forms.Button();
            this.btnStatisticts = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgEntrustBooks = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgAvailableBooks = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgReaders = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntrustBooks)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailableBooks)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEntrustOperation
            // 
            this.btnEntrustOperation.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrustOperation.Image")));
            this.btnEntrustOperation.Location = new System.Drawing.Point(74, 49);
            this.btnEntrustOperation.Name = "btnEntrustOperation";
            this.btnEntrustOperation.Size = new System.Drawing.Size(200, 150);
            this.btnEntrustOperation.TabIndex = 0;
            this.btnEntrustOperation.Text = "Entrust Operations";
            this.btnEntrustOperation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntrustOperation.UseVisualStyleBackColor = true;
            this.btnEntrustOperation.Click += new System.EventHandler(this.btnEntrustOperation_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBook.Image")));
            this.btnAddBook.Location = new System.Drawing.Point(280, 49);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(200, 150);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnAddReader
            // 
            this.btnAddReader.Image = ((System.Drawing.Image)(resources.GetObject("btnAddReader.Image")));
            this.btnAddReader.Location = new System.Drawing.Point(486, 49);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(200, 150);
            this.btnAddReader.TabIndex = 2;
            this.btnAddReader.Text = "Add Reader";
            this.btnAddReader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddReader.UseVisualStyleBackColor = true;
            this.btnAddReader.Click += new System.EventHandler(this.btnAddReader_Click);
            // 
            // btnStatisticts
            // 
            this.btnStatisticts.Image = ((System.Drawing.Image)(resources.GetObject("btnStatisticts.Image")));
            this.btnStatisticts.Location = new System.Drawing.Point(692, 49);
            this.btnStatisticts.Name = "btnStatisticts";
            this.btnStatisticts.Size = new System.Drawing.Size(200, 150);
            this.btnStatisticts.TabIndex = 3;
            this.btnStatisticts.Text = "Statistics";
            this.btnStatisticts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStatisticts.UseVisualStyleBackColor = true;
            this.btnStatisticts.Click += new System.EventHandler(this.btnStatisticts_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(898, 49);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(200, 150);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(1466, 49);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(200, 150);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(74, 205);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1592, 727);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgEntrustBooks);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1584, 694);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entrust Books";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgEntrustBooks
            // 
            this.dgEntrustBooks.AllowUserToAddRows = false;
            this.dgEntrustBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEntrustBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEntrustBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgEntrustBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntrustBooks.Location = new System.Drawing.Point(3, 3);
            this.dgEntrustBooks.MultiSelect = false;
            this.dgEntrustBooks.Name = "dgEntrustBooks";
            this.dgEntrustBooks.ReadOnly = true;
            this.dgEntrustBooks.RowHeadersVisible = false;
            this.dgEntrustBooks.RowHeadersWidth = 62;
            this.dgEntrustBooks.RowTemplate.Height = 28;
            this.dgEntrustBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEntrustBooks.Size = new System.Drawing.Size(1578, 688);
            this.dgEntrustBooks.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgAvailableBooks);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1584, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Available Books";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgAvailableBooks
            // 
            this.dgAvailableBooks.AllowUserToAddRows = false;
            this.dgAvailableBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAvailableBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgAvailableBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAvailableBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAvailableBooks.Location = new System.Drawing.Point(3, 3);
            this.dgAvailableBooks.MultiSelect = false;
            this.dgAvailableBooks.Name = "dgAvailableBooks";
            this.dgAvailableBooks.ReadOnly = true;
            this.dgAvailableBooks.RowHeadersVisible = false;
            this.dgAvailableBooks.RowHeadersWidth = 62;
            this.dgAvailableBooks.RowTemplate.Height = 28;
            this.dgAvailableBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAvailableBooks.Size = new System.Drawing.Size(1578, 688);
            this.dgAvailableBooks.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgReaders);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1584, 694);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Readers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgReaders
            // 
            this.dgReaders.AllowUserToAddRows = false;
            this.dgReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReaders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReaders.Location = new System.Drawing.Point(3, 3);
            this.dgReaders.MultiSelect = false;
            this.dgReaders.Name = "dgReaders";
            this.dgReaders.ReadOnly = true;
            this.dgReaders.RowHeadersVisible = false;
            this.dgReaders.RowHeadersWidth = 62;
            this.dgReaders.RowTemplate.Height = 28;
            this.dgReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReaders.Size = new System.Drawing.Size(1578, 688);
            this.dgReaders.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1678, 944);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStatisticts);
            this.Controls.Add(this.btnAddReader);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnEntrustOperation);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menus";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEntrustBooks)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailableBooks)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReaders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEntrustOperation;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddReader;
        private System.Windows.Forms.Button btnStatisticts;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgEntrustBooks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgAvailableBooks;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgReaders;
    }
}