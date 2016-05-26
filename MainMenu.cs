using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GUISkin skin;

	void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(10, 10, 400, 75), "고-오급 공피하기");

        if( GUI.Button(new Rect(380, 160, 120, 45), "Play"))
        {
            SceneManager.LoadScene(1);
        }
        if( GUI.Button(new Rect(380, 215, 120, 45), "How to Play"))
        {

        }
        if( GUI.Button(new Rect(380, 270, 120, 45), "Special thanks..."))
        {

        }
        if( GUI.Button(new Rect(380, 325, 120, 45), "End"))
        {
            Application.Quit();
        }
    }
}
