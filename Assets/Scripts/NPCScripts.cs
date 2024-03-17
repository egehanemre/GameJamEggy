using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScripts : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float moveDistance = 2f;
    private float originalPosition;
    private bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if(Mathf.Abs(originalPosition - transform.position.x) >= moveDistance)
        {
            Flip();
            moveRight = !moveRight;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
