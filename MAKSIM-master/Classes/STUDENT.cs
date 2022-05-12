using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListClass.Classes
{
    public class STUDENT
    {//поля
        string name;
        string group;
        int math;
        int history;
        int physics;
        int obzh;
        int french;


        //свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public int Math
        {
            get { return math; }
            set { math = value; }
        }
        public int History
        {
            get { return history; }
            set { history = value; }
        }
        public int Physics
        {
            get { return physics; }
            set { physics = value; }
        }
        public int Obzh
        {
            get { return obzh; }
            set { obzh = value; }
        }
        public int French
        {
            get { return french; }
            set { french = value; }
        }
        //конструкторы
        public STUDENT()
        {
            name = "";
            group = "";
            math = 0;
            history = 0;
            physics = 0;
            obzh = 0;
            french = 0;
        }

        public STUDENT(string n, string g, int m, int h, int p, int o, int f)
        {
            this.name = n;
            this.group = g;
            this.math = m;
            this.history = h;
            this.physics = p;
            this.obzh = o;
            this.french = f;
        }


    }
}
