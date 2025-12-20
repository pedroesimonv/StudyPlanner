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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSubNew = new Button();
            btnSubSave = new Button();
            btnSubDelete = new Button();
            btnSubClear = new Button();
            gbSubjectEditor = new GroupBox();
            txtAct5 = new TextBox();
            txtAct4 = new TextBox();
            txtAct3 = new TextBox();
            txtAct2 = new TextBox();
            txtAct1 = new TextBox();
            txtSubCheckpoint = new TextBox();
            lblDondeDeje = new Label();
            txtSubTopic = new TextBox();
            lblTemaActual = new Label();
            chkHasExam = new CheckBox();
            chkSubActive = new CheckBox();
            numTargetAct = new NumericUpDown();
            lblObjetivoActividades = new Label();
            numTargetLight = new NumericUpDown();
            lblObjetivoLigth = new Label();
            numTargetDeep = new NumericUpDown();
            lblObjetivoProfundo = new Label();
            dtpSubExam = new DateTimePicker();
            lblFechaExamen = new Label();
            numSubPriority = new NumericUpDown();
            lblPrioridad = new Label();
            cmbSubCourse = new ComboBox();
            lblCurso = new Label();
            txtSubName = new TextBox();
            lblNombre = new Label();
            gbActividades = new GroupBox();
            dtpAct5 = new DateTimePicker();
            dtpAct4 = new DateTimePicker();
            dtpAct1 = new DateTimePicker();
            dtpAct3 = new DateTimePicker();
            dtpAct2 = new DateTimePicker();
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
            btnBlockAdd = new Button();
            btnBlockEdit = new Button();
            btnBlockRemove = new Button();
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
            colPlanDate = new DataGridViewTextBoxColumn();
            colPlanStart = new DataGridViewTextBoxColumn();
            colPlanEnd = new DataGridViewTextBoxColumn();
            colPlanSubject = new DataGridViewTextBoxColumn();
            colPlanType = new DataGridViewTextBoxColumn();
            colPlanStrategy = new DataGridViewTextBoxColumn();
            colPlanNotes = new DataGridViewTextBoxColumn();
            pnlPlanTop = new Panel();
            btnPlanClear = new Button();
            btnPlanCopy = new Button();
            btnPlanExportCsv = new Button();
            btnPlanRegenerate = new Button();
            btnPlanGenerate = new Button();
            menuStrip1.SuspendLayout();
            statusMain.SuspendLayout();
            tabMain.SuspendLayout();
            tabSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitSubjects).BeginInit();
            splitSubjects.Panel1.SuspendLayout();
            splitSubjects.Panel2.SuspendLayout();
            splitSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            gbSubjectEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetAct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetLight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetDeep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSubPriority).BeginInit();
            gbActividades.SuspendLayout();
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
            menuStrip1.Size = new Size(1364, 24);
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
            statusMain.Location = new Point(0, 794);
            statusMain.Name = "statusMain";
            statusMain.Size = new Size(1364, 22);
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
            tabMain.Location = new Point(0, 24);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1364, 770);
            tabMain.TabIndex = 2;
            // 
            // tabSubjects
            // 
            tabSubjects.Controls.Add(splitSubjects);
            tabSubjects.Location = new Point(4, 24);
            tabSubjects.Name = "tabSubjects";
            tabSubjects.Padding = new Padding(3);
            tabSubjects.Size = new Size(1356, 742);
            tabSubjects.TabIndex = 0;
            tabSubjects.Text = "Asignaturas";
            tabSubjects.UseVisualStyleBackColor = true;
            // 
            // splitSubjects
            // 
            splitSubjects.Dock = DockStyle.Fill;
            splitSubjects.Location = new Point(3, 3);
            splitSubjects.Name = "splitSubjects";
            // 
            // splitSubjects.Panel1
            // 
            splitSubjects.Panel1.Controls.Add(dgvSubjects);
            // 
            // splitSubjects.Panel2
            // 
            splitSubjects.Panel2.Controls.Add(flowLayoutPanel1);
            splitSubjects.Panel2.Controls.Add(gbSubjectEditor);
            splitSubjects.Size = new Size(1350, 736);
            splitSubjects.SplitterDistance = 702;
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
            dgvSubjects.MultiSelect = false;
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.ReadOnly = true;
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(702, 736);
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSubNew);
            flowLayoutPanel1.Controls.Add(btnSubSave);
            flowLayoutPanel1.Controls.Add(btnSubDelete);
            flowLayoutPanel1.Controls.Add(btnSubClear);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 691);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(644, 45);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnSubNew
            // 
            btnSubNew.Location = new Point(3, 3);
            btnSubNew.Name = "btnSubNew";
            btnSubNew.Size = new Size(75, 23);
            btnSubNew.TabIndex = 0;
            btnSubNew.Text = "Nuevo";
            btnSubNew.UseVisualStyleBackColor = true;
            btnSubNew.Click += btnSubNew_Click;
            // 
            // btnSubSave
            // 
            btnSubSave.Location = new Point(84, 3);
            btnSubSave.Name = "btnSubSave";
            btnSubSave.Size = new Size(75, 23);
            btnSubSave.TabIndex = 1;
            btnSubSave.Text = "Guardar";
            btnSubSave.UseVisualStyleBackColor = true;
            btnSubSave.Click += btnSubSave_Click;
            // 
            // btnSubDelete
            // 
            btnSubDelete.Location = new Point(165, 3);
            btnSubDelete.Name = "btnSubDelete";
            btnSubDelete.Size = new Size(75, 23);
            btnSubDelete.TabIndex = 2;
            btnSubDelete.Text = "Eliminar";
            btnSubDelete.UseVisualStyleBackColor = true;
            btnSubDelete.Click += btnSubDelete_Click;
            // 
            // btnSubClear
            // 
            btnSubClear.Location = new Point(246, 3);
            btnSubClear.Name = "btnSubClear";
            btnSubClear.Size = new Size(75, 23);
            btnSubClear.TabIndex = 3;
            btnSubClear.Text = "Limpiar";
            btnSubClear.UseVisualStyleBackColor = true;
            btnSubClear.Click += btnSubClear_Click;
            // 
            // gbSubjectEditor
            // 
            gbSubjectEditor.Controls.Add(txtAct5);
            gbSubjectEditor.Controls.Add(txtAct4);
            gbSubjectEditor.Controls.Add(txtAct3);
            gbSubjectEditor.Controls.Add(txtAct2);
            gbSubjectEditor.Controls.Add(txtAct1);
            gbSubjectEditor.Controls.Add(txtSubCheckpoint);
            gbSubjectEditor.Controls.Add(lblDondeDeje);
            gbSubjectEditor.Controls.Add(txtSubTopic);
            gbSubjectEditor.Controls.Add(lblTemaActual);
            gbSubjectEditor.Controls.Add(chkHasExam);
            gbSubjectEditor.Controls.Add(chkSubActive);
            gbSubjectEditor.Controls.Add(numTargetAct);
            gbSubjectEditor.Controls.Add(lblObjetivoActividades);
            gbSubjectEditor.Controls.Add(numTargetLight);
            gbSubjectEditor.Controls.Add(lblObjetivoLigth);
            gbSubjectEditor.Controls.Add(numTargetDeep);
            gbSubjectEditor.Controls.Add(lblObjetivoProfundo);
            gbSubjectEditor.Controls.Add(dtpSubExam);
            gbSubjectEditor.Controls.Add(lblFechaExamen);
            gbSubjectEditor.Controls.Add(numSubPriority);
            gbSubjectEditor.Controls.Add(lblPrioridad);
            gbSubjectEditor.Controls.Add(cmbSubCourse);
            gbSubjectEditor.Controls.Add(lblCurso);
            gbSubjectEditor.Controls.Add(txtSubName);
            gbSubjectEditor.Controls.Add(lblNombre);
            gbSubjectEditor.Controls.Add(gbActividades);
            gbSubjectEditor.Dock = DockStyle.Top;
            gbSubjectEditor.Location = new Point(0, 0);
            gbSubjectEditor.Name = "gbSubjectEditor";
            gbSubjectEditor.Size = new Size(644, 585);
            gbSubjectEditor.TabIndex = 0;
            gbSubjectEditor.TabStop = false;
            gbSubjectEditor.Text = "Detalle de asignatura";
            // 
            // txtAct5
            // 
            txtAct5.Location = new Point(22, 512);
            txtAct5.Name = "txtAct5";
            txtAct5.Size = new Size(272, 23);
            txtAct5.TabIndex = 20;
            // 
            // txtAct4
            // 
            txtAct4.Location = new Point(22, 483);
            txtAct4.Name = "txtAct4";
            txtAct4.Size = new Size(272, 23);
            txtAct4.TabIndex = 20;
            // 
            // txtAct3
            // 
            txtAct3.Location = new Point(22, 454);
            txtAct3.Name = "txtAct3";
            txtAct3.Size = new Size(272, 23);
            txtAct3.TabIndex = 20;
            // 
            // txtAct2
            // 
            txtAct2.Location = new Point(22, 425);
            txtAct2.Name = "txtAct2";
            txtAct2.Size = new Size(272, 23);
            txtAct2.TabIndex = 20;
            // 
            // txtAct1
            // 
            txtAct1.Location = new Point(22, 396);
            txtAct1.Name = "txtAct1";
            txtAct1.Size = new Size(272, 23);
            txtAct1.TabIndex = 20;
            // 
            // txtSubCheckpoint
            // 
            txtSubCheckpoint.Location = new Point(98, 331);
            txtSubCheckpoint.Name = "txtSubCheckpoint";
            txtSubCheckpoint.Size = new Size(391, 23);
            txtSubCheckpoint.TabIndex = 19;
            // 
            // lblDondeDeje
            // 
            lblDondeDeje.AutoSize = true;
            lblDondeDeje.Location = new Point(12, 336);
            lblDondeDeje.Name = "lblDondeDeje";
            lblDondeDeje.Size = new Size(80, 15);
            lblDondeDeje.TabIndex = 18;
            lblDondeDeje.Text = "Dónde lo dejé";
            // 
            // txtSubTopic
            // 
            txtSubTopic.Location = new Point(89, 302);
            txtSubTopic.Name = "txtSubTopic";
            txtSubTopic.Size = new Size(205, 23);
            txtSubTopic.TabIndex = 17;
            // 
            // lblTemaActual
            // 
            lblTemaActual.AutoSize = true;
            lblTemaActual.Location = new Point(12, 305);
            lblTemaActual.Name = "lblTemaActual";
            lblTemaActual.Size = new Size(71, 15);
            lblTemaActual.TabIndex = 16;
            lblTemaActual.Text = "Tema actual";
            // 
            // chkHasExam
            // 
            chkHasExam.AutoSize = true;
            chkHasExam.Checked = true;
            chkHasExam.CheckState = CheckState.Checked;
            chkHasExam.Location = new Point(309, 124);
            chkHasExam.Name = "chkHasExam";
            chkHasExam.Size = new Size(99, 19);
            chkHasExam.TabIndex = 15;
            chkHasExam.Text = "Tiene examen";
            chkHasExam.UseVisualStyleBackColor = true;
            // 
            // chkSubActive
            // 
            chkSubActive.AutoSize = true;
            chkSubActive.Location = new Point(12, 268);
            chkSubActive.Name = "chkSubActive";
            chkSubActive.Size = new Size(59, 19);
            chkSubActive.TabIndex = 14;
            chkSubActive.Text = "Activa";
            chkSubActive.UseVisualStyleBackColor = true;
            // 
            // numTargetAct
            // 
            numTargetAct.Location = new Point(128, 233);
            numTargetAct.Name = "numTargetAct";
            numTargetAct.Size = new Size(120, 23);
            numTargetAct.TabIndex = 13;
            // 
            // lblObjetivoActividades
            // 
            lblObjetivoActividades.AutoSize = true;
            lblObjetivoActividades.Location = new Point(6, 235);
            lblObjetivoActividades.Name = "lblObjetivoActividades";
            lblObjetivoActividades.Size = new Size(116, 15);
            lblObjetivoActividades.TabIndex = 12;
            lblObjetivoActividades.Text = "Objetivo Actividades";
            // 
            // numTargetLight
            // 
            numTargetLight.Location = new Point(117, 193);
            numTargetLight.Name = "numTargetLight";
            numTargetLight.Size = new Size(120, 23);
            numTargetLight.TabIndex = 11;
            // 
            // lblObjetivoLigth
            // 
            lblObjetivoLigth.AutoSize = true;
            lblObjetivoLigth.Location = new Point(6, 193);
            lblObjetivoLigth.Name = "lblObjetivoLigth";
            lblObjetivoLigth.Size = new Size(88, 15);
            lblObjetivoLigth.TabIndex = 10;
            lblObjetivoLigth.Text = "Objetivo Ligero";
            // 
            // numTargetDeep
            // 
            numTargetDeep.Location = new Point(117, 157);
            numTargetDeep.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numTargetDeep.Name = "numTargetDeep";
            numTargetDeep.Size = new Size(120, 23);
            numTargetDeep.TabIndex = 9;
            // 
            // lblObjetivoProfundo
            // 
            lblObjetivoProfundo.AutoSize = true;
            lblObjetivoProfundo.Location = new Point(6, 159);
            lblObjetivoProfundo.Name = "lblObjetivoProfundo";
            lblObjetivoProfundo.Size = new Size(105, 15);
            lblObjetivoProfundo.TabIndex = 8;
            lblObjetivoProfundo.Text = "Objetivo Profundo";
            // 
            // dtpSubExam
            // 
            dtpSubExam.Format = DateTimePickerFormat.Short;
            dtpSubExam.Location = new Point(94, 120);
            dtpSubExam.Name = "dtpSubExam";
            dtpSubExam.Size = new Size(200, 23);
            dtpSubExam.TabIndex = 7;
            // 
            // lblFechaExamen
            // 
            lblFechaExamen.AutoSize = true;
            lblFechaExamen.Location = new Point(6, 126);
            lblFechaExamen.Name = "lblFechaExamen";
            lblFechaExamen.Size = new Size(82, 15);
            lblFechaExamen.TabIndex = 6;
            lblFechaExamen.Text = "Fecha Exámen";
            // 
            // numSubPriority
            // 
            numSubPriority.Location = new Point(67, 85);
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
            lblPrioridad.Location = new Point(6, 87);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(55, 15);
            lblPrioridad.TabIndex = 4;
            lblPrioridad.Text = "Prioridad";
            // 
            // cmbSubCourse
            // 
            cmbSubCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubCourse.FormattingEnabled = true;
            cmbSubCourse.Items.AddRange(new object[] { "1º", "2º" });
            cmbSubCourse.Location = new Point(63, 49);
            cmbSubCourse.Name = "cmbSubCourse";
            cmbSubCourse.Size = new Size(121, 23);
            cmbSubCourse.TabIndex = 3;
            // 
            // lblCurso
            // 
            lblCurso.AutoSize = true;
            lblCurso.Location = new Point(6, 52);
            lblCurso.Name = "lblCurso";
            lblCurso.Size = new Size(38, 15);
            lblCurso.TabIndex = 2;
            lblCurso.Text = "Curso";
            // 
            // txtSubName
            // 
            txtSubName.Location = new Point(63, 16);
            txtSubName.Name = "txtSubName";
            txtSubName.Size = new Size(345, 23);
            txtSubName.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(6, 19);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // gbActividades
            // 
            gbActividades.Controls.Add(dtpAct5);
            gbActividades.Controls.Add(dtpAct4);
            gbActividades.Controls.Add(dtpAct1);
            gbActividades.Controls.Add(dtpAct3);
            gbActividades.Controls.Add(dtpAct2);
            gbActividades.Location = new Point(12, 377);
            gbActividades.Name = "gbActividades";
            gbActividades.Size = new Size(614, 183);
            gbActividades.TabIndex = 22;
            gbActividades.TabStop = false;
            gbActividades.Text = "Actividades";
            // 
            // dtpAct5
            // 
            dtpAct5.Checked = false;
            dtpAct5.Format = DateTimePickerFormat.Short;
            dtpAct5.Location = new Point(297, 135);
            dtpAct5.Name = "dtpAct5";
            dtpAct5.ShowCheckBox = true;
            dtpAct5.Size = new Size(200, 23);
            dtpAct5.TabIndex = 21;
            // 
            // dtpAct4
            // 
            dtpAct4.Checked = false;
            dtpAct4.Format = DateTimePickerFormat.Short;
            dtpAct4.Location = new Point(297, 106);
            dtpAct4.Name = "dtpAct4";
            dtpAct4.ShowCheckBox = true;
            dtpAct4.Size = new Size(200, 23);
            dtpAct4.TabIndex = 21;
            // 
            // dtpAct1
            // 
            dtpAct1.Checked = false;
            dtpAct1.Format = DateTimePickerFormat.Short;
            dtpAct1.Location = new Point(297, 19);
            dtpAct1.Name = "dtpAct1";
            dtpAct1.ShowCheckBox = true;
            dtpAct1.Size = new Size(200, 23);
            dtpAct1.TabIndex = 21;
            // 
            // dtpAct3
            // 
            dtpAct3.Checked = false;
            dtpAct3.Format = DateTimePickerFormat.Short;
            dtpAct3.Location = new Point(297, 77);
            dtpAct3.Name = "dtpAct3";
            dtpAct3.ShowCheckBox = true;
            dtpAct3.Size = new Size(200, 23);
            dtpAct3.TabIndex = 21;
            // 
            // dtpAct2
            // 
            dtpAct2.Checked = false;
            dtpAct2.Format = DateTimePickerFormat.Short;
            dtpAct2.Location = new Point(297, 48);
            dtpAct2.Name = "dtpAct2";
            dtpAct2.ShowCheckBox = true;
            dtpAct2.Size = new Size(200, 23);
            dtpAct2.TabIndex = 21;
            // 
            // tabWeek
            // 
            tabWeek.Controls.Add(splitContainer1);
            tabWeek.Controls.Add(panel1);
            tabWeek.Location = new Point(4, 24);
            tabWeek.Name = "tabWeek";
            tabWeek.Padding = new Padding(3);
            tabWeek.Size = new Size(1356, 742);
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
            splitContainer1.Size = new Size(1350, 681);
            splitContainer1.SplitterDistance = 446;
            splitContainer1.TabIndex = 1;
            // 
            // gbShifts
            // 
            gbShifts.Controls.Add(dgvShifts);
            gbShifts.Dock = DockStyle.Fill;
            gbShifts.Location = new Point(0, 0);
            gbShifts.Name = "gbShifts";
            gbShifts.Size = new Size(446, 681);
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
            dgvShifts.Location = new Point(3, 19);
            dgvShifts.Name = "dgvShifts";
            dgvShifts.Size = new Size(440, 659);
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
            gbBlocks.Size = new Size(900, 681);
            gbBlocks.TabIndex = 0;
            gbBlocks.TabStop = false;
            gbBlocks.Text = "Huecos de estudio";
            // 
            // flpBlocksButtons
            // 
            flpBlocksButtons.Controls.Add(btnBlockAdd);
            flpBlocksButtons.Controls.Add(btnBlockEdit);
            flpBlocksButtons.Controls.Add(btnBlockRemove);
            flpBlocksButtons.Dock = DockStyle.Bottom;
            flpBlocksButtons.Location = new Point(3, 578);
            flpBlocksButtons.Name = "flpBlocksButtons";
            flpBlocksButtons.Size = new Size(894, 100);
            flpBlocksButtons.TabIndex = 1;
            // 
            // btnBlockAdd
            // 
            btnBlockAdd.Location = new Point(3, 3);
            btnBlockAdd.Name = "btnBlockAdd";
            btnBlockAdd.Size = new Size(75, 23);
            btnBlockAdd.TabIndex = 0;
            btnBlockAdd.Text = "Añadir";
            btnBlockAdd.UseVisualStyleBackColor = true;
            btnBlockAdd.Click += btnBlockAdd_Click_1;
            // 
            // btnBlockEdit
            // 
            btnBlockEdit.Location = new Point(84, 3);
            btnBlockEdit.Name = "btnBlockEdit";
            btnBlockEdit.Size = new Size(75, 23);
            btnBlockEdit.TabIndex = 1;
            btnBlockEdit.Text = "Editar";
            btnBlockEdit.UseVisualStyleBackColor = true;
            btnBlockEdit.Click += btnBlockEdit_Click;
            // 
            // btnBlockRemove
            // 
            btnBlockRemove.Location = new Point(165, 3);
            btnBlockRemove.Name = "btnBlockRemove";
            btnBlockRemove.Size = new Size(75, 23);
            btnBlockRemove.TabIndex = 2;
            btnBlockRemove.Text = "Elimnar";
            btnBlockRemove.UseVisualStyleBackColor = true;
            btnBlockRemove.Click += btnBlockRemove_Click;
            // 
            // dgvBlocks
            // 
            dgvBlocks.AllowUserToAddRows = false;
            dgvBlocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBlocks.Columns.AddRange(new DataGridViewColumn[] { colBlockDate, colBlockStart, colBlockEnd, colBlockDuration, colBlockHint });
            dgvBlocks.Dock = DockStyle.Fill;
            dgvBlocks.Location = new Point(3, 19);
            dgvBlocks.Name = "dgvBlocks";
            dgvBlocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBlocks.Size = new Size(894, 659);
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
            panel1.Size = new Size(1350, 55);
            panel1.TabIndex = 0;
            // 
            // btnWeekClear
            // 
            btnWeekClear.Location = new Point(603, 11);
            btnWeekClear.Name = "btnWeekClear";
            btnWeekClear.Size = new Size(75, 23);
            btnWeekClear.TabIndex = 4;
            btnWeekClear.Text = "Limpiar";
            btnWeekClear.UseVisualStyleBackColor = true;
            // 
            // btnWeekAutoBlocks
            // 
            btnWeekAutoBlocks.Location = new Point(421, 11);
            btnWeekAutoBlocks.Name = "btnWeekAutoBlocks";
            btnWeekAutoBlocks.Size = new Size(176, 23);
            btnWeekAutoBlocks.TabIndex = 3;
            btnWeekAutoBlocks.Text = "Sugerir huecos (según turno)";
            btnWeekAutoBlocks.UseVisualStyleBackColor = true;
            btnWeekAutoBlocks.Click += btnWeekAutoBlocks_Click;
            // 
            // btnWeekLoad
            // 
            btnWeekLoad.Location = new Point(314, 11);
            btnWeekLoad.Name = "btnWeekLoad";
            btnWeekLoad.Size = new Size(101, 23);
            btnWeekLoad.TabIndex = 2;
            btnWeekLoad.Text = "Cargar semana";
            btnWeekLoad.UseVisualStyleBackColor = true;
            // 
            // dtpWeekStart
            // 
            dtpWeekStart.Location = new Point(108, 11);
            dtpWeekStart.Name = "dtpWeekStart";
            dtpWeekStart.Size = new Size(200, 23);
            dtpWeekStart.TabIndex = 1;
            // 
            // lblInicioSemana
            // 
            lblInicioSemana.AutoSize = true;
            lblInicioSemana.Location = new Point(5, 17);
            lblInicioSemana.Name = "lblInicioSemana";
            lblInicioSemana.Size = new Size(97, 15);
            lblInicioSemana.TabIndex = 0;
            lblInicioSemana.Text = "Inicio de Semana";
            // 
            // tabPlan
            // 
            tabPlan.Controls.Add(pnlPlanSummary);
            tabPlan.Controls.Add(dgvPlan);
            tabPlan.Controls.Add(pnlPlanTop);
            tabPlan.Location = new Point(4, 24);
            tabPlan.Name = "tabPlan";
            tabPlan.Padding = new Padding(3);
            tabPlan.Size = new Size(1356, 742);
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
            pnlPlanSummary.Location = new Point(812, 58);
            pnlPlanSummary.Name = "pnlPlanSummary";
            pnlPlanSummary.Size = new Size(541, 681);
            pnlPlanSummary.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblChechlpoint);
            panel2.Controls.Add(lblTema);
            panel2.Controls.Add(btnPlanSessionSave);
            panel2.Controls.Add(chkPlanCompleted);
            panel2.Controls.Add(txtPlanCheckpoint);
            panel2.Controls.Add(txtPlanTopic);
            panel2.Location = new Point(12, 518);
            panel2.Name = "panel2";
            panel2.Size = new Size(523, 157);
            panel2.TabIndex = 3;
            // 
            // lblChechlpoint
            // 
            lblChechlpoint.AutoSize = true;
            lblChechlpoint.Location = new Point(6, 64);
            lblChechlpoint.Name = "lblChechlpoint";
            lblChechlpoint.Size = new Size(68, 15);
            lblChechlpoint.TabIndex = 5;
            lblChechlpoint.Text = "Checkpoint";
            // 
            // lblTema
            // 
            lblTema.AutoSize = true;
            lblTema.Location = new Point(6, 11);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(36, 15);
            lblTema.TabIndex = 4;
            lblTema.Text = "Tema";
            // 
            // btnPlanSessionSave
            // 
            btnPlanSessionSave.Location = new Point(229, 131);
            btnPlanSessionSave.Name = "btnPlanSessionSave";
            btnPlanSessionSave.Size = new Size(125, 23);
            btnPlanSessionSave.TabIndex = 3;
            btnPlanSessionSave.Text = "Guardar Sesión";
            btnPlanSessionSave.UseVisualStyleBackColor = true;
            btnPlanSessionSave.Click += btnPlanSessionSave_Click;
            // 
            // chkPlanCompleted
            // 
            chkPlanCompleted.AutoSize = true;
            chkPlanCompleted.Location = new Point(3, 111);
            chkPlanCompleted.Name = "chkPlanCompleted";
            chkPlanCompleted.Size = new Size(92, 19);
            chkPlanCompleted.TabIndex = 2;
            chkPlanCompleted.Text = "Completado";
            chkPlanCompleted.UseVisualStyleBackColor = true;
            chkPlanCompleted.CheckedChanged += chkPlanCompleted_CheckedChanged;
            // 
            // txtPlanCheckpoint
            // 
            txtPlanCheckpoint.Location = new Point(3, 82);
            txtPlanCheckpoint.Name = "txtPlanCheckpoint";
            txtPlanCheckpoint.Size = new Size(351, 23);
            txtPlanCheckpoint.TabIndex = 1;
            // 
            // txtPlanTopic
            // 
            txtPlanTopic.Location = new Point(3, 29);
            txtPlanTopic.Name = "txtPlanTopic";
            txtPlanTopic.Size = new Size(351, 23);
            txtPlanTopic.TabIndex = 0;
            // 
            // lvSummary
            // 
            lvSummary.Columns.AddRange(new ColumnHeader[] { Asignatura, Objetivo, Planificado });
            lvSummary.Location = new Point(0, 0);
            lvSummary.Name = "lvSummary";
            lvSummary.Size = new Size(535, 241);
            lvSummary.TabIndex = 1;
            lvSummary.UseCompatibleStateImageBehavior = false;
            // 
            // lblResumenSemanal
            // 
            lblResumenSemanal.AutoSize = true;
            lblResumenSemanal.Location = new Point(3, 13);
            lblResumenSemanal.Name = "lblResumenSemanal";
            lblResumenSemanal.Size = new Size(104, 15);
            lblResumenSemanal.TabIndex = 0;
            lblResumenSemanal.Text = "Resumen Semanal";
            // 
            // gbAvisos
            // 
            gbAvisos.Controls.Add(lblWarnings);
            gbAvisos.Location = new Point(3, 247);
            gbAvisos.Name = "gbAvisos";
            gbAvisos.Size = new Size(532, 265);
            gbAvisos.TabIndex = 4;
            gbAvisos.TabStop = false;
            gbAvisos.Text = "Avisos";
            // 
            // lblWarnings
            // 
            lblWarnings.AutoSize = true;
            lblWarnings.Location = new Point(12, 19);
            lblWarnings.Name = "lblWarnings";
            lblWarnings.Size = new Size(41, 15);
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
            dgvPlan.Size = new Size(1350, 681);
            dgvPlan.TabIndex = 1;
            // 
            // colPlanDate
            // 
            colPlanDate.HeaderText = "Fecha";
            colPlanDate.Name = "colPlanDate";
            // 
            // colPlanStart
            // 
            colPlanStart.HeaderText = "Inicio";
            colPlanStart.Name = "colPlanStart";
            // 
            // colPlanEnd
            // 
            colPlanEnd.HeaderText = "Fin";
            colPlanEnd.Name = "colPlanEnd";
            // 
            // colPlanSubject
            // 
            colPlanSubject.HeaderText = "Asignatura";
            colPlanSubject.Name = "colPlanSubject";
            // 
            // colPlanType
            // 
            colPlanType.HeaderText = "Tipo";
            colPlanType.Name = "colPlanType";
            // 
            // colPlanStrategy
            // 
            colPlanStrategy.HeaderText = "Estrategia";
            colPlanStrategy.Name = "colPlanStrategy";
            // 
            // colPlanNotes
            // 
            colPlanNotes.HeaderText = "Notas";
            colPlanNotes.Name = "colPlanNotes";
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
            pnlPlanTop.Size = new Size(1350, 55);
            pnlPlanTop.TabIndex = 0;
            // 
            // btnPlanClear
            // 
            btnPlanClear.Location = new Point(329, 17);
            btnPlanClear.Name = "btnPlanClear";
            btnPlanClear.Size = new Size(75, 23);
            btnPlanClear.TabIndex = 4;
            btnPlanClear.Text = "Eliminar planning";
            btnPlanClear.UseVisualStyleBackColor = true;
            btnPlanClear.Click += btnPlanClear_Click;
            // 
            // btnPlanCopy
            // 
            btnPlanCopy.Location = new Point(248, 17);
            btnPlanCopy.Name = "btnPlanCopy";
            btnPlanCopy.Size = new Size(75, 23);
            btnPlanCopy.TabIndex = 3;
            btnPlanCopy.Text = "Copiar texto";
            btnPlanCopy.UseVisualStyleBackColor = true;
            // 
            // btnPlanExportCsv
            // 
            btnPlanExportCsv.Location = new Point(167, 17);
            btnPlanExportCsv.Name = "btnPlanExportCsv";
            btnPlanExportCsv.Size = new Size(75, 23);
            btnPlanExportCsv.TabIndex = 2;
            btnPlanExportCsv.Text = "Exportar CSV";
            btnPlanExportCsv.UseVisualStyleBackColor = true;
            // 
            // btnPlanRegenerate
            // 
            btnPlanRegenerate.Location = new Point(86, 17);
            btnPlanRegenerate.Name = "btnPlanRegenerate";
            btnPlanRegenerate.Size = new Size(75, 23);
            btnPlanRegenerate.TabIndex = 1;
            btnPlanRegenerate.Text = "Regenerar";
            btnPlanRegenerate.UseVisualStyleBackColor = true;
            // 
            // btnPlanGenerate
            // 
            btnPlanGenerate.Location = new Point(5, 17);
            btnPlanGenerate.Name = "btnPlanGenerate";
            btnPlanGenerate.Size = new Size(75, 23);
            btnPlanGenerate.TabIndex = 0;
            btnPlanGenerate.Text = "Generar planning";
            btnPlanGenerate.UseVisualStyleBackColor = true;
            btnPlanGenerate.Click += btnPlanGenerate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 816);
            Controls.Add(tabMain);
            Controls.Add(statusMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
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
            flowLayoutPanel1.ResumeLayout(false);
            gbSubjectEditor.ResumeLayout(false);
            gbSubjectEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetAct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetLight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetDeep).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSubPriority).EndInit();
            gbActividades.ResumeLayout(false);
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
        private Label lblFechaExamen;
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
        private DataGridViewTextBoxColumn colPlanDate;
        private DataGridViewTextBoxColumn colPlanStart;
        private DataGridViewTextBoxColumn colPlanEnd;
        private DataGridViewTextBoxColumn colPlanSubject;
        private DataGridViewTextBoxColumn colPlanType;
        private DataGridViewTextBoxColumn colPlanStrategy;
        private DataGridViewTextBoxColumn colPlanNotes;
        private ListView lvSummary;
        private ColumnHeader Asignatura;
        private ColumnHeader Objetivo;
        private ColumnHeader Planificado;
        private Label lblWarnings;
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
    }
}
