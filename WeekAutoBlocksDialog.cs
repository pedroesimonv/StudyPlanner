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
    public partial class WeekAutoBlocksDialog : Form
    {
        public enum ShiftType {
            Libre0,   // sin estudio
            Libre1,   // 1 bloque profundo
            Libre2,   // 2 bloques profundos
            Manana,   // trabajas de mañana (06-14)
            Tarde     // trabajas de tarde (14-22)
                      }
        public WeekAutoBlocksDialog()
        {
            InitializeComponent();
            dtpWeekStart.Format = DateTimePickerFormat.Short;

            var items = new object[]
{
    ShiftType.Libre0,
    ShiftType.Libre1,
    ShiftType.Libre2,
    ShiftType.Manana,
    ShiftType.Tarde
};



            cmbMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTue.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWed.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSun.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbMon.Items.AddRange(items);
            cmbTue.Items.AddRange(items);
            cmbWed.Items.AddRange(items);
            cmbThu.Items.AddRange(items);
            cmbFri.Items.AddRange(items);
            cmbSat.Items.AddRange(items);
            cmbSun.Items.AddRange(items);

            // Defaults típicos (puedes cambiarlos)
            cmbMon.SelectedItem = ShiftType.Manana;
            cmbTue.SelectedItem = ShiftType.Manana;
            cmbWed.SelectedItem = ShiftType.Manana;
            cmbThu.SelectedItem = ShiftType.Manana;
            cmbFri.SelectedItem = ShiftType.Manana;

            // Sábado normalmente libre (2 profundos), domingo libre (1 o 0 según prefieras)
            cmbSat.SelectedItem = ShiftType.Libre2;
            cmbSun.SelectedItem = ShiftType.Libre1;


            chkReplaceWeek.Checked = true;
        }

        public bool ReplaceWeekBlocks => chkReplaceWeek.Checked;

        public DateTime GetWeekMonday()
        {
            // Convierte cualquier fecha seleccionada al LUNES de esa semana
            var d = dtpWeekStart.Value.Date;
            int diff = ((int)d.DayOfWeek + 6) % 7; // Monday=0 ... Sunday=6
            return d.AddDays(-diff);
        }

        public Dictionary<DayOfWeek, ShiftType> GetShifts()
        {
            return new Dictionary<DayOfWeek, ShiftType>
            {
                { DayOfWeek.Monday,   (ShiftType)cmbMon.SelectedItem! },
                { DayOfWeek.Tuesday,  (ShiftType)cmbTue.SelectedItem! },
                { DayOfWeek.Wednesday,(ShiftType)cmbWed.SelectedItem! },
                { DayOfWeek.Thursday, (ShiftType)cmbThu.SelectedItem! },
                { DayOfWeek.Friday,   (ShiftType)cmbFri.SelectedItem! },
                { DayOfWeek.Saturday, (ShiftType)cmbSat.SelectedItem! },
                { DayOfWeek.Sunday,   (ShiftType)cmbSun.SelectedItem! },
            };
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
