using Data.Contexts;
using Data.Enitties;

namespace Data.Repositories;

public class MemberRepository(DataContext context) : BaseRepository<MemberEntity>(context)
{
}
