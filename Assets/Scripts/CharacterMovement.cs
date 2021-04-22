using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float speedX, speedForward;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 locVel = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            locVel.x = speedX * Time.deltaTime * (-1);
        else if (Input.GetKey(KeyCode.D))
            locVel.x = speedX * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalk", true);
            locVel.z = speedForward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalk", true);
            locVel.z = speedForward * Time.deltaTime * (-0.5f);
        }
        else
        {
            anim.SetBool("isWalk", false);
            locVel.z = 0;
        }
        transform.position += transform.TransformDirection(locVel);
    }
}
