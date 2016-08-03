using UnityEngine;
using System.Collections;

public class Planetoid : MonoBehaviour
{
    public CircleCollider2D coll;
    public Rigidbody2D rb;

    public int _Direction;
    private bool _PlaySound;

    private FMOD.Studio.EventInstance RotationSound_FMOD;
    private FMOD.Studio.ParameterInstance Direction;

    // Use this for initialization
    void Start()
    {
        // delegate event handling
        InputManager.Instance.rotatePlanetoidKeyPressed += this.RotatePlanetoid;

        _Direction = 0;
        _PlaySound = false;
        coll = GetComponent<CircleCollider2D>();
        
        // FMOD sound
        RotationSound_FMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Sound Effects/Rotation");
        // ensure null values are not sent to FMOD event
        if (RotationSound_FMOD.getParameter("Direction", out Direction) != FMOD.RESULT.OK)
        {
            Debug.LogError("Direction parameter not found on RotationSound_FMOD sound event.");
            return;
        }
        RotationSound_FMOD.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Direction < 0 || _Direction > 0)
        {
            _PlaySound = true;
            Direction.setValue(_Direction);
        }
        else
        {
            _PlaySound = false;
            Direction.setValue(_Direction);
        }
    }

    void RotatePlanetoid(int direction)
    {
        _Direction = direction;

        if (_Direction > 0)
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * 200), Space.World);
            //Debug.Log ("Left key was pressed.");
        }
        else if (_Direction < 0)
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
