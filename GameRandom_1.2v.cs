using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameRandom : MonoBehaviour {
    public Image pfEnemy;
    public MiniMap map;
    public Rigidbody pfBullet;
    public Transform gunEnd;
    
    private float currentTime = 0f;
    private float tempTime = 0f;
    private float bulletDecrease = 0.1f;
    private float bulletFire = 1f;
    private float logNum = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        tempTime += Time.deltaTime;

        if (Mathf.Log(currentTime, 2)> logNum)
        {
            bulletFire -= bulletDecrease;
            logNum += 1.0f;
            bulletDecrease *= 0.9f;
        }

        if(tempTime > bulletFire)
        {
            Image enemyInstance;
            enemyInstance = Instantiate(pfEnemy);
            enemyInstance.transform.parent = map.transform;
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(pfBullet, gunEnd.position, Quaternion.identity) as Rigidbody;
            bulletInstance.AddForce(gunEnd.forward * 1000);
            enemyInstance.GetComponent<Blip>().Target = bulletInstance.transform;

            tempTime = 0.0f;
        }
	}
}