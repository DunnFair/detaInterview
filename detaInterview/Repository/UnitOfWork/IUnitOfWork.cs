using detaInterview.Repository.IRepository;

namespace detaInterview.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEFRepository<T> Repository<T>() where T : class;
    }
}
