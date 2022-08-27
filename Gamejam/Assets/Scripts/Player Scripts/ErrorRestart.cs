using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorRestart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.UnloadSceneAsync("Level 1");
            SceneManager.LoadScene("Level 1");
        }
    }
}
