using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
