using UnityEngine;
using System.Collections;

public class DicerMover : MonoBehaviour {
    public int index;
    public int MoveID;

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(MoveID) {
                case 0:
                    transform.parent.GetComponent<DicerControl>().VerticalMoveUp(index);
                    break;
                case 1:
                    transform.parent.GetComponent<DicerControl>().VerticalMoveDown(index);
                    break;
                case 2:
                    transform.parent.GetComponent<DicerControl>().HorizontalMoveLeft(index);
                    break;
                case 3:
                    transform.parent.GetComponent<DicerControl>().HorizontalMoveRight(index);
                    break;
            }
        }
    }
}
