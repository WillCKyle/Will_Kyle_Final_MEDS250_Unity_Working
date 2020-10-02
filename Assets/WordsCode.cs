using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(konami))]
public class WordsCode : MonoBehaviour
{
    private konami code;

    public Text abcText;

    void Awake()
    {
        code = GetComponent<konami>();
    }

    void Update () {
		if (code.success)
        {
            abcText.gameObject.SetActive(true);
        }
	}
}
