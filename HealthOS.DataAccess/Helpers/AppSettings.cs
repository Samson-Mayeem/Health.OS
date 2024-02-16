namespace HealthOS.DataAccess.Helpers;

public class AppSettings
{
    public string Secret { get; set; }
    public string CloudinaryCloudName { get; set; }
    public string CloudinaryApiKey { get; set; }
    public string CloudinaryApiSecret { get;  set; }
    public string AdminRoleId { get; set; }
    public string SuperAdminRoleId { get; set; }
    public string PatientRoleId { get; set; }
    public string DoctorsRoleId { get; set; }
    public string UsersRoleId { get; set; }
    public string SpecialistRoleId { get; set; }
}