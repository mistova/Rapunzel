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
            ExtendTail();
        else if (Input.GetKeyDown(KeyCode.Backspace))
            ShortenTail();
    }

    public void ExtendTail()
    {
        if(count < tails.Length)
        {
            //tails[count].GetComponent<Collider>().enabled = true;
            //tails[count].GetComponent<MeshRenderer>().enabled = true;
            count++;
        }
    }
    public void ShortenTail()
    {
        if(count > 0) { 
        count--;
        //tails[count].GetComponent<Collider>().enabled = false;
        //tails[count].GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
