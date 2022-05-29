using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody rgb;
    //Vector3 m_EulerAngleVelocity;

    public MovementScript movement;
    public float forwardMomentum = 2000f;
    public float sidewaysMomentum = 500f;

    /*void Start() {
        m_EulerAngleVelocity = new Vector3(0, 0, 500);

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        rgb.MoveRotation(rgb.rotation * deltaRotation);
    }*/

    void FixedUpdate() {
        rgb.AddForce(0, 0, forwardMomentum * Time.deltaTime);

        if(Input.GetKey("d")) {
            rgb.AddForce(sidewaysMomentum * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }    

        if(Input.GetKey("a")) {
            rgb.AddForce(-sidewaysMomentum * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rgb.position.y < -1f) {
            FindObjectOfType<RestartGame>().EndGame();
            movement.enabled = false;
            movement.rgb.drag = 10;
        }
        else if(rgb.position.y > 60.0f) {
            FindObjectOfType<RestartGame>().EndGame();
            movement.enabled = false;
            movement.rgb.drag = 10;
        }
    }
}