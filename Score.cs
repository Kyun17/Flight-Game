using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace game
{
    public class Score : member // member 클래스 상속
    {
        public Score() // 기본 생성자
        {
            Name = null; // member에서 상속받은 Name 프로퍼티 사용
            this.score1 = 0; 
        }
        public Score(string player_name, int score) // 매개변수를 갖는 생성자
        {
            this.score1 = score;
            Name = player_name;
        }
        public int score1;
    }
}
