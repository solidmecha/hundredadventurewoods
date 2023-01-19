using UnityEngine;
using System.Collections;

public class NupPiece : MonoBehaviour {

    bool moving;
    public bool Gold;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !moving)
        {
            moving = true;
           TranslateIt t= gameObject.AddComponent<TranslateIt>();
            Vector3 v = transform.position - GameControl.singleton.Players[GameControl.singleton.ActivePlayerIndex].transform.position;
            if (v.x * v.x > v.z * v.z)
                v = new Vector3(v.x, 0, 0);
            else
                v = new Vector3(0, 0, v.z);
            t.Dest = transform.position + v * 20;
            t.Speed = 1;
        }
        else if(moving)
        {
            Destroy(GetComponent<TranslateIt>());
            moving = false;
            transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x/2f)*2, transform.localPosition.y, Mathf.Round((transform.localPosition.z-1)/2f)*2f+1);
            if (Gold && Vector3.SqrMagnitude(transform.localPosition - Vector3.forward) < .1f)
                GameControl.singleton.SpawnHoney(WorldBuilder.singleton.WorldPosition[0] - 1);
;        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
