
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float fMaxPositionX = 4.0f; //�÷��̾ ��, �� �̵��� ���� â�� ����� �ʵ��� Vecter �ִ밪�� ���� ����
    float fMinPositionX = -4.0f; //�÷��̾ ��, �� �̵��� ���� â�� ����� �ʵ��� Vecter �ּڰ��� ���� ����
    float fPositionX = 0.0f; //�÷��̾ ��, �� �̵��� �� �ִ� X ��ǥ ���� ����

    //Cat ������Ʈ�� Rigidbody2D ������Ʈ�� ���� �������(m_)
    Rigidbody2D m_rigid2DCat = null;
    Animator m_animatorcat = null;
    //�÷��̾ ���� �� ���� ������ ����
    float fjumpForce = 380.0f;
    //�÷��̾� ��, ��� �����̴� ���ӵ�
    float fwalkForce = 20.0f;
    //�÷��̾��� �̵��ӵ��� ������ �ְ� �ӵ�
    float fmaxWalkSpeed = 2.0f;
    //�÷��̾� �¿� ������ Ű ��: ������ ȭ�� Ű -> 1,���� ȭ�� Ű -> 1, �������� ���� �� -> 0 
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
        // ����
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

            // �¿��̵�
            // �÷��̾ ���߰��ϴ� �ڵ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            nLeftRightKeyValue = 0;
        }
        // �÷��̾ ���������� �̵���Ű�� �ڵ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            nLeftRightKeyValue = 1;
        }
        // �÷��̾ �������� �̵���Ű�� �ڵ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nLeftRightKeyValue = -1;
        }
        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
        // m_rigid2DCat.AddForce(transform.right * fwalkForce * nLeftRightKeyValue);

        // �÷��̾� ���ǵ�
        float speedx = Mathf.Abs(m_rigid2DCat.linearVelocity.x);

        // ���ǵ� ����
        if (speedx < fmaxWalkSpeed)
        {
            m_rigid2DCat.AddForce(transform.right * fwalkForce * nLeftRightKeyValue );
        }
    
        // �����̴� ���⿡ ���� �����Ѵ�.
        if (nLeftRightKeyValue != 0)
        {
            transform.localScale = new Vector3(nLeftRightKeyValue, 1, 1);
        }
        // �÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        if (m_rigid2DCat.linearVelocity.y == 0)
        {
            m_animatorcat.speed = speedx / 2.0f;
        }
        else
        {
            m_animatorcat.speed = 1.0f;
        }
        // �÷��̾ ȭ�� ������ �����ٸ� ó������
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    // �� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}
