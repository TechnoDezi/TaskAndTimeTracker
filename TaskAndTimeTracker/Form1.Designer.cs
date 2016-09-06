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
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWorkStartTime = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            this.lblNonBillable = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.radBillable = new System.Windows.Forms.RadioButton();
            this.radNonBillable = new System.Windows.Forms.RadioButton();
            this.radPersonal = new System.Windows.Forms.RadioButton();
            this.radRemoteWorking = new System.Windows.Forms.RadioButton();
            this.btnDeleteSelectedEntry = new System.Windows.Forms.Button();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.txtNewEntryDescription.Location = new System.Drawing.Point(15, 60);
            this.txtNewEntryDescription.Multiline = true;
            this.txtNewEntryDescription.Name = "txtNewEntryDescription";
            this.txtNewEntryDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewEntryDescription.Size = new System.Drawing.Size(594, 69);
            this.txtNewEntryDescription.TabIndex = 1;
            this.txtNewEntryDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewEntryDescription_KeyDown);
            this.txtNewEntryDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewEntryDescription_KeyPress);
            this.txtNewEntryDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewEntryDescription_KeyUp);
            // 
            // btnAddNewEntry
            // 
            this.btnAddNewEntry.Location = new System.Drawing.Point(615, 60);
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
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From Date:";
            // 
            // dpFromDateSearch
            // 
            this.dpFromDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFromDateSearch.Location = new System.Drawing.Point(77, 176);
            this.dpFromDateSearch.Name = "dpFromDateSearch";
            this.dpFromDateSearch.Size = new System.Drawing.Size(114, 20);
            this.dpFromDateSearch.TabIndex = 5;
            // 
            // dpToDateSearch
            // 
            this.dpToDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpToDateSearch.Location = new System.Drawing.Point(264, 176);
            this.dpToDateSearch.Name = "dpToDateSearch";
            this.dpToDateSearch.Size = new System.Drawing.Size(114, 20);
            this.dpToDateSearch.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Filter:";
            // 
            // txtDescriptionSearch
            // 
            this.txtDescriptionSearch.Location = new System.Drawing.Point(422, 179);
            this.txtDescriptionSearch.Name = "txtDescriptionSearch";
            this.txtDescriptionSearch.Size = new System.Drawing.Size(268, 20);
            this.txtDescriptionSearch.TabIndex = 9;
            this.txtDescriptionSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescriptionSearch_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(696, 177);
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
            this.Duration,
            this.cType});
            this.dgvSearchResults.Location = new System.Drawing.Point(15, 208);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.ReadOnly = true;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.Size = new System.Drawing.Size(974, 538);
            this.dgvSearchResults.TabIndex = 11;
            this.dgvSearchResults.Click += new System.EventHandler(this.dgvSearchResults_Click);
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
            // cType
            // 
            this.cType.DataPropertyName = "Type";
            this.cType.HeaderText = "Type";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            this.cType.Width = 150;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(777, 177);
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
            this.label7.Location = new System.Drawing.Point(739, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Billable:";
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
            // lblNonBillable
            // 
            this.lblNonBillable.AutoSize = true;
            this.lblNonBillable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonBillable.Location = new System.Drawing.Point(804, 81);
            this.lblNonBillable.Name = "lblNonBillable";
            this.lblNonBillable.Size = new System.Drawing.Size(0, 13);
            this.lblNonBillable.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(716, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Non Billable:";
            // 
            // radBillable
            // 
            this.radBillable.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBillable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBillable.Checked = true;
            this.radBillable.Location = new System.Drawing.Point(15, 30);
            this.radBillable.Name = "radBillable";
            this.radBillable.Size = new System.Drawing.Size(104, 24);
            this.radBillable.TabIndex = 19;
            this.radBillable.TabStop = true;
            this.radBillable.Text = "Billable";
            this.radBillable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBillable.UseVisualStyleBackColor = true;
            this.radBillable.CheckedChanged += new System.EventHandler(this.radBillable_CheckedChanged);
            // 
            // radNonBillable
            // 
            this.radNonBillable.Appearance = System.Windows.Forms.Appearance.Button;
            this.radNonBillable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNonBillable.Location = new System.Drawing.Point(125, 30);
            this.radNonBillable.Name = "radNonBillable";
            this.radNonBillable.Size = new System.Drawing.Size(104, 24);
            this.radNonBillable.TabIndex = 20;
            this.radNonBillable.Text = "Non Billable";
            this.radNonBillable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNonBillable.UseVisualStyleBackColor = true;
            this.radNonBillable.CheckedChanged += new System.EventHandler(this.radNonBillable_CheckedChanged);
            // 
            // radPersonal
            // 
            this.radPersonal.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPersonal.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPersonal.Location = new System.Drawing.Point(235, 30);
            this.radPersonal.Name = "radPersonal";
            this.radPersonal.Size = new System.Drawing.Size(104, 24);
            this.radPersonal.TabIndex = 21;
            this.radPersonal.Text = "Personal";
            this.radPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPersonal.UseVisualStyleBackColor = true;
            this.radPersonal.CheckedChanged += new System.EventHandler(this.radPersonal_CheckedChanged);
            // 
            // radRemoteWorking
            // 
            this.radRemoteWorking.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRemoteWorking.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRemoteWorking.Location = new System.Drawing.Point(345, 30);
            this.radRemoteWorking.Name = "radRemoteWorking";
            this.radRemoteWorking.Size = new System.Drawing.Size(104, 24);
            this.radRemoteWorking.TabIndex = 22;
            this.radRemoteWorking.Text = "Remote Working";
            this.radRemoteWorking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRemoteWorking.UseVisualStyleBackColor = true;
            this.radRemoteWorking.CheckedChanged += new System.EventHandler(this.radRemoteWorking_CheckedChanged);
            // 
            // btnDeleteSelectedEntry
            // 
            this.btnDeleteSelectedEntry.Location = new System.Drawing.Point(858, 177);
            this.btnDeleteSelectedEntry.Name = "btnDeleteSelectedEntry";
            this.btnDeleteSelectedEntry.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteSelectedEntry.TabIndex = 23;
            this.btnDeleteSelectedEntry.Text = "Delete Selected";
            this.btnDeleteSelectedEntry.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedEntry.Click += new System.EventHandler(this.btnDeleteSelectedEntry_Click);
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHours.Location = new System.Drawing.Point(804, 101);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(0, 13);
            this.lblTotalHours.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(748, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Total:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 758);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDeleteSelectedEntry);
            this.Controls.Add(this.radRemoteWorking);
            this.Controls.Add(this.radPersonal);
            this.Controls.Add(this.radNonBillable);
            this.Controls.Add(this.radBillable);
            this.Controls.Add(this.lblNonBillable);
            this.Controls.Add(this.label9);
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDuration;
        private System.Windows.Forms.Label lblNonBillable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radBillable;
        private System.Windows.Forms.RadioButton radNonBillable;
        private System.Windows.Forms.RadioButton radPersonal;
        private System.Windows.Forms.RadioButton radRemoteWorking;
        private System.Windows.Forms.Button btnDeleteSelectedEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateLogged;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDurationString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label label10;
    }
}

