using System;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField]
    GameObject[] tails;

    [SerializeField]
    Camera camera;

    [SerializeField]
    float speed;

    [SerializeField]
    float limitForce = 3000;

    Vector3 mousePressDownPos;
    Vector3 mouseReleasePos;

    [SerializeField] float forceMultiplier = 10;

    int count;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExtendTail(1);
        else if (Input.GetKeyDown(KeyCode.Backspace))
            ShortenTail(1);
        else if (Input.GetMouseButtonDown(0))
            mousePressDownPos = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
            Shoot(mousePressDownPos - mouseReleasePos);
        }
        else if (Input.GetMouseButton(0))
        {
            mouseReleasePos = Input.mousePosition;
            Vector3 vec = mousePressDownPos - mouseReleasePos;
            vec = new Vector3(vec.x, vec.y, vec.y) * forceMultiplier / 5;
            HowFar.Instance.UpdateTrajectory(vec, tails[0].transform.position);
        }
        else
            HowFar.Instance.HideLine();
        /*
        else if (Input.GetMouseButton(0))
            Hook();*/
    }

    /*private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }*/

    void Shoot(Vector3 Force)
    {
        Vector3 force = new Vector3(Force.x, Force.y, Force.y) * forceMultiplier;
        if (Vector3.Distance(Vector3.zero, force) > limitForce)
            force = force.normalized * limitForce;
        for (int i = 0; i < tails.Length; i++)
        {
            tails[i].GetComponent<Rigidbody>().AddForce(force);
        }
    }

    private void Hook()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 vec = hit.transform.position - tails[i].transform.position;
                tails[i].GetComponent<Rigidbody>().AddForce(vec.normalized * speed);
            }
        }
    }

    public void ExtendTail(int ex)
    {
        for(int i = 0; i < ex && count < tails.Length; i++)
        {
            MeshRenderer[] sp = tails[count].GetComponentsInChildren<MeshRenderer>();
            tails[count].GetComponent<Collider>().enabled = true;
            sp[1].GetComponent<MeshRenderer>().enabled = true;
            if (count > 0)
            {
                sp = tails[count - 1].GetComponentsInChildren<MeshRenderer>();
                sp[0].GetComponent<MeshRenderer>().enabled = true;
                sp[1].GetComponent<MeshRenderer>().enabled = false;
            }
            count++;
        }
    }
    public void ShortenTail(int sh)
    {
        for (int i = 0; i < sh && count > 0; i++)
        {
            count--;
            MeshRenderer[] sp = tails[count].GetComponentsInChildren<MeshRenderer>();
            tails[count].GetComponent<Collider>().enabled = false;
            sp[1].GetComponent<MeshRenderer>().enabled = false;
            sp = tails[count - 1].GetComponentsInChildren<MeshRenderer>();
            sp[1].GetComponent<MeshRenderer>().enabled = true;
            sp[0].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
