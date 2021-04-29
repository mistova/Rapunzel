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
        else if (Input.GetMouseButton(0))
            Hook();
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
            count ++;
        }
    }
    public void ShortenTail(int sh)
    {
        for (int i = 0; i < sh && count > 0; i++)
        { 
            count --;
            MeshRenderer[] sp = tails[count].GetComponentsInChildren<MeshRenderer>();
            tails[count].GetComponent<Collider>().enabled = false;
            sp[1].GetComponent<MeshRenderer>().enabled = false;
            if (count - 1 > 0)
            {
                sp = tails[count - 1].GetComponentsInChildren<MeshRenderer>();
                sp[1].GetComponent<MeshRenderer>().enabled = true;
                sp[0].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
