using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditWFA
{
    class Day
    {
        //fields
        private string name; // day of week
        private int number; // day in year

        //constructors
        Day()
        {
            this.name = "Monday";
            this.number = 0;
        }
        Day(string name,int number)
        {
            this.name = name;
            this.number = number;
        }

        //methods
        public string getName()
        {
            return this.name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public int getNumber()
        {
            return this.number;
        }
        public void setNumber(int number)
        {
            this.number = number;
        }
    }
}