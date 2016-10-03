using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlämningsuppgifter2
{
    public partial class frmShotgun : Form
    {
        bool spelare12;
        bool tur;
        int Spelare1Val;
        int val;
        bool player1shoutguntrue = false;
        bool player2shoutguntrue = false;

        public frmShotgun()
        {
            InitializeComponent();
            tur = true;
        }
        private async void SkottEffekt()
        {
            if (spelare12 == true)
            {
                pboSpelare1Skott.Visible = true;
                await Task.Delay(500);
                pboSpelare1Skott.Visible = false;
            }
            else if (spelare12 == false)
            {
                pboSpelare2Skott.Visible = true;
                await Task.Delay(500);
                pboSpelare2Skott.Visible = false;
            }
        }

        private async void pboSpelare1_Click(object sender, EventArgs e)
        {
            if (p1s3.Visible == false)
            {
                player1shoutguntrue = false;
            }
            Spelare1Val = 1;
            if (tur && p1s3.Visible)
            {
                spelare12 = true;
                spelare1shoutguneffekt();
                await Task.Delay(850);

                DuVann.Visible = true;
                SlutPåSpel();
                btnSpelaIgen.Visible = true;
                tur = true;
            }
            else if (tur && p1s1.Visible)
            {
                //Spelar upp skott effektet
                spelare12 = true;
                SkottEffekt();

                //Ger turen till spelare2
                tur = false;
                await Task.Delay(500);
                spelare2();
            }
            else if (tur == false)
            {
                MessageBox.Show("Vänta på din tur");
            }
            else
            {
                MessageBox.Show("Du måste ha minst ett skott föratt kunna skjuta!!!");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            startbutton();
        }
        private async void spelare2()
        {
            //Väljer ett random val för spelare2
            if (p2s1.Visible)
            {
                Random rand = new Random();
                val = rand.Next(1, 4);
            }
            else
            {
                Random rand = new Random();
                val = rand.Next(2, 4);
            }

            //Val1 = skjuta
            //Val2 = ladda
            //Val3 = blocka

            if (p2s3.Visible)
            {
                spelare12 = false;
                spelare1shoutguneffekt();
                await Task.Delay(850);

                Duförlorade.Visible = true;
                SlutPåSpel();
                btnSpelaIgen.Visible = true;
                tur = true;
            }


            else if (val == 1 && Spelare1Val == 1 && p2s1.Visible == true)
            {
                spelare12 = false;
                SkottEffekt();

                if (p2s7.Visible)
                {
                    p2s7.Visible = false;
                }
                else if (p2s6.Visible)
                {
                    p2s6.Visible = false;
                }
                else if (p2s5.Visible)
                {
                    p2s5.Visible = false;
                }
                else if (p2s4.Visible)
                {
                    p2s4.Visible = false;
                }
                else if (p2s3.Visible)
                {
                    p2s3.Visible = false;
                }
                else if (p2s2.Visible)
                {
                    p2s2.Visible = false;
                }
                else if (p2s1.Visible)
                {
                    p2s1.Visible = false;
                }

                //Gömmer det sista skottet på spelare1
                if (p1s7.Visible)
                {
                    p1s7.Visible = false;
                }
                else if (p1s6.Visible)
                {
                    p1s6.Visible = false;
                }
                else if (p1s5.Visible)
                {
                    p1s5.Visible = false;
                }
                else if (p1s4.Visible)
                {
                    p1s4.Visible = false;
                }
                else if (p1s3.Visible)
                {
                    p1s3.Visible = false;
                }
                else if (p1s2.Visible)
                {
                    p1s2.Visible = false;
                }
                else if (p1s1.Visible)
                {
                    p1s1.Visible = false;
                }
                tur = true;
            }
            else if (val == 1 && Spelare1Val == 2 && p2s1.Visible == true)
            {
                spelare12 = false;
                SkottEffekt();
                await Task.Delay(850);
                Duförlorade.Visible = true;
                SlutPåSpel();
                btnSpelaIgen.Visible = true;
                tur = true;
            }
            else if (val == 1 && Spelare1Val == 3 && p2s1.Visible == true)
            {
                spelare12 = false;
                SkottEffekt();
                //Robot förlorar ett skott
                spelare2förlorarskott();
                tur = true;
            }
            else if (val == 2 && Spelare1Val == 1)
            {
                Spelare2Ladda();
                //Spelare 1 vinner
                await Task.Delay(850);
                DuVann.Visible = true;
                SlutPåSpel();
                btnSpelaIgen.Visible = true;
                tur = true;
            }
            else if (val == 2 && Spelare1Val == 2)
            {
                if (p2s2.Visible)
                {
                    player2shoutguntrue = true;
                    shoutguntext();
                }
                Spelare2Ladda();
                //både spelare för varsin skott
                Spelare1FårSkott();
                Spelare2FårSkott();
                tur = true;
            }
            else if (val == 2 && Spelare1Val == 3)
            {
                if (p2s2.Visible)
                {
                    player2shoutguntrue = true;
                    shoutguntext();
                }
                Spelare2Ladda();
                //Spelare2 får ett skott
                Spelare2FårSkott();
                tur = true;
            }
            else if (val == 3 && Spelare1Val == 1)
            {
                Spelare2Block();
                //Gömmer det sista skottet på spelare1
                if (p1s7.Visible)
                {
                    p1s7.Visible = false;
                }
                else if (p1s6.Visible)
                {
                    p1s6.Visible = false;
                }
                else if (p1s5.Visible)
                {
                    p1s5.Visible = false;
                }
                else if (p1s4.Visible)
                {
                    p1s4.Visible = false;
                }
                else if (p1s3.Visible)
                {
                    p1s3.Visible = false;
                }
                else if (p1s2.Visible)
                {
                    p1s2.Visible = false;
                }
                else if (p1s1.Visible)
                {
                    p1s1.Visible = false;
                }
                tur = true;
            }
            else if (val == 3 && Spelare1Val == 2)
            {
                Spelare2Block();
                //Spelare 1 får ett skott
                Spelare1FårSkott();
                tur = true;
            }
            else if (val == 3 && Spelare1Val == 3)
            {
                Spelare2Block();
                //Inget händer
                tur = true;
            }
        }
        private void Minst3Skott()
        {
            Random rand2 = new Random();
            val = rand2.Next(2, 3);
            spelare2();
        }
        private async void startbutton()
        {
            //Gömmer start knappen
            btnStart.Visible = false;
            btnStartExplode.Visible = true;

            //Väntar på explotion
            await Task.Delay(2420);
            btnStartExplode.Visible = false;

            //visar spelare 1 kontroller
            pboSpelare1.Visible = true;
            btnSpelare1Block.Visible = true;
            btnPlayer1Ladda.Visible = true;

            //visar spelare 2 kontroller
            pboSpelare2.Visible = true;
        }

        private void btnPlayer1Ladda_Click(object sender, EventArgs e)
        {
            if (p1s2.Visible)
            {
                player1shoutguntrue = true;
                shoutguntext();
            }
            if (tur && p1s7.Visible == false)
            {
                Spelare1Val = 2;
                //Ger turen till spelare
                tur = false;
                spelare2();
            }
            else if (p1s7.Visible)
            {
                MessageBox.Show("Du har redan max skott");
            }
            else
            {
                MessageBox.Show("Vänta på din tur");
            }
        }
        private void Spelare1FårSkott()
        {
            if (p1s1.Visible == false)
            {
                p1s1.Visible = true;
            }
            else if (p1s1.Visible && p1s2.Visible == false)
            {
                p1s2.Visible = true;
            }
            else if (p1s2.Visible && p1s3.Visible == false)
            {
                p1s3.Visible = true;

            }
            else if (p1s3.Visible && p1s4.Visible == false)
            {
                p1s4.Visible = true;
            }
            else if (p1s4.Visible && p1s5.Visible == false)
            {
                p1s5.Visible = true;
            }
            else if (p1s5.Visible && p1s6.Visible == false)
            {
                p1s6.Visible = true;
            }
            else if (p1s6.Visible && p1s7.Visible == false)
            {
                p1s7.Visible = true;
            }
        }
        private void Spelare2FårSkott()
        {
            if (p2s1.Visible == false)
            {
                p2s1.Visible = true;
            }
            else if (p2s1.Visible && p2s2.Visible == false)
            {
                p2s2.Visible = true;
            }
            else if (p2s2.Visible && p2s3.Visible == false)
            {
                p2s3.Visible = true;
            }
            else if (p2s3.Visible && p2s4.Visible == false)
            {
                p2s4.Visible = true;
            }
            else if (p2s4.Visible && p2s5.Visible == false)
            {
                p2s5.Visible = true;
            }
            else if (p2s5.Visible && p2s6.Visible == false)
            {
                p2s6.Visible = true;
            }
            else if (p2s6.Visible && p2s7.Visible == false)
            {
                p2s7.Visible = true;
            }
        }
        private void spelare2förlorarskott()
            {
             if (p2s7.Visible)
                {
                    p2s7.Visible = false;
                }
                else if (p2s6.Visible)
                {
                    p2s6.Visible = false;
                }
                else if (p2s5.Visible)
                {
                    p2s5.Visible = false;
                }
                else if (p2s4.Visible)
                {
                    p2s4.Visible = false;
                }
            else
            {
                Minst3Skott();
            }
            }

        private void btnSpelare1Block_Click(object sender, EventArgs e)
        {
            if (tur)
            {
                Spelare1Val = 3;
                //Ger turen till spelare
                tur = false;
                spelare2();
            }
            else
            {
                MessageBox.Show("Vänta på din tur");
            }
        }
        private async void Spelare2Block()
        {
            btnSpelare2Block.Visible = true;
            await Task.Delay(500);
            btnSpelare2Block.Visible = false;
        }
        private async void Spelare2Ladda()
        {
            btnSpelare2lada.Visible = true;
            await Task.Delay(500);
            btnSpelare2lada.Visible = false;
        }
        private void SlutPåSpel()
        {
            //Gömmer spelare 2 kontroller
            pboSpelare1.Visible = false;
            btnSpelare1Block.Visible = false;
            btnPlayer1Ladda.Visible = false;

            //Gömmer spelare 2 kontroller
            pboSpelare2.Visible = false;

            //Gömmer alla skott
            p1s1.Visible = false;
            p1s2.Visible = false;
            p1s3.Visible = false;
            p1s4.Visible = false;
            p1s5.Visible = false;
            p1s6.Visible = false;
            p1s7.Visible = false;

            p2s1.Visible = false;
            p2s2.Visible = false;
            p2s3.Visible = false;
            p2s4.Visible = false;
            p2s5.Visible = false;
            p2s6.Visible = false;
            p2s7.Visible = false;

            //Shoutgun
            player1shoutguntrue = false;
            player2shoutguntrue = false;
            Player1ShoutgunText.Visible = false;
            Player2ShoutgunText.Visible = false;
        }

        private void btnSpelaIgen_Click(object sender, EventArgs e)
        {
            startbutton();
            Duförlorade.Visible = false;
            DuVann.Visible = false;
            btnSpelaIgen.Visible = false;
        }

        //Fixar så att bilder inte ljuser vitt när de göms!!!
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        public async void spelare1shoutguneffekt()
        {
            if (spelare12 == true)
            {
                spelare1shoutgun.Visible = true;
                await Task.Delay(500);
                spelare1shoutgun.Visible = false;
            }
            else if (spelare12 == false)
            {
                Spelare2Shoutgun.Visible = true;
                await Task.Delay(500);
                Spelare2Shoutgun.Visible = false;
            }
        }
        public async void shoutguntext()
        {
            if (player1shoutguntrue)
            {
                Player1ShoutgunText.Visible = true;
            }
            if (player2shoutguntrue)
            {
                Player2ShoutgunText.Visible = true;
            }
        }
    }
}
