using UnityEngine;

public class Tail : MonoBehaviour
{

    [SerializeField]
    GameObject[] tails;

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
    }

    public void ExtendTail(int ex)
    {
        if (count < tails.Length)
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
            count += ex;
        }
    }
    public void ShortenTail(int sh)
    {
        if(count > 0) { 
            count -= sh;
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
