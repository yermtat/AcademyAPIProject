﻿namespace AcademyAPI.Data.Models.Auth;

public class TokenData
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
}
