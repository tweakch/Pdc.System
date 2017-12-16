namespace Pdc.System.Data.Db
{
    public abstract class PdcTable : ITable
    {
        protected PdcTable(ITableDescription tableDescription)
        {
            Description = tableDescription;
        }

        public string Name
        {
            get { return Description.TableName; }
            set { Description.TableName = value; }
        }

        public ITableDescription Description { get; }
    }
}