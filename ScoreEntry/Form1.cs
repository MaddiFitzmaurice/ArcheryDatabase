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

        public struct Score
        {
            public int Arrow1;
            public int Arrow2;
            public int Arrow3;
            public int Arrow4;
            public int Arrow5;
            public int Arrow6;

            public int Arrow1Bullseye;
            public int Arrow2Bullseye;
            public int Arrow3Bullseye;
            public int Arrow4Bullseye;
            public int Arrow5Bullseye;
            public int Arrow6Bullseye;

            public int ArcherID;
            public int RangeID;
            public int RoundID;
        }

        MySqlConnection _con;
        Score _score;

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

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (_con.State == ConnectionState.Open)
            {
                MySqlCommand cmd;

                // Checks to see if a record already exists for StagingID
                cmd = new MySqlCommand(String.Format("INSERT INTO ArrowStaging (Arrow1, Arrow2, Arrow3, Arrow4, Arrow5, Arrow6," +
                    " Arrow1Bullseye, Arrow2Bullseye, Arrow3Bullseye, Arrow4Bullseye, Arrow5Bullseye, Arrow6Bullseye, RangeID, RoundID, ArcherID)" +
                    " VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14});", _score.Arrow1, _score.Arrow2, _score.Arrow3,
                    _score.Arrow4, _score.Arrow5, _score.Arrow6, _score.Arrow1Bullseye, _score.Arrow2Bullseye, _score.Arrow3Bullseye, _score.Arrow4Bullseye, _score.Arrow5Bullseye,
                    _score.Arrow6Bullseye, _score.RangeID, _score.RoundID, _score.ArcherID), _con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Score added.");
            }
            else
            {
                MessageBox.Show("No database connected.");
            }
        }

        private void FieldArrow1_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow1 = Int32.Parse(FieldArrow1.Text);
        }

        private void FieldArrow2_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow2 = Int32.Parse(FieldArrow2.Text);
        }

        private void FieldArrow3_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow3 = Int32.Parse(FieldArrow3.Text);
        }

        private void FieldArrow4_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow4 = Int32.Parse(FieldArrow4.Text);
        }

        private void FieldArrow5_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow5 = Int32.Parse(FieldArrow5.Text);
        }

        private void FieldArrow6_TextChanged(object sender, EventArgs e)
        {
            _score.Arrow6 = Int32.Parse(FieldArrow6.Text);
        }

        private void Bullseye1_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow1Bullseye = Convert.ToInt32(Bullseye1.Checked);
        }

        private void Bullseye2_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow2Bullseye = Convert.ToInt32(Bullseye2.Checked);
        }

        private void Bullseye3_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow3Bullseye = Convert.ToInt32(Bullseye3.Checked);
        }

        private void Bullseye4_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow4Bullseye = Convert.ToInt32(Bullseye4.Checked);
        }

        private void Bullseye5_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow5Bullseye = Convert.ToInt32(Bullseye5.Checked);
        }

        private void Bullseye6_CheckedChanged(object sender, EventArgs e)
        {
            _score.Arrow6Bullseye = Convert.ToInt32(Bullseye6.Checked);
        }

        private void FieldArcherID_TextChanged(object sender, EventArgs e)
        {
            _score.ArcherID = Int32.Parse(FieldArcherID.Text);
        }

        private void FieldRangeID_TextChanged(object sender, EventArgs e)
        {
            _score.RangeID = Int32.Parse(FieldRangeID.Text);
        }

        private void FieldRoundID_TextChanged(object sender, EventArgs e)
        {
            _score.RoundID = Int32.Parse(FieldRoundID.Text);
        }
    }
}