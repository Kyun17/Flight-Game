using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form4 : Form
    {
        int score = 0;
        public string player_name;
        bool goleft, goright, godown, goup, Misslie_exist;
        int misslie_count = 0;
        int misslie_speed = 20;
        int enemy_move;
        int enemy_move2;
        int enemy_move3;
        Random random= new Random(); // 랜덤 클래스
        Random random2= new Random();
        Random random3= new Random();

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            // 키입력을 받아 제어 함수들을 true로 만듬
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                Misslie_exist = true;
            }            
        }

        private void Form4_KeyUp(object sender, KeyEventArgs e)
        {
            // 키가 떼어지면 제어함수들이 false가 됨
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if(e.KeyCode == Keys.Space)
            {
                 Misslie_exist= false;
            }

        }

        int playerspeed = 10; // 플레이어 스피드 변수
        int enemyspped = 10; // 적 스피드 변수
                 
        private void timer4_Tick(object sender, EventArgs e) // 두번째 웨이브 3,4
        {
            if (enemy3.Visible == false && enemy4.Visible == false) // 적들을 모두 해치우면 바로 다음 웨이브로 넘어감
            {
                wave.Text = "wave : 3";
                enemy5.Enabled = true;
                enemy6.Enabled = true;
                enemy7.Enabled = true;
                enemy5.Visible = true;
                enemy6.Visible = true;
                enemy7.Visible = true;
                timer5.Enabled = true;
            }
            timer3.Enabled = false; // 이전에 사용한 웨이브는 false가됨
            enemy_move = random.Next(4); // 적 움직임 제어변수
            enemy_move2 = random2.Next(4, 8); // 적 움직임 제어변수
            // 적 움직임 제어함수
            if (enemy_move == 0)
            {
                enemy3.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy3.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy3.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy3.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy4.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy4.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy4.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy4.Top += enemyspped;
            }
            if (enemy3.Top >= 650 && enemy4.Top >= 650) // 적들이 창에서 사라지면 다음 웨이브로 넘어감
            {
                wave.Text = "wave : 3";
                enemy5.Enabled = true;
                enemy6.Enabled = true;
                enemy7.Enabled = true;
                enemy5.Visible = true;
                enemy6.Visible = true;
                enemy7.Visible = true;
                timer5.Enabled = true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e) // 첫 웨이브 1,2
        {
            if(enemy1.Visible == false && enemy2.Visible == false)
            {
                wave.Text = "wave : 2";
                enemy3.Enabled = true;
                enemy4.Enabled = true;
                enemy3.Visible = true;
                enemy4.Visible = true;
                timer4.Enabled = true;
            }
            enemy_move = random.Next(4);
            enemy_move2= random2.Next(4,8);
            if (enemy_move == 0)
            {
                enemy1.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy1.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy1.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy1.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy2.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy2.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy2.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy2.Top += enemyspped;
            }
            if (enemy2.Top >= 650 && enemy1.Top >= 650)
            {
                wave.Text = "wave : 2";
                enemy3.Enabled = true;
                enemy4.Enabled = true;
                enemy3.Visible = true;
                enemy4.Visible = true;
                timer4.Enabled = true;
            }


        }

        private void timer5_Tick(object sender, EventArgs e)// 세번째 웨이브 5,6,7
        {
            if (enemy5.Visible == false && enemy6.Visible == false && enemy7.Visible == false)
            {
                wave.Text = "wave : 4";
                enemy8.Enabled = true;
                enemy9.Enabled = true;
                enemy8.Visible = true;
                enemy9.Visible = true;
                timer6.Enabled = true;
            }
            timer4.Enabled=false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            enemy_move3 = random2.Next(9, 13);
            if (enemy_move == 0)
            {
                enemy5.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy5.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy5.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy5.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy6.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy6.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy6.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy6.Top += enemyspped;
            }
            if (enemy_move3 == 10)
            {
                enemy7.Left -= enemyspped;
            }
            if (enemy_move3 == 9)
            {
                enemy7.Left += enemyspped;
            }
            if (enemy_move3 == 12)
            {
                enemy7.Top += enemyspped;
            }
            if (enemy_move3 == 11)
            {
                enemy7.Top += enemyspped;
            }
            if (enemy5.Top >= 650 && enemy6.Top >= 650 && enemy7.Top>= 650)
            {
                wave.Text = "wave : 4";
                enemy8.Enabled = true;
                enemy9.Enabled = true;               
                enemy8.Visible = true;
                enemy9.Visible = true;               
                timer6.Enabled = true;
            }

        }

        private void timer6_Tick(object sender, EventArgs e)  // 네번째 웨이브 8,9
        {
            if (enemy8.Visible == false && enemy9.Visible == false)
            {
                wave.Text = "wave : 5";
                enemy10.Enabled = true;
                enemy11.Enabled = true;
                enemy12.Enabled = true;
                enemy10.Visible = true;
                enemy11.Visible = true;
                enemy12.Visible = true;
                timer7.Enabled = true;
            }
            timer5.Enabled= false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            if (enemy_move == 0)
            {
                enemy8.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy8.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy8.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy8.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy9.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy9.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy9.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy9.Top += enemyspped;
            }
            if (enemy8.Top >= 650 && enemy9.Top >= 650)
            {
                wave.Text = "wave : 5";
                enemy10.Enabled = true;
                enemy11.Enabled = true;
                enemy12.Enabled = true;
                enemy10.Visible = true;
                enemy11.Visible = true;
                enemy12.Visible = true;             
                timer7.Enabled = true;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)  // 다섯번째 웨이브 10,11,12
        {
            if (enemy10.Visible == false && enemy11.Visible == false && enemy12.Visible == false)
            {
                wave.Text = "wave : 6";
                enemy13.Enabled = true;
                enemy14.Enabled = true;
                enemy15.Enabled = true;
                enemy13.Visible = true;
                enemy14.Visible = true;
                enemy15.Visible = true;
                timer8.Enabled = true;
            }
            timer6.Enabled = false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            enemy_move3 = random2.Next(9, 13);
            if (enemy_move == 0)
            {
                enemy10.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy10.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy10.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy10.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy11.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy11.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy11.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy11.Top += enemyspped;
            }
            if (enemy_move3 == 10)
            {
                enemy12.Left -= enemyspped;
            }
            if (enemy_move3 == 9)
            {
                enemy12.Left += enemyspped;
            }
            if (enemy_move3 == 12)
            {
                enemy12.Top += enemyspped;
            }
            if (enemy_move3 == 11)
            {
                enemy12.Top += enemyspped;
            }
            if (enemy10.Top >= 650 && enemy11.Top >= 650 && enemy12.Top >= 650)
            {
                wave.Text = "wave : 6";
                enemy13.Enabled = true;
                enemy14.Enabled = true;
                enemy15.Enabled = true;
                enemy13.Visible = true;
                enemy14.Visible = true;
                enemy15.Visible = true;
                timer8.Enabled = true;
            }
        }

        private void timer8_Tick(object sender, EventArgs e) // 여섯번째 웨이브 13,14,15
        {
            if (enemy13.Visible == false && enemy14.Visible == false && enemy15.Visible == false)
            {
                wave.Text = "wave : 7";
                enemy16.Enabled = true;
                enemy17.Enabled = true;
                enemy16.Visible = true;
                enemy17.Visible = true;
                timer9.Enabled = true;
            }
            timer7.Enabled = false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            enemy_move3 = random2.Next(9, 13);
            if (enemy_move == 0)
            {
                enemy13.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy13.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy13.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy13.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy14.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy14.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy14.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy14.Top += enemyspped;
            }
            if (enemy_move3 == 10)
            {
                enemy15.Left -= enemyspped;
            }
            if (enemy_move3 == 9)
            {
                enemy15.Left += enemyspped;
            }
            if (enemy_move3 == 12)
            {
                enemy15.Top += enemyspped;
            }
            if (enemy_move3 == 11)
            {
                enemy15.Top += enemyspped;
            }
            if (enemy13.Top >= 650 && enemy14.Top >= 650 && enemy15.Top >= 650)
            {
                wave.Text = "wave : 7";
                enemy16.Enabled = true;
                enemy17.Enabled = true;             
                enemy16.Visible = true;
                enemy17.Visible = true;              
                timer9.Enabled = true;
            }
        }

        private void timer9_Tick(object sender, EventArgs e) // 일곱번째 웨이브 16,17
        {
            if (enemy16.Visible == false && enemy17.Visible == false)
            {
                wave.Text = "wave : 8";
                enemy18.Enabled = true;
                enemy19.Enabled = true;
                enemy20.Enabled = true;
                enemy18.Visible = true;
                enemy19.Visible = true;
                enemy20.Visible = true;
                timer10.Enabled = true;
            }
            timer8.Enabled = false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            if (enemy_move == 0)
            {
                enemy16.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy16.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy16.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy16.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy17.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy17.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy17.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy17.Top += enemyspped;
            }
            if (enemy16.Top >= 650 && enemy17.Top >= 650)
            {
                wave.Text = "wave : 8";
                enemy18.Enabled = true;
                enemy19.Enabled = true;
                enemy20.Enabled = true;
                enemy18.Visible = true;
                enemy19.Visible = true;
                enemy20.Visible = true;
                timer10.Enabled = true;
            }
        }

        private void timer10_Tick(object sender, EventArgs e)  // 마지막 웨이브 18,19,20
        {
            if (enemy18.Visible == false && enemy19.Visible == false && enemy20.Visible == false && timer10.Enabled == true)
            {
                wave.Text = "wave : Clear";
                Form5 form5 = new Form5()
                {
                    score = score,
                    player_name = player_name,
                };
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer10.Enabled = false;
                MessageBox.Show("Win!", "결과");
                this.Close();
                form5.Show();
               
            }
            timer9.Enabled = false;
            enemy_move = random.Next(4);
            enemy_move2 = random2.Next(4, 8);
            enemy_move3 = random2.Next(9, 13);
            if (enemy_move == 0)
            {
                enemy18.Left -= enemyspped;
            }
            if (enemy_move == 1)
            {
                enemy18.Left += enemyspped;
            }
            if (enemy_move == 2)
            {
                enemy18.Top += enemyspped;
            }
            if (enemy_move == 3)
            {
                enemy18.Top += enemyspped;
            }
            if (enemy_move2 == 7)
            {
                enemy19.Left -= enemyspped;
            }
            if (enemy_move2 == 6)
            {
                enemy19.Left += enemyspped;
            }
            if (enemy_move2 == 5)
            {
                enemy19.Top += enemyspped;
            }
            if (enemy_move2 == 4)
            {
                enemy19.Top += enemyspped;
            }
            if (enemy_move3 == 10)
            {
                enemy20.Left -= enemyspped;
            }
            if (enemy_move3 == 9)
            {
                enemy20.Left += enemyspped;
            }
            if (enemy_move3 == 12)
            {
                enemy20.Top += enemyspped;
            }
            if (enemy_move3 == 11)
            {
                enemy20.Top += enemyspped;
            }
            if (enemy18.Top >= 650 && enemy19.Top >= 650 && enemy20.Top >= 650)
            {
                wave.Text = "wave : Clear";
                Form5 form5 = new Form5()
                {
                    score = score,
                    player_name = player_name,
                };
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer10.Enabled = false;
                MessageBox.Show("Game Over","결과");
                this.Close();
                form5.Show();
               
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            misslie1.Top -= misslie_speed;
            misslie2.Top -= misslie_speed;
            misslie3.Top -= misslie_speed;
            misslie4.Top -= misslie_speed;
            misslie5.Top -= misslie_speed;
            misslie6.Top -= misslie_speed;
            misslie7.Top -= misslie_speed;
            misslie8.Top -= misslie_speed;
            misslie9.Top -= misslie_speed;
            misslie10.Top -= misslie_speed;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }


        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(goleft)
            {
                pictureBox1.Left -= playerspeed;
            }
            if (goright)
            {
                pictureBox1.Left += playerspeed;
            }
            if (goup)
            {
                pictureBox1.Top -= playerspeed;
            }
            if (godown)
            {
                pictureBox1.Top += playerspeed;
            }
            if(Misslie_exist)
            {
                
               if(misslie_count == 0) 
               {
                    misslie1.Visible = true;
                    misslie1.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if(misslie_count == 1) 
               {
                    misslie2.Visible = true;
                    misslie2.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if(misslie_count == 2) 
               {    misslie3.Visible = true;
                    misslie3.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if(misslie_count == 3)
               {
                    misslie4.Visible = true;
                    misslie4.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if(misslie_count == 4)
               {
                    misslie5.Visible = true;
                    misslie5.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if (misslie_count == 5)
               {
                    misslie6.Visible = true;
                    misslie6.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if (misslie_count == 6)
               {
                    misslie7.Visible = true;
                    misslie7.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if (misslie_count == 7)
               {
                    misslie8.Visible = true;
                    misslie8.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if (misslie_count == 8)
               {
                    misslie9.Visible = true;
                    misslie9.Location = pictureBox1.Location;
                    misslie_count++;
               }
               else if (misslie_count == 9)
               {   
                    misslie10.Visible = true;
                    misslie10.Location = pictureBox1.Location;
                    misslie_count = 0;
               }
            }

            // 충돌처리 구문 적과 플레이어
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    if ((string)control.Tag == "enemy")
                    {
                        if (pictureBox1.Bounds.IntersectsWith(control.Bounds) && control.Enabled == true)
                        {
                            timer1.Enabled = false; 
                            timer2.Enabled = false;
                            timer3.Enabled = false;
                            timer4.Enabled = false;
                            timer5.Enabled = false;
                            timer6.Enabled = false;
                            timer7.Enabled = false;
                            timer8.Enabled = false;
                            timer9.Enabled = false;
                            timer10.Enabled = false;
                            MessageBox.Show("GameOver","결과",MessageBoxButtons.OK);
                            Form5 form5 = new Form5()
                            {
                                score = score,
                                player_name= player_name,
                            };
                            this.Close();
                            form5.Show();                          
                        }
                    }
                }
            }

            // 충돌처리구문 미사일 적
            foreach (Control control in this.Controls)
            {
                foreach(Control control1 in this.Controls)
                {
                    if (control is PictureBox && control1 is PictureBox)
                    {
                        if ((string)control.Tag == "misslie")
                        {
                            if((string)control1.Tag == "enemy")
                            {
                                if (control1.Bounds.IntersectsWith(control.Bounds) && control1.Enabled == true && control.Visible == true)
                                {
                                    control1.Enabled = false;
                                    control1.Visible = false;     
                                    control.Visible = false;
                                    score++;
                                    label1.Text = "점수: " + score;
                                }
                            }

                        }
                    }
                }
            }

        }

    }

       

        
        
    
}
