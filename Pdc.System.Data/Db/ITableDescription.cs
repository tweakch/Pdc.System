namespace Pdc.System.Data.Db
{
    public interface ITableDescription
    {
        string TableName { get; set; }
        string Appl { get; set; }
        string Zone { get; set; }
        string Mand { get; set; }
    }
}
