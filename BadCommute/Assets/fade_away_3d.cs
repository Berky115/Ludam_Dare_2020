using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_away_3d : MonoBehaviour
{
      private Material mat;
     void Start () {
         mat = gameObject.GetComponent<MeshRenderer>().material;
     }
     
     void Update () {

         
     }

    void OnTriggerExit(Collider other) {
         fadeAway();
     }

         private IEnumerator fadeAway()
        {        
            
            while (mat.color.a > 0)
            {
                yield return null;
                Color newColor = mat.color;
                newColor.a -= Time.deltaTime;
                mat.color = newColor;
                gameObject.GetComponent<MeshRenderer>().material = mat;
            }
        }
}
