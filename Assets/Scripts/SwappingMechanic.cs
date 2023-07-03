using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingMechanic : MonoBehaviour
{
    [SerializeField] private GameObject whiteCell;
    [SerializeField] private GameObject redCell;
    private GameObject currentCell;

    [SerializeField] private GameObject whiteCellLight; //light child of white cell 
    [SerializeField] private GameObject redCellLight;   //light child of red cell

    [SerializeField] private Camera mainCamera;
    private bool isWhiteCellActive;
    private void Start()
    {
        //white cell moving set to default
        whiteCell.GetComponent<PlayerController>().enabled = true;
        redCell.GetComponent<PlayerController>().enabled = false;

        //change following cell
        whiteCell.GetComponent<FollowCells>().enabled = false;
        redCell.GetComponent<FollowCells>().enabled = true;

        //change the active light
        whiteCellLight.SetActive(true);
        redCellLight.SetActive(false);


        isWhiteCellActive = true;
        currentCell = whiteCell;
    }
    void Update()
    {
        mainCamera.transform.position = new Vector3(currentCell.transform.position.x, currentCell.transform.position.y, -1);
        playerSwaps();
    }

    void playerSwaps()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Swap 
            if (isWhiteCellActive == true)
            {
                //turn to red
                whiteCell.GetComponent<PlayerController>().enabled = false;
                redCell.GetComponent<PlayerController>().enabled = true;

                //change following cell
                whiteCell.GetComponent<FollowCells>().enabled = true;
                redCell.GetComponent<FollowCells>().enabled = false;

                //change the active light
                whiteCellLight.SetActive(false);
                redCellLight.SetActive(true);

                //camera change
                currentCell = redCell;
                isWhiteCellActive = false;


            }
            else
            {
                //turn to white
                whiteCell.GetComponent<PlayerController>().enabled = true;
                redCell.GetComponent<PlayerController>().enabled = false;

                //change following cell
                whiteCell.GetComponent<FollowCells>().enabled = false;
                redCell.GetComponent<FollowCells>().enabled = true;

                //change the active light
                whiteCellLight.SetActive(true);
                redCellLight.SetActive(false);

                //camera change
                currentCell = whiteCell;
                isWhiteCellActive = true;

            }
        }
    }
}
