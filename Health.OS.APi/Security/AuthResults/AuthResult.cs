namespace Health.OS.APi.Security.AuthResults;

public class AuthResult
{
    public string ResultToken { get; set; } = string.Empty;
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
}