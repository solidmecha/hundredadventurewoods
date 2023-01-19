using UnityEngine;
using System.Collections;

public class PuzzraphVertex : MonoBehaviour {

    public bool justSwapped;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(GameControl.singleton.ActivePlayerIndex==0)
            {
                if (transform.parent.GetComponent<PuzzraphControl>().Selected == null && !justSwapped)
                {
                    transform.parent.GetComponent<PuzzraphControl>().Selected = gameObject;
                    GetComponent<Renderer>().material = transform.parent.GetComponent<PuzzraphControl>().Mats[2];
                }
                else if(!justSwapped)
                {
                    Vector3 v = transform.parent.GetComponent<PuzzraphControl>().Selected.transform.position;
                    transform.parent.GetComponent<PuzzraphControl>().Selected.transform.position = transform.position;
                    transform.position = v;
                    transform.parent.GetComponent<PuzzraphControl>().Selected.GetComponent<Renderer>().material = transform.parent.GetComponent<PuzzraphControl>().Mats[0];
                    transform.parent.GetComponent<PuzzraphControl>().Selected.GetComponent<PuzzraphVertex>().justSwapped = true;
                    transform.parent.GetComponent<PuzzraphControl>().Selected = null;
                }
            }
            else
            {
                transform.Rotate(new Vector3(0, 90, 0));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (justSwapped && other.CompareTag("Player"))
        {
            justSwapped = false;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
