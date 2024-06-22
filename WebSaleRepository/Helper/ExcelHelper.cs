using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using WebSaleRepository.Models;

namespace WebSaleRepository.Helper
{
    public static class ExcelHelper
    {
        public static List<EmailModel> FeatchEmailFromExcelFile(Stream fileStream)
        {
            List<EmailModel> emailsInfo = new List<EmailModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(fileStream);

            ExcelWorksheet workSheet = package.Workbook.Worksheets[0]; // doc sheet dau tien
            int rowCount = workSheet.Dimension.Rows; // lay ra so luong dong trong sheet
            for (int row = 2; row <= rowCount; row++) // doc tu dong thu 2 boi vi dong 1 thuong la tieu de
            {
                string toEmail = workSheet.Cells[row, 1].Text; // doc cot 1
                string subject = workSheet.Cells[row, 2].Text; // doc cot 2
                string content = workSheet.Cells[row, 3].Text; // doc cot 3
                if (!string.IsNullOrEmpty(toEmail))
                {
                    emailsInfo.Add(new EmailModel
                    {
                        ToEmail = toEmail,
                        Subject = subject,
                        Content = content
                    });
                }
            }
            return emailsInfo;
        }
    }
}
