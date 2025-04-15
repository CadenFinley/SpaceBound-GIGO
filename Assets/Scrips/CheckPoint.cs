using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource sound;
    private bool collected=false;
    void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (!collected)
            {
                sound.Play();
                gameManager.spawnPoint = transform.position;
                collected = true;
            } 
        }
    }
}