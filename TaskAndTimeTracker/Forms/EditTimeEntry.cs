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
using TaskAndTimeTracker.Models;

namespace TaskAndTimeTracker.Forms
{
    public partial class EditTimeEntry : Form
    {
        public TimeLog timeLogEntry { get; set; }
        public TimeLog prevTimeLogEntry { get; set; }

        public EditTimeEntry()
        {
            InitializeComponent();
        }

        private void EditTimeEntry_Load(object sender, EventArgs e)
        {
            dpDate.Value = timeLogEntry.DateLogged;
            dpTime.Value = timeLogEntry.DateLogged;
            txtDescription.Text = timeLogEntry.Description;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            timeLogEntry.DateLogged = DateTime.Parse(dpDate.Value.ToString("yyyy/MM/dd") + " " + dpTime.Value.ToString("HH:mm:ss"));
            timeLogEntry.Description = txtDescription.Text;

            double duration = (timeLogEntry.DateLogged - prevTimeLogEntry.DateLogged).TotalSeconds;
            string durationString = Helper.GetDurationString(duration);

            timeLogEntry.Duration = duration;
            timeLogEntry.DurationString = durationString;

            using (var session = DataDocumentStore.Instance.OpenSession())
            {                
                session.Store(timeLogEntry);
                session.SaveChanges();
            }

            this.Close();
        }
    }
}
