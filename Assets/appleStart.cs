using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = new Vector3(Random.Range(-.6f,.6f), 1, Random.Range(-.6f, .6f));
        gameObject.GetComponent<Rigidbody>().AddForce(vec*20, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
