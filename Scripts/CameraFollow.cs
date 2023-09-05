using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 offset;
    public void Start()
    {
        offset = transform.position-target.position;
    }
    private void Update()
    {
        transform.position = new Vector3(target.position.x +offset.x, + target.position.y + offset.y, + target.position.z + offset.z);
    }
}
