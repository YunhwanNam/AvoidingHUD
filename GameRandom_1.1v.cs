using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameRandom : MonoBehaviour {
    public Image pfEnemy;
    public MiniMap map;
    public Rigidbody pfBullet;
    public Transform gunEnd;
    
    private float startTime = 0f;
    private int range;
    private float last = 1f;
    private float temp = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;
        if (startTime >= 4f)
        {
            last += 1f;
            startTime = 0.0f - temp;
            temp += 1f;
        }

        range = Random.Range(1, 100);

        if (range <= last)
        {
            Image enemyInstance;
            enemyInstance = Instantiate(pfEnemy);
            enemyInstance.transform.parent = map.transform;
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(pfBullet, gunEnd.position, Quaternion.identity) as Rigidbody;
            bulletInstance.AddForce(gunEnd.forward * 1000);

            enemyInstance.GetComponent<Blip>().Target = bulletInstance.transform;
        }
	}
}