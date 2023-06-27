namespace PRJ.API.JWTs;
public static class JWT
{
    public static string GenerateJwtToken(SessionDTO dto)
    {
        string role = dto.Role;

        var claims = new[]
        {
                new Claim(SessionStrings.UserId, Convert.ToString(dto.UserId)),
                new Claim(SessionStrings.Name, dto.Name),
                new Claim(SessionStrings.RoleId, Convert.ToString(dto.RoleId)),
                new Claim(SessionStrings.Email, dto.Email),
                new Claim(ClaimTypes.Role, role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.JWTkey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
