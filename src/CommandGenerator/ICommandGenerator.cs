﻿using Kros.KORM.Metadata;
using Kros.KORM.Query.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace Kros.KORM.CommandGenerator
{
    /// <summary>
    /// Iterface, which describes generating single-table commands that are used to commit changes made to a DbSet
    /// with the associated database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandGenerator<T>
    {
        /// <summary>
        /// Gets the automatically generated DbCommand object required to perform insertions on the database.
        /// </summary>
        /// <returns>Insert command.</returns>
        DbCommand GetInsertCommand();

        /// <summary>
        /// Gets the automatically generated DbCommand object required to perform updates on the database
        /// </summary>
        /// <exception cref="Exceptions.MissingPrimaryKeyException">GetUpdateCommand doesn't supported when entity doesn't have primary key.</exception>
        /// <returns>Update command.</returns>
        DbCommand GetUpdateCommand();

        /// <summary>
        /// Gets the automatically generated DbCommand object required to perform deletions on the database.
        /// </summary>
        /// <exception cref="Exceptions.MissingPrimaryKeyException">GetDeleteCommand doesn't supported when entity doesn't have primary key.</exception>
        /// <returns>Delete command.</returns>
        DbCommand GetDeleteCommand();

        /// <summary>
        /// Gets the automatically generated DbCommands object required to perform deletions on the database.
        /// </summary>
        /// <param name="ids">Items ids to delete.</param>
        /// <exception cref="Exceptions.MissingPrimaryKeyException">GetDeleteCommands doesn't supported when entity doesn't have primary key.</exception>
        /// <exception cref="Exceptions.CompositePrimaryKeyException">Table has composite primary key.</exception>
        /// <returns>Delete command collection.</returns>
        IEnumerable<DbCommand> GetDeleteCommands(IEnumerable ids);

        /// <summary>
        /// Get delete command with specific condition.
        /// </summary>
        /// <param name="whereExpression">Where condition for DELETE statement.</param>
        /// <returns>Delete command.</returns>
        DbCommand GetDeleteCommand(WhereExpression whereExpression);

        /// <summary>
        /// Fills command's parameters with values from <paramref name="item" />.
        /// </summary>
        /// <param name="command">Command which parameters are filled.</param>
        /// <param name="item">Item, from which command is filled.</param>
        /// <exception cref="System.ArgumentNullException">Either <paramref name="command" /> or <paramref name="item" />
        /// is <see langword="null"/>.</exception>
        void FillCommand(DbCommand command, T item);

        /// <summary>
        /// Get columns for query.
        /// </summary>
        IEnumerable<ColumnInfo> GetQueryColumns();

        /// <summary>
        /// Gets value from the specific column.
        /// </summary>
        /// <param name="columnInfo">The specific column.</param>
        /// <param name="item">The item whose value will be returned.</param>
        /// <returns>
        /// Value from the specific column.
        /// </returns>
        object GetColumnValue(ColumnInfo columnInfo, T item);
    }
}
