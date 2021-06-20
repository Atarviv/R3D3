using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerShoot : MonoBehaviour
{
    public Transform location;
    public GameObject laserPrafab;
    Animator ame;
    // Start is called before the first frame update
    void Start()
    {
        ame = GetComponent<Animator>();

        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            ame.SetBool("isShooting", true);
            }
        else ame.SetBool("isShooting", false);

        }
    public void Shoot()
        {
        Instantiate(laserPrafab, location.position, transform.rotation);
        }
}
