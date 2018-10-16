using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {
    public static Dictionary<string, float> scoreDic = new Dictionary<string, float>(); // Keeps Track of time for each level
    public static int[] bestScore = new int[] { 0, 0, 0, 0 }; // Keeps track of best score
    public float timeOf = 0.0f; //Time Tracker
    public string sceneName; //Current Scene
    public static string previousScene; //Used in getValues 
    public static int buildIndexScene; //Used to find scene int number for bestScore array
    public GameObject time; //Text
    public GameObject score; //Text
    public GameObject highScore; //Text
    public GameObject newScore;

    /* 
    * This code gathers valuable information and stores it, while also determing the next step of where this code should go.
    * This code is used in each level ONLY, while also pointing to getValues if it's current ScoreScreen
    */
    void Start () {
        //Captures current scene
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        //When in ScoreScreen prevent it from going in dictonary
        if (sceneName.Equals("ScoreScreen"))
        {
            getValues(previousScene);//Calls getvalues method when in score screen
        }
        //Record other information about the scene
        else{
            previousScene = sceneName;
            buildIndexScene = currentScene.buildIndex;
            
        }
        //Create Dictonary entries
        if (! scoreDic.ContainsKey(sceneName)){
            scoreDic.Add(sceneName, timeOf);
        }


    }

    /* 
     * This code is used in levels and keeps track of time completed
     */
    void Update () {
        timeOf = Time.timeSinceLevelLoad;//Tracks time since level has been loaded
        scoreDic[sceneName] = timeOf;
    }
    /* 
     * This code is used to update Text in ScoreScreen
     * This code is used in ScoreScreen ONLY
     * @param scene: Gives scene of level being scored
     */
    void getValues(string scene)
    {
        //Code to Prevent NextLevel at level 3
        if (previousScene.Equals("LVL_3"))
        {
            GameObject.Find("NextLevelButton").SetActive(false);
        }
        else
        {
            GameObject.Find("NextLevelButton").SetActive(true);
        }
        //Code for Time Text
        Text tt = time.GetComponent<Text>();
        tt.text = "Time Acheived: " + (int)scoreDic[scene] + " Seconds";

        //Code for Score Text (also calculates score)
        Text st = score.GetComponent<Text>();
        int theScore = 0;
        if(scoreDic[scene] < 500)
        {
           theScore = 500 - (int)(scoreDic[scene]);

            if (bestScore[buildIndexScene] < theScore)
            {
                if(bestScore[buildIndexScene] != 0)
                {
                    Text nt = newScore.GetComponent<Text>();
                    nt.text = "NEW HIGH SCORE";
                }
                bestScore[buildIndexScene] = theScore;
            }
        }
        st.text = "Score Acheived: " + theScore + "/500";

        //Code for High Score
        Text ht = highScore.GetComponent<Text>();
        ht.text = "Highest: " + bestScore[buildIndexScene] +"/500";

    }
}
