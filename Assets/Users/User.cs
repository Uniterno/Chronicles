using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string username;
    public string password;


    public User(string _username,string _password)
    {
        this.username = _username;
        this.password = _password;
    }
}
