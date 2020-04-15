using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;

namespace FormulaOneDesktopWindows
{
    public partial class FormMain : Form
    {
        private Tools DB;
        private BindingList<Team> teams;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DB = new Tools();

            teams = new BindingList<Team>(DB.Teams__GetAll().Values.ToList());
            listBoxTeam.DataSource = teams;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var path = Environment.ExpandEnvironmentVariables($@"{Tools.WORKINGPATH}\teams.json");

            if (DB.SerializeToJSON(this.teams.ToList(), path))
                MessageBox.Show("Completed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("An error occured.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
