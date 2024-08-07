namespace BackEndTask.Application.JwtSettings;

public class JwtToken
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Expires { get; set; }
}