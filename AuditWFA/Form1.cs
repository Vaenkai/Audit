using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Schedule sc = new Schedule();
            
            Table.RowHeadersVisible = false;
            Table.Rows.Add(7);
        }
    }
}