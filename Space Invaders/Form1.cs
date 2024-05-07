using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Background : Form
    {
        int spawnTimer = 0;

        double a = 0;
        int points = 0;
        int cnt = 0;

        Random rand = new Random();
        Invader[] invaders;
        Bullet[] bullets;

        public Background()
        {
            InitializeComponent();
            invaders = new Invader[5];
            bullets = new Bullet[5];
            for (int i = 0; i < 5; i++)
            {
                invaders[i] = new Invader();
                bullets[i] = new Bullet();
                this.Controls.Add(invaders[i].box);
                this.Controls.Add(bullets[i].box);
            }
        }


        private void Player_LocationChanged(object sender, EventArgs e)
        {
            if (Player.Left + Player.Width > this.Width - 15) 
            {
                Player.Left = this.Width - Player.Width - 15;
            }
            else if (Player.Left < 0) 
            {
                Player.Left = 0;
            }
        }

        private void Background_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.A:
                    if (a >= 15) a = 15;
                    else a += 5;
                    Player.Left -= Convert.ToInt32(a);
                    
                    break;

                case Keys.D:
                    if (a >= 15) a = 15;
                    else a += 5;
                    Player.Left += Convert.ToInt32(a);
                    break;

                case Keys.Left:
                    if (a >= 15) a = 15;
                    else a += 5;
                    Player.Left -= Convert.ToInt32(a);
                    break;

                case Keys.Right:
                    if (a >= 15) a = 15;
                    else a += 5;
                    Player.Left += Convert.ToInt32(a);
                    break;

                case Keys.Space:
                    MakeBullet();
                    break;

                    default:
                    a -= 0.1;
                    if (a < 0) a = 0;
                    break;

            }
        }

        private void MakePictureBox() 
        {
            for (int i = 0; i < invaders.Count(); i++)
            {
                if (invaders[i].active == false)
                {
                    double x = rand.NextDouble() * 500;
                    int i_x = (int)Math.Truncate(x);
                    invaders[i].active = true;
                    invaders[i].box.BackColor = Color.White;
                    invaders[i].box.Location = new Point(i_x, -50);
                    break;
                }
            }
        }

        public class Invader
        {
            public PictureBox box;
            public bool active;
            public Invader()
            {
                box = new PictureBox();
                box.Width = 50;
                box.Height = 50;
                box.BackColor = Color.Transparent;
                active = false;
            }

            public void kill()
            {
                box.Width = 0;
                box.Height = 0;
                active = false;
                //MakePictureBox(); --> treba otkriti kako ovo napraviti da se pozove funkcija stvaranja novih kada stari umru, ili ima neki drugi nacin
            }
        }

        public class Bullet
        {
            public PictureBox box;
            public bool active;
            public Bullet()
            {
                box = new PictureBox();
                box.Width = 10;
                box.Height = 20;
                box.BackColor = Color.Transparent;
                active = false;
            }

            public void kill()
            {
                box.Width = 0;
                box.Height = 0;
                active = false;
            }

            public void make() 
            {
                box.Width = 10;
                box.Height = 20;
                box.BackColor = Color.White;
                active = true;
            }
        }

        private void MakeBullet()
        {
            if (cnt < 5)
                if (bullets[cnt].active == false)
                {
                    cnt++;
                    bullets[cnt].make();
                    bullets[cnt].box.Location = new Point(Player.Left + Player.Width / 2 - 5, Player.Top - 20);
                }
                else cnt = 0;
            }

        private bool BBcoll(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {

            int interLeft = Math.Max(x1, x2);
            int interRight = Math.Min(x1 + w1, x2 + w2);
            int interTop = Math.Max(y1, y2);
            int interBottom = Math.Min(y1 + h1, y2 + h2);
            if (interLeft < interRight && interTop < interBottom)
                return true;
            else return false;

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            spawnTimer++;
            if (spawnTimer >= 60)
            {
                MakePictureBox();
                spawnTimer = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < invaders.Count(); i++)
            {
                if (invaders[i].active == true) invaders[i].box.Top += 2;
                //if (invaders[i].active == true && invaders[i].box.Bottom <= 20) invaders[i].kill();
            }

            for (int i = 0; i < bullets.Count(); i++)
            {
                if (bullets[i].active == true) bullets[i].box.Top -= 5;
                //if (bullets[i].active == true && bullets[i].box.Top <= 50) bullets[i].kill();
            }
            /* DODATI KADA HITAJU POD DA JE GAME OVER */
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < bullets.Count(); j++)
                for (int i = 0; i < invaders.Count(); i++)
                {
                    if (BBcoll(bullets[j].box.Left, bullets[j].box.Top, bullets[j].box.Width, bullets[j].box.Height, invaders[i].box.Left, invaders[i].box.Top, invaders[i].box.Width, invaders[i].box.Height) == true)
                    { // provjeriti kaj tocno ne valja msm da je ovdje problem left i top msm da za jedan treba biti to a za drugog right i bottom al treba vidjeti
                        invaders[i].kill();
                        bullets[j].kill();
                    }
                }
        }

        
    }
}
