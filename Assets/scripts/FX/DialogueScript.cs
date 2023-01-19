using UnityEngine;
using System;

public class DialogueScript : MonoBehaviour {

    public UnityEngine.UI.Text TextBox;
    public string[] Speech;
    public int index;

	// Use this for initialization
	void Start () {
	
	}

    void SpeechEnd()
    {
        GameControl.singleton.SetGameStatePlaying();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown && index<Speech.Length)
        {
            TextBox.text = Speech[index];
            index++;
            if (index == Speech.Length)
                SpeechEnd();
        }
	
	}
}
