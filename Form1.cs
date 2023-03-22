using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace game
{
    public partial class Form1 : Form
    {
        private int index = 0;
        public string player_name;

        public Form1()
        {
            InitializeComponent();
        }

        FirebaseConfig fbc = new FirebaseConfig()
        {
            AuthSecret = "4CMobqEG6X99GlDvIpccaUnxWMPzAJJCFuRyPi3x",
            BasePath = "https://member-3bc48-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;



        private void timer1_Tick(object sender, EventArgs e)
        {
            // 배경화면을 움직이게 한다
            index %= imageList1.Images.Count;
            pictureBox1.Image = imageList1.Images[index++];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = client.Get("가입자 명단/" + textBox1.Text);
            member mb = result.ResultAs<member>();
            
            // 데이터 베이스에 저장된 값과 텍스트 박스에 입력된 값을 비교
            if (mb == null) // id 검사
            {
                MessageBox.Show("ID가 틀렸습니다.","ID 입력 오류",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (textBox2.Text == mb.password) // 비밀번호 검사
            {
                MessageBox.Show("로그인 성공", "로그인 중", MessageBoxButtons.OK);
                groupBox2.Enabled= true;
                groupBox2.Visible= true;
                player_name = mb.Name;
                label4.Text = "환영합니다 " + mb.Name + " 님";
                
            }
            else if (textBox1.Text == "") // 빈칸일 경우 오류 메세지
            {
                MessageBox.Show("아이디를 입력해주세요.", "ID 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox2.Text == "") // 빈칸일 경우 오류 메세지
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "PassWord 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.","PassWord 입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 예외처리 구문
            try
            {
                client = new FireSharp.FirebaseClient(fbc);
            }
            catch
            {
                MessageBox.Show("문제발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 회원가입 버튼
            Form2 form2= new Form2();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 게임 시작 버튼
            Form4 form4 = new Form4()
            {
                player_name = player_name,               
            };
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 게임 끝내기 버튼
            this.Close();
        }
    }
}
