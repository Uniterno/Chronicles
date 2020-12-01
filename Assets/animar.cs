using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class animar : MonoBehaviour
{
    float waitTime = 0.0f;
    public Texture2D[] frames;
    public int fps = 10;
    GameObject loadingScreen;

    void Start()
    {
        loadingScreen = GameObject.Find("background");
    }
    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];
        waitTime += Time.deltaTime;
        if(waitTime >= 10)
        {
            MatchStart();
        }
        
    }

    void MatchLoad()
    {

    }

    public void MatchStart()
    {
        loadingScreen.SetActive(false);

    }
}
