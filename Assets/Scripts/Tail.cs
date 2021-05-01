using System;
using UnityEngine;

public class Tail : MonoBehaviour
{
    GameObject[] tails;

    [SerializeField]
    GameObject rootHair;

    [SerializeField]
    Transform holder;

    [SerializeField]
    GameObject hairPref;

    [SerializeField]
    int hairCount;

    [SerializeField]
    Camera camera;

    [SerializeField]
    float speed;

    Vector3 mousePressDownPos;
    Vector3 mouseReleasePos;

    [SerializeField] float forceMultiplier = 10;

    int count;

    void Start()
    {
        count = 1;
        tails = new GameObject[hairCount + 1];
        tails[0] = rootHair.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExtendTail(1);
        else if (Input.GetKeyDown(KeyCode.Backspace))
            ShortenTail(1);
        else if(Input.GetMouseButtonDown(0))
            mousePressDownPos = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
            Shoot(mousePressDownPos - mouseReleasePos);
        }
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
        for (int i = 0; i < count; i++)
        {
            tails[i].GetComponent<Rigidbody>().AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
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
            /*MeshRenderer[] sp = tails[count].GetComponentsInChildren<MeshRenderer>();
            tails[count].GetComponent<Collider>().enabled = true;
            sp[1].GetComponent<MeshRenderer>().enabled = true;
            if (count > 0)
            {
                sp = tails[count - 1].GetComponentsInChildren<MeshRenderer>();
                sp[0].GetComponent<MeshRenderer>().enabled = true;
                sp[1].GetComponent<MeshRenderer>().enabled = false;
            }*/
            tails[count] = Instantiate(hairPref, tails[count - 1].transform.position, tails[count - 1].transform.rotation, holder);
            tails[count].GetComponent<CharacterJoint>().connectedBody = tails[count - 1].GetComponent<Rigidbody>();
            count++;
        }
    }
    public void ShortenTail(int sh)
    {
        for (int i = 0; i < sh && count > 1; i++)
        { /*
            MeshRenderer[] sp = tails[count].GetComponentsInChildren<MeshRenderer>();
            tails[count].GetComponent<Collider>().enabled = false;
            sp[1].GetComponent<MeshRenderer>().enabled = false;
                sp = tails[count - 1].GetComponentsInChildren<MeshRenderer>();
                sp[1].GetComponent<MeshRenderer>().enabled = true;
                sp[0].GetComponent<MeshRenderer>().enabled = false;
            */
            count--;
            Destroy(tails[count]);
        }
    }
}
