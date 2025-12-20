namespace StudyPlannerWinForms
{
    partial class WeekAutoBlocksDialog
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
            dtpWeekStart = new DateTimePicker();
            cmbMon = new ComboBox();
            cmbTue = new ComboBox();
            cmbWed = new ComboBox();
            cmbThu = new ComboBox();
            cmbFri = new ComboBox();
            cmbSat = new ComboBox();
            cmbSun = new ComboBox();
            lblLunes = new Label();
            lblMartes = new Label();
            lblMiercoles = new Label();
            lblJueves = new Label();
            lblViernes = new Label();
            lblSabado = new Label();
            lblDomingo = new Label();
            chkReplaceWeek = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // dtpWeekStart
            // 
            dtpWeekStart.Location = new Point(12, 12);
            dtpWeekStart.Name = "dtpWeekStart";
            dtpWeekStart.Size = new Size(200, 23);
            dtpWeekStart.TabIndex = 0;
            // 
            // cmbMon
            // 
            cmbMon.FormattingEnabled = true;
            cmbMon.Location = new Point(36, 74);
            cmbMon.Name = "cmbMon";
            cmbMon.Size = new Size(121, 23);
            cmbMon.TabIndex = 1;
            // 
            // cmbTue
            // 
            cmbTue.FormattingEnabled = true;
            cmbTue.Location = new Point(163, 74);
            cmbTue.Name = "cmbTue";
            cmbTue.Size = new Size(121, 23);
            cmbTue.TabIndex = 1;
            // 
            // cmbWed
            // 
            cmbWed.FormattingEnabled = true;
            cmbWed.Location = new Point(290, 74);
            cmbWed.Name = "cmbWed";
            cmbWed.Size = new Size(121, 23);
            cmbWed.TabIndex = 1;
            // 
            // cmbThu
            // 
            cmbThu.FormattingEnabled = true;
            cmbThu.Location = new Point(417, 74);
            cmbThu.Name = "cmbThu";
            cmbThu.Size = new Size(121, 23);
            cmbThu.TabIndex = 1;
            // 
            // cmbFri
            // 
            cmbFri.FormattingEnabled = true;
            cmbFri.Location = new Point(544, 74);
            cmbFri.Name = "cmbFri";
            cmbFri.Size = new Size(121, 23);
            cmbFri.TabIndex = 1;
            // 
            // cmbSat
            // 
            cmbSat.FormattingEnabled = true;
            cmbSat.Location = new Point(36, 118);
            cmbSat.Name = "cmbSat";
            cmbSat.Size = new Size(121, 23);
            cmbSat.TabIndex = 1;
            // 
            // cmbSun
            // 
            cmbSun.FormattingEnabled = true;
            cmbSun.Location = new Point(163, 118);
            cmbSun.Name = "cmbSun";
            cmbSun.Size = new Size(121, 23);
            cmbSun.TabIndex = 1;
            // 
            // lblLunes
            // 
            lblLunes.AutoSize = true;
            lblLunes.Location = new Point(40, 57);
            lblLunes.Name = "lblLunes";
            lblLunes.Size = new Size(38, 15);
            lblLunes.TabIndex = 2;
            lblLunes.Text = "Lunes";
            // 
            // lblMartes
            // 
            lblMartes.AutoSize = true;
            lblMartes.Location = new Point(163, 57);
            lblMartes.Name = "lblMartes";
            lblMartes.Size = new Size(43, 15);
            lblMartes.TabIndex = 2;
            lblMartes.Text = "Martes";
            // 
            // lblMiercoles
            // 
            lblMiercoles.AutoSize = true;
            lblMiercoles.Location = new Point(290, 57);
            lblMiercoles.Name = "lblMiercoles";
            lblMiercoles.Size = new Size(58, 15);
            lblMiercoles.TabIndex = 2;
            lblMiercoles.Text = "Miercoles";
            // 
            // lblJueves
            // 
            lblJueves.AutoSize = true;
            lblJueves.Location = new Point(417, 57);
            lblJueves.Name = "lblJueves";
            lblJueves.Size = new Size(41, 15);
            lblJueves.TabIndex = 2;
            lblJueves.Text = "Jueves";
            // 
            // lblViernes
            // 
            lblViernes.AutoSize = true;
            lblViernes.Location = new Point(544, 57);
            lblViernes.Name = "lblViernes";
            lblViernes.Size = new Size(45, 15);
            lblViernes.TabIndex = 2;
            lblViernes.Text = "Viernes";
            // 
            // lblSabado
            // 
            lblSabado.AutoSize = true;
            lblSabado.Location = new Point(40, 100);
            lblSabado.Name = "lblSabado";
            lblSabado.Size = new Size(46, 15);
            lblSabado.TabIndex = 2;
            lblSabado.Text = "Sabado";
            lblSabado.Click += label6_Click;
            // 
            // lblDomingo
            // 
            lblDomingo.AutoSize = true;
            lblDomingo.Location = new Point(163, 100);
            lblDomingo.Name = "lblDomingo";
            lblDomingo.Size = new Size(57, 15);
            lblDomingo.TabIndex = 2;
            lblDomingo.Text = "Domingo";
            lblDomingo.Click += label6_Click;
            // 
            // chkReplaceWeek
            // 
            chkReplaceWeek.AutoSize = true;
            chkReplaceWeek.Location = new Point(218, 16);
            chkReplaceWeek.Name = "chkReplaceWeek";
            chkReplaceWeek.Size = new Size(208, 19);
            chkReplaceWeek.TabIndex = 3;
            chkReplaceWeek.Text = "Reemplazar huecos de esa semana";
            chkReplaceWeek.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(82, 214);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(163, 214);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // WeekAutoBlocksDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 528);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(chkReplaceWeek);
            Controls.Add(lblViernes);
            Controls.Add(lblJueves);
            Controls.Add(lblMiercoles);
            Controls.Add(lblMartes);
            Controls.Add(lblDomingo);
            Controls.Add(lblSabado);
            Controls.Add(lblLunes);
            Controls.Add(cmbFri);
            Controls.Add(cmbThu);
            Controls.Add(cmbWed);
            Controls.Add(cmbSun);
            Controls.Add(cmbTue);
            Controls.Add(cmbSat);
            Controls.Add(cmbMon);
            Controls.Add(dtpWeekStart);
            Name = "WeekAutoBlocksDialog";
            Text = "WeekAutoBlocksDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpWeekStart;
        private ComboBox cmbMon;
        private ComboBox cmbTue;
        private ComboBox cmbWed;
        private ComboBox cmbThu;
        private ComboBox cmbFri;
        private ComboBox cmbSat;
        private ComboBox cmbSun;
        private Label lblLunes;
        private Label lblMartes;
        private Label lblMiercoles;
        private Label lblJueves;
        private Label lblViernes;
        private Label lblSabado;
        private Label lblDomingo;
        private CheckBox chkReplaceWeek;
        private Button btnOk;
        private Button btnCancel;
    }
}