using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickBlcok : MonoBehaviour
{
    public float lenght = 0;// �ڵ� ���� Ž���Ÿ�
    public bool isDelete = false;//���� �� �������� ����

    bool isFell = false;//���� �÷���
    float fadeTime = 0.5f;//���̵� �ƿ� �ð�
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;//���� ����
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");//�÷��̾� ã��
        if (player != null)
        {
            //�÷��̾���� �Ÿ� ���
            float d = Vector2.Distance(transform.position, player.transform.position);
            if (lenght >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    //������ٵ� �������� ����
                    rbody.bodyType = RigidbodyType2D.Dynamic;//������ �� �ִ� ����
                }
            }
        }
        if (isFell)
        {
            //����
            fadeTime -= Time.deltaTime;//������ �����Ͽ� ���̵� �ƿ� ȿ��
            Color col = GetComponent<SpriteRenderer>().color;//�÷� �� ��������
            col.a = fadeTime;//���� ����
            GetComponent<SpriteRenderer>().color = col;//�÷��� �缳��
            if (fadeTime <= 0f)
            {
                //0���� ������(����) ����
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true;//���� �÷��� true
        }
    }
}

