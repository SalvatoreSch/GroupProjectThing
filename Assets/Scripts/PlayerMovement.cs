using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public static float speed = 7f;
    public GameObject player;
    public SpriteRenderer newPlayerShape;
    public SpriteRenderer playerSprite;
    public static SpriteRenderer[] spriteSelection;
    public GameObject oldPlayer;
    public Transform oldPlayerTransform;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }


    void Movement()
    {
        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= speed * Time.deltaTime;
        }
        transform.position += (Vector3)moveDirection;

        if (Input.GetKey(KeyCode.Space))
        {
            NewPlayerShape();
        }

    }

    //0 square, 1 diamond, 2 hexagon, 3 circle, 4 Capsule

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement playerMovement = collision.collider.gameObject.GetComponent<PlayerMovement>();
        if (collision.collider.CompareTag("Coin"))
        {
            //if (collision.gameObject.name == "Square")
            //{
            //    newPlayerShape = spriteSelection[0];
            //}
            //if (collision.gameObject.name == "Isometric Diamond")
            //{
            //    newPlayerShape = spriteSelection[1];
            //}
            //if (collision.gameObject.name == "Hexagon Pointed-Top")
            //{
            //    newPlayerShape = spriteSelection[2];
            //}
            //if (collision.gameObject.name == "Coin")
            //{
            //    newPlayerShape = spriteSelection[3];
            //}
            //if (collision.gameObject.name == "Capsule")
            //{
            //    newPlayerShape = spriteSelection[4];
            //}

            Destroy(collision.gameObject);
            GameManager.CoinCollected();
        }
    }
    public void NewPlayerShape()
    {
        if (GameManager.coolDown == false)
        {
            GameManager.coolDown = true;
            oldPlayer = player;
            oldPlayerTransform = player.transform;
            playerSprite.sprite = newPlayerShape.sprite;

           //ew WaitForSeconds(2);

           //nstantiate(oldPlayer, new Vector3(Random.Range(_xMinPos, xMaxPos), Random.Range(_yMinPos, _yMaxPos), 0), Quaternion.Euler(0, 0, 0));


        }
    }

}