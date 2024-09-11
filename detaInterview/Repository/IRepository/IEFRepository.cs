namespace detaInterview.Repository.IRepository
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 新增單筆
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 移除單筆
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        /// <summary>
        /// 更新單筆
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
    }
}
