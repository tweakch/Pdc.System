namespace Pdc.System.Data.Db
{
    public interface ITable
    {
        string Name { get; set; }
        ITableDescription Description { get; }
    }
}