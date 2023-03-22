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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace game
{
    public partial class Form5 : Form
    {
        public string player_name;
        public int score;

        public Form5()
        {
            InitializeComponent();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            Score s = new Score();
            s.Name = player_name;
            s.score1 = score;
            label1.Text = s.Name + "님의 점수는 " + s.score1 + "점 입니다!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Score s = new Score(player_name, score);
            Form4 form4 = new Form4()
            {
                player_name = s.Name,
            };
            this.Close();
            form4.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
