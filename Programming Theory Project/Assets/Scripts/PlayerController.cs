using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField]
    private float m_speed = 600;
    public float speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    [SerializeField]
    private float m_jumpPower = 5;
    public float jumpPower
    {
        get { return m_jumpPower; }
        set
        {
            if (value >= 0)
            {
                m_jumpPower = value;
            }
        }
    }

    [SerializeField]
    private Color m_color = Color.white;
    public Color color
    {
        get { return m_color; }
        set { m_color = value; }
    }


    protected float m_verticalInput;
    protected float m_horizontalInput;
    protected bool m_isJumping;
    protected Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
        DisplayInfo();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && !m_isJumping)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchPower();
        }
    }

    // ABSTRACTION
    void Move()
    {
        m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_rigidbody.AddForce(Vector3.forward * m_verticalInput * Time.deltaTime * speed);
        m_rigidbody.AddForce(Vector3.right * m_horizontalInput * Time.deltaTime * speed);
    }

    // ABSTRACTION
    protected virtual void Jump()
    {
        m_rigidbody.AddForce(Vector3.up* jumpPower, ForceMode.Impulse);
        m_isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isJumping = false;
        }
    }

    protected virtual void DisplayInfo()
    {
    }

    protected virtual void SwitchPower()
    {
        gameObject.AddComponent<RedRuner>();
        Destroy(GetComponent<PlayerController>());
    }
}
