using UnityEngine;
using System.Collections;

public class Planetoid : MonoBehaviour
{
    public CircleCollider2D coll;
    public Rigidbody2D rb;
    public int Direction;
    private bool _PlaySound;

    // Use this for initialization
    void Start()
    {
        // delegate event handling
        InputManager.Instance.rotatePlanetoidKeyPressed += this.RotatePlanetoid;
        Direction = 0;
        _PlaySound = false;
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction < 0 || Direction > 0)
        {
            _PlaySound = true;
        }
        else
        {
            _PlaySound = false;
        }
    }

    void RotatePlanetoid(int direction)
    {
        Direction = direction;

        if (Direction > 0)
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * 200), Space.World);
            //Debug.Log ("Left key was pressed.");
        }
        else if (Direction < 0)
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * -200), Space.World);
            //Debug.Log ("Right key was pressed.");
        }
        
        //if (_PlaySound == false && Direction != 0)
        //{
        //    PlaySound();
        //}
        //else if (_PlaySound == true && Direction == 0)
        //{
        //    StopSound();
        //}
    }

    //void PlaySound()
    //{
    //    if (Direction < 0)
    //    {
    //        Debug.Log("PlaySound() ... Direction < 0");
    //        //GetComponent<FMODUnity.StudioEventEmitter>().Play();
    //        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/counterclockwise", this.transform.position);
    //        _PlaySound = true;
    //    }

    //    else if (Direction > 0)
    //    {
    //        Debug.Log("PlaySound() ... Direction > 0");
    //        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/clockwise", this.transform.position);
    //        _PlaySound = true;
    //    }
    //}

    //void StopSound()
    //{
    //    Debug.Log("StopSound()");
    //    GetComponent<FMODUnity.StudioEventEmitter>().Stop();
    //    _PlaySound = false;
    //}

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
