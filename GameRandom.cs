using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameRandom : MonoBehaviour {
    public Image pfEnemy;
    public MiniMap map;
    public Rigidbody pfBullet;
    public Transform gunEnd;

    private int randomNumber = 100;
    private float startTime = 0f;
    private int range;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;
        if (startTime / 4.0 == 0.0)
            randomNumber--;
        range = Random.Range(1, randomNumber);

        if(range == 1)
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