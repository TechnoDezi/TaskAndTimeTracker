using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskAndTimeTracker.Classes;
using TaskAndTimeTracker.Classes.Indexes;
using TaskAndTimeTracker.Models;
using Raven.Client;
using Raven;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace TaskAndTimeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDefaults();
            LoadResults();

            txtNewEntryDescription.Focus();
        }

        private void LoadResults()
        {
            var results = QueryResultset();

            dgvSearchResults.DataSource = results.ToList();

            if (results.Count() > 0)
            {
                var totalDuration = results.ToList().Where(x => x.Type == "Billable" || x.Type == "Remote Working" || x.Type == "Unknown").Select(x => x.Duration).Sum();
                lblTotalDuration.Text = GetDurationString(totalDuration);

                var totalDurationNonBillable = results.ToList().Where(x => x.Type == "Non Billable" || x.Type == "Personal").Select(x => x.Duration).Sum();
                lblNonBillable.Text = GetDurationString(totalDurationNonBillable);
            }
            else
            {
                lblTotalDuration.Text = "";
            }
        }

        private void SetDefaults()
        {
            dpFromDateSearch.Value = DateTime.Now;
            dpToDateSearch.Value = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void btnAddNewEntry_Click(object sender, EventArgs e)
        {
            AddNewEntry();
        }

        private void AddNewEntry()
        {
            DateTime startDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " 00:00");
            DateTime toDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59");
            DateTime workStarted = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " " + txtWorkStartTime.Text);
            
            //Get results for today
            IQueryable<TimeLog> results;
            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                results = session.Query<TimeLog>().Where(x => x.DateLogged >= startDate && x.DateLogged <= toDate);
            }

            if (results != null && results.Count() == 0)
            {
                //Add first entry
                AddEntry("Start Work", workStarted, 0, GetTypeString(true));
            }

            //Get Last Entry for today
            TimeLog lastEntry = new TimeLog();
            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                lastEntry = session.Query<TimeLog>().Customize(x => x.WaitForNonStaleResults()).Where(x => x.DateLogged >= startDate && x.DateLogged <= toDate).OrderByDescending(x => x.DateLogged).First();
            }

            //Add entry specified
            double duration = (DateTime.Now - lastEntry.DateLogged).TotalSeconds;
            AddEntry(txtNewEntryDescription.Text, DateTime.Now, duration, GetTypeString(false));

            txtNewEntryDescription.Text = "";
            txtNewEntryDescription.Focus();

            LoadResults();
        }

        private string GetDurationString(double secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);

            return answer;
        }

        private string GetTypeString(bool firstEntry)
        {
            string returnValue = "Unknown";

            if(firstEntry)
            {
                returnValue = "Non Billable";
            }
            else if (radBillable.Checked)
            {
                returnValue = "Billable";
            }
            else if (radNonBillable.Checked)
            {
                returnValue = "Non Billable";
            }
            else if (radPersonal.Checked)
            {
                returnValue = "Personal";
            }
            else if (radRemoteWorking.Checked)
            {
                returnValue = "Remote Working";
            }

            return returnValue;
        }

        private void SetRadioButtonsByType(string workType)
        {
            workType = (string.IsNullOrEmpty(workType)) ? "Unknown" : workType;

            radBillable.Checked = false;
            radNonBillable.Checked = false;
            radPersonal.Checked = false;
            radRemoteWorking.Checked = false;

            switch (workType)
            {
                case "Unknown": radBillable.Checked = true;break;
                case "Non Billable": radNonBillable.Checked = true; break;
                case "Billable": radBillable.Checked = true; break;
                case "Personal": radPersonal.Checked = true; break;
                case "Remote Working": radRemoteWorking.Checked = true; break;
            }
        }

        private void AddEntry(string description, DateTime loggedDate, double duration, string workType)
        {
            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                string durationString = GetDurationString(duration);

                TimeLog tl = new TimeLog();
                tl.DateLogged = loggedDate;
                tl.Description = description.TrimEnd(Environment.NewLine.ToCharArray());
                tl.Duration = duration;
                tl.DurationString = durationString;
                tl.Type = workType;

                session.Store(tl);
                session.SaveChanges();
            }
        }

        private void txtNewEntryDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddNewEntry();
            }
        }

        private void txtDescriptionSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadResults();
                txtDescriptionSearch.Focus();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(saveFileDialog1.FileName);
            }
        }

        private IQueryable<TimeLog> QueryResultset()
        {
            DateTime startDate = DateTime.Parse(dpFromDateSearch.Value.ToString("yyyy/MM/dd") + " 00:00");
            DateTime toDate = DateTime.Parse(dpToDateSearch.Value.ToString("yyyy/MM/dd") + " 23:59:59");

            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                return session.Query<TimeLog, TimeLog_Description>()
                    .Customize(x => x.WaitForNonStaleResults())
                    .Search(x => x.Description, "*" + txtDescriptionSearch.Text + "*", escapeQueryOptions: EscapeQueryOptions.AllowAllWildcards)
                    .Where(x => x.DateLogged >= startDate && x.DateLogged <= toDate)
                    .OrderBy(x => x.DateLogged);
            };
        }

        private void ExportExcel(string fileName)
        {
            var results = QueryResultset();

            if (results.Count() > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date Logged");
                dt.Columns.Add("Month");
                dt.Columns.Add("Year");
                dt.Columns.Add("Description");
                dt.Columns.Add("Duration");
                dt.Columns.Add("Minutes");
                dt.Columns.Add("Work Type");

                foreach (var item in results)
                {
                    DataRow dtRow = dt.NewRow();
                    TimeSpan duration = TimeSpan.FromSeconds(item.Duration);

                    dtRow["Date Logged"] = item.DateLogged;
                    dtRow["Month"] = item.DateLogged.ToString("MMMM");
                    dtRow["Year"] = item.DateLogged.ToString("yyyy");
                    dtRow["Description"] = item.Description;
                    dtRow["Duration"] = item.DurationString;
                    dtRow["Minutes"] = duration.TotalMinutes;
                    dtRow["Work Type"] = (string.IsNullOrEmpty(item.Type)) ? "Unknown" : item.Type;

                    dt.Rows.Add(dtRow);
                }

                using (var pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    ws.Cells.AutoFitColumns();

                    // Add some styling
                    using (ExcelRange rng = ws.Cells[1, 1, 1, dt.Columns.Count])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                        rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    pck.SaveAs(new FileInfo(fileName));

                    MessageBox.Show("Exporting to Excel file success.", "Success");
                }
            }
        }

        private void radBillable_CheckedChanged(object sender, EventArgs e)
        {
            txtNewEntryDescription.Focus();
        }

        private void radNonBillable_CheckedChanged(object sender, EventArgs e)
        {
            txtNewEntryDescription.Focus();
        }

        private void radPersonal_CheckedChanged(object sender, EventArgs e)
        {
            txtNewEntryDescription.Focus();
        }

        private void radRemoteWorking_CheckedChanged(object sender, EventArgs e)
        {
            txtNewEntryDescription.Focus();
        }

        private void dgvSearchResults_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count == 1)
            {
                TimeLog tl = ((TimeLog)dgvSearchResults.SelectedRows[0].DataBoundItem);
                txtNewEntryDescription.Text = tl.Description;
                SetRadioButtonsByType(tl.Type);
            }
            else
            {
                txtNewEntryDescription.Text = "";
                SetRadioButtonsByType("");
            }
        }

        private void txtNewEntryDescription_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnDeleteSelectedEntry_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you wish to delete the selected entries?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in dgvSearchResults.SelectedRows)
                    {
                        TimeLog entry = (TimeLog)item.DataBoundItem;

                        using (var session = DataDocumentStore.Instance.OpenSession())
                        {
                            session.Delete(entry.Id);
                            session.SaveChanges();
                        };
                    }

                    LoadResults();
                }
            }
        }

        private void txtNewEntryDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
