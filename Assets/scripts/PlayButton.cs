using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject quitButton;
    
    private void OnMouseDown()
    {
        
        transform.position -= new Vector3(0, 0.1f, 0);
    }
    private void OnMouseUp()
    {
       
        transform.position += new Vector3(0, 0.1f, 0);
        gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);


    }
   
}
