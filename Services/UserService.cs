// Services/UserService.cs
using DocLink.Data;
using DocLink.DTOs;
using DocLink.Models;
using DocLink.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocLink.Services
{
    public class UserService(UserDbContext context) : IUserService
    {
        public async Task<bool> CompleteDoctorProfileAsync(DoctorProfileDto profile)
        {
            var user = await context.Users.FindAsync(profile.Id);
            if (user is null || user.Role != UserRole.Doctor)
                return false;

            user.Speciality = profile.Speciality;
            user.Description = profile.Description;
            user.Diploma = profile.Diploma;
            user.ProfilePhotoUrl = profile.ProfilePhotoUrl;
            user.IsProfileComplete = true;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
                return false;

            context.Users.Remove(user);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetDoctorsAsync()
        {
            return await context.Users
                .Where(u => u.Role == UserRole.Doctor)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(UserUpdateDto userUpdate)
        {
            var user = await context.Users.FindAsync(userUpdate.Id);
            if (user is null)
                return false;

            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;
            user.PhoneNumber = userUpdate.PhoneNumber;
            user.Email = userUpdate.Email;

            return await context.SaveChangesAsync() > 0;
        }
    }
}