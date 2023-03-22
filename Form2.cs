using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        FirebaseConfig fbc = new FirebaseConfig()  // 데이터 베이스 객체 생성
        {
            AuthSecret = "4CMobqEG6X99GlDvIpccaUnxWMPzAJJCFuRyPi3x", // 데이터 베이스 비밀번호
            BasePath = "https://member-3bc48-default-rtdb.firebaseio.com/" // 데이터 베이스 경로
        };
        IFirebaseClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text==""|| textBox3.Text=="") // 입력 칸에 빈창이 있을시 오류 메시지 창 출력
            {
                MessageBox.Show("빈 칸이 있습니다 확인하세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 회원가입 진행
                var result = client.Get("가입자 명단/" + textBox2.Text);
                member mb = result.ResultAs<member>();
                member mb2 = new member() // member 객체생성
                {
                    Name = textBox1.Text, // 사용자로부터 텍스트박스에 입력받은 값을 저장
                    id = textBox2.Text,
                    password = textBox3.Text
                };
                var send = client.Set("가입자 명단/" + textBox2.Text, mb2); // client에 mb2 객체의 값들을 보내고 저장함
                MessageBox.Show("축하합니다! 회원가입이 완료 되었습니다.","회원가입 성공");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 예외처리 구문
            try // client 객체가 제대로 생성되지 않으면 
            {
                client = new FireSharp.FirebaseClient(fbc);
            }
            catch // 오류 메세지창이 출력됨
            {
                MessageBox.Show("문제발생", "오류",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }
    }
}
