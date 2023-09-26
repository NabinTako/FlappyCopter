using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] private Transform playerObject;

    Vector2 screenWorldSize;

	float cameraXAxisPositionOffSet = 6f;
	float playerXAxisPositionOffSet = 1f;

	private void Awake() {

		screenWorldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		playerObject.position = new Vector3(-screenWorldSize.x + playerXAxisPositionOffSet, 2, 0);

	}

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(playerObject.position.x + cameraXAxisPositionOffSet  , 0, -10);
	}
}
