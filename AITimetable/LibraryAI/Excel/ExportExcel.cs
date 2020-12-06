using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryAI.Excel
{
    public class ExportExcel : FormatExcel
    {
        public string FilePath { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public ExcelPackage exl;
        public List<Subjects> lstSubjects { get; set; }
        public List<Class> lstClasses { get; set; }

        public ExportExcel() { }
        public ExportExcel(string filePath, List<Subjects> lstS, List<Class> lstC) 
        {
            FilePath = filePath;
            Author = "USTeam By FS";
            Title = "Thời khóa biểu";
            lstSubjects = lstS;
            lstClasses = lstC;
        }
        public void ExportFile()
        {
            try
            {
                using (exl = new ExcelPackage())
                {
                    exl.Workbook.Properties.Author = Author;
                    exl.Workbook.Properties.Title = Title;

                    foreach (Class c in lstClasses)
                    {
                        ExportSheet(c);
                    }


                    byte[] bin = exl.GetAsByteArray();

                    File.WriteAllBytes(FilePath, bin);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ExportSheet(Class c)
        {
            exl.Workbook.Worksheets.Add(c.Name);

            ExcelWorksheet sheet = exl.Workbook.Worksheets[c.Name];

            sheet.Name = c.Name;
            sheet.Cells.Style.Font.Size = 12;
            sheet.Cells.Style.Font.Name = "Time New Roman";

            #region tạo bảng

            //Column Header
            string[] colHeader = new string[] { "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật" };
            int colIndex = 2;
            int rowIndex = 1;

            foreach (string cName in colHeader)
            {
                var cell = sheet.Cells[rowIndex, colIndex];

                cell.Value = cName;
                colIndex++;

                //set màu thành gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                //căn chỉnh các border
                var border = cell.Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = ExcelBorderStyle.Thin;
            }


            //Row Header
            colIndex = 1;
            rowIndex = 2;

            for (int i = 0; i < 10; i++)
            {
                var cell = sheet.Cells[rowIndex + i, colIndex];

                cell.Value = "Tiết " + (i + 1);

                var border = cell.Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = ExcelBorderStyle.Thin;
            }


            #endregion


            #region Nhập data

            rowIndex = 2;
            colIndex = 2;

            for (int i = 0; i < c.TimetableClass.Length; i++)
            {
                for (int j = 0; j < c.TimetableClass[i].Length; j++)
                {
                    var cell = sheet.Cells[rowIndex + j, colIndex + i];
                    cell.Value = GetNameSub(c.TimetableClass[i][j]);

                    var border = cell.Style.Border;
                    border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;
                }
            }

            #endregion
        }

        private string GetNameSub(int IDSub)
        {
            switch (IDSub)
            {
                case 0:
                case -1:
                    return "";
                case -99:
                    return "Chào Cờ";
                case -98:
                    return "SHL";
                default:
                    return lstSubjects.FirstOrDefault(c => c.ID == IDSub).Name;
            }
        }
    }
}
