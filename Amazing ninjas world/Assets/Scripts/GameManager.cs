using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float respawnDelay = 1.5f;
    public PlayerController player;
    public Vector3 spawPosition;
    public CameraFollow cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);

        player.Enable();
        player.gameObject.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.transform.position = spawPosition;
        cam.ResetView();
    }
}
