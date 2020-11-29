using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadNext(); 
    }
    public void LoadNext()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    IEnumerator LoadLevel(int lvlIndex)
    {
        //plays animation
        transition.SetTrigger("Start");

        //Waits
        yield return new WaitForSeconds(transTime);
        //Loads
        SceneManager.LoadScene(lvlIndex);
    }
}
