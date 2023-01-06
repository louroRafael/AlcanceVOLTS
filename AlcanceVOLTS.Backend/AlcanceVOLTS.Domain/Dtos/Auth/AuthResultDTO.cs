﻿namespace AlcanceVOLTS.Domain.Dtos.Auth
{
    public class AuthResultDTO
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}