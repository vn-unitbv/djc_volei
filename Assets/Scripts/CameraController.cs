using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public float MinPos;
    public float MaxPos;
    public float MinAngle;
    public float MaxAngle;
    public float StartAngle;
    public float Radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerPos = Player.transform.localPosition.x;

        float t = Mathf.InverseLerp(MinPos, MaxPos, playerPos);

        float angle = StartAngle + Mathf.Lerp(MinAngle, MaxAngle, t);

        float cameraPosX = -Mathf.Sin(angle * Mathf.Deg2Rad) * Radius;
        float cameraPosZ = -Mathf.Cos(angle * Mathf.Deg2Rad) * Radius;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);
        transform.localPosition = new Vector3(cameraPosX, transform.localPosition.y, cameraPosZ);
    }
}
