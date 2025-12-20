namespace StudyPlannerWinForms
{
    partial class TimeBlockDialog
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
            dtpBlockDate = new DateTimePicker();
            dtpBlockStart = new DateTimePicker();
            dtpBlockEnd = new DateTimePicker();
            lblFecha_ = new Label();
            lblInicio_ = new Label();
            lblFin_ = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // dtpBlockDate
            // 
            dtpBlockDate.Format = DateTimePickerFormat.Short;
            dtpBlockDate.Location = new Point(39, 59);
            dtpBlockDate.Name = "dtpBlockDate";
            dtpBlockDate.Size = new Size(200, 23);
            dtpBlockDate.TabIndex = 0;
            // 
            // dtpBlockStart
            // 
            dtpBlockStart.Format = DateTimePickerFormat.Time;
            dtpBlockStart.Location = new Point(273, 59);
            dtpBlockStart.Name = "dtpBlockStart";
            dtpBlockStart.ShowUpDown = true;
            dtpBlockStart.Size = new Size(200, 23);
            dtpBlockStart.TabIndex = 1;
            // 
            // dtpBlockEnd
            // 
            dtpBlockEnd.Format = DateTimePickerFormat.Time;
            dtpBlockEnd.Location = new Point(500, 59);
            dtpBlockEnd.Name = "dtpBlockEnd";
            dtpBlockEnd.ShowUpDown = true;
            dtpBlockEnd.Size = new Size(200, 23);
            dtpBlockEnd.TabIndex = 2;
            // 
            // lblFecha_
            // 
            lblFecha_.AutoSize = true;
            lblFecha_.Location = new Point(45, 32);
            lblFecha_.Name = "lblFecha_";
            lblFecha_.Size = new Size(38, 15);
            lblFecha_.TabIndex = 3;
            lblFecha_.Text = "Fecha";
            // 
            // lblInicio_
            // 
            lblInicio_.AutoSize = true;
            lblInicio_.Location = new Point(277, 36);
            lblInicio_.Name = "lblInicio_";
            lblInicio_.Size = new Size(36, 15);
            lblInicio_.TabIndex = 4;
            lblInicio_.Text = "Inicio";
            // 
            // lblFin_
            // 
            lblFin_.AutoSize = true;
            lblFin_.Location = new Point(500, 36);
            lblFin_.Name = "lblFin_";
            lblFin_.Size = new Size(23, 15);
            lblFin_.TabIndex = 5;
            lblFin_.Text = "Fin";
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(221, 171);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(343, 171);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TimeBlockDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblFin_);
            Controls.Add(lblInicio_);
            Controls.Add(lblFecha_);
            Controls.Add(dtpBlockEnd);
            Controls.Add(dtpBlockStart);
            Controls.Add(dtpBlockDate);
            Name = "TimeBlockDialog";
            Text = "TimeBlockDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpBlockDate;
        private DateTimePicker dtpBlockStart;
        private DateTimePicker dtpBlockEnd;
        private Label lblFecha_;
        private Label lblInicio_;
        private Label lblFin_;
        private Button btnOk;
        private Button btnCancel;
    }
}