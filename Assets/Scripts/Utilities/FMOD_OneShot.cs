using UnityEngine;

public class FMOD_OneShot : MonoBehaviour
{
    public string FMODEventName = "";
    public Vector3 Position;

    // Use this for initialization
    private void Start()
    {
        Position = this.transform.position;

        Play_OneShot();
    }

    public void Play_OneShot()
    {
        // TODO -- (FITZGERALD) simultaenous calls to same prefab cause audio cut off -- find work around
		FMODUnity.RuntimeManager.PlayOneShot("event:/" + FMODEventName, Position);
    }
}