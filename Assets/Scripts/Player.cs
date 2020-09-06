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
    private Collider2D m_Collider;
    public GameManager gameManager;
    private bool isDead = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(!isDead && Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
            wingsSound.Play();
        }
        if(isDead)
        {
            Time.timeScale = 0.8f;
            if(this.transform.position.y <= -0.64)
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Hits a pipe
    {
        if(collision.gameObject.tag != "limit")
        {
            this.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
            m_Collider.enabled = false;
            hitSound.Play();
            isDead = true;  
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) //Scores a point
    {
        int points = 1;
        if(collision.gameObject.tag == "extraPoint"){
            collision.gameObject.SetActive (false);
            points = 2;
        }
        pointSound.Play();
        gameManager.UpdateScore(points);
    }
}
