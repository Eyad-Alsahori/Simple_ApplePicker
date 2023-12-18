using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    public GameObject brocPrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;
    public float newAssetDropDelay = 5.5f;


    void Start()
    {
        // Start dropping apples.
        InvokeRepeating("DropApple", 2f, appleDropDelay);

        // create a delay for the broccli asset.
        InvokeRepeating("DropNewAsset", 4f, newAssetDropDelay);
    }

    void DropApple()
    {
        int currentScore = HighScore.SCORE;

        // Calculate the apple drop speed based on the current score
        float appleDropSpeed = 2f + currentScore * 0.02f;

        // Create the apple
        GameObject apple = Instantiate<GameObject>(applePrefab);

        // Apply force to the apple to control its fall rate
        ConstantForce cat = apple.GetComponent<ConstantForce>();
        Vector3 force = new Vector3(0, -appleDropSpeed, 0);
        cat.force = force;

        // Set the apple's initial position
        apple.transform.position = transform.position;
    }

    void DropNewAsset()
    {
        // Create the new asset
        GameObject newAsset = Instantiate<GameObject>(brocPrefab);

        // Set the new asset's initial position
        newAsset.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);   // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  // Move left       
        }
    }

    void FixedUpdate()
    {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }


}
