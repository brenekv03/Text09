﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(@"..\..\knihy.txt",Encoding.Default);
            string jmenoAutora = textBox1.Text;
            string knizka = "";
            char[] strednik = { ';' };
            bool prvniAutor = false;
            bool prvniProjeti = false;
            while(!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                listBox1.Items.Add(line);
                string[] radek = line.Split(strednik);
                if (prvniProjeti)
                {
                    DateTime rokNapsani = DateTime.Parse(radek[4].ToString());
                    if (rokNapsani > DateTime.Parse("31-12-1950"))
                    {
                        listBox2.Items.Add(line);

                    }
                }
                if (line.Contains(jmenoAutora)&&!prvniAutor)
                {
                    knizka = radek[0];
                    prvniAutor = true;
                }
                prvniProjeti=true;
            }
            if (prvniAutor)
            {
                MessageBox.Show("Vybraný autor je: " + jmenoAutora + " a jeho první knížka v souboru je: " + knizka);
            }
            else 
            {
                MessageBox.Show("Vybraný autor nebyl nalezen");
            }
        }
    }
}
