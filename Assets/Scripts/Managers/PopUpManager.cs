using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Manages all types of PopUp values/strings above objects that trigger them.
/// Owner: John Fitzgerald
/// </summary>
public class PopUpManager: MonoBehaviour
{
    private static PopUpManager instance;

    #region INSTANCE (SINGLETON)

    /// <summary>
    /// Singleton
    /// </summary>
    public static PopUpManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PopUpManager>();
            }

            return instance;
        }
    }
    #endregion INSTANCE (SINGLETON)

    public List<GameObject> CurrentMeteorPopUpList;
    public string PopUpLocation = "Utilities/PopUp";

    private void Awake()
    {
        instance = this;
        CurrentMeteorPopUpList = new List<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (CurrentMeteorPopUpList.Count != 0)
        {
            // can't use foreach here (unable to modify enumerators that are also used as iterators)
            for (int i = 0; i < CurrentMeteorPopUpList.Count; ++i)
            {
                // store list's elements
                GameObject popUp_GO = CurrentMeteorPopUpList[i];
                PopUp popUp_Script = popUp_GO.GetComponent<PopUp>();

                Color currentColor = popUp_Script._TextMesh.color;
                Vector2 position = popUp_GO.transform.position;

                // fade the value's/string's color over time
                currentColor.a = Mathf.Lerp(currentColor.a, 0, Time.deltaTime * popUp_Script.FadeSpeed);
                popUp_Script._TextMesh.color = currentColor;

                // the numbers appear to float away
                position.y = Mathf.Lerp(position.y, position.y + 0.8f, Time.deltaTime * popUp_Script.FloatSpeed);
                popUp_GO.transform.position = position;

                // delete PopUp when deletion time has been reached
                if (popUp_Script.DeleteTime <= Time.time)
                {
                    CurrentMeteorPopUpList.Remove(CurrentMeteorPopUpList[i]);
                    Destroy(popUp_GO);
                }
            }
        }
    }

    /// <summary>
    /// Instantiate PopUp prefab and set PopUp values
    /// </summary>
    public void InitializePopUp(GameObject objectOfEffect_GO, float valueToDisplay, float displayLength, System.Type type, Color color)
    {
        // Instantiate the PopUp prefab
        GameObject popUp_GO = GameObject.Instantiate(Resources.Load(PopUpLocation), objectOfEffect_GO.transform.position, Camera.main.transform.rotation) as GameObject;

        // Set PopUp script
        PopUp popUp = popUp_GO.GetComponent<PopUp>();
        popUp._PopUp(objectOfEffect_GO, popUp_GO, valueToDisplay, displayLength, type, color);

        CurrentMeteorPopUpList.Add(popUp_GO);
        Display(popUp);
    }

    /// <summary>
    ///  Display different types of PopUp values/strings
    /// </summary>
    private void Display(PopUp popUp)
    {
        // A display function will be called depending on the debri's base class
        if (popUp.ObjectOfEffect_Type == typeof(MeteorBehavior))
            SetPointsGained(popUp);
        else
            Debug.LogError("Type is not correctly instantiated for PopUp of this type.");
    }
    
    /// <summary>
    /// Set value/string to be displayed
    /// </summary>
    private void SetPointsGained(PopUp popUp)
    {
        popUp._TextMesh.text = "+" + popUp.ValueToDisplay.ToString();
    }
}