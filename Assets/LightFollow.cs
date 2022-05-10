
using UnityEngine;

public class LightFollow : MonoBehaviour {
    public Transform target;


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x+5, target.position.y+1, target.position.z), Time.deltaTime);
    }
} 
