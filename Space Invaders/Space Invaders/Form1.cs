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

        public bool BBcoll(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            int interLeft = Math.Max(x1, x2);
            int interRight = Math.Min(x1 + w1, x2 + w2);
            int interTop = Math.Max(y1, y2);
            int interBottom = Math.Min(y1 + h1, y2 + h2);
            if (interLeft < interRight && interTop < interBottom)
                return true;
            return false;
        }


        public Background()
        {
            InitializeComponent();
            invaders = new Invader[5];
            bullets = new Bullet[5];
            for (int i = 0; i < 5; i++)
            {
                invaders[i] = new Invader();
                this.Controls.Add(invaders[i].box);
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
                    if (a >= 25) a = 25;
                    else a += 5;
                    Player.Left += Convert.ToInt32(a);
                    break;

                case Keys.Left:
                    if (a >= 25) a = 25;
                    else a += 5;
                    Player.Left -= Convert.ToInt32(a);
                    break;

                case Keys.Right:
                    if (a >= 25) a = 25;
                    else a += 5;
                    Player.Left += Convert.ToInt32(a);
                    break;

                case Keys.Space:
                    cnt++;
                    if (cnt > 5) break;
                    else bullets[cnt].active = true;
                    break;

                    default:
                    a -= 0.1;
                    if (a < 0) a = 0;
                    break;

            }
        }

        private void MakePictureBox() 
        {
            if (cnt < 5)
            {
                if (invaders[cnt].active == false)
                {
                    double x = rand.NextDouble() * 800;
                    int i_x = (int)x;
                    invaders[cnt].active = true;
                    invaders[cnt].box.BackColor = Color.White;
                    invaders[cnt].box.Location = new Point(i_x, -50);
                }
                cnt++;
            }
            else return;
            
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

            public void kill(){
                box.Width = 0;
                box.Height = 0;
                active = false;
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
                box.BackColor = Color.White;
                active = false;
            }

            public void kill()
            {
                box.Width = 0;
                box.Height = 0;
                active = false;
            }
        }


        private void TimerEvent(object sender, EventArgs e)
        {
            spawnTimer++;
            if (spawnTimer >= 30)
            {
                MakePictureBox();
                spawnTimer = 0;


            }

            for (int i = 0; i < invaders.Count(); i++)
            {
                if (invaders[i].active == true) invaders[i].box.Top += 5;
            }       

            for (int i = 0; i < bullets.Count(); i++)
            {
                if (bullets[i].active == true) bullets[i].box.Top -= 5;
            }

            //if (hit reg == true) 
            //{
             //   points += 100;
             //   Counter.Text = "Points: " + points;
            //}
            
            // troubleshoot -> Counter.Text = "Items: " + items.Count();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bullets.Count(); i++)
            {
                /*if (BBcoll(bullets[i].box.Left, bullets[i].box.Top, bullets[i].box.Width, bullets[i].box.Height, invaders[i].box.Left, invaders[i].box.Top, invaders[i].box.Width, invaders[i].box.Width) == true)
                {
                    invaders[i].kill();
                    bullets[i].kill();
                    points += 100;
                }*/ //ovo ne valja jer ih nece dobro provjeravati
            }

            /*
             function BBcoll(x1, y1, w1, h1, x2, y2, w2, h2)
{
  var interLeft = Math.max(x1, x2);
  var interRight = Math.min(x1 + w1, x2 + w2);
  var interTop = Math.max(y1, y2);
  var interBottom = Math.min(y1 + h1, y2+h2);
  if (interLeft < interRight && interTop < interBottom)
  return true;
return false;
}
             */


        }

        
    }
}
