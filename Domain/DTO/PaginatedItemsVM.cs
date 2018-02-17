using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    /// <summary>
    /// 分页视图
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PaginatedItemsVM<TEntity> where TEntity : class
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 数据
        /// </summary>

        public IEnumerable<TEntity> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public dynamic Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <param name="data"></param>

        public PaginatedItemsVM(int count, IEnumerable<TEntity> data, dynamic total = null)
        {
            this.Count = count;
            this.Data = data;
            this.Total = total;
        }
    }
}
