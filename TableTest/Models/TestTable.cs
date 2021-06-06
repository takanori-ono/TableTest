using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTest.Models
{
    public class TestTable
    {
        //TableTest.table_test
        public int No { get; set; }
        public int Flag { get; set; }
        public string Name { get; set; }
        public DateTime? UpDate { get; set; }
        public bool Selection { get; set; }
    }

    public class TestTableList : List<TestTable>
    {
        public int TabID { get; set; }

        public void Build(webtestEntities db)
        {
            foreach(var elm in db.table_test)
            {
                Add(new TestTable
                {
                    No = elm.no,
                    Flag = elm.flag,
                    Name = elm.name,
                    UpDate = elm.dt,
                    Selection = false,
                });

            }
        }
    }
}