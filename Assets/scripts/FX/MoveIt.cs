using UnityEngine;
using System.Collections;

public class MoveIt : MonoBehaviour {

    public float Speed;
    public float counter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition+=(transform.forward*Speed* Time.deltaTime);
        counter -= Time.deltaTime;
        if (counter <= 0)
            Destroy(this);

	}
}
