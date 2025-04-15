using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Camera cam;
    public Vector2 spawnPoint;
    private float distanceToMS;
    public Transform ms;
    public Transform bc;
    public BallControls BC;
    public TextMeshProUGUI Altimiter;
    private double rounded;
    public Transform teleTest;
    void Start ()
    {
        cam = Camera.main;
        spawnPoint = teleTest.transform.position;
    }

    void LateUpdate()
    {

        distanceToMS = (ms.transform.position.y - bc.transform.position.y);
        rounded = Math.Round(distanceToMS);
        Altimiter.text = rounded + "m";
    }
}
