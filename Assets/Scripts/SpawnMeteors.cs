using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnMeteors : MonoBehaviour
{

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public List<GameObject> meteorList;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawn one meteor 
    void Spawn()
    {
        //Debug.Log ("spawned");

        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        // Instantiate the meteor from random point on sides
        Vector2 start1 = new Vector2(borderLeft.position.x, y);
        Vector2 start2 = new Vector2(x, borderTop.position.y);
        Vector2 start3 = new Vector2(borderRight.position.x, y);
        Vector2 start4 = new Vector2(x, borderBottom.position.y);

        float ran = Random.Range(1, 5);
        GameObject meteor = (GameObject)Resources.Load("Sprites/MeteorPrefab");
        if (ran == 1)
            Instantiate(meteor, start1, Quaternion.identity); // default rotation
        else if (ran == 2)
            Instantiate(meteor, start2, Quaternion.identity);
        else if (ran == 3)
            Instantiate(meteor, start3, Quaternion.identity);
        else
            Instantiate(meteor, start4, Quaternion.identity);

        // add the newly created meteor to the list
        meteorList.Add(meteor);

    }
}