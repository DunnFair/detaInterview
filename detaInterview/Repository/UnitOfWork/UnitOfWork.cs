using detaInterview.Repository.Data;
using detaInterview.Repository.IRepository;
using System.Collections;

namespace detaInterview.Repository.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEFRepository<T> Repository<T>() where T : class
        {
            //Hashtable容器初始化
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            //獲取傳入Class的名稱
            string name = typeof(T).Name;
            //如果_repositories 沒有包含傳入的Class Name那就創建一個實例
            if (!_repositories.ContainsKey(name))
            {
                Type typeFromHandle = typeof(EFRepository<>);
                object value = Activator.CreateInstance(typeFromHandle.MakeGenericType(typeof(T)), _dbContext);
                _repositories.Add(name, value);
            }

            return (IEFRepository<T>)_repositories[name];
        }
    }
}
