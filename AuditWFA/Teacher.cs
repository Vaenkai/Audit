using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditWFA
{
    class Teacher
    {
        //fields
        private string name;
        private string surname;
        private string lastName;
        private List<Subject> subjects;

        //constructors 
        public Teacher()
        {
            this.name = "";
            this.surname = "";
            this.lastName = "";
            this.subjects = new List<Subject>();
        }
        public Teacher(string name, string surname,string lastname,List<Subject> subjects)
        {
            this.name = name;
            this.surname = surname;
            this.lastName = lastname;
            this.subjects = subjects;
        }

        //getters/setters
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public string getSurname()
        {
           return this.surname;
        }
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public void setSubjects(List<Subject> subjects)
        {
            this.subjects = subjects;
        }
        public List <Subject> getSubjects()
        {
            return subjects;
        }

        //methods
        public override string ToString()
        {
            return this.name+",";
        }

        //возвращаем список предметов одной строкой
        public string SubjectsToString()
        {
            string tmp = "";
            foreach(Subject subject in subjects)
            {
                tmp += subject.ToString();
            }
            return tmp;
        }
    }
}
