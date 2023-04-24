namespace IdentityCore.Helper
{
    public interface IGenralPurpose
    {
        string GetLogedInUserId();
        bool IsAuthenticated();
    }
}