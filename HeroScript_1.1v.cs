using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {
    public GameManager manager;
    public GameObject deathParticles;
    public GameObject Hero;

    private float lifeTime = 0.1f;
    private float speed = 4.0f;
    private float zeroBase = 0.5f;
    private float rotSpeed = 150f;
    private float currentTime = 0.0f;

    private Vector3 input;
    private Vector3 spawn;
    
	// Use this for initialization
	void Start () {
        spawn = transform.position;
        manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if(Mathf.Log(1.0f + currentTime, 2) > zeroBase)
        {
            speed += 4.0f;
            zeroBase += 0.5f;
            print(speed);
        }

        float amtToMove = speed * Time.deltaTime;
        float amtToRot = rotSpeed * Time.deltaTime;
        float ang = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * amtToMove);
        transform.Rotate(Vector3.up * ang * amtToRot);

        if(transform.position.y < -1)
        {
            Die();
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Die();
        }

        if(other.transform.tag == "Wall")
        {
            Hero.transform.forward = -Hero.transform.forward;
        }
    }
    
    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
        Destroy(gameObject, lifeTime);
        manager.completed = true;
        manager.showWinScreen = true;
    }
}
