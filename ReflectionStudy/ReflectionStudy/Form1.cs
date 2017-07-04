using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionStudy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type t = typeof(RefClass);

            Func<MemberTypes, String> getType = (x) =>
            {
                switch (x)
                {
                    case MemberTypes.Field:
                        {
                            return "字段";
                        }
                    case MemberTypes.Method:
                        {
                            return "方法";
                        }
                    case MemberTypes.Property:
                        {
                            return "属性";
                        }
                    default:
                        {
                            return "未知";
                        }
                }
            };

            //“包含非公开”、“包含实例成员”、“包含公开”、“只包含该类的成员”、“包括表态方法”
            MemberInfo[] minfos = t.GetMembers( BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Public|BindingFlags.DeclaredOnly| BindingFlags.Static);
            foreach (MemberInfo minfo in minfos)
            {
                Console.WriteLine(minfo.Name + ";类型:" + getType(minfo.MemberType));
            }
        }
    }
}
