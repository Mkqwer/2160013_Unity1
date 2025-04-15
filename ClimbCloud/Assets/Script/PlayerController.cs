
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float fMaxPositionX = 4.0f; //플레이어가 좌, 우 이동시 게임 창을 벗어나지 않도록 Vecter 최대값을 설정 변수
    float fMinPositionX = -4.0f; //플레이어가 좌, 우 이동시 게임 창을 벗어나지 않도록 Vecter 최솟값을 설정 변수
    float fPositionX = 0.0f; //플레이어가 좌, 우 이동할 수 있는 X 좌표 저장 변수

    //Cat 오브젝트의 Rigidbody2D 컴포넌트를 갖는 멤버변수(m_)
    Rigidbody2D m_rigid2DCat = null;
    Animator m_animatorcat = null;
    //플레이어에 가할 힘 값을 저장할 변수
    float fjumpForce = 380.0f;
    //플레이어 좌, 우로 움직이는 가속도
    float fwalkForce = 20.0f;
    //플레이어의 이동속도가 지정한 최고 속도
    float fmaxWalkSpeed = 2.0f;
    //플레이아 좌우 움직임 키 값: 오른쪽 화살 키 -> 1,왼쪽 화살 키 -> 1, 움직이지 않을 떄 -> 0 
    int nLeftRightKeyValue = 0;
    //
    float fthreshold = 0.2f;
    void Start()
    {
        Application.targetFrameRate = 60;
        m_rigid2DCat = GetComponent<Rigidbody2D>();
        m_animatorcat = GetComponent<Animator>();
    }

    void Update()
    {
        // 점프
        if (Input.GetMouseButtonDown(0) && m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorcat.SetTrigger("JumpTrigger");
            m_rigid2DCat.AddForce(transform.up * fjumpForce);
        }
        if (Input.GetKey(KeyCode.Space) && m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorcat.SetTrigger("JumpTrigger");
            m_rigid2DCat.AddForce(transform.up * fjumpForce);
        }

            // 좌우이동
            // 플레이어를 멈추게하는 코드
        if (Input.GetKey(KeyCode.LeftShift))
        {
            nLeftRightKeyValue = 0;
        }
        // 플레이어를 오른쪽으로 이동시키는 코드
        if (Input.GetKey(KeyCode.RightArrow))
        {
            nLeftRightKeyValue = 1;
        }
        // 플레이어를 왼쪽으로 이동시키는 코드
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nLeftRightKeyValue = -1;
        }
        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
        // m_rigid2DCat.AddForce(transform.right * fwalkForce * nLeftRightKeyValue);

        // 플레이어 스피드
        float speedx = Mathf.Abs(m_rigid2DCat.linearVelocity.x);

        // 스피드 제한
        if (speedx < fmaxWalkSpeed)
        {
            m_rigid2DCat.AddForce(transform.right * fwalkForce * nLeftRightKeyValue );
        }
    
        // 움직이는 방향에 따라 반전한다.
        if (nLeftRightKeyValue != 0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1, 1);
        }
        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        if (m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorcat.speed = speedx / 2.0f;
        }
        else
        {
            m_animatorcat.speed = 1.0f;
        }
        // 플레이어가 화면 밖으로 나갔다면 처음부터
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    // 골 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
