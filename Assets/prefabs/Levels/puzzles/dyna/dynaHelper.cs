using UnityEngine;
using System.Collections;

public class dynaHelper : MonoBehaviour {

    public bool Flipped;

    private void OnCollisionEnter(Collision other)
    {
       if(!Flipped && other.collider.CompareTag("Player") && transform.parent.GetComponent<dynaController>().Playing)
        {
            dynaController d = transform.parent.GetComponent<dynaController>();
            flip();
            d.CheckedVal = GetComponent<ValHolder>().Val;
            d.LastBlockPos = transform.localPosition;
            d.Invoke("CheckNum", .3f);
            d.Playing = false;
        }
    }

    public void flip()
    {
        Flipped = !Flipped;
        RotateIt r = gameObject.AddComponent<RotateIt>();
        r.Rot = new Vector3(0, 0, 180 * 4);
        r.Speed = 4f;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
