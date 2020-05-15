using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using UnityEngine.UI;
public class batCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject brokenFruitPlum;
    public GameObject brokenFruitOrange;
    public GameObject brokenFruitPineapple;
    public GameObject brokenFruitWatermelon;
    public SteamVR_Behaviour_Pose pose;
    public static int score;
    public TextMeshPro text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
        if (score >= 10)
        {
            //quitText.text = "Press Space to Quit";
        }
        if (Input.GetKey(KeyCode.Space) && score >= 10)
        {
            //Application.LoadLevel(Application.loadedLevel);

            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();

        }

        //text.transform.position = 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        if(collision.gameObject.name == "SqPlum(Clone)")
        {
            GameObject other = collision.gameObject;
            Vector3 location = other.transform.position;
            Quaternion rotation = other.transform.rotation;
            Destroy(other);
            //print(pose.GetAngularVelocity());
            //brokenFruit.GetComponent<Rigidbody>().AddForce(3*pose.GetAngularVelocity(), ForceMode.Impulse);
            //brokenFruitPlum.GetComponent<Rigidbody>().AddRelativeForce(5 * pose.GetVelocity(), ForceMode.Impulse);
            /*brokenFruit.GetComponent<Rigidbody>().velocity = 5 * pose.GetVelocity();
            brokenFruit.GetComponent<Rigidbody>().angularVelocity = 5 * pose.GetAngularVelocity();*/
            print("Velocity: "+ brokenFruitPlum.GetComponent<Rigidbody>().velocity);
            Instantiate(brokenFruitPlum, location, rotation);
            score++;
        }
        if (collision.gameObject.name == "SqOrange(Clone)")
        {
            GameObject other = collision.gameObject;
            Vector3 location = other.transform.position;
            Quaternion rotation = other.transform.rotation;
            Destroy(other);
            //print(pose.GetAngularVelocity());
            //brokenFruit.GetComponent<Rigidbody>().AddForce(3*pose.GetAngularVelocity(), ForceMode.Impulse);
           /* brokenFruitOrange.GetComponent<Rigidbody>().AddRelativeForce(5 * pose.GetVelocity(), ForceMode.Impulse);
            brokenFruitOrange.GetComponent<Rigidbody>().velocity = 5 * pose.GetVelocity();
            brokenFruitOrange.GetComponent<Rigidbody>().angularVelocity = 5 * pose.GetAngularVelocity();*/
            print("Velocity: " + brokenFruitOrange.GetComponent<Rigidbody>().velocity);
            Instantiate(brokenFruitOrange, location, rotation);
            score++;
        }
        if (collision.gameObject.name == "SqPineapple(Clone)")
        {
            GameObject other = collision.gameObject;
            Vector3 location = other.transform.position;
            Quaternion rotation = other.transform.rotation;
            Destroy(other);
            //print(pose.GetAngularVelocity());
            //brokenFruit.GetComponent<Rigidbody>().AddForce(3*pose.GetAngularVelocity(), ForceMode.Impulse);
/*            brokenFruitPineapple.GetComponent<Rigidbody>().AddRelativeForce(5 * pose.GetVelocity(), ForceMode.Impulse);
            brokenFruitPineapple.GetComponent<Rigidbody>().velocity = 5 * pose.GetVelocity();
            brokenFruitPineapple.GetComponent<Rigidbody>().angularVelocity = 5 * pose.GetAngularVelocity();*/
            print("Velocity: " + brokenFruitPineapple.GetComponent<Rigidbody>().velocity);
            Instantiate(brokenFruitPineapple, location, rotation);
            score++;
        }
        if (collision.gameObject.name == "SqWatermelon(Clone)")
        {
            GameObject other = collision.gameObject;
            Vector3 location = other.transform.position;
            Quaternion rotation = other.transform.rotation;
            Destroy(other);
            //print(pose.GetAngularVelocity());
            //brokenFruit.GetComponent<Rigidbody>().AddForce(3*pose.GetAngularVelocity(), ForceMode.Impulse);
/*            brokenFruitPineapple.GetComponent<Rigidbody>().AddRelativeForce(5 * pose.GetVelocity(), ForceMode.Impulse);
            brokenFruitPineapple.GetComponent<Rigidbody>().velocity = 5 * pose.GetVelocity();
            brokenFruitPineapple.GetComponent<Rigidbody>().angularVelocity = 5 * pose.GetAngularVelocity();*/
            print("Velocity: " + brokenFruitPineapple.GetComponent<Rigidbody>().velocity);
            Instantiate(brokenFruitPineapple, location, rotation);
            score+=5;
        }



    }
}
