using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<Tail>().ExtendTail(1);
        Destroy(gameObject);
    }
}
