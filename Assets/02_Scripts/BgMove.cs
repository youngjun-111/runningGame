using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    private float width; // ����� ���� ����
    public static float moveSpeed = 3f;
    public float subSpeed = 0.5f;

    public GameObject sub;
    private void Awake()
    {
        // BoxCollider2D ������Ʈ�� Size �ʵ��� X ���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        sub.transform.Translate(Vector2.left * subSpeed * Time.deltaTime);

        // ���� ��ġ�� �������� �������� width �̻� �̵������� ��ġ�� ����
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // ��ġ�� �����ϴ� �޼���
    private void Reposition()
    {
        // ���� ��ġ���� ���������� ���α���  ��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
