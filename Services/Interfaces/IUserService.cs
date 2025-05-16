// Services/Interfaces/IUserService.cs
using DocLink.DTOs;
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetDoctorsAsync();
        Task<bool> UpdateAsync(UserUpdateDto userUpdate);
        Task<bool> CompleteDoctorProfileAsync(DoctorProfileDto profile);
        Task<bool> DeleteAsync(int id);
    }
}