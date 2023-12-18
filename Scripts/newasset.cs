using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newasset : MonoBehaviour
{
    public int scorePenalty = 50;
    public static float bottomY = -20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            // Destroy the game object if it reaches the bottom of the screen
            Destroy(this.gameObject);
        }
    
}
}

