using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GUISkin skin;
    public Texture2D exam1;

    void Start()
    {
        exam1 = (Texture2D)Resources.Load("설명1");
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 3, Screen.height / 5, Screen.width / 2, Screen.height / 8), "고-오급 공피하기");

        if( GUI.Button(new Rect(Screen.width / 4, Screen.height / 5 * 2, Screen.width / 2, Screen.height / 10), "Play"))
        {
            SceneManager.LoadScene(1);
        }
        if( GUI.Button(new Rect(Screen.width / 4, Screen.height / 30 * 17, Screen.width / 2, Screen.height / 10), "How to Play"))
        {
            SceneManager.LoadScene(2);
        }
        if( GUI.Button(new Rect(Screen.width / 4, Screen.height / 15 * 11, Screen.width / 2, Screen.height / 10), "Quit"))
        {
            Application.Quit();
        }
    }
}
