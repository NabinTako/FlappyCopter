using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    private Player player;

	private const string playerGameObjectName = "Player";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerGameObjectName).GetComponent<Player>();
        scoreText.text = $"Score: {0}";
		player.onPlayerPassPipe += Player_onPlayerPassPipe;
    }

	private void Player_onPlayerPassPipe(int score) {
        if(scoreText != null) {

            scoreText.text = $"Score: {score}";
        }
	}
}
