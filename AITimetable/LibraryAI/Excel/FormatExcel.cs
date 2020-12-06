using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAI.Excel
{
    public class FormatExcel
    {
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }
        public string Sat { get; set; }
        public string Sun { get; set; }

        public FormatExcel()
        {
        }

        public FormatExcel(string mon, string tue, string wed, string thu, string fri, string sat, string sun)
        {
            Mon = mon;
            Tue = tue;
            Wed = wed;
            Thu = thu;
            Fri = fri;
            Sat = sat;
            Sun = sun;
        }

        

    }


}
