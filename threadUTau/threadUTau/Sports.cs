﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace threadUTau
{
    public partial class Sports : Form
    {
        public threadUTau.ServiceReference1.WebService1SoapClient service = new threadUTau.ServiceReference1.WebService1SoapClient();
        public Sports(String username)
        {
            InitializeComponent();
            DataTable table = service.insertTable_sp();
            dataGridView1.DataSource = table;
            label1.Text = username;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String username_labell = label1.Text; 
            service.deleteMessage("Sport", Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()), Convert.ToString(dataGridView1.SelectedCells[2].Value.ToString()), username_labell);
            DataTable table = service.insertTable_sp();
            dataGridView1.DataSource = table;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            String post = textBox1.Text;
            service.postMessage("Sport",post, label1.Text);
            DataTable table = service.insertTable_sp();
            dataGridView1.DataSource = table;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            String username = label1.Text;
            this.Hide();
            Form2 secondForm = new Form2(username);
            secondForm.Show();
            //this.Close();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = label1.Text;
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String currentThread = "Sport";
            this.Hide();
            Comments commentsForm = new Comments(username, currentThread, id);
            commentsForm.Show();
            //this.Close();
            return;
        }
    }
}