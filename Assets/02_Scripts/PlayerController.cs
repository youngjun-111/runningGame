using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpPower = 5f;

    int jumpCount;
    Rigidbody2D rigi;
    Animator anim;
    [SerializeField] float hp;

    bool isAvoidance = false;//회피 중인지 여부
    public float avoidanceTime = 1f;//회피 가능 시간

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        BackJump();
        Dead();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpCount--;
            rigi.velocity = new Vector2(rigi.velocity.x, jumpPower);
            anim.SetBool("jump", true);
        }
    }


    void BackJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && jumpCount > 0)
        {
            jumpCount--;
            rigi.velocity = new Vector2(rigi.velocity.x, jumpPower);
            anim.SetBool("back", true);
            isAvoidance = true;
            Avoidance();
        }
    }
    //회피
    void Avoidance()
    {
        if (isAvoidance)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            Invoke("StopAvoidDance", 1f);
        }
    }
    void StopAvoidDance()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
        isAvoidance = false;
    }
    //땅을 설정해줘서 땅이라면 점프랑 회피를 초기화시켜주기
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 1;
            anim.SetBool("jump", false);
            anim.SetBool("back", false);
        }
        //만약 dead라는 태그랑 만나면 피격 모션
        if (collision.gameObject.CompareTag("Dead"))
        {
            //UI이미지 하트 삭제시키고
            //헐트 애니메이션 실행
            hp--;
            anim.SetBool("hurt", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("hurt", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("hurt", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            anim.SetBool("hurt", false);
        }
    }

    void Dead()
    {
        if(hp <= 0)
        {

        }
    }

}
