using Data.Contexts;
using Data.Enitties;

namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context)
{
}
