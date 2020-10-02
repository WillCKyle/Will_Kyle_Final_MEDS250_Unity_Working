using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerVital : MonoBehaviour
{
    public Slider staminaSlider;
    public int maxStamina;
    private int staminaFallRate;
    public int staminaFallMult;
    private int staminaRegainRate;
    public int staminaRegainMult;

    private CharacterController charController;
    private FirstPersonController playerController;

    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        staminaFallRate = 1;
        staminaRegainRate = 1;

        charController = GetComponent<CharacterController>();
        playerController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;
        }

        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
        }

        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
            playerController.m_RunSpeed = 10 + playerController.count;
        }

        else if (staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            playerController.m_RunSpeed = playerController.m_WalkSpeed;
        }

        else if (staminaSlider.value >= 0)
        {
            playerController.m_RunSpeed = 10 + playerController.count;
        }
    }
}

