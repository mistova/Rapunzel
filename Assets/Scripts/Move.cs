using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    Transform[] tr;
    [SerializeField]
    float speed;

    int count;
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, tr[count % tr.Length].position) > 0.5)
            transform.position += (tr[count % tr.Length].position - transform.position).normalized * speed * Time.deltaTime;
        else
            count++;
    }

}
