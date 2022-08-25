using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;



namespace AdventureWorksForm1
{
    public partial class Form1 : Form
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdventureWorks2016; MultipleActiveResultSets=True;Integrated Security=SSPI;";
        const string dbName = "AdventureWorks2016";
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += MyValueChanged;
            dateTimePicker1.KeyDown += KeyDownEvent;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.Value = default(DateTime);
            dateTimePicker1.Checked = false;
            dateTimePicker1.ShowCheckBox = false;

            dateTimePicker1.CustomFormat = " ";
            this.dataGridView1.AllowUserToAddRows = true;
            dataGridView1.UserAddedRow += AddRowEvent;
            dataGridView1.AllowUserToAddRowsChanged += UpdateRowEvent;
            dataGridView1.RowsAdded += RowAddedEvent;
            dataGridView1.CellClick += ClickCell;
            dataGridView1.Click += ClickEvent;
            //var result= AddLocationIntoLocationSqlTable("bar", 12, 12.20M, DateTime.Now);
            nameTxt.Clear();
            DisplayLocationTable();
            // DeleteLocation(2);

        }

        private void ClickEvent(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 5)
            {
               

                this.idTxt.Text = Convert.ToString(dataGridView1.SelectedCells[0].Value);
                nameTxt.Text = dataGridView1.SelectedCells[1].Value.ToString();
                

                costRateTxt.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value).Replace(",","");
                availabilyTxt.Text = Convert.ToString(dataGridView1.SelectedCells[3].Value);
                this.dateTimePicker1.Text = Convert.ToString(dateTimePicker1.Value);
               
            }
            else
            {
                this.idTxt.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value).Replace(",","");
                nameTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                costRateTxt.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value).Replace(",","");
                availabilyTxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

        }



        private void ClickCell(object sender, DataGridViewCellEventArgs e)
        {
            //.Show("QUI");
            idTxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nameTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            costRateTxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           availabilyTxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void DeleteLocation(Int16 id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("USE " + dbName, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Production.Location WHERE LocationId=@id" +
                    " AND LocationId  NOT IN (SELECT LocationId FROM Production.ProductInventory)";
                command.Parameters.Add("@id", SqlDbType.SmallInt).Value = id;
                try
                {
                    var numRows = command.ExecuteNonQuery();
                    MessageBox.Show("Eliminazione Location OK " + "numero righe " + numRows);
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Errore eliminazione " + e.Message);
                }
            }
        }


        private void RowAddedEvent(object sender, DataGridViewRowsAddedEventArgs e)
        {


        }

        private void UpdateRowEvent(object sender, EventArgs e)
        {


            //  int currColumn = dataGridView1.CurrentCell.ColumnIndex;
            //int currRow = dataGridView1.CurrentCell.RowIndex;
            // string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void AddRowEvent(object sender, DataGridViewRowEventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                nameTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //Console.WriteLine(dataGridView1.CurrentRow.ToString());
            }
        }

        private void Print()
        {
            var builder = new StringBuilder();

            MessageBox.Show(dataGridView1.Columns.Count.ToString());



            builder.AppendLine();
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                builder.Append(column.Name + " ");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    builder.Append(row.Cells[column.Index].Value + " ");
                }
                builder.AppendLine();
            }
            MessageBox.Show(builder.ToString());
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.ShowCheckBox = false;


            }
        }

        private static Int16 AddLocationIntoLocationSqlTable(string nameLocation, short cost, decimal availbailty, DateTime dateTime)
        {
            Int16 result = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlNonQuery = "USE " + dbName;
                SqlCommand command = new SqlCommand(sqlNonQuery, connection);
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Production.Location(Name,CostRate, Availability,ModifiedDate)" +

                    " VALUES(@name, @cost, @av, @dateTime); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = nameLocation;
                command.Parameters.Add("@cost", SqlDbType.SmallMoney).Value = cost;
                command.Parameters.Add("@av", SqlDbType.Decimal).Value = availbailty;
                command.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = dateTime;



                try
                {

                    result = Convert.ToInt16(command.ExecuteScalar());



                }
                catch (Exception se)
                {
                    MessageBox.Show(" Tipo Eccezione catturata " + se.GetType() + "  Messaggio Eccezione " + se.Message);
                }

                return result;
            }
        }


        private void MyValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //MessageBox.Show(dateTimePicker1.Text);
            if (DateTime.Now.ToShortDateString() == dateTimePicker1.Value.ToShortDateString())
            {
                dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            }

            dateTimePicker1.ShowCheckBox = true;


        }

        private void DisplayLocationTable()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("USE " + dbName, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command.CommandText = "SELECT * FROM Production.Location";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;


            }
            ResizeRowsColumnsDataGrid();

        }

        private void ResizeRowsColumnsDataGrid()
        {
            dataGridView1.Height = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.None) + dataGridView1.ColumnHeadersHeight + 2;

            dataGridView1.Width = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.None) + dataGridView1.RowHeadersWidth + 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(idTxt.Text))
            {
                MessageBox.Show("Non è possibile modificare la tabella");
                Application.Exit();

            }
            var id = Convert.ToInt16(idTxt.Text);
            Int16? cost = null;
            decimal? availabilty = null;
            ExtractAndValidateData(ref id, ref cost, ref availabilty);
        }
        private void ExtractAndValidateData(ref Int16 id, ref Int16? cost, ref decimal? availability)
        {


            string name = nameTxt.Text;

            if (!string.IsNullOrEmpty(costRateTxt.Text))
            {
                try
                {
                    cost = Int16.Parse(costRateTxt.Text);
                }
                catch (FormatException e)
                {
                    MessageBox.Show("Errore " + e.Message);

                }
                try
                {
                    if (!string.IsNullOrEmpty(availabilyTxt.Text))
                    {
                        availability = decimal.Parse(availabilyTxt.Text);
                    }

                }
                catch (FormatException fe)
                {
                    MessageBox.Show("Errore 2 " + fe.Message);
                }





                UpdateLocationSqlTable(id, name, cost, availability, dateTimePicker1.Text);


            }




         

        }

        private void UpdateLocationSqlTable(short id, string name, short? cost, decimal? availability, string dateTimeStr)
        {

            using (var connection = new SqlConnection(connectionString))
            {

                MessageBox.Show(connection.ToString());
                var command = new SqlCommand("USE " + dbName, connection);
                connection.Open();
                command.ExecuteNonQuery();

                ConstructUpdateQueryByParameters(name, cost, availability, dateTimeStr, command);
                command.CommandText += " WHERE LocationId=@id ";
                command.Parameters.Add("@id", SqlDbType.SmallInt).Value = id;
                try
                {
                    var numRows = command.ExecuteNonQuery();
                    MessageBox.Show("Aggiornamento tabella avvenuto correttamente righe aggiornate " + numRows);
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Errore " + e.Message);
                }
                this.DisplayLocationTable();
            }

        }
        private void ConstructUpdateQueryByParameters(string name, Int16? cost, decimal? availabilty, string dateTimeStr, SqlCommand command)
        {
            bool addComa = true;

            if (!string.IsNullOrEmpty(name) && !cost.HasValue && !availabilty.HasValue && string.IsNullOrEmpty(dateTimeStr))
            {
                addComa = false;
            }
            if (!string.IsNullOrEmpty(name) && cost.HasValue && !availabilty.HasValue && !string.IsNullOrEmpty(dateTimeStr))
            {
                addComa = false;
            }
            if (string.IsNullOrEmpty(name) && !cost.HasValue && availabilty.HasValue && !string.IsNullOrEmpty(dateTimeStr))
            {
                addComa = false;
            }
            if (string.IsNullOrEmpty(name) && cost.HasValue && !availabilty.HasValue && !string.IsNullOrEmpty(dateTimeStr))
            {
                addComa = false;
            }

            if (string.IsNullOrEmpty(name) && cost.HasValue && !availabilty.HasValue && !string.IsNullOrEmpty(dateTimeStr))
            {
                addComa = false;
            }

            StringBuilder builder = new StringBuilder("UPDATE Production.Location SET ");
            if (!string.IsNullOrEmpty(name))
            {
                builder.Append("name = @name ");



                command.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            }


            if (cost.HasValue)
            {
                if (addComa)
                {
                    builder.Append(", ");
                }
                builder.Append("costRate = @cost ");
                command.Parameters.Add("@cost", SqlDbType.SmallMoney).Value = cost;

            }
            if (availabilty.HasValue)
            {
                if (addComa)
                {
                    builder.Append(", ");
                }
                builder.Append("availability = @av ");
                command.Parameters.Add("@av", SqlDbType.Decimal).Value = availabilty;
            }
            DateTime dateTime;
            if (!string.IsNullOrEmpty(dateTimeStr) && DateTime.TryParse(dateTimeStr, out dateTime))
            {
                if (addComa)
                {
                    builder.Append(", ");
                }
                builder.Append("modifiedDate = @mod");

                command.Parameters.Add("@mod", SqlDbType.DateTime).Value = dateTime;
            }

            command.CommandText = builder.ToString();
        }

        private string GetNameById(short id)
        {
            string name = "";
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("USE " + dbName, connection);
                connection.Open();
                command.ExecuteNonQuery();
                command.CommandText = "SELECT name FROM Production.Location WHERE LocationId=@id";
                command.Parameters.Add("@id", SqlDbType.SmallInt).Value = id;
                try
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Errore GetNameById " + e.Message);
                    Application.Exit();
                }



            }
            return name;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            var name = nameTxt.Text;
            var costRateStr = costRateTxt.Text;
            var availibiltyStr = availabilyTxt.Text;
            var dateTimeStr = dateTimePicker1.Text;
            DateTime dateTime;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(costRateStr) && !string.IsNullOrEmpty(dateTimeStr) && DateTime.TryParse(dateTimeStr, out dateTime))
            {
                try
                {

                    var idLocation = AddLocationIntoLocationSqlTable(nameTxt.Text, Convert.ToInt16(costRateTxt.Text), Convert.ToDecimal(availabilyTxt.Text), dateTimePicker1.Value);
                    MessageBox.Show("Inserimento OK");
                }
                catch(SqlException ex)
				{
                    MessageBox.Show("Errore Inserimento campo name duplicato");
                    Debug.WriteLine("Errore "+ ex.Message);
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Errore " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Errore dati moncanti per l'inserimento");
            }


            DisplayLocationTable();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteLocation(Convert.ToInt16(idTxt.Text));
            DisplayLocationTable();

        }
	}
}

