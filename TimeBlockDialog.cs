using StudyPlannerWinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPlannerWinForms
{
    public partial class TimeBlockDialog : Form
    {
        public TimeBlockDialog()
        {
            InitializeComponent();
            dtpBlockDate.Format = DateTimePickerFormat.Short;

            dtpBlockStart.Format = DateTimePickerFormat.Time;
            dtpBlockStart.ShowUpDown = true;

            dtpBlockEnd.Format = DateTimePickerFormat.Time;
            dtpBlockEnd.ShowUpDown = true;


        }

        public void SetBlock(TimeBlock b)
        {
            dtpBlockDate.Value = b.Date.Date;
            dtpBlockStart.Value = DateTime.Today.Add(b.Start);
            dtpBlockEnd.Value = DateTime.Today.Add(b.End);
        }

        public TimeBlock GetBlock()
        {
            return new TimeBlock
            {
                Date = dtpBlockDate.Value.Date,
                Start = dtpBlockStart.Value.TimeOfDay,
                End = dtpBlockEnd.Value.TimeOfDay
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }


}

