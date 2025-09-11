using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Debug.Log("Apple has fallen below bottomY! Calling AppleMissed.");
            Destroy(gameObject);
            ApplePicker.instance.AppleMissed();
        }
    }

    // This function will run the moment the apple is destroyed for any reason.
    void OnDestroy()
    {
        Debug.Log("Apple was destroyed at Y-position: " + transform.position.y);
    }
}
