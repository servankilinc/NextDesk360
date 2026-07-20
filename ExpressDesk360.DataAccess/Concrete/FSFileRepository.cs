using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class FSFileRepository : RepositoryBase<FSFile, AppDbContext>, IFSFileRepository
    {
        public FSFileRepository(AppDbContext context) : base(context)
        {
        }
    }
}