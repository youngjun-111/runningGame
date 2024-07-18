using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    private float width; // 배경의 가로 길이
    public static float moveSpeed = 3f;
    public float subSpeed = 0.5f;

    public GameObject sub;
    private void Awake()
    {
        // BoxCollider2D 컴포넌트의 Size 필드의 X 값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        sub.transform.Translate(Vector2.left * subSpeed * Time.deltaTime);

        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 리셋
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로길이  만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
