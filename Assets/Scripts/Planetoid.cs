using UnityEngine;
using System.Collections;

public class Planetoid : MonoBehaviour
{
    public CircleCollider2D coll;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // delegate event handling
        InputManager.Instance.rotatePlanetoidKeyPressed += this.RotatePlanetoid;

        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RotatePlanetoid(int direction)
    {
        if (direction > 0)
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * 200), Space.World);
            //Debug.Log ("Left key was pressed.");
        }
        else
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * -200), Space.World);
            //Debug.Log ("Right key was pressed.");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.transform.parent = transform;
    }

    private void OnDestroy()
    {
        // Remove all references to delegate events that were created for this script
        if (InputManager.Instance != null)
        {
            // be sure to remove delegate
            InputManager.Instance.rotatePlanetoidKeyPressed -= this.RotatePlanetoid;
        }
    }
}
