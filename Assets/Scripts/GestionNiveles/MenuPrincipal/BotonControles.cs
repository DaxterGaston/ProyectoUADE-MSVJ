using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonControles : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Camera.main.transform.position = new Vector3(0, -3.50f, -10f);
    }
}
