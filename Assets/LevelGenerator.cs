using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=NtY_R0g8L8E

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private const float SPAWN_INTERVAL = 100.0f;
    private const int INITIAL_PARTS = 5;

    [SerializeField] private List<Transform> levelParts;
    [SerializeField] private Transform startSpawn;
    [SerializeField] private Transform player;
    //[SerializeField] private Player player;

    private Vector3 lastSpawn;

    private void Awake(){
        lastSpawn = startSpawn.Find("EndPosition").position;
        for (int i = 0; i < INITIAL_PARTS; i++){
            SpawnComponent();
        }

    }
    
    private void Update(){

        //Vector3 playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; 

        if ((Vector3.Distance(player.transform.position, lastSpawn)) < SPAWN_INTERVAL){
            //Debug.Log("WE'RE NEAR THE END\n");
            SpawnComponent();
        }
    }

    private void SpawnComponent(){
        Transform randomPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastPartTransform = SpawnComponent(randomPart, lastSpawn);
        lastSpawn = lastPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnComponent(Transform levelPart, Vector3 position){
        Transform componentTransform = Instantiate(levelPart, position, Quaternion.identity); //tell me when you see this comment
        return componentTransform;
    }
}
