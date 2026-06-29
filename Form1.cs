using StudyPlannerWinForms.Models;
using StudyPlannerWinForms.Services;
using System.ComponentModel;

namespace StudyPlannerWinForms;

public partial class Form1 : Form
{
    // ========================================================================
    // CAMPOS DE CLASE Y ESTADO DE LA APLICACIÓN
    // ========================================================================
    private readonly BindingSource _bsSubjects = new();

    private readonly TimeBlockService _timeBlockService = new();
    private readonly PlanSummaryService _planSummaryService = new();
    private readonly SubjectService _subjectService = new();

    private readonly BindingSource _bsBlocks = new();
    private readonly BindingSource _bsPlan = new();
    private BindingList<Subject> _blSubjects = new();
    private BindingList<TimeBlock> _blBlocks = new();
    private BindingList<StudySession> _blPlan = new();
    private readonly TextBox[] _actTitleBoxes;
    private readonly DateTimePicker[] _actDatePickers;
    private Guid? _editingSubjectId = null;
    private AppData _data = new();

    private readonly string _jsonPath = Path.Combine(
    Application.StartupPath,
    "data.json");

    // ========================================================================
    // CONSTRUCTOR
    // ========================================================================
    public Form1()
    {
        InitializeComponent();

        // Inicialización única de los conjuntos de controles de la interfaz.
        _actTitleBoxes = new TextBox[] { txtAct1, txtAct2, txtAct3, txtAct4, txtAct5 };
        _actDatePickers = new DateTimePicker[] { dtpAct1, dtpAct2, dtpAct3, dtpAct4, dtpAct5 };

        // Asegura la existencia del directorio de persistencia de datos.
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath)!);

        SetupSummaryListView();
        SetupSubjectsGrid();
        BindSubjects();
        SetupBlocksGrid();
        BindBlocks();
        SetupPlanGrid();
        BindPlan();
        AutoLoadOnStartup();

        // Suscripción a eventos del ciclo de vida del formulario y controles.
        this.FormClosing += Form1_FormClosing;
        chkHasExam.CheckedChanged += chkHasExam_CheckedChanged;
    }

    // ========================================================================
    // CARGA Y PERSISTENCIA DE DATOS
    // ========================================================================
    private void AutoLoadOnStartup()
    {
        try
        {
            _data = JsonStorage.Load(_jsonPath);
            toolStripStatusLabel1.Text = "Datos cargados automáticamente.";
        }
        catch (Exception ex)
        {
            _data = new AppData();

            MessageBox.Show(
                $"El archivo de datos no se pudo cargar porque está dañado o tiene un formato incorrecto.\n\nSe ha inicializado un espacio de trabajo vacío.\n\nDetalles: {ex.Message}",
                "Aviso del Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            toolStripStatusLabel1.Text = "Error al cargar el JSON. Datos reestablecidos.";
        }

        BindSubjects();
        BindBlocks();
        BindPlan();
        RefreshPlanSummary();
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        CreateLocalBackup();
        JsonStorage.Save(_jsonPath, _data);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void mnuSave_Click(object sender, EventArgs e)
    {
        JsonStorage.Save(_jsonPath, _data);
        toolStripStatusLabel1.Text = "Datos guardados en JSON.";
    }

    private void mnuLoad_Click(object sender, EventArgs e)
    {
        try
        {
            _data = JsonStorage.Load(_jsonPath);
            toolStripStatusLabel1.Text = "Datos cargados desde JSON.";
        }
        catch (Exception ex)
        {
            _data = new AppData();

            MessageBox.Show(
                $"Error al cargar el archivo seleccionado.\n\nDetalles: {ex.Message}",
                "Error de Carga",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            toolStripStatusLabel1.Text = "Fallo en la carga manual del archivo.";
        }

        BindSubjects();
        BindBlocks();
        BindPlan();
        RefreshPlanSummary();
    }

    // ========================================================================
    // GESTIÓN DE ASIGNATURAS (SUBJECTS)
    // ========================================================================
    private void SetupSubjectsGrid()
    {
        dgvSubjects.AutoGenerateColumns = false;

        // Configuración del mapeo de datos entre las columnas de la vista y el modelo.
        colSubName.DataPropertyName = nameof(Subject.Name);
        colSubCourse.DataPropertyName = nameof(Subject.Course);
        colSubPriority.DataPropertyName = nameof(Subject.Priority);
        colSubExam.DataPropertyName = nameof(Subject.ExamDate);
        colSubDeep.DataPropertyName = nameof(Subject.TargetDeepMinutes);
        colSubLight.DataPropertyName = nameof(Subject.TargetLightMinutes);
        colSubAct.DataPropertyName = nameof(Subject.TargetActivityMinutes);
        colSubActive.DataPropertyName = nameof(Subject.Active);

        dgvSubjects.SelectionChanged += dgvSubjects_SelectionChanged;
    }

    private void BindSubjects()
    {
        _blSubjects = new BindingList<Subject>(_data.Subjects);
        _bsSubjects.DataSource = _blSubjects;
        dgvSubjects.DataSource = _bsSubjects;
    }

    private void dgvSubjects_SelectionChanged(object? sender, EventArgs e)
    {
        var s = GetSelectedSubject();
        if (s == null) return;

        LoadSubjectToEditor(s);
    }

    private Subject? GetSelectedSubject()
    {
        if (dgvSubjects.CurrentRow?.DataBoundItem is Subject s)
            return s;

        return null;
    }

    private void LoadSubjectToEditor(Subject s)
    {
        _editingSubjectId = s.Id;

        txtSubName.Text = s.Name;
        cmbSubCourse.SelectedItem = s.Course;
        numSubPriority.Value = s.Priority;
        txtSubTopic.Text = s.CurrentTopic;
        txtSubCheckpoint.Text = s.CurrentCheckpoint;

        // Gestión del estado del selector de fecha evaluando la nulabilidad de la propiedad.
        if (s.ExamDate.HasValue)
        {
            chkHasExam.Checked = true;
            dtpSubExam.Enabled = true;
            dtpSubExam.Value = s.ExamDate.Value;
        }
        else
        {
            chkHasExam.Checked = false;
            dtpSubExam.Enabled = false;
            dtpSubExam.Value = DateTime.Today;
        }

        numTargetDeep.Value = s.TargetDeepMinutes;
        numTargetLight.Value = s.TargetLightMinutes;
        numTargetAct.Value = s.TargetActivityMinutes;
        chkSubActive.Checked = s.Active;

        LoadActivitiesToEditor(s);
    }

    private void btnSubNew_Click(object sender, EventArgs e)
    {
        ClearSubjectEditor();
        _editingSubjectId = null;
    }

    private void btnSubClear_Click(object sender, EventArgs e)
    {
        ClearSubjectEditor();
        dgvSubjects.ClearSelection();
        _editingSubjectId = null;
    }

    private void ClearSubjectEditor()
    {
        txtSubName.Clear();
        cmbSubCourse.SelectedIndex = -1;
        numSubPriority.Value = 3;

        // Restablecimiento del estado del examen.
        chkHasExam.Checked = false;
        dtpSubExam.Enabled = false;
        dtpSubExam.Value = DateTime.Today;

        numTargetDeep.Value = 0;
        numTargetLight.Value = 0;
        numTargetAct.Value = 0;
        chkSubActive.Checked = true;
        txtSubTopic.Clear();
        txtSubCheckpoint.Clear();

        CreateLocalBackup();
        ClearActivitiesEditor();
    }

    private void ClearActivitiesEditor()
    {
        var titles = _actTitleBoxes;
        var dates = _actDatePickers;

        for (int i = 0; i < 5; i++)
        {
            titles[i].Clear();
            dates[i].Value = DateTime.Today;
            dates[i].Checked = false;
        }
    }

    private void LoadActivitiesToEditor(Subject s)
    {
        ClearActivitiesEditor();

        var titles = _actTitleBoxes;
        var dates = _actDatePickers;

        for (int i = 0; i < Math.Min(5, s.Activities.Count); i++)
        {
            titles[i].Text = s.Activities[i].Title;

            if (s.Activities[i].DueDate.HasValue)
            {
                dates[i].Value = s.Activities[i].DueDate.Value.Date;
                dates[i].Checked = true;
            }
            else
            {
                dates[i].Value = DateTime.Today;
                dates[i].Checked = false;
            }
        }
    }

    private List<SubjectActivity> ReadActivitiesFromEditor()
    {
        var list = new List<SubjectActivity>();
        var titles = _actTitleBoxes;
        var dates = _actDatePickers;

        for (int i = 0; i < 5; i++)
        {
            var title = titles[i].Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
                continue;

            DateTime? due = dates[i].Checked ? dates[i].Value.Date : (DateTime?)null;

            list.Add(new SubjectActivity
            {
                Title = title,
                DueDate = due
            });
        }

        return list;
    }

    private void chkHasExam_CheckedChanged(object? sender, EventArgs e)
    {
        dtpSubExam.Enabled = chkHasExam.Checked;
    }

    private void btnSubSave_Click(object sender, EventArgs e)
    {
        //Validaciones de UI
        var name = txtSubName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            toolStripStatusLabel1.Text = "El nombre de la asignatura no puede estar vacío.";
            return;
        }
        if (cmbSubCourse.SelectedItem == null)
        {
            toolStripStatusLabel1.Text = "Selecciona el curso (1º/2º).";
            return;
        }

        //Empaquetamos los datos del formulario en un objeto temporal
        var tempSubject = new Subject
        {
            Name = name,
            Course = cmbSubCourse.SelectedItem.ToString()!,
            Priority = (int)numSubPriority.Value,
            ExamDate = chkHasExam.Checked ? dtpSubExam.Value.Date : null,
            TargetDeepMinutes = (int)numTargetDeep.Value,
            TargetLightMinutes = (int)numTargetLight.Value,
            TargetActivityMinutes = (int)numTargetAct.Value,
            Active = chkSubActive.Checked,
            CurrentTopic = txtSubTopic.Text.Trim(),
            CurrentCheckpoint = txtSubCheckpoint.Text.Trim(),
            Activities = ReadActivitiesFromEditor()
        };

        //Delegación del guardado al servicio
        _editingSubjectId = _subjectService.SaveSubject(_data, _editingSubjectId, tempSubject, out var statusMsg);

        //Actualización de la interfaz y persistencia en el JSON
        _blSubjects.ResetBindings();
        CreateLocalBackup();
        JsonStorage.Save(_jsonPath, _data);
        toolStripStatusLabel1.Text = statusMsg;
    }

    private void btnSubDelete_Click(object sender, EventArgs e)
    {
        var s = GetSelectedSubject();
        if (s == null)
        {
            toolStripStatusLabel1.Text = "Debe seleccionar una asignatura para proceder con la eliminación.";
            return;
        }

        var ok = MessageBox.Show(
            $"¿Está seguro de que desea eliminar la asignatura '{s.Name}'?",
            "Confirmación de eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        if (_subjectService.DeleteSubject(_data, s, out var statusMsg))
        {
            _blSubjects.ResetBindings();
            ClearSubjectEditor();
            _editingSubjectId = null;
            CreateLocalBackup();
            JsonStorage.Save(_jsonPath, _data);
        }

        toolStripStatusLabel1.Text = statusMsg;
    }

    // ========================================================================
    // GESTIÓN DE BLOQUES DE TIEMPO (TIME BLOCKS)
    // ========================================================================
    private void SetupBlocksGrid()
    {
        dgvBlocks.AutoGenerateColumns = false;

        // Configuración de la cuadrícula para restringir la edición directa.
        dgvBlocks.ReadOnly = true;
        dgvBlocks.AllowUserToAddRows = false;
        dgvBlocks.AllowUserToDeleteRows = false;
        dgvBlocks.EditMode = DataGridViewEditMode.EditProgrammatically;

        colBlockDate.DataPropertyName = nameof(TimeBlock.Date);
        colBlockStart.DataPropertyName = nameof(TimeBlock.Start);
        colBlockEnd.DataPropertyName = nameof(TimeBlock.End);

        dgvBlocks.CellFormatting += dgvBlocks_CellFormatting;
        dgvBlocks.DataError += dgvBlocks_DataError;
    }

    private void dgvBlocks_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        // Intercepción y supresión de excepciones de formato generadas por el DataGridView.
        e.ThrowException = false;
    }

    private void dgvBlocks_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvBlocks.Rows[e.RowIndex].DataBoundItem is not TimeBlock b)
            return;

        string colName = dgvBlocks.Columns[e.ColumnIndex].Name;

        if (colName == "colBlockDate")
        {
            e.Value = b.Date.ToString("dd/MM/yyyy");
            e.FormattingApplied = true;
        }
        else if (colName == "colBlockStart")
        {
            e.Value = DateTime.Today.Add(b.Start).ToString("HH:mm");
            e.FormattingApplied = true;
        }
        else if (colName == "colBlockEnd")
        {
            e.Value = DateTime.Today.Add(b.End).ToString("HH:mm");
            e.FormattingApplied = true;
        }
        else if (colName == "colBlockDuration")
        {
            e.Value = b.DurationMinutes;
            e.FormattingApplied = true;
        }
        else if (colName == "colBlockHint")
        {
            e.Value = b.DurationMinutes >= 50 ? "Profundo" : "Ligero";
            e.FormattingApplied = true;
        }
    }

    private void BindBlocks()
    {
        _blBlocks = new BindingList<TimeBlock>(_data.TimeBlocks);
        _bsBlocks.DataSource = _blBlocks;
        dgvBlocks.DataSource = _bsBlocks;
    }

    private TimeBlock? GetSelectedBlock()
    {
        return dgvBlocks.CurrentRow?.DataBoundItem as TimeBlock;
    }

    private void btnWeekAutoBlocks_Click(object sender, EventArgs e)
    {
        using var dlg = new WeekAutoBlocksDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return;

        var monday = dlg.GetWeekMonday();
        var shifts = dlg.GetShifts();

        _timeBlockService.GenerateWeekBlocks(_data, monday, shifts, dlg.ReplaceWeekBlocks);

        _blBlocks.ResetBindings();
        toolStripStatusLabel1.Text = "Generación de bloques semanales completada.";
    }

    private void btnBlockAdd_Click_1(object sender, EventArgs e)
    {
        using var dlg = new TimeBlockDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return;

        var block = dlg.GetBlock();

        if (!_timeBlockService.IsBlockValid(block, editing: null, _data.TimeBlocks, out var msg))
        {
            MessageBox.Show(msg, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _data.TimeBlocks.Add(block);
        _blBlocks.ResetBindings();

        toolStripStatusLabel1.Text = "Bloque de tiempo añadido correctamente.";
    }

    private void btnBlockEdit_Click(object sender, EventArgs e)
    {
        var selected = GetSelectedBlock();
        if (selected == null)
        {
            toolStripStatusLabel1.Text = "Debe seleccionar un bloque para iniciar la edición.";
            return;
        }

        using var dlg = new TimeBlockDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;
        dlg.SetBlock(selected);

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var edited = dlg.GetBlock();

        if (!_timeBlockService.IsBlockValid(edited, editing: selected, _data.TimeBlocks, out var msg))
        {
            MessageBox.Show(msg, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        selected.Date = edited.Date;
        selected.Start = edited.Start;
        selected.End = edited.End;

        _blBlocks.ResetBindings();
        toolStripStatusLabel1.Text = "Bloque de tiempo modified correctamente.";
    }

    private void btnBlockRemove_Click(object sender, EventArgs e)
    {
        var selected = GetSelectedBlock();
        if (selected == null)
        {
            toolStripStatusLabel1.Text = "Debe seleccionar un bloque para proceder con la eliminación.";
            return;
        }

        var ok = MessageBox.Show(
            "¿Confirma la eliminación del bloque de tiempo seleccionado?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        _data.TimeBlocks.Remove(selected);
        _blBlocks.ResetBindings();

        toolStripStatusLabel1.Text = "Bloque de tiempo eliminado.";
    }

    // ========================================================================
    // RESUMEN Y PLANIFICACIÓN DE SESIONES (PLAN)
    // ========================================================================
    private void SetupPlanGrid()
    {
        dgvPlan.AutoGenerateColumns = false;
        dgvPlan.ReadOnly = true;
        dgvPlan.AllowUserToAddRows = false;
        dgvPlan.AllowUserToDeleteRows = false;
        dgvPlan.EditMode = DataGridViewEditMode.EditProgrammatically;

        colPlanDate.DataPropertyName = nameof(StudySession.Date);
        colPlanStart.DataPropertyName = nameof(StudySession.Start);
        colPlanEnd.DataPropertyName = nameof(StudySession.End);
        colPlanSubject.DataPropertyName = nameof(StudySession.SubjectId);
        colPlanType.DataPropertyName = nameof(StudySession.Type);
        colPlanStrategy.DataPropertyName = nameof(StudySession.Strategy);
        colPlanNotes.DataPropertyName = nameof(StudySession.Notes);

        // Optimización del comportamiento de escalado y renderizado del Grid.
        dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        colPlanDate.FillWeight = 12;
        colPlanStart.FillWeight = 8;
        colPlanEnd.FillWeight = 8;
        colPlanSubject.FillWeight = 20;
        colPlanType.FillWeight = 12;
        colPlanStrategy.FillWeight = 25;
        colPlanNotes.FillWeight = 15;

        dgvPlan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dgvPlan.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

        colPlanStrategy.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        colPlanNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        dgvPlan.RowTemplate.MinimumHeight = 22;

        dgvPlan.DataError += dgvPlan_DataError;
        dgvPlan.CellFormatting += dgvPlan_CellFormatting;
        dgvPlan.SelectionChanged += dgvPlan_SelectionChanged;
    }

    private void SetupSummaryListView()
    {
        lvSummary.View = View.Details;
        lvSummary.FullRowSelect = true;
        lvSummary.GridLines = true;
        lvSummary.HideSelection = false;

        lvSummary.Columns.Clear();
        lvSummary.Columns.Add("Asignatura", 160);
        lvSummary.Columns.Add("Objetivo (D/L/A)", 170);
        lvSummary.Columns.Add("Planificado (D/L/A)", 190);
    }

    private void RefreshPlanSummary()
    {
        lvSummary.Items.Clear();
        lblWarnings.Text = "";

        var summary = _planSummaryService.CalculateSummary(_data);

        foreach (var row in summary.Rows)
        {
            var item = new ListViewItem(row.SubjectName);
            item.SubItems.Add(row.TargetDla);
            item.SubItems.Add(row.PlannedDla);
            lvSummary.Items.Add(item);
        }

        lblWarnings.Text = summary.Warnings.Count == 0
            ? "Estado óptimo: Sin avisos reportados."
            : string.Join(Environment.NewLine, summary.Warnings);
    }

    private StudySession? GetSelectedSession() => dgvPlan.CurrentRow?.DataBoundItem as StudySession;

    private void dgvPlan_SelectionChanged(object? sender, EventArgs e)
    {
        var s = GetSelectedSession();
        if (s == null) return;

        txtPlanTopic.Text = s.Topic;
        txtPlanCheckpoint.Text = s.Checkpoint;
        chkPlanCompleted.Checked = s.Completed;
    }

    private void dgvPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;
    }

    private void BindPlan()
    {
        _blPlan = new BindingList<StudySession>(_data.Plan);
        _bsPlan.DataSource = _blPlan;
        dgvPlan.DataSource = _bsPlan;
    }

    private void dgvPlan_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvPlan.Rows[e.RowIndex].DataBoundItem is not StudySession s)
            return;

        string colName = dgvPlan.Columns[e.ColumnIndex].Name;

        if (colName == "colPlanDate")
        {
            e.Value = s.Date.ToString("dd/MM/yyyy");
            e.FormattingApplied = true;
        }
        else if (colName == "colPlanStart")
        {
            e.Value = DateTime.Today.Add(s.Start).ToString("HH:mm");
            e.FormattingApplied = true;
        }
        else if (colName == "colPlanEnd")
        {
            e.Value = DateTime.Today.Add(s.End).ToString("HH:mm");
            e.FormattingApplied = true;
        }
        else if (colName == "colPlanSubject")
        {
            var sub = _data.Subjects.FirstOrDefault(x => x.Id == s.SubjectId);
            e.Value = sub?.Name ?? "(Entidad huérfana / Sin asignatura)";
            e.FormattingApplied = true;
        }
    }

    private void btnPlanGenerate_Click(object sender, EventArgs e)
    {
        // Instanciación del servicio inyector de lógica de negocio.
        var generator = new PlanGenerator();

        // Ejecución del algoritmo de optimización y distribución temporal.
        var result = generator.GeneratePlan(_data);

        // Actualización de la capa de presentación según el resultado del procesamiento.
        if (!result.Success)
        {
            MessageBox.Show(result.Message, "Sistema de Planificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _blPlan.ResetBindings();
        RefreshPlanSummary();
        toolStripStatusLabel1.Text = result.Message;
    }

    private void btnPlanClear_Click(object sender, EventArgs e)
    {
        if (_data.Plan.Count == 0)
        {
            toolStripStatusLabel1.Text = "No existen registros de planificación activos.";
            return;
        }

        var ok = MessageBox.Show(
            "Esta acción purgará la totalidad de la planificación generada.\n\n¿Desea proceder?",
            "Advertencia de purga de datos",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        _data.Plan.Clear();
        _blPlan.ResetBindings();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Registros de planificación purgados.";
        JsonStorage.Save(_jsonPath, _data);
    }

    private void btnPlanSessionSave_Click(object sender, EventArgs e)
    {
        var s = GetSelectedSession();
        if (s == null) return;

        s.Topic = txtPlanTopic.Text.Trim();
        s.Checkpoint = txtPlanCheckpoint.Text.Trim();
        s.Completed = chkPlanCompleted.Checked;

        _blPlan.ResetBindings();
        toolStripStatusLabel1.Text = "Estado de sesión actualizado exitosamente.";
    }

    private void CreateLocalBackup()
    {
        try
        {
            if (File.Exists(_jsonPath))
            {
                string backupPath = _jsonPath + ".bak";
                File.Copy(_jsonPath, backupPath, overwrite: true);
            }
        }
        catch
        {
            // Fallo silencioso para que un error en el backup no congele la aplicación
        }
    }

    private void chkPlanCompleted_CheckedChanged(object sender, EventArgs e)
    {
        // Manejador de estado reservado para implementaciones futuras de telemetría o actualización en caliente.
    }

    private void lbTask_Click(object sender, EventArgs e)
    {
    }
}