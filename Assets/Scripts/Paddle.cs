using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration paramaters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenHeightInUnits = 12f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 11f;
    [SerializeField] bool side;

    // cached referances
    GameSession theGameSession;
    ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<ball>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        if (side)
        {
            paddlePos.y = Mathf.Clamp(GetYPos(), minY, maxY);
        }
        else
        {
            paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        }
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    private float GetYPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.y;
        }
        else
        {
            return Input.mousePosition.y / Screen.height * screenHeightInUnits;
        }
    }
}