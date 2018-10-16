using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* This class is only used for buttons to change scenes
*/
public class ChangeScene : MonoBehaviour {
    public static int CURRENT = 1;
    public void Change(string scene) // Start Button
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeToNextLevel() // Next Level Button
    {
        CURRENT += 1;
        SceneManager.LoadScene(CURRENT);
    }
    public void KeepLevel() //Current Level Button
    {
        SceneManager.LoadScene(CURRENT);
    }
}
