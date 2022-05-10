using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        //SceneManager.LoadScene("startscene", LoadSceneMode.Single);
    }

    private void start_game()
    {
        Debug.Log("Game Started!\n");
        SceneManager.LoadScene("gamescene", LoadSceneMode.Single);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerPrefs.SetInt("selected_character", 1);
            start_game();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerPrefs.SetInt("selected_character", 0);
            start_game();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerPrefs.SetInt("selected_character", 2);
            start_game();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
