using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class moveText : MonoBehaviour
{
    public TextMeshPro TMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TMP.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 10);
        
        print("Camera rot: "+this.transform.eulerAngles);
        print("TMP pos: "+TMP.transform.position);
    }
}
