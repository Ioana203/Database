using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
         {
            student_meniu.Visible = false;
            curs_meniu.Visible = false;
            note_meniu.Visible = false;
         } 

        private void hideSubmenu()
        {
            if(student_meniu.Visible == true) 
                student_meniu.Visible = false;
            if(curs_meniu.Visible == true)
                curs_meniu.Visible = false;
            if(note_meniu.Visible == true)
                note_meniu.Visible = false;
            
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else 
                submenu.Visible = false;
        }

        #region Studenti
        private void buton_studenti_Click(object sender, EventArgs e)
        {
            showSubmenu(student_meniu);

        }
        private void buton_inregistrare_Click(object sender, EventArgs e)
        {
            openChildForm( new InregistrareStudent());
            hideSubmenu();
        }
        private void buton_status_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_tabelstd_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_printstd_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion Studenti

        #region Cursuri
        private void buton_cursuri_Click(object sender, EventArgs e)
        {
            showSubmenu(curs_meniu);
        }
        private void buton_inregistrarecurs_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_accesarecurs_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_printcurs_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion

        #region Note

        private void buton_note_Click(object sender, EventArgs e)
        {
            showSubmenu(note_meniu);
        }
        private void buton_adauganote_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_acceseazanote_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        private void buton_printnote_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion

        // 
        private Form activateForm = null;
        private void openChildForm(Form childForm)
        {
            if( activateForm != null)
             activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            
        }
        private void status_Click(object sender, EventArgs e)
        {
           
        }
        private void iesire_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            panel_main.Controls.Add(panel_cover);
        }































        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
