using UnityEngine;

public class CameraFunction : MonoBehaviour
{
        public Transform player;  // Reference to the player GameObject
        public Vector2 yBounds = new Vector2(0f, 10f);  // Y-axis camera bounds
        private Vector3 offset;  // The initial offset between the camera and player
        void Start()
        {
            // Calculate the initial offset
            offsetCheck();
        }
        void LateUpdate()
        {
            if (player == null)
                return;
            // Lock the camera rotation
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            // Follow the player's Y position
            float newY = Mathf.Clamp(player.position.y + offset.y, yBounds.x, yBounds.y);
            Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
            transform.position = newPosition;
        }

        public void offsetCheck()
        {
            offset = transform.position - player.position;
        }
}
