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
        /// 页码
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { get; private set; }

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

        public PaginatedItemsVM(int pageIndex, int pageSize, int count, IEnumerable<TEntity> data, dynamic total = null)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Data = data;
            this.Total = total;
        }
    }
}
