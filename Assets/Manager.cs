using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    bool game_ended = false;
    public void gameover()
    {
        if (!game_ended)
        {
            game_ended = true;
            Debug.Log("Game has ENDED.\n");
            SceneManager.LoadScene("endscene", LoadSceneMode.Single);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("endscene"));
            
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
