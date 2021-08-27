namespace Followers.Model.Clients.Dto
{
    /// <summary>
    /// Client's dto information 
    /// </summary>
    /// <param name="Id">Client's identifier</param>
    /// <param name="Name">Client's name</param>
    /// <param name="Followers">Followers quantity</param>
    /// <param name="IsActive">Is deleted></param>
    public record ClientData(int Id, string Name, int Followers, bool IsActive);
}
