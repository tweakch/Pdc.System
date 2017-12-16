using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Pdc.System.Data.Extensions
{
    public static class DbSetExtensions
    {
        /// <summary>
        ///     Creates a DataTable from a <see cref="DbSet{TEntity}" />.
        ///     <para>
        ///         The <see cref="DataTable" /> will have a column for every property of
        ///         <typeparam name="TEntity">TEntity</typeparam>
        ///     </para>
        /// </summary>
        /// <typeparam name="TEntity">The type the <see cref="DataTable"/> will represent as a table.</typeparam>
        /// <param name="set"></param>
        /// <param name="cleanUp">Cleanup hook to manipulate the <see cref="DataTable"/> before it is being returned.</param>
        /// <returns><see cref="DataTable" /> with a column for every property of TEntity</returns>
        public static DataTable ToDataTable<TEntity>(this DbSet<TEntity> set,
            Func<DataTable, DataTable> cleanUp = null) where TEntity : class
        {
            Func<TEntity, JObject> viewSelector = JObject.FromObject;
            return ToDataTable(set, viewSelector, cleanUp);
        }

        /// <summary>
        ///     Creates a DataTable from a <see cref="DbSet{TEntity}" />.
        ///     <para> 
        ///         The <see cref="DataTable" /> will have a column for every property that the viewSelector returns.
        ///     </para>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="set"></param>
        /// <param name="viewSelector"></param>
        /// <param name="cleanUp"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<TEntity>(this DbSet<TEntity> set, Func<TEntity, JObject> viewSelector,
            Func<DataTable, DataTable> cleanUp = null) where TEntity : class
        {
            var dataTable = CreateDataTable(set, viewSelector);
            InsertRows(set, dataTable, viewSelector);
            return cleanUp == null ? dataTable : cleanUp(dataTable);
        }

        private static DataTable CreateDataTable<TEntitiy>(DbSet<TEntitiy> set, Func<TEntitiy, JObject> selector)
            where TEntitiy : class
        {
            var dataTable = new DataTable();
            foreach (var entity in set)
            {
                var o = selector(entity);
                AddHeader(o, dataTable);
            }
            return dataTable;
        }

        private static void InsertRows<TEntity>(DbSet<TEntity> dbSet, DataTable dataTable,
            Func<TEntity, JObject> viewSelector) where TEntity : class
        {
            foreach (var entity in dbSet)
            {
                var row = dataTable.NewRow();

                foreach (var property in viewSelector(entity).Properties())
                {
                    row[property.Name] = property.Value;
                }

                dataTable.Rows.Add(row);
            }
        }

        private static void AddHeader(JObject o, DataTable dataTable)
        {
            foreach (
                var propertyName in o.Properties().Select(p => p.Name).Where(name => !dataTable.Columns.Contains(name)))
            {
                var column = dataTable.Columns.Add(propertyName);
                column.DataType = typeof (string);
                //column.MaxLength = 255;
            }
        }
    }
}