using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherCollision : MonoBehaviour
{
    public Canvas miniTest;
    
    bool inTrigger = false;
    
    void Start()
    {
        GameObject tempObject = GameObject.Find("MiniGame");
        if (tempObject != null) {
            miniTest = tempObject.GetComponent<Canvas>();}
            }
    
    void OnTriggerEnter2D(Collider2D teacher) {
    if (teacher.gameObject.tag=="TeacherCollider"){
        inTrigger = true;
        }
        }
        
    void OnTriggerExit2D(Collider2D teacher) {
    if (teacher.gameObject.tag=="TeacherCollider"){
        inTrigger = false;
        }
        }
        
    void FixedUpdate () {
    if(inTrigger && Input.GetKeyDown("e")){
                //Debug.Log("You Started The MiniGame!");
                miniTest.gameObject.SetActive (true);
                }

            // Doesn't need to be next to teacher to exit minigame as movement not locked during quizz.    
    if(Input.GetKeyDown("space")){
                //Debug.Log("You Left The MiniGame!");
                miniTest.gameObject.SetActive (false);
                }
                }

}