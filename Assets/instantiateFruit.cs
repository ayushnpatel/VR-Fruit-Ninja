using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateFruit : MonoBehaviour
{

    public GameObject gameObjectPlum;
    public GameObject gameObjectOrange;
    public GameObject gameObjectPineapple;
    public GameObject gameObjectWatermelon;

    float time;
    // Start is called before the first frame update
    void Start()
    {
/*        gameObjectPlum.AddComponent<destroyObj>();

        gameObjectOrange.AddComponent<destroyObj>();

        gameObjectPineapple.AddComponent<destroyObj>();
*/
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, 30);
        if(rand == 1)
        {
            float randX = Random.Range(-1f, 1f);
            float randZ = Random.Range(-1f, 1f);

            int rand2 = Random.Range(1, 4);
            int rand3 = Random.Range(1, 30);

            if (rand2 == 1)
            {
                Instantiate(gameObjectPlum, new Vector3(randX, 0f, randZ), transform.rotation);

            }
            else if (rand2 == 2)
            {
                Instantiate(gameObjectOrange, new Vector3(randX, 0f, randZ), transform.rotation);

            }
            else if (rand2 == 3)
            {
                Instantiate(gameObjectPineapple, new Vector3(randX, 0f, randZ), transform.rotation);
            }
            else if (rand3 == 1)
            {
                Instantiate(gameObjectWatermelon, new Vector3(randX, 0f, randZ), transform.rotation);
            }
            // gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*5, ForceMode.Impulse);
        }
        //-1.4, 1.9, -1 -> 1.4, 1.9, 1
    }
}
