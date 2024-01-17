using Microsoft.Extensions.Options;

namespace Health.OS.APi.Security;

public class JwtConfig
{
    public string Secret { get; set; }
}