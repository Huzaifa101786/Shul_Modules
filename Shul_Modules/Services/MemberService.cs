using Microsoft.EntityFrameworkCore;
using Shul_Modules.Data;
using Shul_Modules.Models;

namespace Shul_Modules.Services
{
    public class MemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all members
        public async Task<List<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        // Add a new member
        public async Task AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        // Update an existing member
        public async Task UpdateMemberAsync(Member member)
        {
            /*_context.Members.Update(member);
            await _context.SaveChangesAsync();*/
            var existingMember = await _context.Members.FindAsync(member.MemberId);
            if (existingMember != null)
            {
                // Update the properties of the existingMember with the new values
                _context.Entry(existingMember).CurrentValues.SetValues(member);

                // Save the changes
                await _context.SaveChangesAsync();
            }

        }

        // Delete a member
        public async Task DeleteMemberAsync(int memberId)
        {
            var member = await _context.Members.FindAsync(memberId);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        // Get a single member by ID
        public async Task<Member?> GetMemberByIdAsync(int memberId)
        {
            return await _context.Members.FindAsync(memberId);
        }
    }
}
