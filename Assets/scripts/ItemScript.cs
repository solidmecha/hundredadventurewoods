using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public int ItemID;


    private void OnDestroy()
    {
        switch(ItemID)
        {
            case 0:
                GameControl.singleton.GetComponent<MessageControl>().ShowMessage("'Space' to use as Piglet", 3f);
                GameControl.singleton.Invoke("MsgControls", 3f);
                GameControl.singleton.Players[0].GetComponent<SwordSwing>().Sword = GameControl.singleton.Swords[0];
                break;
            case 1:
                GameControl.singleton.HoneyCount++;
                GameControl.singleton.GetComponent<MessageControl>().ShowMessage(GameControl.singleton.HoneyCount.ToString()+" Honey found!", 3f);
                break;
            case 2:
                GameControl.singleton.GetComponent<MessageControl>().ShowMessage("Sword upgraded!", 3f);
                GameControl.singleton.Players[0].GetComponent<SwordSwing>().Sword = GameControl.singleton.Swords[1];
                break;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
