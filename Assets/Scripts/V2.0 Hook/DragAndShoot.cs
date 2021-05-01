using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    
    [SerializeField] float forceMultiplier = 10;

    private Rigidbody rb;

    //private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }
    
    void Shoot(Vector3 Force)
    {
        //if (isShoot)
            //return;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        //isShoot = true;
    }
}
