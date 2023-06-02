using EntranceTestCore6.Data;
using EntranceTestCore6.Models;

namespace EntranceTestCore6.Repositories
{
    public interface IMemberRepository
    {
        public Task<List<MemberModel>> GetAllMembersAsync();
        public Task<MemberModel> GetMemberAsync(int id);
        public Task<int> AddMemberAsync(MemberModel model);
        public Task<int> UpdateMemberAsync(int id, MemberModel model);
        public Task DeleteMemberAsync(int id);
    }
}
