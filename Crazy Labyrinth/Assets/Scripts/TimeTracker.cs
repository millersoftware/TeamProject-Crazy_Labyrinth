using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {
    public static Dictionary<string, float> scoreDic = new Dictionary<string, float>();
    public float timeOf = 0.0f;
    public string sceneName;
    public static string previousScene;
    public GameObject time;
    public GameObject score;
    public GameObject highScore;

    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName.Equals("ScoreScreen"))
        {
            getValues(previousScene);
        }
        else{
            previousScene = sceneName;
            
        }
        scoreDic.Add(sceneName, timeOf);


    }
	
	// Update is called once per frame
	void Update () {
        timeOf = Time.timeSinceLevelLoad;//Tracks time since level has been loaded
        scoreDic[sceneName] = timeOf;
    }


    void getValues(string scene)
    {
        Text tt = time.GetComponent<Text>();
        tt.text = "Time Acheived: " + (int)scoreDic[scene] + " Seconds";
        Text st = score.GetComponent<Text>();
        int theScore = 0;
        if(scoreDic[scene] < 500)
        {
           theScore = 500 - (int)(scoreDic[scene]);
        }
        st.text = "Score Acheived: " + theScore + "/500";

    }
}
