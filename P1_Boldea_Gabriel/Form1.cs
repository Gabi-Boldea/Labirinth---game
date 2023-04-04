using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1_Boldea_Gabriel
{
    public partial class Form1 : Form
    {
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flickering ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            lbl_vieti.Text = Convert.ToString(vieti);
        }

        bool st, dr, sus, jos;
        int viteza = 3;
        int vieti = 5;
        int pozitie = 0;
        int timp = 100;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (st == true)
            {
                /*if (player.Left <= 0)
                    player.Left = player.Left + 2;
                else
                    player.Left = player.Left - viteza;
                */
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            st = false;
                            player.Left = player.Left + viteza + 10;
                        }
                    }
                }
                player.Left = player.Left - viteza;
                if (pozitie == 1)
                {
                    player.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    pozitie = 0;
                }
            }
            if (dr == true)
            {
                /*if (player.Left >= this.Width-player.Width-20)
                    player.Left = player.Left - 2;
                else
                    player.Left = player.Left + viteza;
                */
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            dr = false;
                            player.Left = player.Left - viteza - 10;
                        }
                    } 
                }
                player.Left = player.Left + viteza;
                if (pozitie == 0)
                {
                    player.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    pozitie = 1;
                }
            }
            if (sus == true)
            {
                /*if (player.Top <= 35)
                {
                    player.Top = player.Top + 2;
                    vieti--;
                    lbl_vieti.Text = Convert.ToString(vieti);
                }*/
                foreach(Control x in this.Controls)
                {
                    if((string)x.Tag=="ziduri")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            sus = false;
                            player.Top = player.Top + viteza + 10;
                        }
                    }
                }
                player.Top = player.Top - viteza;
            }
            if (jos == true)
            {
                /*if (player.Top >= this.Height - player.Height - 40)
                    player.Top = player.Top - 2;
                else
                    player.Top = player.Top + viteza;
                */
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "ziduri")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            vieti--;
                            lbl_vieti.Text = Convert.ToString(vieti);
                            jos = false;
                            player.Top = player.Top - viteza - 10;
                        }
                    }
                }
                player.Top = player.Top + viteza;
            }
            if (vieti == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("Game Over!");
                Application.Exit();
            }
            if(player.Bounds.IntersectsWith(usa.Bounds))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("You Win!");
                Application.Exit();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_timp.Text = Convert.ToString(timp);
            timp--;
            if(timp==0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("Game Over!");
                Application.Exit();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                st = false;
            if (e.KeyCode == Keys.Right)
                dr = false;
            if (e.KeyCode == Keys.Up)
                sus = false;
            if (e.KeyCode == Keys.Down)
                jos = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                st = true;
            if (e.KeyCode == Keys.Right)
                dr = true;
            if (e.KeyCode == Keys.Up)
                sus = true;
            if (e.KeyCode == Keys.Down)
                jos = true;
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
