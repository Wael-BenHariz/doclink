using DocLink.DTOs;
using DocLink.Models;

namespace DocLink.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto request);
        Task<User?> RegisterAsync(UserDto request);
        //Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);

        Task<User?> RegisterPatientAsync(PatientRegisterDto request);
        Task<User?> RegisterDoctorAsync(DoctorRegisterDto request);
    }
}
