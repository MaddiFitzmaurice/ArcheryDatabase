using MySql.Data.MySqlClient;
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

       
    }
}