using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorBehavior : MonoBehaviour
{

    float ran;
    float count = 0;
    public bool shouldMove = true;
    //Rigidbody2D rb;
    //Rigidbody2D planetRB;
    GameObject planet;


    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        planet = GameObject.Find("planetoid2");

        //planetRB = planet.GetComponent<Rigidbody2D>();

        ran = Random.Range(1, 5);
        if (ran == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.tag = "green";
        }
        else if (ran == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.tag = "red";
        }
        else if (ran == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            gameObject.tag = "cyan";
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            gameObject.tag = "magenta";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Vector3 pos = transform.position;
            // move meteor toward origin
            transform.Translate(-pos * (Time.deltaTime), Camera.main.transform); // time controls speed
        }

        if (transform.parent == null)
            shouldMove = true;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        //if (coll.gameObject.tag == "planetoid")
        shouldMove = false;

        if (this.tag == coll.gameObject.tag)
        {
            //count++;
            //Debug.Log (count);
            
            
            // if same colors collide, kill em
            Destroy(this.gameObject);
            Destroy(coll.gameObject);
           
        }

        if (coll.gameObject.tag != "planetoid")
        {
            coll.transform.parent = planet.transform;
        }
    }

    //Tried to fix it so meteors wouldn't be left floating when their buddies were destroyed
    //in theory i tried to set its parent to null so that it would be told to start moving again
    //perhaps because this is ignored when objects are destroyed?
    void OnCollisionExit2D(Collider2D coll)
    {
        coll.transform.parent = null;   //doesn't work
        transform.parent = null;
    }

    //psuedo for
    //how to destroy match3+
    //    //meteor hits match
    //    //add match to the meteor's list of 'touching'
    //    //pass list to match
    //    //search for other matches touching
    //    //continue passing list and destroying

}