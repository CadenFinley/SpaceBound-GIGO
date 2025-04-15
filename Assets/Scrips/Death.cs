using UnityEngine;
public class Death : MonoBehaviour
{
    private GameManager gameManager;
    public BallControls bc;
    private Vector2 startPoint;
    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        startPoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.gameObject.transform.position = new Vector2(gameManager.spawnPoint.x , gameManager.spawnPoint.y+1);
            bc.StopMovement();
            if(bc.transform.position.y < 260) {
                bc.changeGrav(1);
            }
        }
    }

}