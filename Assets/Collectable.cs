using UnityEngine;

public class Collectable : MonoBehaviour{

    [SerializeField] LayerMask layer;

    /*    void OnTriggerEnter(Collider entity){
            //FindObjectOfType<LightManager>().increase_light();
            Debug.Log("Testing\n");
        }*/

    private void Start()
    {
        //layer = LayerMask.NameToLayer("player");
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.1f, layer, QueryTriggerInteraction.Ignore))
        {
            FindObjectOfType<LightManager>().increase_light();
        }
    }
}