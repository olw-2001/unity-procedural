using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MovementScript movement;

    void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.collider.tag == "Obstacles") {
            movement.enabled = false;
            movement.rgb.drag = 5;
            //movement.rgb.useGravity = false;
            FindObjectOfType<RestartGame>().EndGame();
        }
    }

}
