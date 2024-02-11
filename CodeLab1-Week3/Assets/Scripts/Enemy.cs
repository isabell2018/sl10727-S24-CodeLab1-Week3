using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    
    private Rigidbody rb;
    public float t = 0.125f;//speed of the enemy
    public GameObject gameOver;
    public TextMeshProUGUI GameOverText;
    public GameObject score;
    public float scorenumber;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        
        //make enemy move towards the player
        Vector3 newp = Vector3.MoveTowards(rb.transform.position, player.transform.position,t);
        rb.transform.position = new Vector3(newp.x,newp.y, newp.z);
        
        //
    }

    private void OnCollisionEnter(Collision other)
    {
        //if collide with player, game over
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.activeSelf)
            {
                Debug.Log("Game Over");
                player.SetActive(false);
                score.SetActive(false);
                gameOver.SetActive(true);
                GameOverText.text = "Game Over! Score: " +
                                    Manager.instance.Score +
                                    "\nHigh Score: " +
                                    Manager.instance.HighScore;
            }
        }
    }
}
