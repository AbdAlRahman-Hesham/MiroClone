using MiroClone.Server.BLL.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using MiroClone.Server.DAL.Model;
using MiroClone.Server.DAL.Data;

namespace MiroClone.Server.BLL.Repositories
{
    public class BoardRepository(AppDbContext context) : GenericRepository<Board>(context),IBoardRepository 
    {


      

        
    }
}
