using UnityEngine;
using System.Collections;

public class DicerScript : MonoBehaviour {

	public int Val;
    public bool Checked;
    public bool Scored;

	// Use this for initialization
	void Start () {	
	
	}

	public void ShowPips()
	{
        DicerControl DC = transform.parent.GetComponent<DicerControl>();
        switch (Val)
        {
            case 1:
                Instantiate(DC.pip, transform.position + Vector3.up * 0.5f, Quaternion.identity, transform);
                break;
            case 2:
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, -.32f), Quaternion.identity, transform);
                break;
            case 3:
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + Vector3.up * 0.5f, Quaternion.identity, transform);
                break;
            case 4:
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, -.32f), Quaternion.identity, transform);
                break;
            case 5:
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + Vector3.up * 0.5f, Quaternion.identity, transform);
                break;
            case 6:
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, .32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, -.32f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(-.32f, .5f, 0f), Quaternion.identity, transform);
                Instantiate(DC.pip, transform.position + new Vector3(.32f, .5f, 0f), Quaternion.identity, transform);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
