using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proiect
{
    public partial class InregistrareStudent : Form
    {
        StudentClass student = new StudentClass();
        public InregistrareStudent()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_actualizeaza_Click(object sender, EventArgs e)
        {
            // cauta imagine in pc
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Selecteaza Imagine(*.jpg; *.png; *.gif) | *.jpg;*.png; *.gif" ;

            if(opf.ShowDialog() == DialogResult.OK )
                pictureBox_img.Image=Image.FromFile(opf.FileName);
        }

        private void button_sterge_Click(object sender, EventArgs e)
        {
            // sterge 
            textBox_nume.Clear();
            textBox_prenume.Clear();
            textBox_telefon.Clear();
            textBox_adresa.Clear(); 
            pictureBox_img.Image = null;
        }

        // functie care verifica
        bool verify()
        {
            if((textBox_nume.Text=="") || (textBox_prenume.Text=="") || 
                    (textBox_adresa.Text=="") || (textBox_telefon.Text=="")||
                    (pictureBox_img.Image==null))
                    {
                        return false;
                    }
            else 
                return true;
        }
        private void button_adauga_Click(object sender, EventArgs e)
        {
            // adauga un student 
            string Nume = textBox_nume.Text;
            string Prenume = textBox_prenume.Text;
            DateTime bdate= dateTimePicker1.Value;
            string Telefon = textBox_telefon.Text;
            string Adresa = textBox_adresa.Text;
            string gender = radioButton_baiat.Checked ? "Baiat" : "Fata";
           

          // verificare varsta
          int born_year = dateTimePicker1.Value.Year;
          int this_year = DateTime.Now.Year;
            if((this_year - born_year) < 10 || (this_year - born_year) > 100) {
                MessageBox.Show("Varsta trebuie sa fie intre 10 si 100","Invalid", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(verify())
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox_img.Image.Save(ms, pictureBox_img.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (student.insertStudent(Nume, Prenume, bdate, Telefon, Adresa, gender, img))
                    {
                        showTable();
                        MessageBox.Show("S-a adaugat un student nou", "Adauga student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                } catch(Exception ex)
            
                {
                    MessageBox.Show(ex.Message, "Incercati iar!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Sterge casetele", "Adauga student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InregistrareStudent_Load(object sender, EventArgs e)
        {
            showTable();
        }

        // pentru a arata lista de studenti in datagridview
        public void showTable()
        {
            DataGridView_std.DataSource = student.getStudentlist();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_std.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
