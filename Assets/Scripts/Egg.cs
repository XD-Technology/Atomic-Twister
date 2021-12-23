using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    public static float GlobalGravity = -9.8f;
    [SerializeField]
    public float gravityScale = 1.0f;
    private bool isForce = false;

    public float counter;
    //public Vector3 maxVelocity;
    //public Vector3 minVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
        //minVelocity = new Vector3(0, 10000,0);
        //maxVelocity = Vector3.zero;
        counter = -11.133f;
        Time.timeScale = 1.4f;
    }

   /* private void FixedUpdate()
    {
        Vector3 gravity = GlobalGravity * gravityScale * Vector3.up;
        egg.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Force()
    {
        isForce = false;
        egg.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }
    */
    private void Update()
    {

        Vector3 Velocity = rb.velocity;
        if (Velocity.y > 5) rb.velocity = new Vector3(0, 6, 0);

        //if (Velocity.y < minVelocity.y) minVelocity = Velocity;
        //if (Velocity.y > maxVelocity.y) maxVelocity = Velocity;
        //Debug.Log(minVelocity.y +"\n" + maxVelocity.y);

    }

    private void OnCollisionEnter(Collision collision)
    {
        isForce = true;

        if (collision.gameObject.tag == "Red")
        {
            //Restart();
            return;
        }

        if (collision.gameObject.tag == "Green")
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
