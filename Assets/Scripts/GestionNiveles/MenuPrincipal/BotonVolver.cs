using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVolver : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Camera.main.transform.position = new Vector3(0, 0, -10f);
    }
}
