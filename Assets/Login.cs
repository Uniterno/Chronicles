using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
public class Login : MonoBehaviour
{
    //public string filepath = "Assets\\StreamingAssets\\UserDatabase.json";
    public UserJson deserialized;
    public string username;
    public string password;
    public GameObject UserField;
    public GameObject PassField;
    
    public void Start()
    {

        loadJson(Application.streamingAssetsPath + "\\UserDatabase.json");

    }




    public void LoginOption()
    {

        username = UserField.GetComponent<InputField>().text;
        password = PassField.GetComponent<InputField>().text;
        User us = new User(null,null,null);




        if (deserialized.Users.TryGetValue(username, out us))
         {
             if (hash(password,us.s) == us.password) {
                 SceneManager.LoadScene("MainMenu");
             }

             else
             {
                 Debug.Log("bad password");
             }

             Debug.Log("user exists");
         }

        Debug.Log(username);
        Debug.Log(password);
        

    }

    public void loadJson(string file)
    {
       string _file = File.ReadAllText(file);
        deserialized = JsonConvert.DeserializeObject<UserJson>(_file);
    }

    public string hash(string password, string salt)
    {
        byte[] npsw = System.Text.Encoding.UTF8.GetBytes(password);
        byte[] saltV = System.Text.Encoding.UTF8.GetBytes(salt);
        var hashedPsw = new Rfc2898DeriveBytes(npsw, saltV, 10000);
        return System.Convert.ToBase64String(hashedPsw.GetBytes(24));
    }

    public string salt()
    {
        var b = new byte[128 / 8];
        var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(b);
        return System.Convert.ToBase64String(b);
    }
    public void test()
    {
        Debug.Log("hi");
    }

}
