﻿namespace Pdc.System.Data.Db
{
    public class PdcTable : ITable
    {

        public PdcTable()
        {
            Name = "Test";
        }

        public string Name{ get; set; }
    }

    public interface ITable
    {
        string Name { get; set; }
    }
}
