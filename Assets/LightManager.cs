
using UnityEngine;

public class LightManager : MonoBehaviour {
    public Light lightSource;
    public AudioSource soundTriggerCollect;
    public AudioSource soundTriggerBad;
    public float dimming;
    private int selected_character;
    private float negation;

    public void increase_light()
    {
        lightSource.intensity = 1;
    }
    public void decrease_light()
    {
        lightSource.intensity *= 0.8f;
    }

    private void Start()
    {
        selected_character = PlayerPrefs.GetInt("selected_character");
        negation = (1 - dimming) * 0.3f;
    }

    void FixedUpdate() {

        if (selected_character != 2)
        {
            lightSource.intensity *= dimming;
        }
        else
        {
            lightSource.intensity *= (dimming + negation);
        }




        if (lightSource.intensity <= 0.03)
        {
            FindObjectOfType<Manager>().gameover();
        }
    }
} 
