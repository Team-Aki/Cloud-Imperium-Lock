using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject lockObject;
    [SerializeField]
    public GameObject doorObject;

    public enum State { open, closed }
    [SerializeField]
    public State state = State.closed;

    [SerializeField]
    public bool codeExpired = false;

    public enum Difficulty { easy, medium, hard, wtf }
    [SerializeField]
    public Difficulty difficulty;

    // Start is called before the first frame update
    void Start()
    {
        ResetLock();
    }

    // Update is called once per frame
    void Update()
    {
        //if (state == State.closed)
        //{
        //    if (!lockObject.GetComponent</*LOCK SCRIPT*/>().locked)
        //    {
        //        doorObject.GetComponent<Animator>().SetBool("open", true);
        //    }
        //    else
        //    {
        //        doorObject.GetComponent<Animator>().SetBool("open", false);
        //    }
        //}
        //else if(state == State.open)
        //{
        //    doorObject.GetComponent<Animator>().SetBool("open", true);
        //}
    }

    public void ResetLock()
    {
        //create a new lock based on the difficulty set above as a child of lockObject;

        state = State.closed;
        codeExpired = false;
    }
}
