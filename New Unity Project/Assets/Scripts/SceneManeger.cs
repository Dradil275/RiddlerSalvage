using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameScene(string name)
    {
        if(name == "START")
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void ExitGame(string name)
    {
        if(name == "EXIT")
        {
            Application.Quit();
        }
    }
}
