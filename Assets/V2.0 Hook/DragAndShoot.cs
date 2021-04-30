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

    private bool isShoot;

    //private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z: forceInit.y)) * forceMultiplier;

        if (!isShoot)
        {
            HowFar.Instance.UpdateTrajectory(forceVector: forceV, rb, startingPoint: transform.position);
        }
    }

    private void OnMouseUp()
    {
        HowFar.Instance.HideLine();
        HowFar.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos -mouseReleasePos);
    }
    
    void Shoot(Vector3 Force)
    {
        //if (isShoot)
            //return;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        //isShoot = true;
    }
}
