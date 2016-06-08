using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {
    public GameManager manager;
    public GameObject deathParticles;
    public GameObject Hero;

    private float lifeTime = 0.1f;
    private float speed = 4.0f;
    private float zeroBase = 0.5f;
    private float currentTime = 0.0f;

    private Vector3 input;
    private Vector3 spawn;

    void Start()
    {
        spawn = transform.position;
        manager = manager.GetComponent<GameManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (Mathf.Log(1.0f + currentTime, 2) > zeroBase)
        {
            speed += 4.0f;
            zeroBase += 0.5f;
        }

        float amtToMove = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amtToMove);
        if (transform.position.y < -1)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }

        if (other.transform.tag == "Wall1")
        {
            Hero.transform.forward = new Vector3(Hero.transform.forward.x, Hero.transform.forward.y, -Hero.transform.forward.z);
        }

        if(other.transform.tag == "Wall2")
        {
            Hero.transform.forward = new Vector3(-Hero.transform.forward.x, Hero.transform.forward.y, Hero.transform.forward.z);
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
