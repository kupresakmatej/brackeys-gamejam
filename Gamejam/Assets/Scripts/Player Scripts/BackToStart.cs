using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{  
    void Update()
    {
        if(SoulsBar.light_left <= 0)
        {
            SceneManager.UnloadSceneAsync("Level 1");
            SceneManager.LoadScene("Level 1");
        }
    }
}
