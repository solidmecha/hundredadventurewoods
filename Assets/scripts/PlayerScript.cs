using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed;
    bool inJump;
    float[] jumpTime;
    public float jumpforce;

    // Use this for initialization
    void Start() {
        jumpTime = new float[2];
        jumpTime[1] = .5f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
        }
    }
    public void StepForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    bool isGrounded()
    {
        return true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameControl.singleton.CurrentState != GameControl.GameState.inFX)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, -45, 0);
                StepForward();
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 45, 0); StepForward();
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, -135, 0); StepForward();
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 135, 0); StepForward();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.localEulerAngles = Vector3.zero; StepForward();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.localEulerAngles = new Vector3(0, -90, 0); StepForward();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.localEulerAngles = new Vector3(0, -180, 0); StepForward();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.localEulerAngles = new Vector3(0, 90, 0); StepForward();
            }


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpforce * 3f), ForceMode.Impulse);
                inJump = true;
                jumpTime[0] = 0;
            }
            else if (inJump && (Input.GetKey(KeyCode.Space)) && jumpTime[0] < jumpTime[1])
            {
                jumpTime[0] += Time.deltaTime;
                GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpforce * 3f));
            }
            else
            {
                inJump = false;
                jumpTime[0] = 0;
            }
        }
    }

}
