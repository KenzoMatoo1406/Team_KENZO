using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float speed = 5f;
    void Start()
    {
        // Solo la c�mara del jugador local debe seguirlo
        if (photonView.IsMine)
        {
            Camera mainCam = Camera.main;
            mainCam.transform.SetParent(transform);

            // Posici�n para tercera persona
            mainCam.transform.localPosition = new Vector3(0, 1.5f, -3f); // ajusta a gusto
            mainCam.transform.localRotation = Quaternion.Euler(10f, 0f, 0f);
        }
    }
    private void Update()
    {
        // Solo el jugador due�o de este objeto puede moverlo
        if (!photonView.IsMine)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
