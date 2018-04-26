using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public float zoomLevelMin, zoomLevel2, zoomLevel3, zoomLevelMax;
    private Camera PlayerCamera;
    public float zoomSpeed = 0.5f;

    private int currentLevel = 1;

    // Use this for initialization
    void Start()
    {
        PlayerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentLevel++;

            if (currentLevel > 4)
            {
                currentLevel = 1;
            }

            Debug.Log(currentLevel);
        }
    }

    void LateUpdate()
    {
        switch (currentLevel)
        {
            case 1:
                PlayerCamera.orthographicSize = Mathf.Lerp(PlayerCamera.orthographicSize, zoomLevelMin, Time.deltaTime * zoomSpeed);
                break;
            case 2:
                PlayerCamera.orthographicSize = Mathf.Lerp(PlayerCamera.orthographicSize, zoomLevel2, Time.deltaTime * zoomSpeed);
                break;
            case 3:
                PlayerCamera.orthographicSize = Mathf.Lerp(PlayerCamera.orthographicSize, zoomLevel3, Time.deltaTime * zoomSpeed);
                break;
            case 4:
                PlayerCamera.orthographicSize = Mathf.Lerp(PlayerCamera.orthographicSize, zoomLevelMax, Time.deltaTime * zoomSpeed);
                break;
            default:
                break;
        }

    }
}
