using UnityEngine;
using System.Collections;

public class RotateIt : MonoBehaviour {
    public Vector3 FinalAngles;
    public Vector3 Rot;
    public float Speed;
    public float counter;

	// Use this for initialization
	void Start () {
        counter = 1f / Speed;
        FinalAngles = transform.localEulerAngles + Rot * counter;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Rot * Time.deltaTime);
        counter -= Time.deltaTime;
        if(counter<=0)
        {
            transform.localEulerAngles = FinalAngles;
            Destroy(this);
        }
	}
}
