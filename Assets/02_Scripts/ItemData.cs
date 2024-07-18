using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    life,
    jumpCount,
}

public class ItemData : MonoBehaviour
{
    public ItemType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(type == ItemType.jumpCount)
            {
                ItemKeeper.jumpCount += 1;
            }else if (type == ItemType.life)
            {
                ItemKeeper.hp++;
            }
        }
    }
}
