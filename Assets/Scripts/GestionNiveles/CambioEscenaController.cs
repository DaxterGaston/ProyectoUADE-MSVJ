using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaController : MonoBehaviour
{
    public void Ganaste()
    {
        SceneManager.LoadScene("Ganaste");
    }

    public void Perdiste()
    {
        SceneManager.LoadScene("Perdiste");
    }
}
