using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intrectable : MonoBehaviour
{
    [SerializeField] float interactDistance = 2.0f;
    [SerializeField] LayerMask itemLayer;
    [SerializeField] Canvas canvas;

    bool isInRange = false;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector2.one * interactDistance);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange)
                TryInteract();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            canvas.gameObject.SetActive(false);
        }
    }

    void TryInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one * interactDistance, 0, itemLayer);
        foreach (Collider2D collider in colliders)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
