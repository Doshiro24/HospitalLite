namespace HospitalLite.Core.DTOs
{
    public record TokenDto(string AccessToken, DateTime AccessTokenExpiration, string RefreshToken);
}
