using MiroClone.Server.BLL.Repositories;
using MiroClone.Server.BLL.RepositoryInterfaces;
using MiroClone.Server.DAL.Data;



namespace MiroClone.Server.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        private IBoardRepository _boardRepository;

        public UnitOfWork(AppDbContext _appDbContext)
        {

            db = _appDbContext;
        }

        public IBoardRepository BoardRepository
        {
            get
            {

                _boardRepository ??= new BoardRepository(db);

                return _boardRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void saveChange()
        {
            db.SaveChanges();
        }
    }
    public interface IUnitOfWork : IDisposable
    {
        public IBoardRepository BoardRepository { get; }
        public void saveChange();
    }
}
