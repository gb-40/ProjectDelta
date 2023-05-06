using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    public Transform cam; 
    //public ArenaController arena; 
    [SerializeField] GameObject backGroundStars;
    private float parallaxScale = 0.1f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Parallax();
        FollowPlayer();
    }

    void Parallax()
    {
        backGroundStars.transform.position = new Vector3(-transform.position.x, - transform.position.y*parallaxScale, backGroundStars.transform.position.z);
    }

    void FollowPlayer()
    {
        Vector3 pos = new Vector3(cam.position.x/2, cam.position.y/2, cam.position.z/2);
        transform.position = pos;
    }

   
   
}
