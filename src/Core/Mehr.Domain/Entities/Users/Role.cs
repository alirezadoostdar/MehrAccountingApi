﻿namespace Mehr.Domain.Entities.Users;

public class Role
{
    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
