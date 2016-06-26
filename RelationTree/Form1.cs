using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelationTree
{
    public partial class Form1 : Form
    {
        Individual root;
        public Form1()
        {
            InitializeComponent();
            root = new Individual();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setTree();
            TreeNode node1 = populate(root);
            node1.Tag = root;
            treeView1.Nodes.Add(node1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Individual node = (Individual) treeView1.SelectedNode.Tag;
            MessageBox.Show(node.getInfo());
            new Details();
        }

        public void setTree()
        {
            Individual narayanan = new Individual("Narayanan", true, "Kallamvelli Illam", null, null, null);
            narayanan.setLast(true);

            Individual narasimhan = new Individual("Hari", true, "Kallamvelli Illam", narayanan, null, null);
            Individual madhavan = new Individual("Madhavan", true, "Kallamvelli Illam", narayanan, null, null);
            Individual sathi = new Individual("Sathi", false, "Kallamvelli Illam", narayanan, null, null);
            Individual sankaran = new Individual("Sankaran", true, "Kallamvelli Illam", narayanan, null, null);
            Individual vamanan = new Individual("Vamanan", true, "Kallamvelli Illam", narayanan, null, null);
            vamanan.setLast(true);
            narayanan.setChildren(new List<Individual> { narasimhan, madhavan, sathi, sankaran, vamanan });

            Individual sreekanth = new Individual("Sreekanth", true, "Kallamvelli Illam", narasimhan, null, null);
            Individual sreeja = new Individual("Sreeja", false, "Kallamvelli Illam", narasimhan, null, null);
            sreeja.setLast(true);
            narasimhan.setChildren(new List<Individual> { sreekanth, sreeja});

            Individual kartika = new Individual("Kartika", false, "Kallamvelli Illam", sathi, null, null);
            Individual manu = new Individual("Manu", true, "Kallamvelli Illam", sathi, null, null);
            manu.setLast(true);
            sathi.setChildren(new List<Individual> { kartika, manu });

            Individual akhil = new Individual("Akhil", true, "Kallamvelli Illam", madhavan, null, null);
            Individual hari = new Individual("Hari", true, "Kallamvelli Illam", madhavan, null, null);
            Individual saranya = new Individual("Saranya", false, "Kallamvelli Illam", madhavan, null, null);
            saranya.setLast(true);
            madhavan.setChildren(new List<Individual> { akhil, hari, saranya });

            Individual kichu = new Individual("Kichu", true, "Kallamvelli Illam", sankaran, null, null);
            Individual achu = new Individual("Achu", true, "Kallamvelli Illam", sankaran, null, null);
            achu.setLast(true);
            sankaran.setChildren(new List<Individual> { kichu, achu });

            Individual udhav = new Individual("Udhav", true, "Kallamvelli Illam", vamanan, null, null);
            udhav.setLast(true);
            vamanan.setChildren(new List<Individual> { udhav });

            root =  narayanan;
        }

        public static TreeNode populate(Individual rootnode)
        {
            TreeNode rootitem, child = null;

            rootitem = new TreeNode(rootnode.getName());
            rootitem.Tag = rootnode;
            rootitem.Collapse(false);

            if (rootnode.getChildren() != null)
            {
                List<Individual> childs = rootnode.getChildren();
                foreach(Individual ch in childs)
                {
                    child = populate(ch);
                    child.Collapse(true);
                    rootitem.Nodes.Add(child);
                }
            }
            return rootitem;
        }
    }
}
