using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
       
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        // Find out whether current second is odd or even
        //bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;
        // Enable renderer accordingly
        if (Input.GetKeyDown("space"))
            rend.enabled = true;
        if (!Input.GetKeyDown("space"))
            rend.enabled = false;

        if (Input.GetKey(KeyCode.T)) { Debug.DrawRay(transform.position, new Vector3 (0,0,transform.position.x), Color.black); }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "wall")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}