﻿using KockapokerForm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockapokerForm
{
    public partial class frmFo : Form
    {
        private Dobas gep;
        private Dobas ember;
        private PictureBox[] gepKep;
        private PictureBox[] emberkep;

        public frmFo()
        {
            InitializeComponent();
            gepKep = new PictureBox[5] { pbGep1, pbGep2, pbGep3, pbGep4, pbGep5 };
            emberkep = new PictureBox[5] { pbEmber1,pbEmber2,pbEmber3,pbEmber4,pbEmber5};
            gep = new Dobas();
            ember = new Dobas();
            lblGepReszeredmeny.Text = "";
            lblgeperedmeny.Text = "0";
            lblEmberReszeredmeny.Text = "";
            lblEmbereredmeny.Text = "0";
        }

        private void KepElhelyez(PictureBox pb, int szam)
        {
            switch (szam)
            {
                case 1: pb.Image = Resources.egy;
                    break;
                case 2: pb.Image = Resources.ketto;
                    break;
                case 3: pb.Image = Resources.harom;
                    break;
                case 4: pb.Image = Resources.negy;
                    break;
                case 5: pb.Image = Resources.ot;
                    break;
                case 6: pb.Image = Resources.hat;
                    break;

                default:
                    break;
            }
        }

        private void DobasMegjelenit(Dobas d,PictureBox[] kepek)
        {

            //KepElhelyez(pbGep1, d.Kockak[0]);
            //KepElhelyez(pbGep2, d.Kockak[1]);
            //KepElhelyez(pbGep3, d.Kockak[2]);
            //KepElhelyez(pbGep4, d.Kockak[3]);
            //KepElhelyez(pbGep5, d.Kockak[4]);

            for (int i = 0; i < 5; i++)
            {
                KepElhelyez(kepek[i], d.Kockak[i]);
            }

        }

        private void btnDobas_Click(object sender, EventArgs e)
        {
            gep.EgyDobas();
            ember.EgyDobas();
            DobasMegjelenit(gep,gepKep);
            DobasMegjelenit(ember,emberkep);
            lblEmberReszeredmeny.Text = ember.Eredmeny;
            lblGepReszeredmeny.Text = gep.Eredmeny;

            if (gep.Pont > ember.Pont)
            {
                MessageBox.Show("Gép nyert","Játszott kör",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gep.Nyert++;
                lblgeperedmeny.Text = gep.Nyert.ToString();
            }
            if (gep.Pont < ember.Pont)
            {
                MessageBox.Show("Ember nyert", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ember.Nyert++;
                lblEmbereredmeny.Text = ember.Nyert.ToString();
            }
            if (gep.Pont == ember.Pont)
            {
                MessageBox.Show("Döntetlen", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }
    }
}
