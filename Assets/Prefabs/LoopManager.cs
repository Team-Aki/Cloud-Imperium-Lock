using System.Collections;
using System.Collections.Generic;
using System;
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

    private int firstDoor = 0;

    private bool doorTriggeredLastFrame = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    //There is a critical bug that prevents the player to advance if they fail
    //activeDoor-- is called every frame, it goes to 0 on single fail

    // Update is called once per frame
    void Update()
    {
       
        if (doors[activeDoor].GetComponent<DoorManager>().state == DoorManager.State.closed)
        {
            doorTriggeredLastFrame = false;
            doors[activeDoor].GetComponent<DoorManager>().lockObject.SetActive(true);
            Debug.Log("active door " + activeDoor);
        }
        else if (doors[activeDoor].GetComponent<DoorManager>().state == DoorManager.State.open)
        {
            if (!doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().isPlaying && !doorTriggeredLastFrame)
            {
                Debug.Log("active door 2nd check" + activeDoor);
                doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().clip = doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().GetClip("Open");
                doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().Play();
                doors[activeDoor].GetComponent<DoorManager>().lockObject.SetActive(false);
                //activeDoor++;
            }
            else if (!doors[activeDoor].GetComponent<DoorManager>().doorObject.GetComponent<Animation>().isPlaying)
            {
                Debug.Log("active door 3rd check" + activeDoor);
                doors[activeDoor].GetComponent<DoorManager>().ResetLock();
                activeDoor++;
            }

            doorTriggeredLastFrame = true;
        }
        
        if (doors[activeDoor].GetComponent<DoorManager>().codeExpired)
        {
            doors[activeDoor].GetComponent<DoorManager>().ResetLock();
            doors[activeDoor].GetComponent<DoorManager>().lockObject.SetActive(false);

            Debug.Log("active door back " + activeDoor);

            //activeDoor--;

            Debug.Log("active door back after " + activeDoor);


            /*if (activeDoor == 3)
                activeDoor = firstDoor;
            else if (activeDoor == 2)
                activeDoor = 2;
            else if (activeDoor == 1)
                activeDoor = 1;
            else*/
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
