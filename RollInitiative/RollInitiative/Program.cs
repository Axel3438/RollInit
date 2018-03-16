using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollInitiative
{

    //list class!!
    //pulled most of the code straigth from the example located at
    //https://msdn.microsoft.com/en-us/library/w56d4y5z(v=vs.110).aspx
    [Serializable]
    public class CharBlock : IEquatable<CharBlock>, IComparable<CharBlock>
    {
        public string Name;
        public string DMNotes;
        public int Initiative;
        public int InitMod;
        public int BaseAC;
        public int TouchAC;
        public int FlatAC;
        public int Fort;
        public int Reflex;
        public int Will;
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CharBlock objAsChar = obj as CharBlock;
            if (objAsChar == null) return false;
            else return Equals(objAsChar);
        }

        public int SortByNameAscending(string name1, string name2)
        {

            return name2.CompareTo(name1);
        }

        public override int GetHashCode()
        {
            return Initiative;
        }

        // Default comparer for CharBlock type.
        public int CompareTo(CharBlock CompareChar)
        {
            // A null value means that this object is greater.
            if (CompareChar == null)
                return 1;

            //The first one test to see if it is greater. If it is not greater, it is the same or lower, so test to see if it is the same
            // if the same, and there is a higher modifier,they go first!
            else if ((CompareChar.InitMod < this.InitMod)&& (CompareChar.Initiative==this.Initiative)) return 1;

            else
                return this.Initiative.CompareTo(CompareChar.Initiative);
        }
        public bool Equals(CharBlock other)
        {
            if (other == null) return false;
            return (this.Initiative.Equals(other.Initiative));
        }
        // Should also override == and != operators.
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
