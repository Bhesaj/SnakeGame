using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerKeyboard : MonoBehaviour
{
    Rigidbody2D rb;
    TrailRenderer TR;
    public float speed;
    public GameObject Food;
    public GameObject Food1;
    //public GameObject Tail;
    public GameObject Enemy;
    public GameObject Enemy1;
    //public handlerovement handler;
    Vector2 x;
    public bool revert;
    public int score;
    public AudioClip foodsound;
    private AudioSource source;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TR = GetComponent<TrailRenderer>();
        source = GetComponent<AudioSource>();
        score = 0;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 2.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
           rb.velocity = new Vector2(0.0f, -2.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-2.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(2.0f, 0.0f);
        }


    }


    void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.transform.tag == "Enemy")
        {
            SceneManager.LoadScene("EndGame");
        }

        if (hit.transform.tag == "Floor")
        {
            Debug.Log("revert");
            rb.velocity = -rb.velocity;
        }

        if (hit.transform.tag == "Food")
        {
            //Destroy(hit.gameObject);
            Food.transform.position = new Vector2(Random.Range(-6.0f, 1.6f), Random.Range(2.5f, -2.1f));
            Enemy.transform.position = new Vector2(Random.Range(-6.0f, 1.6f), Random.Range(2.5f, -2.1f));
            Food1.transform.position = new Vector2(Random.Range(-6.0f, 1.6f), Random.Range(2.5f, -2.1f));
            Enemy1.transform.position = new Vector2(Random.Range(-6.0f, 1.6f), Random.Range(2.5f, -2.1f));
            source.PlayOneShot(foodsound);
            scoretext.scoreValue += 10;
            PlayerLength();


        }

        void PlayerLength()
        {
            //GameObject newTail= Instantiate(Tail, transform.position, Quaternion.identity);
            TR.time = TR.time + 0.1f;
            score++;

        }
    }

    //void OnTriggerExit2D(Collider2D hit)
    //{
    //   revert = false;
    //}
}
