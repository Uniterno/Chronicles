using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public string password;
    public int InventoryID;
    public string s;
    


    public User(string _username,string _password,string _s)
    {
        this.username = _username;
        this.password = _password;
        this.s = _s;

    }



   
}
public class UserJson
{
    public Dictionary<string, User> Users { set; get; }
}