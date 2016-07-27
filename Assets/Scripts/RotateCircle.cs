using UnityEngine;
using System.Collections;

public class RotateCircle : MonoBehaviour
{
    public CircleCollider2D coll;
    public Rigidbody2D rb;
    void Start()
    {
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.forward, (Time.deltaTime * 200), Space.World);
            //Debug.Log ("Left key was pressed.");
            
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(Vector3.forward, (Time.deltaTime * -200), Space.World);
            //Debug.Log ("Right key was pressed.");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.transform.parent = transform;
    }
}



