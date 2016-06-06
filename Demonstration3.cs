using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Demonstration3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 4 * 3, Screen.height / 6 * 5, Screen.width / 5, Screen.height / 10), "초기 화면으로"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
