using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> stu = new List<Student>();

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void cleartextboxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.StudentID = int.Parse(textBox1.Text);
            s.StudentName = textBox2.Text;
            s.Age = int.Parse(textBox3.Text);
            s.marks = int.Parse(textBox4.Text);
            s.gender = textBox5.Text;

            stu.Add(s);
            MessageBox.Show("Record Added ");
            cleartextboxes();
        }

        private void searchbyname_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var myString = from std in stu
                           where std.StudentName == textBox6.Text
                           select std;
            foreach (var s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var myString = from mark in stu
                           where mark.marks >= int.Parse(textBox7.Text)
                           orderby mark.marks descending
                           select mark;
            foreach (var s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);

            }
            textBox7.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from s in stu
                           select s;
            foreach (var s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from s in stu
                           orderby s.marks descending
                           select s;
            foreach (var s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var myString = from s in stu
                           orderby s.gender ascending, s.marks descending, s.Age ascending
                           select s;
            foreach (var s in myString)
            {
                dataGridView1.Rows.Add(s.StudentID, s.StudentName, s.Age, s.marks, s.gender);

            }
        }
    }
}
