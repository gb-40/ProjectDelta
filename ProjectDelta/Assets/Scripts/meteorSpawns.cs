using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorSpawns : MonoBehaviour
{
public GameObject meteorPrefab; 
public int NumOfMetors  = 10; 
private float range = 45f; 
public int minSize; 
public int maxSize; 
private List<GameObject> meteors = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateMeteors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void  GenerateMeteors()
   {
        for (int i = 0; i < NumOfMetors; i++)
        {   //pick location
            Vector2 pos = new Vector3 (Random.Range(-range,range), Random.Range(-range,range),0);
            //pick size
            float size = Random.Range (minSize, maxSize); 
           // Debug.Log(size);
            //spawn metor
            GameObject meteor = Instantiate(meteorPrefab, pos, Quaternion.identity);
            //set size
            meteor.transform.localScale = new Vector3(size,size, 1);

            while(CheckOverLap(meteors,meteor))
            {
                pos = new Vector3 (Random.Range(-range,range), Random.Range(-range,range),0);
                meteor.transform.position = pos; 
            }
            meteors.Add(meteor);
        }
   }

   bool CheckOverLap(List<GameObject> meteors, GameObject newMeteor)
   {
    foreach ( GameObject m in meteors) 
    {
        float distance = Vector3.Distance(m.transform.position, newMeteor.transform.position);
        float minDistance = m.transform.localScale.x/2f + newMeteor.transform.localScale.x / 2f;

        if(distance<minDistance)
        {
            return true; 
        }
    }
    return false; 
   }
}



