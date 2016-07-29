using UnityEngine;

/// <summary>
/// A popup value/string that appears above a GameObject.
/// Control the initial position of the numbers here.
/// Owner: John Fitzgerald
/// </summary>
public class PopUp : MonoBehaviour
{
    public string PopUpLocation = "Utilities/PopUp";

    public GameObject PopUp_GO;
    public GameObject ObjectOfEffect_GO;
    public System.Type ObjectOfEffect_Type; // The GameObject that triggered PopUp
    public TextMesh _TextMesh;

    // Value/string options
    public int ValueToDisplay;
    public float DisplayLength;
    public float DeleteTime;
    public float FadeSpeed;
    public float FloatSpeed;

    // Needed PopUp positions
    public Vector2 Parent_Pos;              // PopUpManager's position
    public Vector2 ObjectOfEffect_Pos; 
    public Vector2 PopUp_Pos;

    /// <summary>
    /// Sloppy constructor (can't have normal constructor because of Monobehaviour)
    /// </summary>
    public void _PopUp(GameObject objectOfEffect_GO, GameObject popUp_GO, float valueToDisplay, float displayLength, System.Type type, Color color)
    {
        PopUp_GO = popUp_GO;
        ObjectOfEffect_GO = objectOfEffect_GO;
        PopUp_GO.transform.parent = PopUpManager.Instance.transform;
        ObjectOfEffect_Type = type;
        _TextMesh = gameObject.GetComponent<TextMesh>();
        _TextMesh.color = color;

        ValueToDisplay = (int)valueToDisplay;
        DisplayLength = displayLength;
        DeleteTime = Time.time + DisplayLength;
        // TO-DO: change so FadeSpeed and FloatSpeed aren't hard coded
        FadeSpeed = 4f;
        FloatSpeed = 2f;

        Parent_Pos = PopUpManager.Instance.gameObject.transform.position;
        ObjectOfEffect_Pos = ObjectOfEffect_GO.transform.position;
        SetPopUp_Pos();
    }

    /// <summary>
    /// Sets PopUp position randomly in the vacininty of the object of effect
    /// </summary>
    private void SetPopUp_Pos()
    {
        // PopUp position is random within a range.
        float[] pos = { 0, 0};
        for (int i = 0; i < 1; i++)
            pos[i] = UnityEngine.Random.Range(-0.2f, 0.2f);

        // Initial position will be above the debri.
        PopUp_Pos = new Vector2(ObjectOfEffect_Pos.x + pos[0], ObjectOfEffect_Pos.y + pos[1]);
    }
}