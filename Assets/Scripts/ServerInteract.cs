using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerInteraction : MonoBehaviour
{
    public GameObject panel;
    private bool playerInsideTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
        }
    }

    void Update()
    {
        // Check if the player is inside the trigger and pressed the 'E' key
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            TogglePanel();
        }
    }

    private void TogglePanel()
    {
        // Check if the panel is inactive
        if (!panel.activeSelf)
        {
            // Set the panel active
            panel.SetActive(true);

            // Pause the game while the panel is active (optional)
            Time.timeScale = 0f;
        }
        else
        {
            // Set the panel inactive
            panel.SetActive(false);

            // Resume the game (optional)
            Time.timeScale = 1f;
        }
    }
}
