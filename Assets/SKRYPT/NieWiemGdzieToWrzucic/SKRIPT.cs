using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKRIPT : MonoBehaviour
{

    //SerializeField chyba sprawia,że można zmieniać wartości w Unity, nawet kiedy są private
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float maxspeed = 40f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private float crouchSpeed = 0.3f; 
    private bool m_Grounded;
    private Rigidbody2D m_Rb2D;
    private Transform m_GroundCheckA;
    private Transform m_GroundCheckB;
    private bool crouch;
    private bool facingRight;
    [SerializeField] private Animator animator;




    void Awake()
    {
        m_GroundCheckA = transform.Find("GroundCheckA");
        m_GroundCheckB = transform.Find("GroundCheckB");
        m_Rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //żeby ten kawałek kodu działał, postać musi mieć dwoje dzieci, GroundCheckA i GroundCheckB. Są one wierzchołkami prostokąta, który sprawdza, jakie są w nim collidery.
        //Jeśli w prostokącie jest więcej colliderów niż tylko postaci (tu jeden), to postać jest uziemiona.
        //m_WhatIsGround sprawdza, jakie warstwy są traktowane jako ziemia. Trzeba to ustawić w Unity.
        Collider2D[] colliders = Physics2D.OverlapAreaAll(m_GroundCheckA.position, m_GroundCheckB.position, m_WhatIsGround);
        if (colliders.Length > 1)
        {
            m_Grounded = true;
            animator.SetBool("IsJumping", false);
        }
        //wykonujemy ruch
        Move();

        //wracamy do stanu uziemionego (inaczej po jednym zetknięciu z ziemią zawsze bylibyśmy uziemieni
        m_Grounded = false;
    }
    public void Move()
    {
        float currentSpeed = m_Rb2D.velocity.x;
        //sprawdzamy, czy gracz wciska dół
        if (Input.GetKeyDown("down")) {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        //sprawdzamy czy wartość bezwzględna szybkości nie jest większa niż prędkość maksymalna
        if (Mathf.Abs(currentSpeed) < maxspeed)
        {
            //tworzymy nowy wektor poziomy
            Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal")*speed, 0);
            //dodajemy siłę do gracza. Ta struktura sprawdza wartość części przed znakiem zapytania. Jeśli "crouch" jest prawdą, mnożymy wektor przez "crouch speed" (dzieje się to co przed dwukropkiem)
            //jeśli "crouch" nie jest prawdą, po prostu dodajemy wektor(dzieje się to co po dwukropku)
            m_Rb2D.AddForce(crouch ? crouchSpeed * movementVector : movementVector);
            animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        }
        if ((currentSpeed > 0 && facingRight) || (currentSpeed < 0 && !facingRight))
        {
            Flip();
        } 
        //skaczemy
        if (Input.GetKeyDown("space") && m_Grounded)
        {
            m_Rb2D.AddForce(jumpForce * Vector2.up);
            animator.SetBool("IsJumping", true);
        }

        //ustawiamy kucanie na fałsz, bo inaczej nigdy byśmy nie wstali po kucnięciu
        if (Input.GetKeyUp("down")){
            crouch = false;
            animator.SetBool("IsCrouching", false);
        }

    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
}
 