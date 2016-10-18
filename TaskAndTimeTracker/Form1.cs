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
using TaskAndTimeTracker.Forms;

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
                var totalDurationBillable = results.ToList().Where(x => x.Type == "Billable" || x.Type == "Remote Working" || x.Type == "Unknown").Select(x => x.Duration).Sum();
                lblTotalDuration.Text = Helper.GetDurationString(totalDurationBillable);

                var totalDurationNonBillable = results.ToList().Where(x => x.Type == "Non Billable" || x.Type == "Personal").Select(x => x.Duration).Sum();
                lblNonBillable.Text = Helper.GetDurationString(totalDurationNonBillable);

                var totalDuration = results.ToList().Select(x => x.Duration).Sum();
                lblTotalHours.Text = Helper.GetDurationString(totalDuration);
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
                string durationString = Helper.GetDurationString(duration);

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
                using (var pck = new ExcelPackage())
                {
                    //Create Summary Sheet
                    ExcelWorksheet wsSum = pck.Workbook.Worksheets.Add("Summary");
                    DataTable dtSummary = GetTimeLogSummaryForExport(results);
                    wsSum.Cells["A1"].LoadFromDataTable(dtSummary, true);
                    wsSum.Cells.AutoFitColumns();
                    
                    using (ExcelRange rng = wsSum.Cells[1, 1, 1, dtSummary.Columns.Count])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                        rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    //Create Time Log Sheet
                    DataTable dtLog = GetTimeLogForExport(results);
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Time Log");
                    ws.Cells["A1"].LoadFromDataTable(dtLog, true);
                    ws.Cells.AutoFitColumns();
                    
                    using (ExcelRange rng = ws.Cells[1, 1, 1, dtLog.Columns.Count])
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

        private DataTable GetTimeLogSummaryForExport(IQueryable<TimeLog> results)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Start Time");
            dt.Columns.Add("End Time");
            dt.Columns.Add("Billable");
            dt.Columns.Add("Non Billable");
            dt.Columns.Add("Total Hours Worked");

            //Get unique days
            var days = results.ToList().Select(x => x.DateLogged.ToString("yyyy/MM/dd")).Distinct();

            foreach(string day in days)
            {
                DataRow dtRow = dt.NewRow();

                dtRow["Date"] = day;

                var dayList = results.ToList().Where(x => x.DateLogged.ToString("yyyy/MM/dd") == day);
                dtRow["Start Time"] = dayList.Select(x => x.DateLogged).Min().ToString("HH:mm:ss");
                dtRow["End Time"] = dayList.Select(x => x.DateLogged).Max().ToString("HH:mm:ss");

                var totalDurationBillable = dayList.Where(x => x.Type == "Billable" || x.Type == "Remote Working" || x.Type == "Unknown").Select(x => x.Duration).Sum();
                dtRow["Billable"] = Helper.GetDurationString(totalDurationBillable);

                var totalDurationNonBillable = dayList.Where(x => x.Type == "Non Billable" || x.Type == "Personal").Select(x => x.Duration).Sum();
                dtRow["Non Billable"] = Helper.GetDurationString(totalDurationNonBillable);

                var totalDuration = dayList.Select(x => x.Duration).Sum();
                dtRow["Total Hours Worked"] = Helper.GetDurationString(totalDuration);

                dt.Rows.Add(dtRow);
            }

            return dt;
        }

        private DataTable GetTimeLogForExport(IQueryable<TimeLog> results)
        {
            DataTable dtLog = new DataTable();
            dtLog.Columns.Add("Date Logged");
            dtLog.Columns.Add("Day");
            dtLog.Columns.Add("Month");
            dtLog.Columns.Add("Year");
            dtLog.Columns.Add("Description");
            dtLog.Columns.Add("Duration");
            dtLog.Columns.Add("Minutes");
            dtLog.Columns.Add("Work Type");

            foreach (var item in results)
            {
                DataRow dtRow = dtLog.NewRow();
                TimeSpan duration = TimeSpan.FromSeconds(item.Duration);

                dtRow["Date Logged"] = item.DateLogged;
                dtRow["Month"] = item.DateLogged.ToString("MMMM");
                dtRow["Year"] = item.DateLogged.ToString("yyyy");
                dtRow["Day"] = item.DateLogged.ToString("dd");
                dtRow["Description"] = item.Description;
                dtRow["Duration"] = item.DurationString;
                dtRow["Minutes"] = duration.TotalMinutes;
                dtRow["Work Type"] = (string.IsNullOrEmpty(item.Type)) ? "Unknown" : item.Type;

                dtLog.Rows.Add(dtRow);
            }

            return dtLog;
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

        private void tsmiEditLogEntry_Click(object sender, EventArgs e)
        {
            if (dgvSearchResults.SelectedRows.Count == 1)
            {
                EditTimeEntry edit = new EditTimeEntry();
                edit.timeLogEntry = (TimeLog)dgvSearchResults.SelectedRows[0].DataBoundItem;
                edit.prevTimeLogEntry = GetPreviousEntry(edit.timeLogEntry);
                edit.ShowDialog();

                LoadResults();
            }
        }

        private TimeLog GetPreviousEntry(TimeLog currentItem)
        {
            IQueryable<TimeLog> results = QueryResultset();

            Int32 index = results.ToList().IndexOf(results.Where(x => x.Id == currentItem.Id).First());
            TimeLog prevEntry = results.ToList().ElementAt(index - 1);

            return prevEntry;
        }
    }
}
