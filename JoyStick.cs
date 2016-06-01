using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {

	public void OnMouseDown()
    {
        Debug.Log("Click");
        transform.Rotate(new Vector3(0, 17, 0));
    }
}
