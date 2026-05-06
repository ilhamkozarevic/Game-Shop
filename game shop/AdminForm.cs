using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace game_shop
{
    public partial class AdminForm : Form
    {
        private string connString;
        private OleDbConnection connection;

        // TAB 1
        private ComboBox cmbTables;
        private DataGridView dgvViewData;

        // TAB 2
        private ComboBox cmbEditTable;
        private DataGridView dgvEditData;
        private DataTable editDataTable;
        private OleDbDataAdapter editAdapter;
        private DataSet editDataSet;
        private Button btnAdd, btnSave, btnDelete;
        private Label lblEditStatus;

        // TAB 3
        private ComboBox cmbQueries;
        private TextBox txtParam;
        private Label lblParam;
        private Button btnRunQuery;
        private DataGridView dgvQueryResult;
        private Label lblQueryDesc;

        private readonly Dictionary<string, string> queryDescriptions = new Dictionary<string, string>
        {
            { "Sve igre odredjenog korisnika",        "Unesite username:" },
            { "Svi administratori",                  "" },
            { "Top 5 igara po ocjeni",               "" },
            { "Korisnici bez ijedne igre",           "" },
            { "Igre s prosjecnom ocjenom",           "" },
            { "Recenzije odredjene igre",             "Unesite naziv igre:" },
            { "Korisnici koji su kupili igru",       "Unesite naziv igre:" },
            { "Igre po zanru",                       "Unesite zanr:" },
            { "Broj igara po korisniku",             "" },
            { "Najaktivniji korisnici (br. recenzija)", "" },
        };

        public AdminForm()
        {
            InitializeComponent();

            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;";
            connection = new OleDbConnection(connString);

            InitializeViewTab();
            InitializeEditTab();
            InitializeQueryTab();

            LoadTableNames();
            LoadEditTableNames();
            LoadQueryNames();

            this.FormClosed += new FormClosedEventHandler(AdminFormFormClosed);
        }

        // TAB 1 – VIEW

        private void InitializeViewTab()
        {
            if (tabControl1 == null || tabControl1.TabPages.Count == 0) return;
            TabPage viewTab = tabControl1.TabPages[0];

            Label lbl = new Label();
            lbl.Text = "Odaberi tabelu:";
            lbl.Location = new Point(20, 15);
            lbl.Size = new Size(100, 20);

            cmbTables = new ComboBox();
            cmbTables.Location = new Point(130, 12);
            cmbTables.Size = new Size(200, 25);
            cmbTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTables.SelectedIndexChanged += (s, e) =>
            {
                if (cmbTables.SelectedItem != null)
                    LoadDataForTable(cmbTables.SelectedItem.ToString());
            };

            dgvViewData = new DataGridView();
            dgvViewData.Location = new Point(20, 50);
            dgvViewData.Size = new Size(viewTab.Width - 40, viewTab.Height - 75);
            dgvViewData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvViewData.AllowUserToAddRows = false;
            dgvViewData.ReadOnly = true;

            viewTab.Controls.AddRange(new Control[] { lbl, cmbTables, dgvViewData });
        }

        private void LoadTableNames()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                cmbTables.Items.Clear();
                foreach (DataRow row in schema.Rows)
                {
                    string name = row["TABLE_NAME"].ToString();
                    if (!name.StartsWith("MSys")) cmbTables.Items.Add(name);
                }
                if (cmbTables.Items.Count > 0)
                {
                    cmbTables.SelectedIndex = 0;
                    LoadDataForTable(cmbTables.SelectedItem.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Greska pri ucitavanju tabela: " + ex.Message); }
            finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        }

        private void LoadDataForTable(string tableName)
        {
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(
                    "SELECT * FROM [" + tableName + "]", connString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvViewData.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Greska: " + ex.Message); }
            finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        }

        // TAB 2 – EDIT

        private void InitializeEditTab()
        {
            if (tabControl1.TabPages.Count < 2) return;
            TabPage editTab = tabControl1.TabPages[1];

            Label lblTable = new Label();
            lblTable.Text = "Tabela:";
            lblTable.Location = new Point(20, 15);
            lblTable.Size = new Size(60, 20);

            cmbEditTable = new ComboBox();
            cmbEditTable.Location = new Point(85, 12);
            cmbEditTable.Size = new Size(180, 25);
            cmbEditTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditTable.SelectedIndexChanged += (s, e) =>
            {
                if (cmbEditTable.SelectedItem != null)
                    LoadEditData(cmbEditTable.SelectedItem.ToString());
            };

            btnAdd = new Button();
            btnAdd.Text = "➕ Dodaj red";
            btnAdd.Location = new Point(290, 10);
            btnAdd.Size = new Size(110, 28);
            btnAdd.Click += BtnAddClick;

            btnSave = new Button();
            btnSave.Text = "💾 Sacuvaj";
            btnSave.Location = new Point(410, 10);
            btnSave.Size = new Size(100, 28);
            btnSave.Click += BtnSaveClick;

            btnDelete = new Button();
            btnDelete.Text = "🗑 Obrisi";
            btnDelete.Location = new Point(520, 10);
            btnDelete.Size = new Size(90, 28);
            btnDelete.Click += BtnDeleteClick;

            lblEditStatus = new Label();
            lblEditStatus.Location = new Point(20, 45);
            lblEditStatus.Size = new Size(600, 20);
            lblEditStatus.ForeColor = Color.Green;

            dgvEditData = new DataGridView();
            dgvEditData.Location = new Point(20, 75);
            dgvEditData.Size = new Size(editTab.Width - 40, editTab.Height - 100);
            dgvEditData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEditData.AllowUserToAddRows = false;
            dgvEditData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            editTab.Controls.AddRange(new Control[] {
                lblTable, cmbEditTable, btnAdd, btnSave, btnDelete, lblEditStatus, dgvEditData
            });
        }

        private void LoadEditTableNames()
        {
            string[] editableTables = { "Igre", "Korisnici" };
            foreach (string t in editableTables)
                cmbEditTable.Items.Add(t);

            if (cmbEditTable.Items.Count > 0)
            {
                cmbEditTable.SelectedIndex = 0;
                LoadEditData(cmbEditTable.SelectedItem.ToString());
            }
        }

        private void LoadEditData(string tableName)
        {
            try
            {
                editDataSet = new DataSet();

                editAdapter = new OleDbDataAdapter("SELECT * FROM [" + tableName + "]", connString);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(editAdapter);

                editAdapter.Fill(editDataSet, tableName);

                editDataTable = editDataSet.Tables[tableName];
                dgvEditData.DataSource = editDataTable;
                SetStatus("Tabela '" + tableName + "' ucitana. Ukupno redova: " + editDataTable.Rows.Count, Color.Gray);
            }
            catch (Exception ex) { MessageBox.Show("Greska pri ucitavanju editovanja: " + ex.Message); }
            finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            if (editDataTable == null) return;
            DataRow newRow = editDataTable.NewRow();
            editDataTable.Rows.Add(newRow);
            dgvEditData.FirstDisplayedScrollingRowIndex = dgvEditData.RowCount - 1;
            SetStatus("Novi red dodan. Popunite polja i kliknite Sacuvaj.", Color.Blue);
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (editAdapter == null || editDataSet == null) return;
            try
            {
                dgvEditData.EndEdit();
                string tableName = cmbEditTable.SelectedItem.ToString();

                if (connection.State == ConnectionState.Closed) connection.Open();
                OleDbCommandBuilder builder = new OleDbCommandBuilder(editAdapter);

                int rows = editAdapter.Update(editDataSet, tableName);
                editDataSet.AcceptChanges();
                SetStatus("Sacuvano! Izmijenjeno redova: " + rows, Color.Green);
            }
            catch (Exception ex)
            {
                SetStatus("Greska pri cuvanju: " + ex.Message, Color.Red);
            }
            finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            if (dgvEditData.CurrentRow == null || editDataTable == null) return;
            int idx = dgvEditData.CurrentRow.Index;
            if (idx < 0 || idx >= editDataTable.Rows.Count) return;

            var confirm = MessageBox.Show(
                "Da li ste sigurni da zelite obrisati odabrani red?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                editDataTable.Rows[idx].Delete();
                BtnSaveClick(sender, e);
            }
        }

        private void SetStatus(string msg, Color color)
        {
            lblEditStatus.Text = msg;
            lblEditStatus.ForeColor = color;
        }

        // TAB 3 – QUERY

        private void InitializeQueryTab()
        {
            if (tabControl1.TabPages.Count < 3) return;
            TabPage queryTab = tabControl1.TabPages[2];

            Label lblQ = new Label();
            lblQ.Text = "Odaberi upit:";
            lblQ.Location = new Point(20, 15);
            lblQ.Size = new Size(100, 20);

            cmbQueries = new ComboBox();
            cmbQueries.Location = new Point(130, 12);
            cmbQueries.Size = new Size(280, 25);
            cmbQueries.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQueries.SelectedIndexChanged += CmbQueriesSelectedIndexChanged;

            lblQueryDesc = new Label();
            lblQueryDesc.Location = new Point(20, 50);
            lblQueryDesc.Size = new Size(200, 20);
            lblQueryDesc.ForeColor = Color.DimGray;

            lblParam = new Label();
            lblParam.Text = "Parametar:";
            lblParam.Location = new Point(20, 75);
            lblParam.Size = new Size(100, 20);
            lblParam.Visible = false;

            txtParam = new TextBox();
            txtParam.Location = new Point(130, 72);
            txtParam.Size = new Size(200, 25);
            txtParam.Visible = false;

            btnRunQuery = new Button();
            btnRunQuery.Text = "▶ Pokreni upit";
            btnRunQuery.Location = new Point(345, 70);
            btnRunQuery.Size = new Size(130, 28);
            btnRunQuery.Click += BtnRunQueryClick;

            dgvQueryResult = new DataGridView();
            dgvQueryResult.Location = new Point(20, 110);
            dgvQueryResult.Size = new Size(queryTab.Width - 40, queryTab.Height - 135);
            dgvQueryResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvQueryResult.AllowUserToAddRows = false;
            dgvQueryResult.ReadOnly = true;

            queryTab.Controls.AddRange(new Control[] {
                lblQ, cmbQueries, lblQueryDesc, lblParam, txtParam, btnRunQuery, dgvQueryResult
            });
        }

        private void LoadQueryNames()
        {
            foreach (string key in queryDescriptions.Keys)
                cmbQueries.Items.Add(key);
            if (cmbQueries.Items.Count > 0)
                cmbQueries.SelectedIndex = 0;
        }

        private void CmbQueriesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQueries.SelectedItem == null) return;
            string selected = cmbQueries.SelectedItem.ToString();
            string paramHint = queryDescriptions[selected];
            bool needsParam = !string.IsNullOrEmpty(paramHint);

            lblParam.Visible = needsParam;
            txtParam.Visible = needsParam;
            txtParam.Text = "";

            if (needsParam)
            {
                lblParam.Text = paramHint;
                lblQueryDesc.Text = "Unesite parametar pa kliknite Pokreni.";
            }
            else
            {
                lblQueryDesc.Text = "Kliknite Pokreni za izvrsavanje upita.";
            }
        }

        private void BtnRunQueryClick(object sender, EventArgs e)
        {
            if (cmbQueries.SelectedItem == null) return;
            string selected = cmbQueries.SelectedItem.ToString();
            string param = txtParam.Text.Trim();

            bool needsParam = !string.IsNullOrEmpty(queryDescriptions[selected]);
            if (needsParam && string.IsNullOrEmpty(param))
            {
                MessageBox.Show("Molimo unesite parametar.", "Nedostaje parametar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = BuildQuerySQL(selected, param);
            if (string.IsNullOrEmpty(sql)) return;

            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connString);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQueryResult.DataSource = dt;
                lblQueryDesc.Text = "Rezultat: " + dt.Rows.Count + " redova.";
            }
            catch (Exception ex) { MessageBox.Show("Greska pri izvrsavanju upita: " + ex.Message); }
            finally { if (connection.State == ConnectionState.Open) connection.Close(); }
        }

        private string BuildQuerySQL(string queryName, string param)
        {
            string safeParam = param.Replace("'", "''");

            switch (queryName)
            {
                case "Sve igre odredjenog korisnika":
                    return "SELECT I.Naziv, I.Zanr, I.Cijena " +
                           "FROM (Korisnici K INNER JOIN Biblioteka B ON K.KorisnikID = B.KorisnikID) " +
                           "INNER JOIN Igre I ON B.IgraID = I.IgraID " +
                           "WHERE K.KorisnickoIme = '" + safeParam + "'";

                case "Svi administratori":
                    return "SELECT KorisnikID, KorisnickoIme, Uloga " +
                           "FROM Korisnici WHERE Uloga = 'Admin'";

                case "Top 5 igara po ocjeni":
                    return "SELECT TOP 5 I.Naziv, I.Zanr, I.Cijena, AVG(R.Ocjena) AS ProsjecnaOcjena " +
                           "FROM Igre I INNER JOIN Recenzije R ON I.IgraID = R.IgraID " +
                           "GROUP BY I.Naziv, I.Zanr, I.Cijena " +
                           "ORDER BY AVG(R.Ocjena) DESC";

                case "Korisnici bez ijedne igre":
                    return "SELECT K.KorisnikID, K.KorisnickoIme, K.Uloga " +
                           "FROM Korisnici K " +
                           "WHERE K.KorisnikID NOT IN (SELECT KorisnikID FROM Biblioteka)";

                case "Igre s prosjecnom ocjenom":
                    return "SELECT I.Naziv, I.Zanr, " +
                           "AVG(R.Ocjena) AS ProsjecnaOcjena, COUNT(R.RecenzijaID) AS BrojRecenzija " +
                           "FROM Igre I LEFT JOIN Recenzije R ON I.IgraID = R.IgraID " +
                           "GROUP BY I.Naziv, I.Zanr " +
                           "ORDER BY AVG(R.Ocjena) DESC";

                case "Recenzije odredjene igre":
                    return "SELECT K.KorisnickoIme, R.Ocjena, R.Komentar " +
                           "FROM (Recenzije R INNER JOIN Igre I ON R.IgraID = I.IgraID) " +
                           "INNER JOIN Korisnici K ON R.KorisnikID = K.KorisnikID " +
                           "WHERE I.Naziv = '" + safeParam + "'";

                case "Korisnici koji su kupili igru":
                    return "SELECT K.KorisnickoIme, K.Uloga " +
                           "FROM (Biblioteka B INNER JOIN Korisnici K ON B.KorisnikID = K.KorisnikID) " +
                           "INNER JOIN Igre I ON B.IgraID = I.IgraID " +
                           "WHERE I.Naziv = '" + safeParam + "'";

                case "Igre po zanru":
                    return "SELECT Naziv, Cijena " +
                           "FROM Igre WHERE Zanr = '" + safeParam + "'";

                case "Broj igara po korisniku":
                    return "SELECT K.KorisnickoIme, COUNT(B.IgraID) AS BrojIgara " +
                           "FROM Korisnici K LEFT JOIN Biblioteka B ON K.KorisnikID = B.KorisnikID " +
                           "GROUP BY K.KorisnickoIme " +
                           "ORDER BY COUNT(B.IgraID) DESC";

                case "Najaktivniji korisnici (br. recenzija)":
                    return "SELECT K.KorisnickoIme, COUNT(R.RecenzijaID) AS BrojRecenzija " +
                           "FROM Korisnici K LEFT JOIN Recenzije R ON K.KorisnikID = R.KorisnikID " +
                           "GROUP BY K.KorisnickoIme " +
                           "ORDER BY COUNT(R.RecenzijaID) DESC";

                default:
                    return "";
            }
        }

        private void AdminFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}