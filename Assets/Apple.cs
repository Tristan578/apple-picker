using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }

        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        apScript.AppleMissed();
    }
}
