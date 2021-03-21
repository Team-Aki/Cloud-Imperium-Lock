using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCam;

    [SerializeField]
    private GameObject[] doors = new GameObject[4];

    [SerializeField]
    private Transform[] cameraPlacements = new Transform[4];

    [SerializeField]
    private int activeDoor = 0;

    private bool doorTriggeredLastFrame = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (doors[activeDoor].GetComponent<DoorManager>().state == DoorManager.State.closed)
        {
            doorTriggeredLastFrame = false;
        }
        else if (doors[activeDoor].GetComponent<DoorManager>().state == DoorManager.State.open)
        {
            if (!doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().isPlaying && !doorTriggeredLastFrame)
            {
                doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().clip = doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().GetClip("Open");
                doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().Play();
            }
            else if (!doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().isPlaying)
            {
                doors[activeDoor].GetComponent<DoorManager>().ResetLock();
                activeDoor++;
            }

            doorTriggeredLastFrame = true;
        }
        
        if (doors[activeDoor].GetComponent<DoorManager>().codeExpired)
        {
            doors[activeDoor].GetComponent<DoorManager>().ResetLock();
            activeDoor--;
        }

        if (activeDoor < 0)
            activeDoor = 0;
    }

    void LateUpdate()
    {
        mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, cameraPlacements[activeDoor].position, 0.2f);
        mainCam.transform.rotation = cameraPlacements[activeDoor].rotation;
    }
}
