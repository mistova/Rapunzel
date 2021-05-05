using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scir : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Tail>().ShortenTail(1);
            other.gameObject.GetComponent<Tail>().ShortenTail(2);
        }
    }
}
