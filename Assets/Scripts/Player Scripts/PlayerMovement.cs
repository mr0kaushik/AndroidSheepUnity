using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float m_MoveSpeed = 3f;
    public float m_SmoothMovement = 15f;

    private Vector3 m_TargetForward;
    private bool m_CanMove;
    private Vector3 m_LocalPosition;



    private Rigidbody m_RigidBody;

    private Camera m_MainCamera;

    void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_MainCamera = Camera.main;
        m_TargetForward = transform.forward;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateForward();
        GetInput();

    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(PlayerHelper.MOUSE_LEFT))
        {
            m_CanMove = true;
        }
        else if (Input.GetMouseButtonUp(PlayerHelper.MOUSE_LEFT))
        {
            m_CanMove = false;
        }
    }

    private void UpdateForward()
    {
        transform.forward = Vector3.Slerp(transform.forward,
         m_TargetForward, Time.deltaTime * m_SmoothMovement);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (m_CanMove)
        {
            m_LocalPosition = new Vector3(Input.GetAxisRaw(PlayerHelper.MOUSE_X),
             0f, Input.GetAxisRaw(PlayerHelper.MOUSE_Y));

            m_LocalPosition.Normalize();

            m_LocalPosition *= m_MoveSpeed * Time.fixedDeltaTime;
            m_LocalPosition = Quaternion.Euler(0f, m_MainCamera.transform.eulerAngles.y, 0f) * m_LocalPosition;

            m_RigidBody.MovePosition(m_RigidBody.position + m_LocalPosition);

            if (m_LocalPosition != Vector3.zero)
            {
                m_TargetForward = Vector3.ProjectOnPlane(-m_LocalPosition, Vector3.up);
            }
        }
    }
}
