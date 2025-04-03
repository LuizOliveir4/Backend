using Data.Repositories;
using Domain.Models;

namespace Business.Services;

public class MemberService(MemberRepository userRepository)
{
    private readonly MemberRepository _userRepository = userRepository;

    public async Task<IEnumerable<Member>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        var users = entities.Select(e => new Member
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName
        });
        return users;
    }
}
