using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de User
/// </summary>
public class User
{
    public int id { get; set; }
    public string Username { get; set; }

    public string password { get; set; }


    public User()
    {}

    public User(int id, string username, string password)
    { this.id = id; this.Username = username; this.password = password; }

    public User(string username, string password)
    {this.Username = username; this.password = password; }
}