namespace Schema.Models;

public class User
{
    public int UserId { get; set; }

    public required string Name { get; set; }

    /* navigation properties */
    public required UserNetworkInfo UserNetworkInfo { get; set; }
}
