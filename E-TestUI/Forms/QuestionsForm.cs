﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETestUI;

namespace ETestUI
{
    public partial class QuestionsForm : Form
    {
        public QuestionsForm()
        {
            InitializeComponent();
        }
        ResourceManager rm = new ResourceManager(typeof(QuestionsForm));

        private string studentName;
        Etest test = new Etest();

        public Etest Test { get => test; set => test = value; }

        private void load(Question q)
        {
            lprasanje.Text = rm.GetString("lprasanje.Text") + q.Title;
            radioButton1.Text = q.Offer1;
            radioButton2.Text = q.Offer2;
            radioButton3.Text = q.Offer3;
            radioButton4.Text = q.Offer4;

        }
        private string Radiocheck1()
        {

            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            if (radioButton3.Checked)
            {
                return radioButton3.Text;
            }
            return radioButton4.Text;
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            
            if (Test.Count == Test.NumberOfQuestions - 2)
            {
                nextButton.Text = rm.GetString("finish");
            }
            if (Test.Count >= 0)
            {
                backButton.Enabled = true;
            }
            if (Test.Count == Test.NumberOfQuestions-1)
            {
                this.Hide();
                MessageBox.Show(rm.GetString("lprasanje.Text") + Test.Points + "/" + Test.NumberOfQuestions);

            }
            else
            {
                load(Test.Next(Radiocheck1()));
            }
        }
        private void QuestionsForm_Load(object sender, EventArgs e)
        {
            backButton.Text = rm.GetString("backButton.Text");
            backButton.Enabled = false;
            lname.Text += studentName;
            load(Test.Load());
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            load(Test.Back());
            if (Test.Count < Test.NumberOfQuestions)
            {
                nextButton.Text = rm.GetString("nextButton.Text");
            }
            if (Test.Count == 0)
            {
                backButton.Enabled = false;
            }
        }
    }
}