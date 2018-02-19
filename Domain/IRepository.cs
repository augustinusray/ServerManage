using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// 仓储接口定义
    /// </summary>
    public interface IRepository
    {

    }
    /// <summary>
    /// 定义泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity:class,new()
    {
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllList();

        /// <summary>
        /// 根据lambda表达式条件获取实体集合
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据lambda表达式条件获取单个实体
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<TEntity> Insert(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        void Delete(TEntity entity);



        /// <summary>
        /// 获取实体数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();


        /// <summary>
        /// 事务性保存
        /// </summary>
        Task Save();
    }
}
