using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace ScoreEntry
{
    public partial class ScoreEntry : Form
    {
        string _server = "feenix-mariadb.swin.edu.au";
        string _database = "s103779510_db";
        string _user = "s103779510";
        string _password = "280496";

        MySqlConnection _con;
        int _stagingID;

        public ScoreEntry()
        {
            InitializeComponent();
            string conString = "server=" + _server + ";uid=" + _user + ";pwd=" + _password + ";database=" + _database;
            _con = new MySqlConnection(conString);
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_con.State == ConnectionState.Closed)
                {
                    _con.Open();
                    MessageBox.Show("Connection successful.");
                }
                else
                {
                    _con.Close();
                    MessageBox.Show("Connection closed.");
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FieldArrow1_Click(object sender, EventArgs e)
        {

        }



        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (_con.State == ConnectionState.Open)
            {
                MySqlCommand cmd;

                // Checks to see if a record already exists for StagingID
                cmd = new MySqlCommand("SELECT * FROM ArrowStaging WHERE StagingID = " + _stagingID, _con);
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show(reader.Read().ToString());
                reader.Close();
            }
            else
            {
                MessageBox.Show("No database connected.");
            }
        }

        // Store StagingID
        private void FieldStagingId_TextChanged(object sender, EventArgs e)
        {
            string input = FieldStagingId.Text;
            input = input.Trim();

            if (input != "")
            {
                _stagingID = Int32.Parse(input);
                //MessageBox.Show(input);
            }
        }
    }
}