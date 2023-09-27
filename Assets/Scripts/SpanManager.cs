using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanManager : MonoBehaviour
{

	[SerializeField] private Transform[] spanLocations;
	[SerializeField] private Transform[] cloudSpanLocations;
	[SerializeField] private GameObject pipe;
	[SerializeField] private GameObject[] clouds;

	Vector2 screenWorldSize;
	[SerializeField] private float spanInterval = 2f;
	private float pipeSpanTime = 0f;
	private float cloudSpanTime = 0f;
	private Vector2 locationToSpanObject;



	// Start is called before the first frame update
	void Start() {
		screenWorldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


		Vector2 spanerPositionOffSetValue = new Vector2(1f, 0.3f);
		screenWorldSize += spanerPositionOffSetValue;

		spanLocations[0].position = screenWorldSize;
		spanLocations[1].position = new Vector2(screenWorldSize.x,-screenWorldSize.y);

		float cloudSpanerPositionOffSetValue = 1.5f;
		foreach (var cloudTransform in cloudSpanLocations) {

			cloudTransform.position = new Vector3(screenWorldSize.x + cloudSpanerPositionOffSetValue , 0, 0);
		}
	}

	// Update is called once per frame
	void Update() {

		if(Time.time > pipeSpanTime + spanInterval) {

			pipeSpanTime = Time.time;
			int locationSelected = Random.Range(0, 2);
			float yAxisScaleValueOfPipe = Random.Range(0.8f, 1.46f);
			locationToSpanObject = spanLocations[locationSelected].position;
			
			if(locationSelected == 1) {

				Instantiate(pipe, locationToSpanObject, Quaternion.identity).transform.localScale = new Vector3(1, yAxisScaleValueOfPipe, 1);
			} else {

				Instantiate(pipe, locationToSpanObject, Quaternion.identity).transform.localScale = new Vector3(1, -yAxisScaleValueOfPipe, 1);
			}

        }
		if(Time.time > cloudSpanTime + Random.Range(1.0f,2.0f) ){

			cloudSpanTime = Time.time;

			foreach (var cloudTransform in cloudSpanLocations) {
				float cloudYaxixValue = Random.Range(0, screenWorldSize.y) - 0.5f;
				cloudTransform.position = new Vector3(cloudTransform.position.x, cloudYaxixValue, 0);

				GameObject cloud = Instantiate(clouds[Random.Range(0,3)], cloudTransform.position, Quaternion.identity);

				Destroy(cloud, 6f);
			}
		}
	}
}
