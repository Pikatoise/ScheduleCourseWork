using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ScheduleCourseWork
{
    public static class TableGenerator
    {
        public static Table Generate()
        {
            Table table = new Table();

            TableRow tr = new TableRow();

            TableCell tc1 = new TableCell();

            tc1.Append(new Paragraph(new Run(new Text("some text"))));

            tr.Append(tc1);

            table.Append(tr);

            return table;
        }
    }
}