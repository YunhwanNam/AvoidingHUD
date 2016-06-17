using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Timer variables
    private float startTime = 0f;
    private string currentTime;
    private Rect timerRect = new Rect(Screen.width / 30, Screen.height / 20, Screen.width / 4, Screen.height / 8);

    // Score variables
    private float currentScore = 0f;
    private int totalScore;
    private string showScore;
    private Rect scoreRect = new Rect(Screen.width / 7 * 5, Screen.height / 20, Screen.width / 3, Screen.height / 8);

    //GUI SKIN
    public GUISkin skin;

    //충돌판정 boolean 값
    public bool completed = false;
    public bool showWinScreen = false;

    //일시정지 boolean 값
    public bool paused;

    void Start()
    {
        paused = false;
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

        if (GUI.Button(new Rect(Screen.width / 4 * 3, Screen.height / 10, Screen.width / 15, Screen.height / 15), "Pause"))
        {
            paused = !paused;
            if (paused)
                Time.timeScale = 0;
            else if (!paused)
                Time.timeScale = 1;
        }

        if (showWinScreen)
        {
            Rect winScreenRect = new Rect(Screen.width / 4, Screen.height / 4, Screen.width *.5f, Screen.height *.5f);
            GUI.Box(winScreenRect, "Game Over");
            
            if(GUI.Button(new Rect(winScreenRect.x + (winScreenRect.width / 5 * 3), winScreenRect.y + (winScreenRect.height / 3 * 2), winScreenRect.width / 3, winScreenRect.height / 4), "Continue?"))
            {
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }

            if(GUI.Button(new Rect(winScreenRect.x + (winScreenRect.width / 10), winScreenRect.y + (winScreenRect.height / 3 * 2), winScreenRect.width / 4, winScreenRect.height / 4), "Quit"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }

            GUI.Label(new Rect(winScreenRect.x + (winScreenRect.width / 8), winScreenRect.y + (winScreenRect.height / 10), winScreenRect.width / 4 * 3, winScreenRect.height / 5 * 2), showScore);
        }
    }
}