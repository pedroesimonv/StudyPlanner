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
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "StudyPlanner",
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
        _data = JsonStorage.Load(_jsonPath);

        BindSubjects();
        BindBlocks();
        BindPlan();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Datos cargados automáticamente.";
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
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
        _data = JsonStorage.Load(_jsonPath);

        BindSubjects();
        BindBlocks();
        BindPlan();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Datos cargados desde JSON.";
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
        // Verificación de integridad de los datos de entrada.
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

        Subject? existing = null;
        if (_editingSubjectId.HasValue)
            existing = _data.Subjects.FirstOrDefault(x => x.Id == _editingSubjectId.Value);

        if (existing == null)
        {
            // Instanciación de una nueva entidad Subject.
            var s = new Subject
            {
                Id = Guid.NewGuid(),
                Name = name,
                Course = cmbSubCourse.SelectedItem.ToString()!,
                Priority = (int)numSubPriority.Value,
                ExamDate = chkHasExam.Checked ? dtpSubExam.Value.Date : (DateTime?)null,
                TargetDeepMinutes = (int)numTargetDeep.Value,
                TargetLightMinutes = (int)numTargetLight.Value,
                TargetActivityMinutes = (int)numTargetAct.Value,
                Active = chkSubActive.Checked,
                CurrentTopic = txtSubTopic.Text.Trim(),
                CurrentCheckpoint = txtSubCheckpoint.Text.Trim(),
                Activities = ReadActivitiesFromEditor(),
            };

            _data.Subjects.Add(s);
            _blSubjects.ResetBindings();
            _editingSubjectId = s.Id;

            toolStripStatusLabel1.Text = "Asignatura creada exitosamente.";
        }
        else
        {
            // Modificación de la entidad Subject existente.
            existing.Name = name;
            existing.Course = cmbSubCourse.SelectedItem.ToString()!;
            existing.Priority = (int)numSubPriority.Value;
            existing.ExamDate = chkHasExam.Checked ? dtpSubExam.Value.Date : (DateTime?)null;
            existing.TargetDeepMinutes = (int)numTargetDeep.Value;
            existing.TargetLightMinutes = (int)numTargetLight.Value;
            existing.TargetActivityMinutes = (int)numTargetAct.Value;
            existing.Active = chkSubActive.Checked;
            existing.CurrentTopic = txtSubTopic.Text.Trim();
            existing.CurrentCheckpoint = txtSubCheckpoint.Text.Trim();
            existing.Activities = ReadActivitiesFromEditor();

            _blSubjects.ResetBindings();
            toolStripStatusLabel1.Text = "Asignatura actualizada exitosamente.";
        }
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

        _data.Subjects.Remove(s);
        _blSubjects.ResetBindings();
        ClearSubjectEditor();
        _editingSubjectId = null;

        toolStripStatusLabel1.Text = "Asignatura eliminada del sistema.";
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

    private bool IsBlockValid(TimeBlock b, TimeBlock? editing, out string message)
    {
        message = "";

        if (b.End <= b.Start)
        {
            message = "Inconsistencia temporal: La hora de finalización debe ser posterior a la de inicio.";
            return false;
        }
        if (b.DurationMinutes < 15)
        {
            message = "La duración mínima permitida para un bloque de estudio es de 15 minutos.";
            return false;
        }

        // Algoritmo de validación de solapamiento temporal.
        foreach (var other in _data.TimeBlocks)
        {
            if (editing != null && ReferenceEquals(other, editing)) continue;

            if (other.Date.Date != b.Date.Date) continue;

            bool overlap = b.Start < other.End && other.Start < b.End;
            if (overlap)
            {
                message = "Se ha detectado un conflicto: Este bloque se solapa con otro registro existente en la misma fecha.";
                return false;
            }
        }

        return true;
    }

    private void btnWeekAutoBlocks_Click(object sender, EventArgs e)
    {
        using var dlg = new WeekAutoBlocksDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return;

        var monday = dlg.GetWeekMonday();
        var shifts = dlg.GetShifts();

        GenerateWeekBlocks(monday, shifts, dlg.ReplaceWeekBlocks);

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

        if (!IsBlockValid(block, editing: null, out var msg))
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

        if (!IsBlockValid(edited, editing: selected, out var msg))
        {
            MessageBox.Show(msg, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        selected.Date = edited.Date;
        selected.Start = edited.Start;
        selected.End = edited.End;

        _blBlocks.ResetBindings();
        toolStripStatusLabel1.Text = "Bloque de tiempo modificado correctamente.";
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

    private static TimeSpan TS(int h, int m) => new TimeSpan(h, m, 0);

    private static List<(TimeSpan start, TimeSpan end)> TemplateForShift(WeekAutoBlocksDialog.ShiftType shift)
    {
        // Diccionario de reglas de negocio que define los periodos de estudio recomendados
        // según el patrón de turnos laborales del usuario.
        return shift switch
        {
            WeekAutoBlocksDialog.ShiftType.Manana => new List<(TimeSpan, TimeSpan)>
            {
                (TS(16,00), TS(18,00)),
                (TS(18,15), TS(20,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Tarde => new List<(TimeSpan, TimeSpan)>
            {
                (TS(09,30), TS(11,30)),
                (TS(11,35), TS(12,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Libre0 => new List<(TimeSpan, TimeSpan)>(),
            WeekAutoBlocksDialog.ShiftType.Libre1 => new List<(TimeSpan, TimeSpan)>
            {
                (TS(10,00), TS(12,00)),
            },
            WeekAutoBlocksDialog.ShiftType.Libre2 => new List<(TimeSpan, TimeSpan)>
            {
                (TS(10,00), TS(12,00)),
                (TS(16,00), TS(18,00)),
            },
            _ => new List<(TimeSpan, TimeSpan)>()
        };
    }

    private void GenerateWeekBlocks(DateTime monday, Dictionary<DayOfWeek, WeekAutoBlocksDialog.ShiftType> shifts, bool replaceWeek)
    {
        var weekStart = monday.Date;
        var weekEndExclusive = weekStart.AddDays(7);

        if (replaceWeek)
        {
            // Ejecución de borrado en cascada para la semana seleccionada.
            _data.TimeBlocks.RemoveAll(b => b.Date.Date >= weekStart && b.Date.Date < weekEndExclusive);
        }

        for (int i = 0; i < 7; i++)
        {
            var day = weekStart.AddDays(i);
            var shift = shifts[day.DayOfWeek];

            var slots = TemplateForShift(shift);

            foreach (var (start, end) in slots)
            {
                var block = new TimeBlock
                {
                    Date = day.Date,
                    Start = start,
                    End = end
                };

                // Omite inserciones que violen la restricción de solapamiento temporal.
                if (!IsBlockValid(block, editing: null, out _))
                    continue;

                _data.TimeBlocks.Add(block);
            }
        }

        // Ordenamiento cronológico de la colección.
        _data.TimeBlocks.Sort((a, b) =>
        {
            int c = a.Date.Date.CompareTo(b.Date.Date);
            if (c != 0) return c;
            return a.Start.CompareTo(b.Start);
        });
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

    private static string FormatDla(int deep, int light, int act)
    {
        int total = deep + light + act;
        return $"D:{deep} L:{light} A:{act} (T:{total})";
    }

    private static string FormatDue(DateTime due)
    {
        return due.ToString("dd/MM/yyyy");
    }

    private void RefreshPlanSummary()
    {
        lvSummary.Items.Clear();
        lblWarnings.Text = "";

        var activeSubjects = _data.Subjects.Where(s => s.Active).ToList();

        // Agrupación mediante LINQ y proyección de datos para calcular los totales de planificación.
        var minutesBySubject = _data.Plan
            .GroupBy(p => p.SubjectId)
            .ToDictionary(
                g => g.Key,
                g => new
                {
                    Deep = g.Where(x => x.Type == BlockType.Profundo).Sum(x => x.DurationMinutes),
                    Light = g.Where(x => x.Type == BlockType.Ligero).Sum(x => x.DurationMinutes),
                    Act = g.Where(x => x.Type == BlockType.Actividades).Sum(x => x.DurationMinutes),
                });

        var warnings = new List<string>();

        // Evaluación de discrepancias entre objetivos establecidos y minutos planificados.
        foreach (var s in activeSubjects)
        {
            minutesBySubject.TryGetValue(s.Id, out var planned);

            int pDeep = planned?.Deep ?? 0;
            int pLight = planned?.Light ?? 0;
            int pAct = planned?.Act ?? 0;

            int tDeep = s.TargetDeepMinutes;
            int tLight = s.TargetLightMinutes;
            int tAct = s.TargetActivityMinutes;

            var item = new ListViewItem(s.Name);
            item.SubItems.Add(FormatDla(tDeep, tLight, tAct));
            item.SubItems.Add(FormatDla(pDeep, pLight, pAct));
            lvSummary.Items.Add(item);

            if (tDeep > 0 && pDeep < tDeep)
                warnings.Add($"Faltan {tDeep - pDeep} min PROFUNDO en {s.Name}");

            if (tLight > 0 && pLight < tLight)
                warnings.Add($"Faltan {tLight - pLight} min LIGERO en {s.Name}");

            if (tAct > 0 && pAct < tAct)
                warnings.Add($"Faltan {tAct - pAct} min ACTIVIDADES en {s.Name}");
        }

        // Análisis predictivo de entregas inminentes (ventana de 7 días).
        var today = DateTime.Today;
        var limit = today.AddDays(7);

        var upcoming = _data.Subjects
            .Where(s => s.Active)
            .SelectMany(s => s.Activities.Select(a => new { Subject = s, Act = a }))
            .Where(x => !string.IsNullOrWhiteSpace(x.Act.Title))
            .Where(x => x.Act.DueDate.HasValue)
            .Select(x => new
            {
                x.Subject.Name,
                Title = x.Act.Title.Trim(),
                Due = x.Act.DueDate!.Value.Date
            })
            .Where(x => x.Due >= today && x.Due <= limit)
            .OrderBy(x => x.Due)
            .ThenBy(x => x.Name)
            .ToList();

        if (upcoming.Count > 0)
        {
            warnings.Add("");
            warnings.Add("📌 Entregas próximas (7 días):");

            foreach (var u in upcoming)
            {
                var daysLeft = (u.Due - today).Days;
                var dText = daysLeft == 0 ? "HOY" : $"en {daysLeft} día(s)";
                warnings.Add($"- {u.Name}: {u.Title} → {FormatDue(u.Due)} ({dText})");
            }
        }

        // Detección retrospectiva de entregas vencidas.
        var overdue = _data.Subjects
            .Where(s => s.Active)
            .SelectMany(s => s.Activities.Select(a => new { Subject = s, Act = a }))
            .Where(x => !string.IsNullOrWhiteSpace(x.Act.Title))
            .Where(x => x.Act.DueDate.HasValue)
            .Select(x => new
            {
                x.Subject.Name,
                Title = x.Act.Title.Trim(),
                Due = x.Act.DueDate!.Value.Date
            })
            .Where(x => x.Due < today)
            .OrderByDescending(x => x.Due)
            .ThenBy(x => x.Name)
            .ToList();

        if (overdue.Count > 0)
        {
            warnings.Add("");
            warnings.Add("⚠️ Entregas vencidas:");

            foreach (var o in overdue)
            {
                var daysLate = (today - o.Due).Days;
                warnings.Add($"- {o.Name}: {o.Title} → {FormatDue(o.Due)} (hace {daysLate} día(s))");
            }
        }

        if (_data.Plan.Count == 0)
            warnings.Insert(0, "El sistema no contiene registros de planificación generados.");

        lblWarnings.Text = warnings.Count == 0 ? "Estado óptimo: Sin avisos reportados." : string.Join(Environment.NewLine, warnings);
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

    private void chkPlanCompleted_CheckedChanged(object sender, EventArgs e)
    {
        // Manejador de estado reservado para implementaciones futuras de telemetría o actualización en caliente.
    }
}