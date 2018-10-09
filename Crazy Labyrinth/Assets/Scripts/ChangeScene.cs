using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* This class is only used for buttons to change scenes
*/

public class ChangeScene : MonoBehaviour {
    public static int current = 1;
    public void Change(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeToNextLevel()
    {
        current += 1;
        SceneManager.LoadScene(current);
    }
    public void KeepLevel()
    {
        SceneManager.LoadScene(current);
    }
}
