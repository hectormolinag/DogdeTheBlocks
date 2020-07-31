using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float speed = 15f;
	[SerializeField] float MapWidht = 5f;

    private Rigidbody2D rb2D;

	private void Start()
	{
        rb2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        Vector2 newPos = rb2D.position + Vector2.right * x;

        newPos.x = Mathf.Clamp(newPos.x, -MapWidht, MapWidht);

        rb2D.MovePosition(newPos);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Score"))
        {
            GameManager._instance.AddScore();
            Destroy(collision.gameObject);
        }
        else
        {
            GameManager._instance.EndGame();
            GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
