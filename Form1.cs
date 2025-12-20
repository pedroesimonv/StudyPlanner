using StudyPlannerWinForms.Models;
using StudyPlannerWinForms.Services;
using System.ComponentModel;

//using static StudyPlannerWinForms.StudySession;

namespace StudyPlannerWinForms;

public partial class Form1 : Form

{
    public Form1()

    {
        InitializeComponent();
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath)!);

        SetupSummaryListView();
        // Luego: SetupGrids(); (cuando conectemos dgv)

        SetupSubjectsGrid();
        BindSubjects();
        SetupBlocksGrid();
        BindBlocks();
        SetupPlanGrid();
        BindPlan();
        AutoLoadOnStartup();
        this.FormClosing += Form1_FormClosing;
        chkHasExam.CheckedChanged += chkHasExam_CheckedChanged;

    }

    private readonly BindingSource _bsSubjects = new();
    private BindingList<Subject> _blSubjects = new();
    private Guid? _editingSubjectId = null;
    private readonly BindingSource _bsBlocks = new();
    private BindingList<TimeBlock> _blBlocks = new();
    private readonly BindingSource _bsPlan = new();
    private BindingList<StudySession> _blPlan = new();

    private void AutoLoadOnStartup()
    {
        _data = JsonStorage.Load(_jsonPath);

        BindSubjects();
        BindBlocks();
        BindPlan();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Datos cargados automáticamente.";
    }
    private void chkHasExam_CheckedChanged(object? sender, EventArgs e)
    {
        dtpSubExam.Enabled = chkHasExam.Checked;
    }


    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        JsonStorage.Save(_jsonPath, _data);
    }

    private void SetupSubjectsGrid()
    {
        dgvSubjects.AutoGenerateColumns = false;

        // IMPORTANTE: mapea tus columnas del diseñador con propiedades del modelo
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


        // ExamDate nullable -> checkbox + enabled
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
            dtpSubExam.Value = DateTime.Today; // solo visual
        }

        numTargetDeep.Value = s.TargetDeepMinutes;
        numTargetLight.Value = s.TargetLightMinutes;
        numTargetAct.Value = s.TargetActivityMinutes;
        chkSubActive.Checked = s.Active;
        LoadActivitiesToEditor(s);

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

        // Minutos planificados agrupados por asignatura y por tipo
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

            // Avisos por tipo (solo si hay objetivo > 0)
            if (tDeep > 0 && pDeep < tDeep)
                warnings.Add($"Faltan {tDeep - pDeep} min PROFUNDO en {s.Name}");

            if (tLight > 0 && pLight < tLight)
                warnings.Add($"Faltan {tLight - pLight} min LIGERO en {s.Name}");

            if (tAct > 0 && pAct < tAct)
                warnings.Add($"Faltan {tAct - pAct} min ACTIVIDADES en {s.Name}");
        }
        // ===============================
        // Avisos de ACTIVIDADES próximas
        // ===============================
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
            warnings.Add(""); // separador visual
            warnings.Add("📌 Entregas próximas (7 días):");

            foreach (var u in upcoming)
            {
                var daysLeft = (u.Due - today).Days;
                var dText = daysLeft == 0 ? "HOY" : $"en {daysLeft} día(s)";
                warnings.Add($"- {u.Name}: {u.Title} → {FormatDue(u.Due)} ({dText})");
            }
        }
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
            warnings.Insert(0, "No hay planning generado todavía.");

        lblWarnings.Text = warnings.Count == 0 ? "Sin avisos." : string.Join(Environment.NewLine, warnings);
    }

    private AppData _data = new();

    private string _jsonPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "StudyPlanner",
        "data.json");

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

        // Examen nullable controlado por checkbox
        chkHasExam.Checked = false;
        dtpSubExam.Enabled = false;
        dtpSubExam.Value = DateTime.Today; // valor visual, no se guardará si chkHasExam está false

        numTargetDeep.Value = 0;
        numTargetLight.Value = 0;
        numTargetAct.Value = 0;
        chkSubActive.Checked = true;
        txtSubTopic.Clear();
        txtSubCheckpoint.Clear();
        ClearActivitiesEditor();


    }
    private TextBox[] ActTitleBoxes() => new[] { txtAct1, txtAct2, txtAct3, txtAct4, txtAct5 };
    private DateTimePicker[] ActDatePickers() => new[] { dtpAct1, dtpAct2, dtpAct3, dtpAct4, dtpAct5 };

    private void ClearActivitiesEditor()
    {
        var titles = ActTitleBoxes();
        var dates = ActDatePickers();

        for (int i = 0; i < 5; i++)
        {
            titles[i].Clear();
            dates[i].Value = DateTime.Today;
            dates[i].Checked = false; // <- sin fecha
        }
    }

    private void LoadActivitiesToEditor(Subject s)
    {
        ClearActivitiesEditor();

        var titles = ActTitleBoxes();
        var dates = ActDatePickers();

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
        var titles = ActTitleBoxes();
        var dates = ActDatePickers();

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



    private void btnSubSave_Click(object sender, EventArgs e)
    {
        // Validación mínima
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
            // Crear
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
            _blSubjects.ResetBindings(); // refresca grid
            _editingSubjectId = s.Id;

            toolStripStatusLabel1.Text = "Asignatura creada.";
        }
        else
        {
            // Editar
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
            toolStripStatusLabel1.Text = "Asignatura actualizada.";
        }
    }

    private void btnSubDelete_Click(object sender, EventArgs e)
    {
        var s = GetSelectedSubject();
        if (s == null)
        {
            toolStripStatusLabel1.Text = "Selecciona una asignatura para eliminar.";
            return;
        }

        var ok = MessageBox.Show(
            $"¿Eliminar '{s.Name}'?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        _data.Subjects.Remove(s);
        _blSubjects.ResetBindings();
        ClearSubjectEditor();
        _editingSubjectId = null;

        toolStripStatusLabel1.Text = "Asignatura eliminada.";
    }

    private void SetupBlocksGrid()
    {
        dgvBlocks.AutoGenerateColumns = false;

        // Como editas con diálogos, desactivamos edición directa en el grid
        dgvBlocks.ReadOnly = true;
        dgvBlocks.AllowUserToAddRows = false;
        dgvBlocks.AllowUserToDeleteRows = false;
        dgvBlocks.EditMode = DataGridViewEditMode.EditProgrammatically;

        colBlockDate.DataPropertyName = nameof(TimeBlock.Date);
        colBlockStart.DataPropertyName = nameof(TimeBlock.Start);
        colBlockEnd.DataPropertyName = nameof(TimeBlock.End);

        dgvBlocks.CellFormatting += dgvBlocks_CellFormatting;

        // Opcional: evita el popup por cualquier conversión rara
        dgvBlocks.DataError += dgvBlocks_DataError;
    }

    private void dgvBlocks_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        // Evita el cuadro de diálogo por defecto
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
            message = "La hora de fin debe ser mayor que la hora de inicio.";
            return false;
        }
        if (b.DurationMinutes < 15)
        {
            message = "El hueco debe tener al menos 15 minutos.";
            return false;
        }

        // No solapes el mismo día
        foreach (var other in _data.TimeBlocks)
        {
            // Si estamos editando, ignoramos el hueco original seleccionado
            if (editing != null && ReferenceEquals(other, editing)) continue;

            if (other.Date.Date != b.Date.Date) continue;

            bool overlap = b.Start < other.End && other.Start < b.End;
            if (overlap)
            {
                message = "Este hueco se solapa con otro hueco del mismo día.";
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
        toolStripStatusLabel1.Text = "Huecos de la semana generados.";
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
            MessageBox.Show(msg, "Hueco inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _data.TimeBlocks.Add(block);
        _blBlocks.ResetBindings();

        toolStripStatusLabel1.Text = "Hueco añadido.";
    }

    private void btnBlockEdit_Click(object sender, EventArgs e)
    {
        var selected = GetSelectedBlock();
        if (selected == null)
        {
            toolStripStatusLabel1.Text = "Selecciona un hueco para editar.";
            return;
        }

        using var dlg = new TimeBlockDialog();
        dlg.StartPosition = FormStartPosition.CenterParent;
        dlg.SetBlock(selected);

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var edited = dlg.GetBlock();

        if (!IsBlockValid(edited, editing: selected, out var msg))
        {
            MessageBox.Show(msg, "Hueco inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        selected.Date = edited.Date;
        selected.Start = edited.Start;
        selected.End = edited.End;

        _blBlocks.ResetBindings();
        toolStripStatusLabel1.Text = "Hueco editado.";
    }

    private void btnBlockRemove_Click(object sender, EventArgs e)
    {
        var selected = GetSelectedBlock();
        if (selected == null)
        {
            toolStripStatusLabel1.Text = "Selecciona un hueco para eliminar.";
            return;
        }

        var ok = MessageBox.Show(
            "¿Eliminar el hueco seleccionado?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        _data.TimeBlocks.Remove(selected);
        _blBlocks.ResetBindings();

        toolStripStatusLabel1.Text = "Hueco eliminado.";
    }

    private void SetupPlanGrid()
    {
        dgvPlan.AutoGenerateColumns = false;

        // Como el planning se genera, no se edita directamente en el grid
        dgvPlan.ReadOnly = true;
        dgvPlan.AllowUserToAddRows = false;
        dgvPlan.AllowUserToDeleteRows = false;
        dgvPlan.EditMode = DataGridViewEditMode.EditProgrammatically;

        // Mapeo de columnas del diseñador a propiedades del modelo
        colPlanDate.DataPropertyName = nameof(StudySession.Date);
        colPlanStart.DataPropertyName = nameof(StudySession.Start);
        colPlanEnd.DataPropertyName = nameof(StudySession.End);
        colPlanSubject.DataPropertyName = nameof(StudySession.SubjectId); // se formatea a nombre en CellFormatting
        colPlanType.DataPropertyName = nameof(StudySession.Type);
        colPlanStrategy.DataPropertyName = nameof(StudySession.Strategy);
        colPlanNotes.DataPropertyName = nameof(StudySession.Notes);

        // =========================
        // MEJORAS DE AUTO-AJUSTE UI
        // =========================

        // Opción recomendada para que NO se disparen columnas por textos largos:
        // - Todo rellena el ancho disponible de forma proporcional.
        dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Proporciones (ajusta si quieres)
        colPlanDate.FillWeight = 12;
        colPlanStart.FillWeight = 8;
        colPlanEnd.FillWeight = 8;
        colPlanSubject.FillWeight = 20;
        colPlanType.FillWeight = 12;
        colPlanStrategy.FillWeight = 25;
        colPlanNotes.FillWeight = 15;

        // Filas: crecerán solo si hay texto envuelto (Strategy/Notes)
        dgvPlan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        // Por defecto NO envolvemos (para que no crezcan todas las filas)
        dgvPlan.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

        // Solo Strategy y Notes envuelven texto
        colPlanStrategy.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        colPlanNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        // Altura mínima razonable
        dgvPlan.RowTemplate.MinimumHeight = 22;

        // Opcional: evita el cuadro de diálogo de error por conversiones/formateos
        dgvPlan.DataError += dgvPlan_DataError;

        // Formateo visual (fecha/hora/subjectId->nombre)
        dgvPlan.CellFormatting += dgvPlan_CellFormatting;

        dgvPlan.SelectionChanged += dgvPlan_SelectionChanged;

    }
    private StudySession? GetSelectedSession()
    => dgvPlan.CurrentRow?.DataBoundItem as StudySession;

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
            e.Value = sub?.Name ?? "(Sin asignatura)";
            e.FormattingApplied = true;
        }
    }

    /*private void GeneratePlanV1()
    {
        // 1) Limpia plan anterior
        _data.Plan.Clear();

        // 2) Asignaturas activas
        var subjects = _data.Subjects.Where(x => x.Active).ToList();
        if (subjects.Count == 0)
        {
            MessageBox.Show("No hay asignaturas activas.", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // 3) Huecos disponibles ordenados por fecha/hora
        var blocks = _data.TimeBlocks
            .OrderBy(b => b.Date.Date)
            .ThenBy(b => b.Start)
            .ToList();

        if (blocks.Count == 0)
        {
            MessageBox.Show("No hay huecos de estudio. Añade huecos en 'Semana y huecos'.", "Planning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // 4) Calcula "minutos pendientes" por asignatura
        //    (total objetivo semanal = profundo + ligero + actividades)
        var remaining = subjects.ToDictionary(
            s => s.Id,
            s => s.TargetDeepMinutes + s.TargetLightMinutes + s.TargetActivityMinutes
        );

        // Si una asignatura tiene 0 objetivo total, le damos un mínimo para que pueda recibir huecos
        foreach (var id in remaining.Keys.ToList())
            if (remaining[id] <= 0) remaining[id] = 30;

        // 5) Asigna cada hueco a la asignatura con más minutos pendientes.
        foreach (var b in blocks)
        {
            var chosen = remaining
                .OrderByDescending(kv => kv.Value) // más pendiente primero
                .Select(kv => kv.Key)
                .First();

            var duration = b.DurationMinutes;

            // Tipo según duración
            var type = duration >= 50 ? BlockType.Profundo : BlockType.Ligero;

            var strategy = type == BlockType.Profundo
                ? "Ejercicios + corrección"
                : "Flashcards + repaso";

            var session = new StudySession
            {
                Date = b.Date.Date,
                Start = b.Start,
                End = b.End,
                SubjectId = chosen,
                Type = type,
                Strategy = strategy,
                Notes = ""
            };

            _data.Plan.Add(session);

            // Resta minutos pendientes (nunca baja de 0)
            remaining[chosen] = Math.Max(0, remaining[chosen] - duration);
        }

        // 6) Refrescar binding + resumen
        _blPlan.ResetBindings();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Planning generado.";
    }*/

    /* private void GeneratePlanV21()
     {
         _data.Plan.Clear();

         var subjects = _data.Subjects.Where(x => x.Active).ToList();
         if (subjects.Count == 0)
         {
             MessageBox.Show("No hay asignaturas activas.", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
             return;
         }

         var blocks = _data.TimeBlocks
             .OrderBy(b => b.Date.Date)
             .ThenBy(b => b.Start)
             .ToList();

         if (blocks.Count == 0)
         {
             MessageBox.Show("No hay huecos de estudio. Añade huecos en 'Semana y huecos'.", "Planning",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
             return;
         }

         // Minutos restantes por tipo (lo importante del V2.1)
         var deepRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetDeepMinutes));
         var lightRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetLightMinutes));
         var actRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetActivityMinutes));

         // Si todo está a 0, metemos mínimos para que el algoritmo no se quede “sin objetivo”
         if (deepRemaining.Values.Sum() == 0) foreach (var id in deepRemaining.Keys.ToList()) deepRemaining[id] = 30;
         if (lightRemaining.Values.Sum() == 0) foreach (var id in lightRemaining.Keys.ToList()) lightRemaining[id] = 30;

         int plannedActBlocks = 0;
         int maxActBlocks = 2; // regla simple: como mucho 2 huecos de “actividades” por semana/plan

         foreach (var b in blocks)
         {
             int duration = b.DurationMinutes;

             // Regla base: hueco largo -> Profundo, corto -> Ligero
             var preferredType = duration >= 50 ? BlockType.Profundo : BlockType.Ligero;

             // Regla Actividades (simple y controlada):
             // - Si quedan actividades pendientes
             // - y el hueco es razonable (>= 40 min)
             // - y aún no hemos asignado demasiados bloques de actividades
             bool shouldUseActivities =
                 duration >= 40 &&
                 plannedActBlocks < maxActBlocks &&
                 actRemaining.Values.Sum() > 0;

             Guid chosenSubjectId;
             BlockType finalType;

             if (shouldUseActivities)
             {
                 finalType = BlockType.Actividades;
                 chosenSubjectId = PickSubjectByRemaining(actRemaining, subjects);
                 plannedActBlocks++;
                 actRemaining[chosenSubjectId] = Math.Max(0, actRemaining[chosenSubjectId] - duration);
             }
             else if (preferredType == BlockType.Profundo)
             {
                 finalType = BlockType.Profundo;
                 chosenSubjectId = PickSubjectByRemaining(deepRemaining, subjects);
                 deepRemaining[chosenSubjectId] = Math.Max(0, deepRemaining[chosenSubjectId] - duration);
             }
             else
             {
                 finalType = BlockType.Ligero;
                 chosenSubjectId = PickSubjectByRemaining(lightRemaining, subjects);
                 lightRemaining[chosenSubjectId] = Math.Max(0, lightRemaining[chosenSubjectId] - duration);
             }

             var strategy = finalType switch
             {
                 BlockType.Profundo => "Ejercicios + corrección (sin distracciones)",
                 BlockType.Ligero => "Flashcards + repaso activo",
                 BlockType.Actividades => "Actividad evaluable / entrega",
                 _ => ""
             };

             _data.Plan.Add(new StudySession
             {
                 Date = b.Date.Date,
                 Start = b.Start,
                 End = b.End,
                 SubjectId = chosenSubjectId,
                 Type = finalType,
                 Strategy = strategy,
                 Notes = ""
             });
         }

         _blPlan.ResetBindings();
         RefreshPlanSummary();
         toolStripStatusLabel1.Text = "Planning generado (V2.1).";
     }/*

     /* private Guid PickSubjectByRemaining(Dictionary<Guid, int> remainingBySubject, List<Subject> activeSubjects)
      {
          // Si por alguna razón todos están a 0, elige la primera activa
          if (remainingBySubject.Values.All(v => v <= 0))
              return activeSubjects[0].Id;

          return remainingBySubject
              .OrderByDescending(kv => kv.Value)
              .Select(kv => kv.Key)
              .First();
      }*/

    private void GeneratePlanV22()
    {
        _data.Plan.Clear();

        var subjects = _data.Subjects.Where(x => x.Active).ToList();
        if (subjects.Count == 0)
        {
            MessageBox.Show("No hay asignaturas activas.", "Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var blocks = _data.TimeBlocks
            .OrderBy(b => b.Date.Date)
            .ThenBy(b => b.Start)
            .ToList();

        if (blocks.Count == 0)
        {
            MessageBox.Show("No hay huecos de estudio. Añade huecos en 'Semana y huecos'.", "Planning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Minutos restantes por tipo (igual que V2.1)
        var deepRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetDeepMinutes));
        var lightRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetLightMinutes));
        var actRemaining = subjects.ToDictionary(s => s.Id, s => Math.Max(0, s.TargetActivityMinutes));

        // Si están todos a 0, ponemos mínimos para no quedarnos sin reparto
        if (deepRemaining.Values.Sum() == 0) foreach (var id in deepRemaining.Keys.ToList()) deepRemaining[id] = 30;
        if (lightRemaining.Values.Sum() == 0) foreach (var id in lightRemaining.Keys.ToList()) lightRemaining[id] = 30;

        int plannedActBlocks = 0;
        int maxActBlocks = 2; // regla simple (ajustable)

        foreach (var b in blocks)
        {
            int duration = b.DurationMinutes;

            var preferredType = duration >= 50 ? BlockType.Profundo : BlockType.Ligero;

            bool shouldUseActivities =
                duration >= 40 &&
                plannedActBlocks < maxActBlocks &&
                actRemaining.Values.Sum() > 0;

            Guid chosenSubjectId;
            BlockType finalType;

            if (shouldUseActivities)
            {
                finalType = BlockType.Actividades;
                chosenSubjectId = PickSubjectByRemainingWeighted(actRemaining, subjects);
                plannedActBlocks++;
                actRemaining[chosenSubjectId] = Math.Max(0, actRemaining[chosenSubjectId] - duration);
            }
            else if (preferredType == BlockType.Profundo)
            {
                finalType = BlockType.Profundo;
                chosenSubjectId = PickSubjectByRemainingWeighted(deepRemaining, subjects);
                deepRemaining[chosenSubjectId] = Math.Max(0, deepRemaining[chosenSubjectId] - duration);
            }
            else
            {
                finalType = BlockType.Ligero;
                chosenSubjectId = PickSubjectByRemainingWeighted(lightRemaining, subjects);
                lightRemaining[chosenSubjectId] = Math.Max(0, lightRemaining[chosenSubjectId] - duration);
            }

            var strategy = finalType switch
            {
                BlockType.Profundo => "Ejercicios + corrección (sin distracciones)",
                BlockType.Ligero => "Flashcards + repaso activo",
                BlockType.Actividades => "Actividad evaluable / entrega",
                _ => ""
            };

            var chosenSub = subjects.First(x => x.Id == chosenSubjectId);
            _data.Plan.Add(new StudySession
            {
                Date = b.Date.Date,
                Start = b.Start,
                End = b.End,
                SubjectId = chosenSubjectId,
                Type = finalType,
                Strategy = strategy,
                Notes = "",

                Topic = chosenSub.CurrentTopic,
                Checkpoint = chosenSub.CurrentCheckpoint,
                Completed = false
            });
        }

        _blPlan.ResetBindings();
        RefreshPlanSummary();
        toolStripStatusLabel1.Text = "Planning generado (V2.2).";
    }

    private Guid PickSubjectByRemainingWeighted(
     Dictionary<Guid, int> remainingBySubject,
     List<Subject> activeSubjects)
    {
        // Si por alguna razón todos están a 0, elige la primera activa
        if (remainingBySubject.Values.All(v => v <= 0))
            return activeSubjects[0].Id;

        // Elegimos por: remaining * (peso prioridad+examen)
        // Esto mantiene el sentido de "minutos pendientes", pero empuja hacia lo urgente.
        Guid bestId = activeSubjects[0].Id;
        double bestScore = double.MinValue;

        foreach (var sub in activeSubjects)
        {
            remainingBySubject.TryGetValue(sub.Id, out int rem);
            if (rem <= 0) continue;

            double score = rem * SubjectWeight(sub);

            if (score > bestScore)
            {
                bestScore = score;
                bestId = sub.Id;
            }
        }

        // Si todos rem <= 0 (caso raro), fallback:
        if (bestScore == double.MinValue)
            return activeSubjects[0].Id;

        return bestId;
    }

    private static double PriorityWeight(int priority)
    {
        // priority 1..5 -> peso 2.0..1.0 (aprox)
        // 1 -> 2.0, 2 -> 1.75, 3 -> 1.5, 4 -> 1.25, 5 -> 1.0
        priority = Math.Clamp(priority, 1, 5);
        return 2.25 - (priority * 0.25);
    }

    private static double ExamWeight(DateTime? examDate)
    {
        if (examDate == null) return 1.0;

        // Días hasta examen (si está en pasado, lo tratamos como 0 para “máxima urgencia”)
        var days = (examDate.Value.Date - DateTime.Today).TotalDays;
        if (days < 0) days = 0;

        // Ventana de urgencia (supongamos 28 días): cuanto más cerca, más peso
        const double window = 28.0;
        var urgency = Math.Clamp((window - days) / window, 0.0, 1.0); // 0..1

        // Peso final: 1.0 a 2.0
        return 1.0 + urgency;
    }

    private static double SubjectWeight(Subject s)
    {
        return PriorityWeight(s.Priority) * ExamWeight(s.ExamDate);
    }

    private void btnPlanGenerate_Click(object sender, EventArgs e)
    {
        GeneratePlanV22();
    }

    private static TimeSpan TS(int h, int m) => new TimeSpan(h, m, 0);

    private static List<(TimeSpan start, TimeSpan end)> TemplateForShift(WeekAutoBlocksDialog.ShiftType shift)
    {
        // Tus reglas:
        // - Trabajas TARDE -> estudias 09:30-12:00 (porque a las 12:00 paseas al perrete)
        // - Trabajas MAÑANA -> estudias 16:00-20:00
        // - DÍA LIBRE -> eliges 0/1/2 profundos

        return shift switch
        {
            // Trabajas 06-14 -> estudio 16-20 (2 profundos)
            WeekAutoBlocksDialog.ShiftType.Manana => new List<(TimeSpan, TimeSpan)>
        {
            (TS(16,00), TS(18,00)), // Profundo
            (TS(18,15), TS(20,00)), // Profundo
        },

            // Trabajas 14-22 -> estudio 09:30-12:00 (profundo + ligero corto)
            WeekAutoBlocksDialog.ShiftType.Tarde => new List<(TimeSpan, TimeSpan)>
        {
            (TS(09,30), TS(11,30)), // Profundo
            (TS(11,35), TS(12,00)), // Ligero (repaso rápido / flashcards)
        },

            // Libre: 0 huecos
            WeekAutoBlocksDialog.ShiftType.Libre0 => new List<(TimeSpan, TimeSpan)>(),

            // Libre: 1 profundo
            WeekAutoBlocksDialog.ShiftType.Libre1 => new List<(TimeSpan, TimeSpan)>
        {
            (TS(10,00), TS(12,00)), // Profundo
        },

            // Libre: 2 profundos
            WeekAutoBlocksDialog.ShiftType.Libre2 => new List<(TimeSpan, TimeSpan)>
        {
            (TS(10,00), TS(12,00)), // Profundo
            (TS(16,00), TS(18,00)), // Profundo
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

                // Validación (evita solapes con lo que ya exista)
                if (!IsBlockValid(block, editing: null, out _))
                    continue;

                _data.TimeBlocks.Add(block);
            }
        }

        // Ordena por fecha/hora
        _data.TimeBlocks.Sort((a, b) =>
        {
            int c = a.Date.Date.CompareTo(b.Date.Date);
            if (c != 0) return c;
            return a.Start.CompareTo(b.Start);
        });
    }

    private void btnPlanClear_Click(object sender, EventArgs e)
    {
        if (_data.Plan.Count == 0)
        {
            toolStripStatusLabel1.Text = "No hay planning que eliminar.";
            return;
        }

        var ok = MessageBox.Show(
            "Esto eliminará TODO el planning generado.\n\n¿Quieres continuar?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (ok != DialogResult.Yes) return;

        _data.Plan.Clear();
        _blPlan.ResetBindings();
        RefreshPlanSummary();

        toolStripStatusLabel1.Text = "Planning eliminado.";
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
        toolStripStatusLabel1.Text = "Sesión actualizada.";
    }

    private void chkPlanCompleted_CheckedChanged(object sender, EventArgs e)
    {

    }
}