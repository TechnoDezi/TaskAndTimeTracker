namespace TaskAndTimeTracker
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewEntryDescription = new System.Windows.Forms.TextBox();
            this.btnAddNewEntry = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpFromDateSearch = new System.Windows.Forms.DateTimePicker();
            this.dpToDateSearch = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescriptionSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateLogged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDurationString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWorkStartTime = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add new entry";
            // 
            // txtNewEntryDescription
            // 
            this.txtNewEntryDescription.Location = new System.Drawing.Point(15, 25);
            this.txtNewEntryDescription.Multiline = true;
            this.txtNewEntryDescription.Name = "txtNewEntryDescription";
            this.txtNewEntryDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewEntryDescription.Size = new System.Drawing.Size(594, 69);
            this.txtNewEntryDescription.TabIndex = 1;
            this.txtNewEntryDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewEntryDescription_KeyUp);
            // 
            // btnAddNewEntry
            // 
            this.btnAddNewEntry.Location = new System.Drawing.Point(615, 25);
            this.btnAddNewEntry.Name = "btnAddNewEntry";
            this.btnAddNewEntry.Size = new System.Drawing.Size(75, 69);
            this.btnAddNewEntry.TabIndex = 2;
            this.btnAddNewEntry.Text = "Add";
            this.btnAddNewEntry.UseVisualStyleBackColor = true;
            this.btnAddNewEntry.Click += new System.EventHandler(this.btnAddNewEntry_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From Date:";
            // 
            // dpFromDateSearch
            // 
            this.dpFromDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFromDateSearch.Location = new System.Drawing.Point(77, 147);
            this.dpFromDateSearch.Name = "dpFromDateSearch";
            this.dpFromDateSearch.Size = new System.Drawing.Size(114, 20);
            this.dpFromDateSearch.TabIndex = 5;
            // 
            // dpToDateSearch
            // 
            this.dpToDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpToDateSearch.Location = new System.Drawing.Point(264, 147);
            this.dpToDateSearch.Name = "dpToDateSearch";
            this.dpToDateSearch.Size = new System.Drawing.Size(114, 20);
            this.dpToDateSearch.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Filter:";
            // 
            // txtDescriptionSearch
            // 
            this.txtDescriptionSearch.Location = new System.Drawing.Point(422, 150);
            this.txtDescriptionSearch.Name = "txtDescriptionSearch";
            this.txtDescriptionSearch.Size = new System.Drawing.Size(268, 20);
            this.txtDescriptionSearch.TabIndex = 9;
            this.txtDescriptionSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescriptionSearch_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(696, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cDateLogged,
            this.cDescription,
            this.cDurationString,
            this.Duration});
            this.dgvSearchResults.Location = new System.Drawing.Point(15, 177);
            this.dgvSearchResults.MultiSelect = false;
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.ReadOnly = true;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.Size = new System.Drawing.Size(962, 465);
            this.dgvSearchResults.TabIndex = 11;
            // 
            // cId
            // 
            this.cId.DataPropertyName = "Id";
            this.cId.HeaderText = "ID";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            this.cId.Visible = false;
            // 
            // cDateLogged
            // 
            this.cDateLogged.DataPropertyName = "DateLogged";
            this.cDateLogged.HeaderText = "Date Logged";
            this.cDateLogged.Name = "cDateLogged";
            this.cDateLogged.ReadOnly = true;
            this.cDateLogged.Width = 150;
            // 
            // cDescription
            // 
            this.cDescription.DataPropertyName = "Description";
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.ReadOnly = true;
            this.cDescription.Width = 450;
            // 
            // cDurationString
            // 
            this.cDurationString.DataPropertyName = "DurationString";
            this.cDurationString.HeaderText = "Duration";
            this.cDurationString.Name = "cDurationString";
            this.cDurationString.ReadOnly = true;
            this.cDurationString.Width = 150;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "cDuration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(777, 148);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(714, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Work Start Time:";
            // 
            // txtWorkStartTime
            // 
            this.txtWorkStartTime.Location = new System.Drawing.Point(807, 25);
            this.txtWorkStartTime.Name = "txtWorkStartTime";
            this.txtWorkStartTime.Size = new System.Drawing.Size(85, 20);
            this.txtWorkStartTime.TabIndex = 14;
            this.txtWorkStartTime.Text = "08:15";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Duration:";
            // 
            // lblTotalDuration
            // 
            this.lblTotalDuration.AutoSize = true;
            this.lblTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDuration.Location = new System.Drawing.Point(804, 63);
            this.lblTotalDuration.Name = "lblTotalDuration";
            this.lblTotalDuration.Size = new System.Drawing.Size(0, 13);
            this.lblTotalDuration.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 654);
            this.Controls.Add(this.lblTotalDuration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWorkStartTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDescriptionSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dpToDateSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dpFromDateSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewEntry);
            this.Controls.Add(this.txtNewEntryDescription);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Task and Time Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewEntryDescription;
        private System.Windows.Forms.Button btnAddNewEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFromDateSearch;
        private System.Windows.Forms.DateTimePicker dpToDateSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescriptionSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWorkStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateLogged;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDurationString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDuration;
    }
}

