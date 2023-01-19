using UnityEngine;
using System.Collections;

public class multimemTile : MonoBehaviour {
   public bool flipped;
    public bool hasPineCone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && transform.parent.GetComponent<MultimemControl>().Playing && !flipped)
        {
            RotateIt r = gameObject.AddComponent<RotateIt>();
            r.Rot = new Vector3(0, 0, 360);
            r.Speed = 2;
            flipped = true;
            if (hasPineCone)
                transform.parent.GetComponent<MultimemControl>().IncFlipCount();
            else
                transform.parent.GetComponent<MultimemControl>().Reset();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
