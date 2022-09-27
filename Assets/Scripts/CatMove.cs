using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public GameManager gameManager;
    public Portal portal;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    int jumpCount = 2;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpCount = 0;
        
    }

    private void Update()
    {
        //Jump -> 2단점프
        if(jumpCount > 0)
        {
            if (Input.GetButtonDown("Jump")) //&& !anim.GetBool("isJumping") = 무한 점프 막기
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
                jumpCount--;
            }
        }
        
        if (Input.GetButtonUp("Horizontal")) //버튼에서 손을 때는 경우, 속력을 줄임
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //방향 전환
        if(Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DOWN ARROW");
        }

        //Animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3) // 절대값 = abs
        {
            anim.SetBool("isMoving", false);
        } else
            anim.SetBool("isMoving", true);
    }

    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //maxSpeed보다 빠른 경우
        //속도 관련한 벡터 -> velocity
        if (rigid.velocity.x > maxSpeed) // Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); 
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // Landing Platform
        if (rigid.velocity.y < 1)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 3, Color.red);
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down * 3, 3, LayerMask.GetMask("Platform"));

            if (rayhit.collider != null)
            {
                if (rayhit.distance < 1.5f) // player 크기의 반 -> 크기 3으로 수정해서 1.5
                {
                    //Debug.Log(rayhit.collider.name);
                    anim.SetBool("isJumping", false);
                    jumpCount = 2;
                }
            }
        }

        /*Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;*/
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log("충돌");

        // 스테이지 이동(포탈 종류에 따라)
        portal = collision.gameObject.GetComponent<Portal>();

        //rigid.velocity.y < 1
        //Input.GetKeyDown(KeyCode.Z)
        if (collision.gameObject.layer == 10 && rigid.velocity.y < 0)
        {
            switch (portal.type)
            {
                // 일반 교실 IN
                case "InClass":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "InClass2f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "InClass3f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "InClass4f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "InClass5f":
                    DoorPortalPlayerReposition(portal.type);
                    break;

                    // 특정 교실 IN
                case "InArtRoom":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "InMusicRoom":
                    DoorPortalPlayerReposition(portal.type);
                    break;

                // 일반 교실 OUT
                case "OutClass":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "OutClass2f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "OutClass3f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "OutClass4f":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "OutClass5f":
                    DoorPortalPlayerReposition(portal.type);
                    break;

                    // 특정 교실 OUT
                case "OutArt":
                    DoorPortalPlayerReposition(portal.type);
                    break;
                case "OutMusic":
                    DoorPortalPlayerReposition(portal.type);
                    break;


                // 층 이동 포탈(위로)
                case "Go2f":
                    Vector3 Go2F = portal.portal.transform.position;
                    Vector3 Pos2f = new Vector3(Go2F.x - 3f, Go2F.y, Go2F.z);
                    transform.position = Pos2f;
                    break;
                case "Go3f":
                    Vector3 Go3F = portal.portal.transform.position;
                    Vector3 Pos3f = new Vector3(Go3F.x - 3f, Go3F.y, Go3F.z);
                    transform.position = Pos3f;
                    break;
                case "Go4f":
                    Vector3 Go4F = portal.portal.transform.position;
                    Vector3 Pos4f = new Vector3(Go4F.x -3f, Go4F.y, Go4F.z);
                    transform.position = Pos4f;
                    break;
                case "Go5f":
                    Vector3 Go5F = portal.portal.transform.position;
                    Vector3 Pos5f = new Vector3(Go5F.x - 3f, Go5F.y, Go5F.z);
                    transform.position = Pos5f;
                    break;

                // 층 이동 포탈(아래로)
                case "Down2f":
                    Vector3 Down2F = portal.portal.transform.position;
                    Vector3 PosDown2f = new Vector3(Down2F.x + 3f, Down2F.y, Down2F.z);
                    transform.position = PosDown2f;
                    break;
                case "Down3f":
                    Vector3 Down3F = portal.portal.transform.position;
                    Vector3 PosDown3f = new Vector3(Down3F.x + 3f, Down3F.y, Down3F.z);
                    transform.position = PosDown3f;
                    break;
                case "Down4f":
                    Vector3 Down4F = portal.portal.transform.position;
                    Vector3 PosDown4f = new Vector3(Down4F.x + 3f, Down4F.y, Down4F.z);
                    transform.position = PosDown4f;
                    break;
                case "Down5f":
                    Vector3 Down5F = portal.portal.transform.position;
                    Vector3 PosDown5f = new Vector3(Down5F.x + 3f, Down5F.y, Down5F.z);
                    transform.position = PosDown5f;
                    break;
            }
        }

    }

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }

    void DoorPortalPlayerReposition(string type)
    {
        Vector3 classRoom = portal.portal.transform.position;
        Vector3 classPos = new Vector3(classRoom.x + 4f, classRoom.y, classRoom.z);
        gameManager.NextStage(classPos, type);
    }

}
