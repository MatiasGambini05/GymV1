using GymV1.ModelsContextDTOs.DTOs;

namespace GymV1.Services.Interfaces
{
    public interface IAuthService
    {
        bool IsEmptyFieldSignup(NewUserDTO newUserDTO);
        bool LoginCheck(LoginDTO loginDTO);
        Task<AuthResponseDTO> Login(LoginDTO loginDTO);
    }
}
