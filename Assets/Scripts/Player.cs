using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //sounds
    public AudioSource wingsSound;
    public AudioSource pointSound;
    public AudioSource hitSound;

    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;
    public GameManager gameManager;
    public bool isDead = false;
    public Text score;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
            wingsSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Hits a pipe
    {
        hitSound.Play();
        isDead = true;
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision) //Scores a point
    {
        /*scoreValue++;
        if (score != null) { 
            score.text = scoreValue.ToString();
        }*/
        pointSound.Play();
        gameManager.UpdateScore();
    }
}
