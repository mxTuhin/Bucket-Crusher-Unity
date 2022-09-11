using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySystems : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene("_Scenes/"+_sceneName);
    }

}
