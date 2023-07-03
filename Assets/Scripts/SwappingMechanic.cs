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

    //set tags
    GameObject[] virusTag;
    GameObject[] oxygenTag;


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

        
        HideOxygen();

        isWhiteCellActive = true;
        currentCell = whiteCell;
    }
    void Update()
    {
        mainCamera.transform.position = new Vector3(currentCell.transform.position.x, currentCell.transform.position.y, -1);
        PlayerSwaps();
    }

    void PlayerSwaps()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Swap 
            if (isWhiteCellActive == true)
            {
                //turn to cell red
                whiteCell.GetComponent<PlayerController>().enabled = false;
                redCell.GetComponent<PlayerController>().enabled = true;

                //change following cell
                whiteCell.GetComponent<FollowCells>().enabled = true;
                redCell.GetComponent<FollowCells>().enabled = false;

                //change the active light
                whiteCellLight.SetActive(false);
                redCellLight.SetActive(true);

                HideVirus();

                //camera change
                currentCell = redCell;
                isWhiteCellActive = false;


            }
            else
            {
                //turn cell to white
                whiteCell.GetComponent<PlayerController>().enabled = true;
                redCell.GetComponent<PlayerController>().enabled = false;

                //change following cell
                whiteCell.GetComponent<FollowCells>().enabled = false;
                redCell.GetComponent<FollowCells>().enabled = true;

                //change the active light
                whiteCellLight.SetActive(true);
                redCellLight.SetActive(false);

                HideOxygen();

                //camera change
                currentCell = whiteCell;
                isWhiteCellActive = true;

            }
        }
    }

    //method for hiding oxygen
    //ERRORS BELLOW
    void HideOxygen()
    {

        if (oxygenTag != null)
        {
            
            oxygenTag = GameObject.FindGameObjectsWithTag("Oxygen");

            //hide oxygen
            foreach (GameObject oxygen in oxygenTag)
            {
                oxygen.SetActive(false);
            }
        }

        if (virusTag != null)
        {
            virusTag = GameObject.FindGameObjectsWithTag("Virus");

            //hide oxygen
            foreach (GameObject virus in virusTag)
            {
                virus.SetActive(true);
            }
        }
    }

    //method for hiding 
    void HideVirus()
    {
        if (oxygenTag != null)
        {
            oxygenTag = GameObject.FindGameObjectsWithTag("Oxygen");

            //hide oxygen
            foreach (GameObject oxygen in oxygenTag)
            {
                oxygen.SetActive(true);
            }
        }

        if (virusTag != null)
        {
            virusTag = GameObject.FindGameObjectsWithTag("Virus");

            //hide oxygen
            foreach (GameObject virus in virusTag)
            {
                virus.SetActive(false);
            }
        }
    }
}
