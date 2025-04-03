using Data.Contexts;
using Data.Enitties;

namespace Data.Repositories;

public class ClientRepository(DataContext context) : BaseRepository<ClientEntity>(context)
{
}
