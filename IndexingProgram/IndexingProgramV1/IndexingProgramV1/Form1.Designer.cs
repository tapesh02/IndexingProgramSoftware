namespace IndexingProgramV1
{
    partial class startingForm
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
            this.lstBoxFolders = new System.Windows.Forms.ListBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnSearchIndex = new System.Windows.Forms.Button();
            this.txtBoxSearchIndex = new System.Windows.Forms.TextBox();
            this.lstViewIndex = new System.Windows.Forms.ListView();
            this.columnWordOccurrence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearchWord = new System.Windows.Forms.Label();
            this.rchTxtBoxFileDescription = new System.Windows.Forms.RichTextBox();
            this.lblTxtFileView = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.txtBoxUrl = new System.Windows.Forms.TextBox();
            this.btnUrl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxFolders
            // 
            this.lstBoxFolders.FormattingEnabled = true;
            this.lstBoxFolders.Location = new System.Drawing.Point(12, 64);
            this.lstBoxFolders.Name = "lstBoxFolders";
            this.lstBoxFolders.Size = new System.Drawing.Size(169, 238);
            this.lstBoxFolders.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(12, 26);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "add folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(93, 26);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveFolder.TabIndex = 2;
            this.btnRemoveFolder.Text = "remove folder";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // btnSearchIndex
            // 
            this.btnSearchIndex.Location = new System.Drawing.Point(321, 23);
            this.btnSearchIndex.Name = "btnSearchIndex";
            this.btnSearchIndex.Size = new System.Drawing.Size(75, 23);
            this.btnSearchIndex.TabIndex = 5;
            this.btnSearchIndex.Text = "search";
            this.btnSearchIndex.UseVisualStyleBackColor = true;
            this.btnSearchIndex.Click += new System.EventHandler(this.btnSearchIndex_Click);
            // 
            // txtBoxSearchIndex
            // 
            this.txtBoxSearchIndex.Location = new System.Drawing.Point(204, 26);
            this.txtBoxSearchIndex.Name = "txtBoxSearchIndex";
            this.txtBoxSearchIndex.Size = new System.Drawing.Size(102, 20);
            this.txtBoxSearchIndex.TabIndex = 6;
            // 
            // lstViewIndex
            // 
            this.lstViewIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWordOccurrence,
            this.columnFileName,
            this.columnFolderName});
            this.lstViewIndex.FullRowSelect = true;
            this.lstViewIndex.GridLines = true;
            this.lstViewIndex.Location = new System.Drawing.Point(204, 100);
            this.lstViewIndex.MultiSelect = false;
            this.lstViewIndex.Name = "lstViewIndex";
            this.lstViewIndex.Size = new System.Drawing.Size(192, 202);
            this.lstViewIndex.TabIndex = 7;
            this.lstViewIndex.UseCompatibleStateImageBehavior = false;
            this.lstViewIndex.View = System.Windows.Forms.View.Details;
            this.lstViewIndex.SelectedIndexChanged += new System.EventHandler(this.lstViewIndex_SelectedIndexChanged);
            // 
            // columnWordOccurrence
            // 
            this.columnWordOccurrence.Text = "occurrence";
            this.columnWordOccurrence.Width = 70;
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "file";
            this.columnFileName.Width = 70;
            // 
            // columnFolderName
            // 
            this.columnFolderName.Text = "folder";
            this.columnFolderName.Width = 70;
            // 
            // lblSearchWord
            // 
            this.lblSearchWord.AutoSize = true;
            this.lblSearchWord.Location = new System.Drawing.Point(233, 64);
            this.lblSearchWord.Name = "lblSearchWord";
            this.lblSearchWord.Size = new System.Drawing.Size(0, 13);
            this.lblSearchWord.TabIndex = 8;
            // 
            // rchTxtBoxFileDescription
            // 
            this.rchTxtBoxFileDescription.Location = new System.Drawing.Point(425, 100);
            this.rchTxtBoxFileDescription.Name = "rchTxtBoxFileDescription";
            this.rchTxtBoxFileDescription.Size = new System.Drawing.Size(222, 202);
            this.rchTxtBoxFileDescription.TabIndex = 9;
            this.rchTxtBoxFileDescription.Text = "";
            // 
            // lblTxtFileView
            // 
            this.lblTxtFileView.AutoSize = true;
            this.lblTxtFileView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtFileView.Location = new System.Drawing.Point(420, 55);
            this.lblTxtFileView.Name = "lblTxtFileView";
            this.lblTxtFileView.Size = new System.Drawing.Size(0, 26);
            this.lblTxtFileView.TabIndex = 10;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(351, 319);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(115, 30);
            this.btnViewReport.TabIndex = 13;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.IncludeSubdirectories = true;
            //this.fileSystemWatcher.Path = "C:\\Users\\Dell\\Dropbox";
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            // 
            // txtBoxUrl
            // 
            this.txtBoxUrl.Location = new System.Drawing.Point(425, 23);
            this.txtBoxUrl.Name = "txtBoxUrl";
            this.txtBoxUrl.Size = new System.Drawing.Size(143, 20);
            this.txtBoxUrl.TabIndex = 14;
            this.txtBoxUrl.Text = "http://www.example.com";
            // 
            // btnUrl
            // 
            this.btnUrl.Location = new System.Drawing.Point(575, 23);
            this.btnUrl.Name = "btnUrl";
            this.btnUrl.Size = new System.Drawing.Size(75, 23);
            this.btnUrl.TabIndex = 15;
            this.btnUrl.Text = "Extract url";
            this.btnUrl.UseVisualStyleBackColor = true;
            this.btnUrl.Click += new System.EventHandler(this.btnUrl_Click);
            // 
            // startingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 352);
            this.Controls.Add(this.btnUrl);
            this.Controls.Add(this.txtBoxUrl);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lblTxtFileView);
            this.Controls.Add(this.rchTxtBoxFileDescription);
            this.Controls.Add(this.lblSearchWord);
            this.Controls.Add(this.lstViewIndex);
            this.Controls.Add(this.txtBoxSearchIndex);
            this.Controls.Add(this.btnSearchIndex);
            this.Controls.Add(this.btnRemoveFolder);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.lstBoxFolders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "startingForm";
            this.Text = "Index Program";
            this.Load += new System.EventHandler(this.startingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxFolders;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnSearchIndex;
        private System.Windows.Forms.TextBox txtBoxSearchIndex;
        private System.Windows.Forms.ListView lstViewIndex;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnFolderName;
        private System.Windows.Forms.ColumnHeader columnWordOccurrence;
        private System.Windows.Forms.Label lblSearchWord;
        private System.Windows.Forms.RichTextBox rchTxtBoxFileDescription;
        private System.Windows.Forms.Label lblTxtFileView;
        private System.Windows.Forms.Button btnViewReport;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.TextBox txtBoxUrl;
    }
}

