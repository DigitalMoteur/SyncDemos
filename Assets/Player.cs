using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_rigidbody = null;

    // The rate in meters per second at which the player will accelerate when moving
    [SerializeField] private float m_accelerationRate = 10.0f;
    // The rate in degrees per second that we want the player to turn while turning
    [SerializeField] private float m_turnRate = 10.0f; 

    [SerializeField] private KeyCode m_forward;
    [SerializeField] private KeyCode m_backward;
    [SerializeField] private KeyCode m_turnRight;
    [SerializeField] private KeyCode m_turnLeft;


    // Use this for initialization
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        if (m_rigidbody == null)
        {
            Debug.LogError("We don't have a rigidbody on the player, but we're expecting one!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check that the rigidbody has been properly set before we operate on it!
        if (m_rigidbody)
        {
            // Calculate how much we want to accelerate this frame
            Vector3 movementDirection = Vector3.zero;
            if (Input.GetKey(m_forward))
            {
                movementDirection += transform.forward;
            }
            if (Input.GetKey(m_backward))
            {
                movementDirection -= transform.forward;
            }
            Vector3 acceleration = movementDirection * (Time.deltaTime * m_accelerationRate);

            // Calculate how much we want to turn this frame
            float deltaTurn = m_turnRate * Time.deltaTime;
            Vector3 rotation = Vector3.zero;
            if (Input.GetKey(m_turnRight))
            {
                rotation.y += deltaTurn * -1;
            }
            if (Input.GetKey(m_turnLeft))
            {
                rotation.y += deltaTurn;
            }

            // Apply our acceleration and rotation!
            m_rigidbody.velocity += acceleration;
            m_rigidbody.angularVelocity += rotation;
        }
    }
}