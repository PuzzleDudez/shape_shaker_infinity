using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    #region EVENTS (DELEGATES)

    public delegate void RotatePlanetoid(int direction);
    public event RotatePlanetoid rotatePlanetoidKeyPressed;

    #endregion EVENTS (DELEGATES)

    #region INSTANCE (SINGLETON)

    /// <summary>
    /// Singleton
    /// </summary>
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<InputManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    #endregion INSTANCE (SINGLETON)

    // Update is called once per frame
    private void Update()
    {
        // Rotate planetoid clockwise
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (rotatePlanetoidKeyPressed != null)
            {
                rotatePlanetoidKeyPressed(1);
            }
        }
        // Rotate planetoid counter-clockwise
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (rotatePlanetoidKeyPressed != null)
            {
                rotatePlanetoidKeyPressed(-1);
            }
        }
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
            // TO-DO: pause menu
		}

        // Speed game up for testing purposes
        #if UNITY_EDITOR
        // Increase time by 1
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (Time.timeScale < 1.0f)
            {
                Time.timeScale += 0.1f;
            }
            else
            {
                Time.timeScale += 1f;
            }
            Debug.Log("Time.timeScale: " + Time.timeScale);
        }
        // Decrease time by 1
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (Time.timeScale > 1f)
            {
                Time.timeScale -= 1;
            }
            else if (Time.timeScale >= 0.1f)
            {
                Time.timeScale -= 0.1f;
            }

            Debug.Log("Time.timeScale: " + Time.timeScale);
        }
        // Return to time 1 (normal)
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Time.timeScale = 1;
            Debug.Log("Time.timeScale: " + Time.timeScale);
        }
#endif
    }
}