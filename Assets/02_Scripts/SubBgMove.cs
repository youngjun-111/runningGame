using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBgMove : MonoBehaviour
{
    float width;

    public float subMoveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * subMoveSpeed * Time.deltaTime);

        if (transform.position.x <= -width-3.3)
        {
            Reposition();
        }

    }
    private void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로길이  만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;
    }

}
