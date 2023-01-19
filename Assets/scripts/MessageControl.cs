using UnityEngine;
using System.Collections;

public class MessageControl : MonoBehaviour {

    public UnityEngine.UI.Text MsgText;

	// Use this for initialization
	void Start () {
	
	}

    public void ShowMessage(string m, float count)
    {
        MsgText.text = m;
        Invoke("ClearMessage", count);
    }

    public void ClearMessage()
    {
        MsgText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
