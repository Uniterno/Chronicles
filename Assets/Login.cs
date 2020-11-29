using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Login : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public void LoginOption()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void setGet()
    {

    }
}
