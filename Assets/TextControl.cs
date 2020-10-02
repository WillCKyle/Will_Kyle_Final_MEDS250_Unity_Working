using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour
{

    public GameObject canvasGameObject;
    private Canvas canvas;

    void Start()
    {
        // When the game starts: 
        // Make the scroll text canvas game object inactive. 
        Canvas canvas = canvasGameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger cube: 
        // Make the scroll text canvas game object active.
        Debug.Log("Entered Trigger Handler");
        Canvas canvas = canvasGameObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        // When the player exits the trigger cube: 
        // Make the scroll text canvas game object inactive.        
        Debug.Log("Exited Trigger Handler");
        Canvas canvas = canvasGameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }
}
