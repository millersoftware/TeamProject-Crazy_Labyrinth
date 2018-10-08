using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour {
    public static Dictionary<string, float> scoreDic = new Dictionary<string, float>();
    public float timeOf = 0.0f;
    public string sceneName;
    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        scoreDic.Add(sceneName, timeOf);

    }
	
	// Update is called once per frame
	void Update () {
        timeOf = Time.timeSinceLevelLoad;//Tracks time since level has been loaded
        scoreDic[sceneName] = timeOf;
    }
}
