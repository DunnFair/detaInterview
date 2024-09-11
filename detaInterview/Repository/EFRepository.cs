using detaInterview.Repository.Data;
using detaInterview.Repository.IRepository;

namespace detaInterview.Repository
{
    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public EFRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 新增單筆
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 新增多筆
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 刪除單筆
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            foreach (TEntity item in entities)
            {
                Remove(item);
            }
        }
        /// <summary>
        /// 更新單筆
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// 更新多筆
        /// </summary>
        /// <param name="entities"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (_dbContext == null)
            {
                throw new ArgumentNullException("entity");
            }

            foreach (TEntity item in entities)
            {
                Update(item);
            }
        }
    }
}
