using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D rb;

	private float minimunVelocityX = 1f;
	private float maxiumVelocityX = 4f;

	private float minimunVelocityY = -2f;
	private float maxiumVelocityY = 2.5f;

	private float velocityXValue;
	private float velocityYValue;

	public event Action<int> onPlayerPassPipe;

	private int score = 0;
	private const string ScorePlayerPrefsName = "Score";


	[SerializeField] private float jumpForce;
	[SerializeField] private float jumpForceMultiplier;
	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update() {
		velocityXValue = Mathf.Clamp((rb.velocity.x), minimunVelocityX, maxiumVelocityX);

		rb.velocity = new Vector2(velocityXValue, rb.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(Vector2.up * jumpForce * jumpForceMultiplier * Time.deltaTime, ForceMode2D.Impulse);
			velocityYValue = Mathf.Clamp((rb.velocity.y), minimunVelocityY, maxiumVelocityY);
			rb.velocity = new Vector2(velocityXValue, velocityYValue);
		}

	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.transform.parent.tag.Contains("Pipe")) {
			score++;
			onPlayerPassPipe?.Invoke(score);
			Destroy(collision.transform.parent.gameObject, 0.7f);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.parent.tag.Contains("Pipe")) {

			PlayerPrefs.SetInt(ScorePlayerPrefsName, score);

			Debug.LogError("GameOver");

		}
	}
}
