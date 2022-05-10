using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldcollide : MonoBehaviour
{

    [SerializeField] LayerMask layer;
    /* void OnTriggerEnter(Collider entity)
    {
        FindObjectOfType<LightManager>().decrease_light();
    } */
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.1f, layer, QueryTriggerInteraction.Ignore))
        {
            FindObjectOfType<LightManager>().decrease_light();
        }
    }
}
