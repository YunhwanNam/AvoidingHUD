using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Count
    private float currentScore = 0f;
    private int totalScore;

    //Timer variables
    public Rect timerRect;
    private float startTime = 0f;
    private string currentTime;
    private string showScore;
    public Rect scoreRect;

    //GUI SKIN
    public GUISkin skin;

    public bool completed = false;
    public bool showWinScreen = false;
    public int winScreenWidth, winScreenHeight;

    void Start()
    {
    }

    void Update()
    {
        if (!completed)
        {
            startTime += Time.deltaTime;
            currentTime = string.Format("Time : {0:0.0}", startTime);
            currentScore += startTime * Time.deltaTime * 30;
            totalScore = (int)currentScore;
            showScore = string.Format("Score : {00000}", totalScore);
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(timerRect, currentTime);
        GUI.Label(scoreRect, showScore);

        if (showWinScreen)
        {
            Rect winScreenRect = new Rect(Screen.width / 2 - (winScreenWidth/2), Screen.height / 2 - (winScreenHeight/2), Screen.width *.5f, Screen.height *.5f);
            GUI.Box(winScreenRect, "Game Over");
            
            if(GUI.Button(new Rect(winScreenRect.x + winScreenRect.width - 170, winScreenRect.y + winScreenRect.height - 60, 150, 40), "Continue?"))
            {
                SceneManager.LoadScene(1);
            }
            if(GUI.Button(new Rect(winScreenRect.x + 20, winScreenRect.y + winScreenRect.height - 60, 100, 40), "Quit"))
            {
                SceneManager.LoadScene(0);
            }

            GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 280, 50), "Score : " + currentScore.ToString());
        }
    }
}