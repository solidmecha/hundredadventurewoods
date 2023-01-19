using UnityEngine;
using System.Collections;

public class NupBuilder : MonoBehaviour {

    void MakeBoard()
    {
        int w = GameControl.singleton.RNG.Next(12);
        int a = -6;
        int b = -4;
        int d = -2;
        int c = -5;

        for(int i=0;i<w;i++)
        {
           GameObject g= Instantiate(transform.parent.GetChild(0).gameObject, transform.parent)as GameObject;
            int x = 0;
            int y = 1;
            while ((x == 0 && y == 1)|| (x==a & y==c) || (x==b && y==c) || (x==d && y==c))
            {
                x = GameControl.singleton.RNG.Next(-3, 4);
                y = GameControl.singleton.RNG.Next(-3, 3);
            }
            g.transform.localPosition = new Vector3(x*2, transform.parent.GetChild(0).position.y, y*2+1);

        }
    }

	// Use this for initialization
	void Start () {
        MakeBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
