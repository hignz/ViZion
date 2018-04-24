using UnityEngine;
using System.Collections;

public class FaceControllerClass : MonoBehaviour
{
    float mod = 0.1f;
    float zVal = 0.0f;

    void Update()
    {
        if (true)
        {
            Vector3 rotate = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rotate;

            zVal += mod;

            if (transform.eulerAngles.z >= 6.0f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.1f;
            }
            else if (transform.eulerAngles.z < 387.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.1f;
            }
        }
    }
}
