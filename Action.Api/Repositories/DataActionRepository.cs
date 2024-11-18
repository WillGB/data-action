using Action.Api.Models;
using Action.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Action.Api.Repositories {
    public class DataActionRepository : Repository<DataAction>, IDataActionRepository
    {

        public DataActionRepository(DbContext context) : base(context) { }
    }
}