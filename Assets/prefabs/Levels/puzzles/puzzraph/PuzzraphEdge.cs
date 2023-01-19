using UnityEngine;
using System.Collections;

public class PuzzraphEdge : MonoBehaviour {

    public bool Solved;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal") && transform.parent.parent.parent.GetComponent<PuzzraphControl>().playing)
        {
            Solved = true;
            GetComponent<Renderer>().material = transform.parent.parent.parent.GetComponent<PuzzraphControl>().Mats[1];
            transform.parent.parent.parent.GetComponent<PuzzraphControl>().CheckSolve();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("goal"))
        {
            Solved = false;
            GetComponent<Renderer>().material = transform.parent.parent.parent.GetComponent<PuzzraphControl>().Mats[0];
        }
    }

    private void Start()
    {
        
    }
}
