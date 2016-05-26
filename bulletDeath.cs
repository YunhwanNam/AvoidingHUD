using UnityEngine;
using System.Collections;

public class bulletDeath : MonoBehaviour {

    private float lifeTime;
    private float startTime = 0f;

	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;

        lifeTime = 10f + (startTime / 10f);
        if(startTime > lifeTime)
        {
            Destroy(gameObject, 0.1f);
        }
	}
}
