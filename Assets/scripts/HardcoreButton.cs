using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardcireButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.position -= new Vector3(0, 0.1f, 0);
    }

    private void OnMouseUp()
    {
        transform.position += new Vector3(0, 0.1f, 0);
        SceneManager.LoadScene("HardcoreMode");
    }
}
