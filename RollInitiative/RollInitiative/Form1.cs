using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollInitiative
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<CharBlock> Characters = new List<CharBlock>();
        List<string> CharName = new List<string>();
        int UniqueIndex = 0;
        public string FilePath;
        Random rng = new Random();
        bool Saving = false;
        bool Loading = false;
        bool Adding = false;
        

        //Updates the name list. It changes only the name being altered currently. 
        public void UpdateNames()
        {
            CharName.Clear();
            int listsize = Characters.Count;
            for (int i = 0; i < listsize; i++)
            {
                CharName.Add(Characters[i].Name);
            }
            listBox1.DataSource = null;
            listBox1.DataSource = CharName;
            listBox1.Refresh();
        }

        //Character names
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //index would flip to negative, so that was made into absolute value. band aid fix away!
            UniqueIndex=Math.Abs(listBox1.SelectedIndex);
            try
            {
                textBox1.Text = Characters[UniqueIndex].Name;
                textBox2.Text = Characters[UniqueIndex].InitMod.ToString();
                textBox3.Text = Characters[UniqueIndex].BaseAC.ToString();
                textBox4.Text = Characters[UniqueIndex].TouchAC.ToString();
                textBox5.Text = Characters[UniqueIndex].FlatAC.ToString();
                textBox6.Text = Characters[UniqueIndex].Fort.ToString();
                textBox7.Text = Characters[UniqueIndex].Reflex.ToString();
                textBox8.Text = Characters[UniqueIndex].Will.ToString();
                textBox9.Text = Characters[UniqueIndex].Initiative.ToString();
                richTextBox2.Text = Characters[UniqueIndex].DMNotes;
            }
            //it can crash as it tries to update. This forces it not to crash by doing NOTHING!
            catch { }
  
        }

        //roll all
        private void Button1_Click(object sender, EventArgs e)
        {
           //if you cannot figure this out, I weep for you
           for(int i=0; i< Characters.Count; i++)
            {
                int init = rng.Next(1, 20);
                Characters[i].Initiative = init + Characters[i].InitMod;
            }
            Characters.Sort();
            UpdateNames();
        }

        //roll this
        private void Button2_Click(object sender, EventArgs e)
        {
            //now even smaller!!
            int init = rng.Next(1, 20);
            if (Characters.Count != 0) {
                Characters[UniqueIndex].Initiative = init + Characters[UniqueIndex].InitMod;
                Characters.Sort();
                UpdateNames();
            }
        }

        //add character
        private void Button4_Click(object sender, EventArgs e)
        {
            //I should do this in a better fashion, but my mind went blank and.. it works.
            Characters.Add(new CharBlock());
            Characters[Characters.Count - 1].Name = "moog";
            Characters[Characters.Count - 1].InitMod = 0;
            Characters[Characters.Count - 1].BaseAC = 0;
            Characters[Characters.Count - 1].TouchAC = 0;
            Characters[Characters.Count - 1].FlatAC = 0;
            Characters[Characters.Count - 1].Fort = 0;
            Characters[Characters.Count - 1].Reflex = 0;
            Characters[Characters.Count - 1].Will = 0;
            Characters[Characters.Count - 1].Initiative = -1;
            UpdateNames();
        }

        //delete character
        private void Button3_Click(object sender, EventArgs e)
        {
            if(Characters.Count != 0)
            {
                Characters.RemoveAt(UniqueIndex);
                UpdateNames();

            }
        }
        //update Button
        private void Update_Click(object sender, EventArgs e)
        {
            //the reason I have all the preparation. if the box is blank it is not happy, and I should use try catch and default to 0. SHOULD
            if (Characters.Count != 0) {
                Characters[UniqueIndex].Name = textBox1.Text;
                Characters[UniqueIndex].DMNotes = richTextBox2.Text;
                try
                {
                    Characters[UniqueIndex].InitMod = Int32.Parse(textBox2.Text);

                }
                catch
                {
                    MessageBox.Show("Init Mod not an int");
                }
                try
                {
                    Characters[UniqueIndex].BaseAC = Int32.Parse(textBox3.Text);

                }
                catch
                {
                    MessageBox.Show("Base AC not an int");
                }
                try
                {
                    Characters[UniqueIndex].TouchAC = Int32.Parse(textBox4.Text);
                }
                catch
                {
                    MessageBox.Show("Touch AC not an int");
                }
                try
                {

                    Characters[UniqueIndex].FlatAC = Int32.Parse(textBox5.Text);
                }
                catch
                {
                    MessageBox.Show("Flat AC not an int");
                }
                try
                {
                    Characters[UniqueIndex].Fort = Int32.Parse(textBox6.Text);
                }
                catch
                {
                    MessageBox.Show("Fort not an int");
                }
                try
                {
                    Characters[UniqueIndex].Reflex = Int32.Parse(textBox7.Text);
                }
                catch
                {
                    MessageBox.Show("Reflex not an int");
                }
                try
                {
                    Characters[UniqueIndex].Will = Int32.Parse(textBox8.Text);
                    Characters[UniqueIndex].Initiative = Int32.Parse(textBox9.Text);
                }
                catch
                {
                    MessageBox.Show("Will not an int");
                }
                try
                {
                    Characters[UniqueIndex].Initiative = Int32.Parse(textBox9.Text);
                }
                catch
                {
                    MessageBox.Show("Initiative not an int");
                }

                Characters.Sort();
                UpdateNames();
            }
        }
        //Block of what was going to be used, but decided against. It isn't happy with them being removed.
        //name
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Init Modifier
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //AC
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //Touch AC
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //Flat footed
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //Fort Save
        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
        //Reflex Save
        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        //Will Save
        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        //Init
        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
        //DM notes
        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        //the part I'm unsure about, right here. First off, i need to make a new form. After that, let;s just start with a label and a textbox
        private void SavePartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saving = true;
            Form2 Loc = new Form2();
            Loc.Show();
            Loc.IHasText += new EventHandler(MakeWayForFile);

        }

        private void LoadPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading = true;
            Form2 Loc = new Form2();
            Loc.Show();
            Loc.IHasText += new EventHandler(MakeWayForFile);
        }

        private void AddPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adding = true;
            Form2 Loc = new Form2();
            Loc.Show();
            Loc.IHasText += new EventHandler(MakeWayForFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void MakeWayForFile(object sender, EventArgs e)
        {
            var TextBoxContents = (TextBox)sender;
            FilePath = TextBoxContents.Text+".bin";
            if (Saving) {
                Saving = false;
                using (Stream stream = File.Open(FilePath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, Characters);
                }
                
            }
            if (Loading) {
                //load will clear the list first, then load the party
                Loading = false;
                try
                {
                    using (Stream stream = File.Open(FilePath, FileMode.Open))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        Characters.Clear();
                        Characters = (List<CharBlock>)bformatter.Deserialize(stream);
                    }
                    Characters.Sort();
                    UpdateNames();
                }
                catch
                {
                    MessageBox.Show("cannot find file(probably):" + FilePath);
                }
               
            }
            if (Adding) {
                //adding creates a temporary list, which is then added to the current list
                Adding = false;
                List<CharBlock> ExtraChars;
                try {
                    using (Stream stream = File.Open(FilePath, FileMode.Open))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


                        ExtraChars = (List<CharBlock>)bformatter.Deserialize(stream);
                        for (int i = 0; i < ExtraChars.Count; i++)
                        {
                            Characters.Add(ExtraChars[i]);
                        }
                        Characters.Sort();
                        UpdateNames();
                    }
                }
                catch {
                    MessageBox.Show("cannot find file(probably): " +FilePath);
                }
                
            }
        }
    }
}
