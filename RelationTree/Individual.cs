using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationTree
{
    public class Individual
    {
        private String name;
        private bool genderMale;
        private Individual parent;
        private List<Individual> children;
        private Individual spouse;
        private String illam;
        private bool islast = false;

        public Individual(String name, bool genderMale, String illam, Individual parent, Individual spouse, List<Individual> children)
        {
            this.name = name;
            this.genderMale = genderMale;
            this.illam = illam;
            this.parent = parent;
            this.children = children;
            this.spouse = spouse;
        }

        public Individual()
        {
            this.name = "";
            this.genderMale = true;
            this.illam = "";
            this.parent = null;
            this.spouse = null;
            this.children = new List<Individual>();
        }

        public String getIllam()
        {
            return illam;
        }

        public void setIllam(String illam)
        {
            this.illam = illam;
        }

        public bool isLast()
        {
            return islast;
        }

        public void setLast(bool isLast)
        {
            this.islast = isLast;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public bool isGenderMale()
        {
            return genderMale;
        }

        public void setGenderMale(bool genderMale)
        {
            this.genderMale = genderMale;
        }

        public Individual getParent()
        {
            return parent;
        }

        public void setParent(Individual parent)
        {
            this.parent = parent;
        }

        public List<Individual> getChildren()
        {
            return children;
        }

        public void setChildren(List<Individual> children)
        {
            this.children = children;
        }

        public void addChildren(Individual[] children)
        {
            foreach (Individual y in children)
                addChildren(y);
        }

        public void removeChild(Individual child)
        {
            List<Individual> existing = getChildren();
            setChildren(null);
            foreach (Individual y in existing)
            {
                if (y != child)
                    addChildren(y);
            }
        }

        public void addChildren(Individual child)
        {
            children.Add(child);
        }

        public String toString()
        {
            return this.name;
        }

        public Individual getSpouse()
        {
            return spouse;
        }

        public void setSpouse(Individual spouse)
        {
            this.spouse = spouse;
        }

        public Individual getRoot()
        {
            if (parent == null)
                return this;
            else
                return parent.getRoot();
        }

        public String getInfo()
        {
            String info = "Name : " + name;
            info += "\nIllam : " + illam;
            info += "\nGender : " + (genderMale ? "Male" : "Female");
            info += "\nParent : " + (parent == null ? "NA" : parent.toString());
            info += "\nChildren : " + (children == null ? "Nil" : String.Join(",", children));
            info += "\n" + (genderMale ? "Wife" : "Husband") + " : " + (spouse == null ? "Nil" : spouse.toString());
            info += "\nRoot : " + getRoot().toString();
            return info;
        }
    }
}
