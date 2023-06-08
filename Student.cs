using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_FirstProject
{
    struct Student // struct created for student
    {
        public int studentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public char grade { get; set; }
        public MonthOfAdmission monthAdmitted { get; set; }
    }

    enum MonthOfAdmission // enum for month of admission
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
