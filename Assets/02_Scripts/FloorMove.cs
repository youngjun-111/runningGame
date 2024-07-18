using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * BgMove.moveSpeed * Time.deltaTime);
        if(transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
