using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class konami : MonoBehaviour
{
    public int lives;
    private KeyCode[] keys = new KeyCode[]
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C
    };

    public bool success;

    IEnumerator Start ()
    {
        float timer = 0f;
        int index = 0;

        while(true)
        {
            if (Input.GetKeyDown(keys[index]))
            {
                index++;

                if (index == keys.Length)
                {
                    success = true;
                    timer = 0f;
                }
                else
                {
                    timer = 0.5f;
                }
            }
            yield return null;
        }

        timer -= Time.deltaTime;
        if (timer<0)
        {
            timer = 0;
            index = 0;
        }
    }

}
