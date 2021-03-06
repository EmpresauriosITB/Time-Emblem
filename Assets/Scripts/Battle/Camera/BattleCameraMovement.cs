using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraMovement : MonoBehaviour
{
    //Movement
    public float borderMoveSpeed = 1.2f;
    public float screenOffset = .005f;
    // ZOOM
    public float zoomSpeed = 6f;
    public Vector2 zoomLimits;

    Camera myCam;

    [SerializeField] private Vector2 screenXLimits = Vector2.zero;
    [SerializeField] private Vector2 screenZLimits = Vector2.zero;

    private void Start()
    {
        myCam = GetComponent<Camera>();
    }

    void Update()
    {
        // Zoom code 
        var zoom = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = myCam.transform.position;
        myCam.orthographicSize -= zoom * zoomSpeed;

        myCam.orthographicSize = Mathf.Clamp(myCam.orthographicSize,
            zoomLimits.x, zoomLimits.y);

        // Camera movement per border
        Vector3 Speed = new Vector3();

        if (Input.mousePosition.x < Screen.width * screenOffset)
            Speed.x -= borderMoveSpeed;
        else if (Input.mousePosition.x > Screen.width - (Screen.width * screenOffset))
            Speed.x += borderMoveSpeed;

        if (Input.mousePosition.y < Screen.height * screenOffset)
            Speed.z -= borderMoveSpeed;
        else if (Input.mousePosition.y > Screen.height - (Screen.height * screenOffset))
            Speed.z += borderMoveSpeed;

        pos.x = Mathf.Clamp(pos.x, screenXLimits.x, screenXLimits.y);
        pos.z = Mathf.Clamp(pos.z, screenZLimits.x, screenZLimits.y);
        myCam.transform.position = pos;

        transform.position += Speed * Time.deltaTime;
    }
}
