namespace StudyPlannerWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            mnuSave = new ToolStripMenuItem();
            mnuLoad = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            exportarToolStripMenuItem = new ToolStripMenuItem();
            mnuExportCsv = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            statusMain = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tabMain = new TabControl();
            tabSubjects = new TabPage();
            splitSubjects = new SplitContainer();
            dgvSubjects = new DataGridView();
            colSubName = new DataGridViewTextBoxColumn();
            colSubCourse = new DataGridViewTextBoxColumn();
            colSubPriority = new DataGridViewTextBoxColumn();
            colSubExam = new DataGridViewTextBoxColumn();
            colSubDeep = new DataGridViewTextBoxColumn();
            colSubLight = new DataGridViewTextBoxColumn();
            colSubAct = new DataGridViewTextBoxColumn();
            colSubActive = new DataGridViewCheckBoxColumn();
            gbPrioridad = new GroupBox();
            lblObjetivoProfundo = new Label();
            numTargetDeep = new NumericUpDown();
            numTargetAct = new NumericUpDown();
            lblObjetivoLigth = new Label();
            lblObjetivoActividades = new Label();
            numTargetLight = new NumericUpDown();
            gbActividades = new GroupBox();
            lbDateTask = new Label();
            lbTask = new Label();
            txtAct5 = new TextBox();
            dtpAct5 = new DateTimePicker();
            dtpAct4 = new DateTimePicker();
            txtAct4 = new TextBox();
            txtAct1 = new TextBox();
            dtpAct1 = new DateTimePicker();
            dtpAct3 = new DateTimePicker();
            txtAct3 = new TextBox();
            dtpAct2 = new DateTimePicker();
            txtAct2 = new TextBox();
            gbEvaluationDate = new GroupBox();
            chkHasExam = new CheckBox();
            dtpSubExam = new DateTimePicker();
            gbTask = new GroupBox();
            lblTemaActual = new Label();
            txtSubTopic = new TextBox();
            lblDondeDeje = new Label();
            txtSubCheckpoint = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSubNew = new Button();
            btnSubSave = new Button();
            btnSubDelete = new Button();
            btnSubClear = new Button();
            gbSubjectEditor = new GroupBox();
            lblActiva = new Label();
            chkSubActive = new CheckBox();
            numSubPriority = new NumericUpDown();
            lblPrioridad = new Label();
            cmbSubCourse = new ComboBox();
            lblCurso = new Label();
            txtSubName = new TextBox();
            lblNombre = new Label();
            tabWeek = new TabPage();
            splitContainer1 = new SplitContainer();
            gbShifts = new GroupBox();
            dgvShifts = new DataGridView();
            colShiftDate = new DataGridViewTextBoxColumn();
            colShiftDay = new DataGridViewTextBoxColumn();
            colShiftType = new DataGridViewComboBoxColumn();
            colShiftNotes = new DataGridViewTextBoxColumn();
            gbBlocks = new GroupBox();
            flpBlocksButtons = new FlowLayoutPanel();
            btnBlockRemove = new Button();
            btnBlockAdd = new Button();
            btnBlockEdit = new Button();
            dgvBlocks = new DataGridView();
            colBlockDate = new DataGridViewTextBoxColumn();
            colBlockStart = new DataGridViewTextBoxColumn();
            colBlockEnd = new DataGridViewTextBoxColumn();
            colBlockDuration = new DataGridViewTextBoxColumn();
            colBlockHint = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnWeekClear = new Button();
            btnWeekAutoBlocks = new Button();
            btnWeekLoad = new Button();
            dtpWeekStart = new DateTimePicker();
            lblInicioSemana = new Label();
            tabPlan = new TabPage();
            pnlPlanSummary = new Panel();
            panel2 = new Panel();
            lbComple = new Label();
            lblChechlpoint = new Label();
            lblTema = new Label();
            btnPlanSessionSave = new Button();
            chkPlanCompleted = new CheckBox();
            txtPlanCheckpoint = new TextBox();
            txtPlanTopic = new TextBox();
            lvSummary = new ListView();
            Asignatura = new ColumnHeader();
            Objetivo = new ColumnHeader();
            Planificado = new ColumnHeader();
            lblResumenSemanal = new Label();
            gbAvisos = new GroupBox();
            lblWarnings = new Label();
            dgvPlan = new DataGridView();
            pnlPlanTop = new Panel();
            btnPlanClear = new Button();
            btnPlanCopy = new Button();
            btnPlanExportCsv = new Button();
            btnPlanRegenerate = new Button();
            btnPlanGenerate = new Button();
            colPlanDate = new DataGridViewTextBoxColumn();
            colPlanStart = new DataGridViewTextBoxColumn();
            colPlanEnd = new DataGridViewTextBoxColumn();
            colPlanSubject = new DataGridViewTextBoxColumn();
            colPlanType = new DataGridViewTextBoxColumn();
            colPlanStrategy = new DataGridViewTextBoxColumn();
            colPlanNotes = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            statusMain.SuspendLayout();
            tabMain.SuspendLayout();
            tabSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitSubjects).BeginInit();
            splitSubjects.Panel1.SuspendLayout();
            splitSubjects.Panel2.SuspendLayout();
            splitSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            gbPrioridad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetDeep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetAct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetLight).BeginInit();
            gbActividades.SuspendLayout();
            gbEvaluationDate.SuspendLayout();
            gbTask.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            gbSubjectEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSubPriority).BeginInit();
            tabWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            gbShifts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShifts).BeginInit();
            gbBlocks.SuspendLayout();
            flpBlocksButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBlocks).BeginInit();
            panel1.SuspendLayout();
            tabPlan.SuspendLayout();
            pnlPlanSummary.SuspendLayout();
            panel2.SuspendLayout();
            gbAvisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlan).BeginInit();
            pnlPlanTop.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, exportarToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1417, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuSave, mnuLoad, mnuExit });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnuSave
            // 
            mnuSave.Name = "mnuSave";
            mnuSave.Size = new Size(116, 22);
            mnuSave.Text = "Guardar";
            mnuSave.Click += mnuSave_Click;
            // 
            // mnuLoad
            // 
            mnuLoad.Name = "mnuLoad";
            mnuLoad.Size = new Size(116, 22);
            mnuLoad.Text = "Cargar";
            mnuLoad.Click += mnuLoad_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(116, 22);
            mnuExit.Text = "Salir";
            // 
            // exportarToolStripMenuItem
            // 
            exportarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuExportCsv });
            exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            exportarToolStripMenuItem.Size = new Size(62, 20);
            exportarToolStripMenuItem.Text = "Exportar";
            // 
            // mnuExportCsv
            // 
            mnuExportCsv.Name = "mnuExportCsv";
            mnuExportCsv.Size = new Size(200, 22);
            mnuExportCsv.Text = "Exportar planning a CSV";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(126, 22);
            mnuAbout.Text = "Acerca de";
            // 
            // statusMain
            // 
            statusMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusMain.Location = new Point(0, 817);
            statusMain.Name = "statusMain";
            statusMain.Size = new Size(1417, 22);
            statusMain.TabIndex = 1;
            statusMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(32, 17);
            toolStripStatusLabel1.Text = "Listo";
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabSubjects);
            tabMain.Controls.Add(tabWeek);
            tabMain.Controls.Add(tabPlan);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabMain.Location = new Point(0, 24);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1417, 793);
            tabMain.TabIndex = 2;
            // 
            // tabSubjects
            // 
            tabSubjects.Controls.Add(splitSubjects);
            tabSubjects.Location = new Point(4, 30);
            tabSubjects.Name = "tabSubjects";
            tabSubjects.Padding = new Padding(15);
            tabSubjects.Size = new Size(1409, 759);
            tabSubjects.TabIndex = 0;
            tabSubjects.Text = "Asignaturas";
            tabSubjects.UseVisualStyleBackColor = true;
            // 
            // splitSubjects
            // 
            splitSubjects.Dock = DockStyle.Fill;
            splitSubjects.Location = new Point(15, 15);
            splitSubjects.Name = "splitSubjects";
            // 
            // splitSubjects.Panel1
            // 
            splitSubjects.Panel1.Controls.Add(dgvSubjects);
            // 
            // splitSubjects.Panel2
            // 
            splitSubjects.Panel2.Controls.Add(gbPrioridad);
            splitSubjects.Panel2.Controls.Add(gbActividades);
            splitSubjects.Panel2.Controls.Add(gbEvaluationDate);
            splitSubjects.Panel2.Controls.Add(gbTask);
            splitSubjects.Panel2.Controls.Add(flowLayoutPanel1);
            splitSubjects.Panel2.Controls.Add(gbSubjectEditor);
            splitSubjects.Size = new Size(1379, 729);
            splitSubjects.SplitterDistance = 716;
            splitSubjects.TabIndex = 0;
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { colSubName, colSubCourse, colSubPriority, colSubExam, colSubDeep, colSubLight, colSubAct, colSubActive });
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.Location = new Point(0, 0);
            dgvSubjects.Margin = new Padding(0);
            dgvSubjects.MultiSelect = false;
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.ReadOnly = true;
            dgvSubjects.RowHeadersWidth = 50;
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(716, 729);
            dgvSubjects.TabIndex = 0;
            // 
            // colSubName
            // 
            colSubName.HeaderText = "Asignatura";
            colSubName.Name = "colSubName";
            colSubName.ReadOnly = true;
            // 
            // colSubCourse
            // 
            colSubCourse.HeaderText = "Curso";
            colSubCourse.Name = "colSubCourse";
            colSubCourse.ReadOnly = true;
            // 
            // colSubPriority
            // 
            colSubPriority.HeaderText = "Prioridad";
            colSubPriority.Name = "colSubPriority";
            colSubPriority.ReadOnly = true;
            // 
            // colSubExam
            // 
            colSubExam.HeaderText = "Examen";
            colSubExam.Name = "colSubExam";
            colSubExam.ReadOnly = true;
            // 
            // colSubDeep
            // 
            colSubDeep.HeaderText = "Objetivo Profundo";
            colSubDeep.Name = "colSubDeep";
            colSubDeep.ReadOnly = true;
            // 
            // colSubLight
            // 
            colSubLight.HeaderText = "Objetivo Ligero";
            colSubLight.Name = "colSubLight";
            colSubLight.ReadOnly = true;
            // 
            // colSubAct
            // 
            colSubAct.HeaderText = "Objetivo Actividades";
            colSubAct.Name = "colSubAct";
            colSubAct.ReadOnly = true;
            // 
            // colSubActive
            // 
            colSubActive.HeaderText = "Activa";
            colSubActive.Name = "colSubActive";
            colSubActive.ReadOnly = true;
            // 
            // gbPrioridad
            // 
            gbPrioridad.Controls.Add(lblObjetivoProfundo);
            gbPrioridad.Controls.Add(numTargetDeep);
            gbPrioridad.Controls.Add(numTargetAct);
            gbPrioridad.Controls.Add(lblObjetivoLigth);
            gbPrioridad.Controls.Add(lblObjetivoActividades);
            gbPrioridad.Controls.Add(numTargetLight);
            gbPrioridad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbPrioridad.Location = new Point(329, 162);
            gbPrioridad.Name = "gbPrioridad";
            gbPrioridad.Size = new Size(283, 137);
            gbPrioridad.TabIndex = 1;
            gbPrioridad.TabStop = false;
            gbPrioridad.Text = "Prioridad de la Asignatura";
            gbPrioridad.UseCompatibleTextRendering = true;
            // 
            // lblObjetivoProfundo
            // 
            lblObjetivoProfundo.AutoSize = true;
            lblObjetivoProfundo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObjetivoProfundo.Location = new Point(40, 35);
            lblObjetivoProfundo.Name = "lblObjetivoProfundo";
            lblObjetivoProfundo.Size = new Size(110, 15);
            lblObjetivoProfundo.TabIndex = 8;
            lblObjetivoProfundo.Text = "Objetivo Profundo";
            // 
            // numTargetDeep
            // 
            numTargetDeep.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            numTargetDeep.Location = new Point(156, 33);
            numTargetDeep.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numTargetDeep.Name = "numTargetDeep";
            numTargetDeep.Size = new Size(120, 23);
            numTargetDeep.TabIndex = 9;
            // 
            // numTargetAct
            // 
            numTargetAct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            numTargetAct.Location = new Point(156, 97);
            numTargetAct.Name = "numTargetAct";
            numTargetAct.Size = new Size(120, 23);
            numTargetAct.TabIndex = 13;
            // 
            // lblObjetivoLigth
            // 
            lblObjetivoLigth.AutoSize = true;
            lblObjetivoLigth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObjetivoLigth.Location = new Point(57, 69);
            lblObjetivoLigth.Name = "lblObjetivoLigth";
            lblObjetivoLigth.Size = new Size(93, 15);
            lblObjetivoLigth.TabIndex = 10;
            lblObjetivoLigth.Text = "Objetivo Ligero";
            // 
            // lblObjetivoActividades
            // 
            lblObjetivoActividades.AutoSize = true;
            lblObjetivoActividades.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblObjetivoActividades.Location = new Point(31, 99);
            lblObjetivoActividades.Name = "lblObjetivoActividades";
            lblObjetivoActividades.Size = new Size(122, 15);
            lblObjetivoActividades.TabIndex = 12;
            lblObjetivoActividades.Text = "Objetivo Actividades";
            // 
            // numTargetLight
            // 
            numTargetLight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            numTargetLight.Location = new Point(156, 67);
            numTargetLight.Name = "numTargetLight";
            numTargetLight.Size = new Size(120, 23);
            numTargetLight.TabIndex = 11;
            // 
            // gbActividades
            // 
            gbActividades.Controls.Add(lbDateTask);
            gbActividades.Controls.Add(lbTask);
            gbActividades.Controls.Add(txtAct5);
            gbActividades.Controls.Add(dtpAct5);
            gbActividades.Controls.Add(dtpAct4);
            gbActividades.Controls.Add(txtAct4);
            gbActividades.Controls.Add(txtAct1);
            gbActividades.Controls.Add(dtpAct1);
            gbActividades.Controls.Add(dtpAct3);
            gbActividades.Controls.Add(txtAct3);
            gbActividades.Controls.Add(dtpAct2);
            gbActividades.Controls.Add(txtAct2);
            gbActividades.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbActividades.Location = new Point(7, 429);
            gbActividades.Name = "gbActividades";
            gbActividades.Size = new Size(663, 249);
            gbActividades.TabIndex = 22;
            gbActividades.TabStop = false;
            gbActividades.Text = "Actividades";
            // 
            // lbDateTask
            // 
            lbDateTask.AutoSize = true;
            lbDateTask.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDateTask.Location = new Point(426, 36);
            lbDateTask.Name = "lbDateTask";
            lbDateTask.Size = new Size(103, 15);
            lbDateTask.TabIndex = 22;
            lbDateTask.Text = "Fecha de entrega";
            // 
            // lbTask
            // 
            lbTask.AutoSize = true;
            lbTask.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTask.Location = new Point(28, 36);
            lbTask.Name = "lbTask";
            lbTask.Size = new Size(59, 15);
            lbTask.TabIndex = 22;
            lbTask.Text = "Actividad";
            lbTask.Click += lbTask_Click;
            // 
            // txtAct5
            // 
            txtAct5.Location = new Point(19, 203);
            txtAct5.Name = "txtAct5";
            txtAct5.Size = new Size(401, 29);
            txtAct5.TabIndex = 20;
            // 
            // dtpAct5
            // 
            dtpAct5.Checked = false;
            dtpAct5.Format = DateTimePickerFormat.Short;
            dtpAct5.Location = new Point(426, 200);
            dtpAct5.Name = "dtpAct5";
            dtpAct5.ShowCheckBox = true;
            dtpAct5.Size = new Size(200, 29);
            dtpAct5.TabIndex = 21;
            // 
            // dtpAct4
            // 
            dtpAct4.Checked = false;
            dtpAct4.Format = DateTimePickerFormat.Short;
            dtpAct4.Location = new Point(426, 165);
            dtpAct4.Name = "dtpAct4";
            dtpAct4.ShowCheckBox = true;
            dtpAct4.Size = new Size(200, 29);
            dtpAct4.TabIndex = 21;
            // 
            // txtAct4
            // 
            txtAct4.Location = new Point(19, 165);
            txtAct4.Name = "txtAct4";
            txtAct4.Size = new Size(401, 29);
            txtAct4.TabIndex = 20;
            // 
            // txtAct1
            // 
            txtAct1.Location = new Point(19, 57);
            txtAct1.Name = "txtAct1";
            txtAct1.Size = new Size(401, 29);
            txtAct1.TabIndex = 20;
            // 
            // dtpAct1
            // 
            dtpAct1.Checked = false;
            dtpAct1.Format = DateTimePickerFormat.Short;
            dtpAct1.Location = new Point(426, 57);
            dtpAct1.Name = "dtpAct1";
            dtpAct1.ShowCheckBox = true;
            dtpAct1.Size = new Size(200, 29);
            dtpAct1.TabIndex = 21;
            // 
            // dtpAct3
            // 
            dtpAct3.Checked = false;
            dtpAct3.Format = DateTimePickerFormat.Short;
            dtpAct3.Location = new Point(426, 130);
            dtpAct3.Name = "dtpAct3";
            dtpAct3.ShowCheckBox = true;
            dtpAct3.Size = new Size(200, 29);
            dtpAct3.TabIndex = 21;
            // 
            // txtAct3
            // 
            txtAct3.Location = new Point(19, 130);
            txtAct3.Name = "txtAct3";
            txtAct3.Size = new Size(401, 29);
            txtAct3.TabIndex = 20;
            // 
            // dtpAct2
            // 
            dtpAct2.Checked = false;
            dtpAct2.Format = DateTimePickerFormat.Short;
            dtpAct2.Location = new Point(426, 92);
            dtpAct2.Name = "dtpAct2";
            dtpAct2.ShowCheckBox = true;
            dtpAct2.Size = new Size(200, 29);
            dtpAct2.TabIndex = 21;
            // 
            // txtAct2
            // 
            txtAct2.Location = new Point(19, 92);
            txtAct2.Name = "txtAct2";
            txtAct2.Size = new Size(401, 29);
            txtAct2.TabIndex = 20;
            // 
            // gbEvaluationDate
            // 
            gbEvaluationDate.Controls.Add(chkHasExam);
            gbEvaluationDate.Controls.Add(dtpSubExam);
            gbEvaluationDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEvaluationDate.Location = new Point(59, 192);
            gbEvaluationDate.Name = "gbEvaluationDate";
            gbEvaluationDate.Size = new Size(247, 84);
            gbEvaluationDate.TabIndex = 17;
            gbEvaluationDate.TabStop = false;
            gbEvaluationDate.Text = "Fecha de Exámen";
            // 
            // chkHasExam
            // 
            chkHasExam.AutoSize = true;
            chkHasExam.Checked = true;
            chkHasExam.CheckState = CheckState.Checked;
            chkHasExam.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkHasExam.Location = new Point(19, 20);
            chkHasExam.Name = "chkHasExam";
            chkHasExam.Size = new Size(99, 19);
            chkHasExam.TabIndex = 15;
            chkHasExam.Text = "Tiene examen";
            chkHasExam.UseVisualStyleBackColor = true;
            // 
            // dtpSubExam
            // 
            dtpSubExam.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpSubExam.Format = DateTimePickerFormat.Short;
            dtpSubExam.Location = new Point(28, 45);
            dtpSubExam.Name = "dtpSubExam";
            dtpSubExam.Size = new Size(200, 29);
            dtpSubExam.TabIndex = 7;
            // 
            // gbTask
            // 
            gbTask.Controls.Add(lblTemaActual);
            gbTask.Controls.Add(txtSubTopic);
            gbTask.Controls.Add(lblDondeDeje);
            gbTask.Controls.Add(txtSubCheckpoint);
            gbTask.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbTask.Location = new Point(7, 321);
            gbTask.Name = "gbTask";
            gbTask.Size = new Size(658, 102);
            gbTask.TabIndex = 1;
            gbTask.TabStop = false;
            gbTask.Text = "Tema en curso";
            // 
            // lblTemaActual
            // 
            lblTemaActual.AutoSize = true;
            lblTemaActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTemaActual.Location = new Point(31, 29);
            lblTemaActual.Name = "lblTemaActual";
            lblTemaActual.Size = new Size(73, 15);
            lblTemaActual.TabIndex = 16;
            lblTemaActual.Text = "Tema actual";
            // 
            // txtSubTopic
            // 
            txtSubTopic.Location = new Point(31, 47);
            txtSubTopic.Name = "txtSubTopic";
            txtSubTopic.Size = new Size(205, 29);
            txtSubTopic.TabIndex = 17;
            // 
            // lblDondeDeje
            // 
            lblDondeDeje.AutoSize = true;
            lblDondeDeje.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDondeDeje.Location = new Point(261, 29);
            lblDondeDeje.Name = "lblDondeDeje";
            lblDondeDeje.Size = new Size(84, 15);
            lblDondeDeje.TabIndex = 18;
            lblDondeDeje.Text = "Dónde lo dejé";
            // 
            // txtSubCheckpoint
            // 
            txtSubCheckpoint.Location = new Point(261, 47);
            txtSubCheckpoint.Name = "txtSubCheckpoint";
            txtSubCheckpoint.Size = new Size(391, 29);
            txtSubCheckpoint.TabIndex = 19;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSubNew);
            flowLayoutPanel1.Controls.Add(btnSubSave);
            flowLayoutPanel1.Controls.Add(btnSubDelete);
            flowLayoutPanel1.Controls.Add(btnSubClear);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 654);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(659, 75);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnSubNew
            // 
            btnSubNew.BackColor = Color.FromArgb(79, 70, 229);
            btnSubNew.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSubNew.Location = new Point(3, 3);
            btnSubNew.Name = "btnSubNew";
            btnSubNew.Size = new Size(320, 29);
            btnSubNew.TabIndex = 0;
            btnSubNew.Text = "+ Nueva Asignatura";
            btnSubNew.UseVisualStyleBackColor = false;
            btnSubNew.Click += btnSubNew_Click;
            // 
            // btnSubSave
            // 
            btnSubSave.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSubSave.Location = new Point(329, 3);
            btnSubSave.Name = "btnSubSave";
            btnSubSave.Size = new Size(320, 29);
            btnSubSave.TabIndex = 1;
            btnSubSave.Text = "Guardar";
            btnSubSave.UseVisualStyleBackColor = true;
            btnSubSave.Click += btnSubSave_Click;
            // 
            // btnSubDelete
            // 
            btnSubDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSubDelete.Location = new Point(3, 38);
            btnSubDelete.Name = "btnSubDelete";
            btnSubDelete.Size = new Size(320, 29);
            btnSubDelete.TabIndex = 2;
            btnSubDelete.Text = "Eliminar";
            btnSubDelete.UseVisualStyleBackColor = true;
            btnSubDelete.Click += btnSubDelete_Click;
            // 
            // btnSubClear
            // 
            btnSubClear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnSubClear.Location = new Point(329, 38);
            btnSubClear.Name = "btnSubClear";
            btnSubClear.Size = new Size(320, 29);
            btnSubClear.TabIndex = 3;
            btnSubClear.Text = "Limpiar";
            btnSubClear.UseVisualStyleBackColor = true;
            btnSubClear.Click += btnSubClear_Click;
            // 
            // gbSubjectEditor
            // 
            gbSubjectEditor.Controls.Add(lblActiva);
            gbSubjectEditor.Controls.Add(chkSubActive);
            gbSubjectEditor.Controls.Add(numSubPriority);
            gbSubjectEditor.Controls.Add(lblPrioridad);
            gbSubjectEditor.Controls.Add(cmbSubCourse);
            gbSubjectEditor.Controls.Add(lblCurso);
            gbSubjectEditor.Controls.Add(txtSubName);
            gbSubjectEditor.Controls.Add(lblNombre);
            gbSubjectEditor.Dock = DockStyle.Top;
            gbSubjectEditor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbSubjectEditor.Location = new Point(0, 0);
            gbSubjectEditor.Name = "gbSubjectEditor";
            gbSubjectEditor.Size = new Size(659, 142);
            gbSubjectEditor.TabIndex = 0;
            gbSubjectEditor.TabStop = false;
            gbSubjectEditor.Text = "Detalle de asignatura";
            // 
            // lblActiva
            // 
            lblActiva.AutoSize = true;
            lblActiva.Font = new Font("Segoe UI", 9F);
            lblActiva.Location = new Point(206, 106);
            lblActiva.Name = "lblActiva";
            lblActiva.Size = new Size(137, 15);
            lblActiva.TabIndex = 16;
            lblActiva.Text = "¿Es una signatura activa?";
            // 
            // chkSubActive
            // 
            chkSubActive.AutoSize = true;
            chkSubActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkSubActive.Location = new Point(349, 105);
            chkSubActive.Name = "chkSubActive";
            chkSubActive.Size = new Size(61, 19);
            chkSubActive.TabIndex = 14;
            chkSubActive.Text = "Activa";
            chkSubActive.UseVisualStyleBackColor = true;
            // 
            // numSubPriority
            // 
            numSubPriority.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numSubPriority.Location = new Point(461, 53);
            numSubPriority.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numSubPriority.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSubPriority.Name = "numSubPriority";
            numSubPriority.Size = new Size(120, 23);
            numSubPriority.TabIndex = 5;
            numSubPriority.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrioridad
            // 
            lblPrioridad.AutoSize = true;
            lblPrioridad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrioridad.Location = new Point(461, 35);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(57, 15);
            lblPrioridad.TabIndex = 4;
            lblPrioridad.Text = "Prioridad";
            // 
            // cmbSubCourse
            // 
            cmbSubCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubCourse.FormattingEnabled = true;
            cmbSubCourse.Items.AddRange(new object[] { "1º", "2º" });
            cmbSubCourse.Location = new Point(329, 52);
            cmbSubCourse.Name = "cmbSubCourse";
            cmbSubCourse.Size = new Size(121, 29);
            cmbSubCourse.TabIndex = 3;
            // 
            // lblCurso
            // 
            lblCurso.AutoSize = true;
            lblCurso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurso.Location = new Point(329, 34);
            lblCurso.Name = "lblCurso";
            lblCurso.Size = new Size(38, 15);
            lblCurso.TabIndex = 2;
            lblCurso.Text = "Curso";
            // 
            // txtSubName
            // 
            txtSubName.Location = new Point(41, 52);
            txtSubName.Name = "txtSubName";
            txtSubName.Size = new Size(282, 29);
            txtSubName.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.Location = new Point(41, 34);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(53, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // tabWeek
            // 
            tabWeek.Controls.Add(splitContainer1);
            tabWeek.Controls.Add(panel1);
            tabWeek.Location = new Point(4, 30);
            tabWeek.Name = "tabWeek";
            tabWeek.Padding = new Padding(3);
            tabWeek.Size = new Size(1409, 759);
            tabWeek.TabIndex = 1;
            tabWeek.Text = "Semana y huecos";
            tabWeek.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 58);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(gbShifts);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gbBlocks);
            splitContainer1.Size = new Size(1403, 698);
            splitContainer1.SplitterDistance = 463;
            splitContainer1.TabIndex = 1;
            // 
            // gbShifts
            // 
            gbShifts.Controls.Add(dgvShifts);
            gbShifts.Dock = DockStyle.Fill;
            gbShifts.Location = new Point(0, 0);
            gbShifts.Name = "gbShifts";
            gbShifts.Size = new Size(463, 698);
            gbShifts.TabIndex = 0;
            gbShifts.TabStop = false;
            gbShifts.Text = "Turnos de trabajo";
            // 
            // dgvShifts
            // 
            dgvShifts.AllowUserToAddRows = false;
            dgvShifts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShifts.Columns.AddRange(new DataGridViewColumn[] { colShiftDate, colShiftDay, colShiftType, colShiftNotes });
            dgvShifts.Dock = DockStyle.Fill;
            dgvShifts.Location = new Point(3, 25);
            dgvShifts.Name = "dgvShifts";
            dgvShifts.Size = new Size(457, 670);
            dgvShifts.TabIndex = 0;
            // 
            // colShiftDate
            // 
            colShiftDate.HeaderText = "Fecha";
            colShiftDate.Name = "colShiftDate";
            // 
            // colShiftDay
            // 
            colShiftDay.HeaderText = "Día";
            colShiftDay.Name = "colShiftDay";
            // 
            // colShiftType
            // 
            colShiftType.HeaderText = "Turno";
            colShiftType.Name = "colShiftType";
            // 
            // colShiftNotes
            // 
            colShiftNotes.HeaderText = "Notas";
            colShiftNotes.Name = "colShiftNotes";
            // 
            // gbBlocks
            // 
            gbBlocks.Controls.Add(flpBlocksButtons);
            gbBlocks.Controls.Add(dgvBlocks);
            gbBlocks.Dock = DockStyle.Fill;
            gbBlocks.Location = new Point(0, 0);
            gbBlocks.Name = "gbBlocks";
            gbBlocks.Size = new Size(936, 698);
            gbBlocks.TabIndex = 0;
            gbBlocks.TabStop = false;
            gbBlocks.Text = "Huecos de estudio";
            // 
            // flpBlocksButtons
            // 
            flpBlocksButtons.Controls.Add(btnBlockRemove);
            flpBlocksButtons.Controls.Add(btnBlockAdd);
            flpBlocksButtons.Controls.Add(btnBlockEdit);
            flpBlocksButtons.Location = new Point(3, 614);
            flpBlocksButtons.Name = "flpBlocksButtons";
            flpBlocksButtons.Size = new Size(930, 87);
            flpBlocksButtons.TabIndex = 1;
            // 
            // btnBlockRemove
            // 
            btnBlockRemove.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBlockRemove.Location = new Point(3, 3);
            btnBlockRemove.Name = "btnBlockRemove";
            btnBlockRemove.Size = new Size(265, 38);
            btnBlockRemove.TabIndex = 2;
            btnBlockRemove.Text = "Elimnar";
            btnBlockRemove.UseVisualStyleBackColor = true;
            btnBlockRemove.Click += btnBlockRemove_Click;
            // 
            // btnBlockAdd
            // 
            btnBlockAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBlockAdd.Location = new Point(274, 3);
            btnBlockAdd.Name = "btnBlockAdd";
            btnBlockAdd.Size = new Size(265, 38);
            btnBlockAdd.TabIndex = 0;
            btnBlockAdd.Text = "Añadir";
            btnBlockAdd.UseVisualStyleBackColor = true;
            btnBlockAdd.Click += btnBlockAdd_Click_1;
            // 
            // btnBlockEdit
            // 
            btnBlockEdit.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBlockEdit.Location = new Point(545, 3);
            btnBlockEdit.Name = "btnBlockEdit";
            btnBlockEdit.Size = new Size(265, 38);
            btnBlockEdit.TabIndex = 1;
            btnBlockEdit.Text = "Editar";
            btnBlockEdit.UseVisualStyleBackColor = true;
            btnBlockEdit.Click += btnBlockEdit_Click;
            // 
            // dgvBlocks
            // 
            dgvBlocks.AllowUserToAddRows = false;
            dgvBlocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBlocks.Columns.AddRange(new DataGridViewColumn[] { colBlockDate, colBlockStart, colBlockEnd, colBlockDuration, colBlockHint });
            dgvBlocks.Dock = DockStyle.Fill;
            dgvBlocks.Location = new Point(3, 25);
            dgvBlocks.Name = "dgvBlocks";
            dgvBlocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBlocks.Size = new Size(930, 670);
            dgvBlocks.TabIndex = 0;
            // 
            // colBlockDate
            // 
            colBlockDate.HeaderText = "Fecha";
            colBlockDate.Name = "colBlockDate";
            // 
            // colBlockStart
            // 
            colBlockStart.HeaderText = "Inicio";
            colBlockStart.Name = "colBlockStart";
            // 
            // colBlockEnd
            // 
            colBlockEnd.HeaderText = "Fin";
            colBlockEnd.Name = "colBlockEnd";
            // 
            // colBlockDuration
            // 
            colBlockDuration.HeaderText = "Min";
            colBlockDuration.Name = "colBlockDuration";
            colBlockDuration.ReadOnly = true;
            // 
            // colBlockHint
            // 
            colBlockHint.HeaderText = "Sugerencia";
            colBlockHint.Name = "colBlockHint";
            colBlockHint.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnWeekClear);
            panel1.Controls.Add(btnWeekAutoBlocks);
            panel1.Controls.Add(btnWeekLoad);
            panel1.Controls.Add(dtpWeekStart);
            panel1.Controls.Add(lblInicioSemana);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1403, 55);
            panel1.TabIndex = 0;
            // 
            // btnWeekClear
            // 
            btnWeekClear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnWeekClear.Location = new Point(715, 8);
            btnWeekClear.Name = "btnWeekClear";
            btnWeekClear.Size = new Size(75, 32);
            btnWeekClear.TabIndex = 4;
            btnWeekClear.Text = "Limpiar";
            btnWeekClear.UseVisualStyleBackColor = true;
            // 
            // btnWeekAutoBlocks
            // 
            btnWeekAutoBlocks.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnWeekAutoBlocks.Location = new Point(493, 9);
            btnWeekAutoBlocks.Name = "btnWeekAutoBlocks";
            btnWeekAutoBlocks.Size = new Size(216, 31);
            btnWeekAutoBlocks.TabIndex = 3;
            btnWeekAutoBlocks.Text = "Sugerir huecos (según turno)";
            btnWeekAutoBlocks.UseVisualStyleBackColor = true;
            btnWeekAutoBlocks.Click += btnWeekAutoBlocks_Click;
            // 
            // btnWeekLoad
            // 
            btnWeekLoad.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnWeekLoad.Location = new Point(386, 9);
            btnWeekLoad.Name = "btnWeekLoad";
            btnWeekLoad.Size = new Size(101, 31);
            btnWeekLoad.TabIndex = 2;
            btnWeekLoad.Text = "Cargar semana";
            btnWeekLoad.UseVisualStyleBackColor = true;
            // 
            // dtpWeekStart
            // 
            dtpWeekStart.Location = new Point(128, 13);
            dtpWeekStart.Name = "dtpWeekStart";
            dtpWeekStart.Size = new Size(237, 29);
            dtpWeekStart.TabIndex = 1;
            // 
            // lblInicioSemana
            // 
            lblInicioSemana.AutoSize = true;
            lblInicioSemana.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInicioSemana.Location = new Point(23, 18);
            lblInicioSemana.Name = "lblInicioSemana";
            lblInicioSemana.Size = new Size(99, 15);
            lblInicioSemana.TabIndex = 0;
            lblInicioSemana.Text = "Inicio de Semana";
            // 
            // tabPlan
            // 
            tabPlan.Controls.Add(pnlPlanSummary);
            tabPlan.Controls.Add(dgvPlan);
            tabPlan.Controls.Add(pnlPlanTop);
            tabPlan.Location = new Point(4, 30);
            tabPlan.Name = "tabPlan";
            tabPlan.Padding = new Padding(3);
            tabPlan.Size = new Size(1409, 759);
            tabPlan.TabIndex = 2;
            tabPlan.Text = "Planning";
            tabPlan.UseVisualStyleBackColor = true;
            // 
            // pnlPlanSummary
            // 
            pnlPlanSummary.Controls.Add(panel2);
            pnlPlanSummary.Controls.Add(lvSummary);
            pnlPlanSummary.Controls.Add(lblResumenSemanal);
            pnlPlanSummary.Controls.Add(gbAvisos);
            pnlPlanSummary.Dock = DockStyle.Right;
            pnlPlanSummary.Location = new Point(865, 58);
            pnlPlanSummary.Name = "pnlPlanSummary";
            pnlPlanSummary.Size = new Size(541, 698);
            pnlPlanSummary.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbComple);
            panel2.Controls.Add(lblChechlpoint);
            panel2.Controls.Add(lblTema);
            panel2.Controls.Add(btnPlanSessionSave);
            panel2.Controls.Add(chkPlanCompleted);
            panel2.Controls.Add(txtPlanCheckpoint);
            panel2.Controls.Add(txtPlanTopic);
            panel2.Location = new Point(12, 518);
            panel2.Name = "panel2";
            panel2.Size = new Size(517, 165);
            panel2.TabIndex = 3;
            // 
            // lbComple
            // 
            lbComple.AutoSize = true;
            lbComple.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbComple.Location = new Point(176, 91);
            lbComple.Name = "lbComple";
            lbComple.Size = new Size(116, 15);
            lbComple.TabIndex = 6;
            lbComple.Text = "¿Tema completado?";
            // 
            // lblChechlpoint
            // 
            lblChechlpoint.AutoSize = true;
            lblChechlpoint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChechlpoint.Location = new Point(46, 51);
            lblChechlpoint.Name = "lblChechlpoint";
            lblChechlpoint.Size = new Size(70, 15);
            lblChechlpoint.TabIndex = 5;
            lblChechlpoint.Text = "Checkpoint";
            // 
            // lblTema
            // 
            lblTema.AutoSize = true;
            lblTema.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTema.Location = new Point(73, 17);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(37, 15);
            lblTema.TabIndex = 4;
            lblTema.Text = "Tema";
            // 
            // btnPlanSessionSave
            // 
            btnPlanSessionSave.Location = new Point(226, 126);
            btnPlanSessionSave.Name = "btnPlanSessionSave";
            btnPlanSessionSave.Size = new Size(125, 27);
            btnPlanSessionSave.TabIndex = 3;
            btnPlanSessionSave.Text = "Guardar Sesión";
            btnPlanSessionSave.UseVisualStyleBackColor = true;
            btnPlanSessionSave.Click += btnPlanSessionSave_Click;
            // 
            // chkPlanCompleted
            // 
            chkPlanCompleted.AutoSize = true;
            chkPlanCompleted.Location = new Point(295, 90);
            chkPlanCompleted.Name = "chkPlanCompleted";
            chkPlanCompleted.Size = new Size(120, 25);
            chkPlanCompleted.TabIndex = 2;
            chkPlanCompleted.Text = "Completado";
            chkPlanCompleted.UseVisualStyleBackColor = true;
            chkPlanCompleted.CheckedChanged += chkPlanCompleted_CheckedChanged;
            // 
            // txtPlanCheckpoint
            // 
            txtPlanCheckpoint.Location = new Point(120, 48);
            txtPlanCheckpoint.Name = "txtPlanCheckpoint";
            txtPlanCheckpoint.Size = new Size(351, 29);
            txtPlanCheckpoint.TabIndex = 1;
            // 
            // txtPlanTopic
            // 
            txtPlanTopic.Location = new Point(116, 14);
            txtPlanTopic.Name = "txtPlanTopic";
            txtPlanTopic.Size = new Size(351, 29);
            txtPlanTopic.TabIndex = 0;
            // 
            // lvSummary
            // 
            lvSummary.Columns.AddRange(new ColumnHeader[] { Asignatura, Objetivo, Planificado });
            lvSummary.Location = new Point(12, 31);
            lvSummary.Name = "lvSummary";
            lvSummary.Size = new Size(517, 210);
            lvSummary.TabIndex = 1;
            lvSummary.UseCompatibleStateImageBehavior = false;
            // 
            // lblResumenSemanal
            // 
            lblResumenSemanal.AutoSize = true;
            lblResumenSemanal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResumenSemanal.Location = new Point(12, 7);
            lblResumenSemanal.Name = "lblResumenSemanal";
            lblResumenSemanal.Size = new Size(150, 21);
            lblResumenSemanal.TabIndex = 0;
            lblResumenSemanal.Text = "Resumen Semanal";
            // 
            // gbAvisos
            // 
            gbAvisos.Controls.Add(lblWarnings);
            gbAvisos.Location = new Point(12, 247);
            gbAvisos.Name = "gbAvisos";
            gbAvisos.Size = new Size(517, 265);
            gbAvisos.TabIndex = 4;
            gbAvisos.TabStop = false;
            gbAvisos.Text = "Avisos";
            // 
            // lblWarnings
            // 
            lblWarnings.AutoSize = true;
            lblWarnings.Location = new Point(12, 19);
            lblWarnings.Name = "lblWarnings";
            lblWarnings.Size = new Size(57, 21);
            lblWarnings.TabIndex = 2;
            lblWarnings.Text = "Avisos";
            // 
            // dgvPlan
            // 
            dgvPlan.AllowUserToAddRows = false;
            dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlan.Columns.AddRange(new DataGridViewColumn[] { colPlanDate, colPlanStart, colPlanEnd, colPlanSubject, colPlanType, colPlanStrategy, colPlanNotes });
            dgvPlan.Dock = DockStyle.Fill;
            dgvPlan.Location = new Point(3, 58);
            dgvPlan.Name = "dgvPlan";
            dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlan.Size = new Size(1403, 698);
            dgvPlan.TabIndex = 1;
            // 
            // pnlPlanTop
            // 
            pnlPlanTop.Controls.Add(btnPlanClear);
            pnlPlanTop.Controls.Add(btnPlanCopy);
            pnlPlanTop.Controls.Add(btnPlanExportCsv);
            pnlPlanTop.Controls.Add(btnPlanRegenerate);
            pnlPlanTop.Controls.Add(btnPlanGenerate);
            pnlPlanTop.Dock = DockStyle.Top;
            pnlPlanTop.Location = new Point(3, 3);
            pnlPlanTop.Name = "pnlPlanTop";
            pnlPlanTop.Size = new Size(1403, 55);
            pnlPlanTop.TabIndex = 0;
            // 
            // btnPlanClear
            // 
            btnPlanClear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPlanClear.Location = new Point(705, 13);
            btnPlanClear.Name = "btnPlanClear";
            btnPlanClear.Size = new Size(169, 27);
            btnPlanClear.TabIndex = 4;
            btnPlanClear.Text = "Eliminar planning";
            btnPlanClear.UseVisualStyleBackColor = true;
            btnPlanClear.Click += btnPlanClear_Click;
            // 
            // btnPlanCopy
            // 
            btnPlanCopy.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPlanCopy.Location = new Point(530, 13);
            btnPlanCopy.Name = "btnPlanCopy";
            btnPlanCopy.Size = new Size(169, 27);
            btnPlanCopy.TabIndex = 3;
            btnPlanCopy.Text = "Copiar texto";
            btnPlanCopy.UseVisualStyleBackColor = true;
            // 
            // btnPlanExportCsv
            // 
            btnPlanExportCsv.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPlanExportCsv.Location = new Point(355, 13);
            btnPlanExportCsv.Name = "btnPlanExportCsv";
            btnPlanExportCsv.Size = new Size(169, 27);
            btnPlanExportCsv.TabIndex = 2;
            btnPlanExportCsv.Text = "Exportar CSV";
            btnPlanExportCsv.UseVisualStyleBackColor = true;
            // 
            // btnPlanRegenerate
            // 
            btnPlanRegenerate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPlanRegenerate.Location = new Point(180, 13);
            btnPlanRegenerate.Name = "btnPlanRegenerate";
            btnPlanRegenerate.Size = new Size(169, 27);
            btnPlanRegenerate.TabIndex = 1;
            btnPlanRegenerate.Text = "Regenerar";
            btnPlanRegenerate.UseVisualStyleBackColor = true;
            // 
            // btnPlanGenerate
            // 
            btnPlanGenerate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnPlanGenerate.Location = new Point(5, 13);
            btnPlanGenerate.Name = "btnPlanGenerate";
            btnPlanGenerate.Size = new Size(169, 27);
            btnPlanGenerate.TabIndex = 0;
            btnPlanGenerate.Text = "Generar planning";
            btnPlanGenerate.UseVisualStyleBackColor = true;
            btnPlanGenerate.Click += btnPlanGenerate_Click;
            // 
            // colPlanDate
            // 
            colPlanDate.FillWeight = 159.898483F;
            colPlanDate.HeaderText = "Fecha";
            colPlanDate.MinimumWidth = 3;
            colPlanDate.Name = "colPlanDate";
            // 
            // colPlanStart
            // 
            colPlanStart.FillWeight = 78.35025F;
            colPlanStart.HeaderText = "Inicio";
            colPlanStart.Name = "colPlanStart";
            // 
            // colPlanEnd
            // 
            colPlanEnd.FillWeight = 78.35025F;
            colPlanEnd.HeaderText = "Fin";
            colPlanEnd.Name = "colPlanEnd";
            // 
            // colPlanSubject
            // 
            colPlanSubject.FillWeight = 78.35025F;
            colPlanSubject.HeaderText = "Asignatura";
            colPlanSubject.Name = "colPlanSubject";
            // 
            // colPlanType
            // 
            colPlanType.FillWeight = 78.35025F;
            colPlanType.HeaderText = "Tipo";
            colPlanType.Name = "colPlanType";
            // 
            // colPlanStrategy
            // 
            colPlanStrategy.FillWeight = 78.35025F;
            colPlanStrategy.HeaderText = "Estrategia";
            colPlanStrategy.Name = "colPlanStrategy";
            // 
            // colPlanNotes
            // 
            colPlanNotes.FillWeight = 78.35025F;
            colPlanNotes.HeaderText = "Notas";
            colPlanNotes.Name = "colPlanNotes";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1417, 839);
            Controls.Add(tabMain);
            Controls.Add(statusMain);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Study Planner";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusMain.ResumeLayout(false);
            statusMain.PerformLayout();
            tabMain.ResumeLayout(false);
            tabSubjects.ResumeLayout(false);
            splitSubjects.Panel1.ResumeLayout(false);
            splitSubjects.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitSubjects).EndInit();
            splitSubjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            gbPrioridad.ResumeLayout(false);
            gbPrioridad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetDeep).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetAct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetLight).EndInit();
            gbActividades.ResumeLayout(false);
            gbActividades.PerformLayout();
            gbEvaluationDate.ResumeLayout(false);
            gbEvaluationDate.PerformLayout();
            gbTask.ResumeLayout(false);
            gbTask.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            gbSubjectEditor.ResumeLayout(false);
            gbSubjectEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSubPriority).EndInit();
            tabWeek.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            gbShifts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShifts).EndInit();
            gbBlocks.ResumeLayout(false);
            flpBlocksButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBlocks).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPlan.ResumeLayout(false);
            pnlPlanSummary.ResumeLayout(false);
            pnlPlanSummary.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            gbAvisos.ResumeLayout(false);
            gbAvisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlan).EndInit();
            pnlPlanTop.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem mnuSave;
        private ToolStripMenuItem mnuLoad;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem mnuAbout;
        private StatusStrip statusMain;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabControl tabMain;
        private TabPage tabSubjects;
        private TabPage tabWeek;
        private TabPage tabPlan;
        private SplitContainer splitSubjects;
        private DataGridView dgvSubjects;
        private DataGridViewTextBoxColumn colSubName;
        private DataGridViewTextBoxColumn colSubCourse;
        private DataGridViewTextBoxColumn colSubPriority;
        private DataGridViewTextBoxColumn colSubExam;
        private DataGridViewTextBoxColumn colSubDeep;
        private DataGridViewTextBoxColumn colSubLight;
        private DataGridViewTextBoxColumn colSubAct;
        private DataGridViewCheckBoxColumn colSubActive;
        private GroupBox gbSubjectEditor;
        private ComboBox cmbSubCourse;
        private Label lblCurso;
        private TextBox txtSubName;
        private Label lblNombre;
        private NumericUpDown numSubPriority;
        private Label lblPrioridad;
        private DateTimePicker dtpSubExam;
        private CheckBox chkSubActive;
        private NumericUpDown numTargetAct;
        private Label lblObjetivoActividades;
        private NumericUpDown numTargetLight;
        private Label lblObjetivoLigth;
        private NumericUpDown numTargetDeep;
        private Label lblObjetivoProfundo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSubNew;
        private Button btnSubSave;
        private Button btnSubDelete;
        private Button btnSubClear;
        private Panel panel1;
        private Button btnWeekClear;
        private Button btnWeekAutoBlocks;
        private Button btnWeekLoad;
        private DateTimePicker dtpWeekStart;
        private Label lblInicioSemana;
        private SplitContainer splitContainer1;
        private GroupBox gbShifts;
        private DataGridView dgvShifts;
        private DataGridViewTextBoxColumn colShiftDate;
        private DataGridViewTextBoxColumn colShiftDay;
        private DataGridViewComboBoxColumn colShiftType;
        private DataGridViewTextBoxColumn colShiftNotes;
        private GroupBox gbBlocks;
        private DataGridView dgvBlocks;
        private FlowLayoutPanel flpBlocksButtons;
        private Button btnBlockAdd;
        private Button btnBlockEdit;
        private Button btnBlockRemove;
        private Panel pnlPlanTop;
        private Button btnPlanCopy;
        private Button btnPlanExportCsv;
        private Button btnPlanRegenerate;
        private Button btnPlanGenerate;
        private Panel pnlPlanSummary;
        private Label lblResumenSemanal;
        private DataGridView dgvPlan;
        private DataGridViewTextBoxColumn colBlockDate;
        private DataGridViewTextBoxColumn colBlockStart;
        private DataGridViewTextBoxColumn colBlockEnd;
        private DataGridViewTextBoxColumn colBlockDuration;
        private DataGridViewTextBoxColumn colBlockHint;
        private CheckBox chkHasExam;
        private Button btnPlanClear;
        private TextBox txtSubCheckpoint;
        private Label lblDondeDeje;
        private TextBox txtSubTopic;
        private Label lblTemaActual;
        private Panel panel2;
        private Button btnPlanSessionSave;
        private CheckBox chkPlanCompleted;
        private TextBox txtPlanCheckpoint;
        private TextBox txtPlanTopic;
        private DateTimePicker dtpAct5;
        private DateTimePicker dtpAct4;
        private DateTimePicker dtpAct3;
        private DateTimePicker dtpAct2;
        private DateTimePicker dtpAct1;
        private TextBox txtAct5;
        private TextBox txtAct4;
        private TextBox txtAct3;
        private TextBox txtAct2;
        private TextBox txtAct1;
        private GroupBox gbActividades;
        private GroupBox gbAvisos;
        private Label lblChechlpoint;
        private Label lblTema;
        private ListView lvSummary;
        private ColumnHeader Asignatura;
        private ColumnHeader Objetivo;
        private ColumnHeader Planificado;
        private GroupBox gbTask;
        private Label lbDateTask;
        private Label lbTask;
        private GroupBox gbPrioridad;
        private Label lblActiva;
        private GroupBox gbEvaluationDate;
        private Label lbComple;
        private Label lblWarnings;
        private DataGridViewTextBoxColumn colPlanDate;
        private DataGridViewTextBoxColumn colPlanStart;
        private DataGridViewTextBoxColumn colPlanEnd;
        private DataGridViewTextBoxColumn colPlanSubject;
        private DataGridViewTextBoxColumn colPlanType;
        private DataGridViewTextBoxColumn colPlanStrategy;
        private DataGridViewTextBoxColumn colPlanNotes;
    }
}
