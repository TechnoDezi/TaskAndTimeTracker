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
                var totalDuration = results.ToList().Select(x => x.Duration).Sum();
                lblTotalDuration.Text = GetDurationString(totalDuration);
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
                AddEntry("Start Work", workStarted, 0);
            }

            //Get Last Entry for today
            TimeLog lastEntry = new TimeLog();
            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                lastEntry = session.Query<TimeLog>().Customize(x => x.WaitForNonStaleResults()).Where(x => x.DateLogged >= startDate && x.DateLogged <= toDate).OrderByDescending(x => x.DateLogged).First();
            }

            //Add entry specified
            double duration = (DateTime.Now - lastEntry.DateLogged).TotalSeconds;
            AddEntry(txtNewEntryDescription.Text, DateTime.Now, duration);

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

        private void AddEntry(string description, DateTime loggedDate, double duration)
        {
            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                string durationString = GetDurationString(duration);

                TimeLog tl = new TimeLog();
                tl.DateLogged = loggedDate;
                tl.Description = description;
                tl.Duration = duration;
                tl.DurationString = durationString;

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
            if (e.KeyCode == Keys.Enter)
            {
                LoadResults();
                txtDescriptionSearch.Focus();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
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
    }
}
