using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherCollision : MonoBehaviour
{
    public Canvas miniTest1;
    public Canvas miniTest2;
    
    bool inTrigger1 = false;
    bool inTrigger2 = false;
    
    void Start()
    {
        GameObject tempObject1 = GameObject.Find("MiniGame1");
        if (tempObject1 != null) {
            miniTest1 = tempObject1.GetComponent<Canvas>();}
        
        GameObject tempObject2 = GameObject.Find("MiniGame2");
        if (tempObject2 != null) {
            miniTest2 = tempObject2.GetComponent<Canvas>();}
    }
    

    void OnTriggerEnter2D(Collider2D teacher) {
    if (teacher.gameObject.tag=="TeacherCollider"){
        if (teacher.gameObject.name=="TeacherColliderOne"){
        inTrigger1 = true;}
        if (teacher.gameObject.name=="TeacherColliderTwo"){
        inTrigger2 = true;}
    }
    }
        
    void OnTriggerExit2D(Collider2D teacher) {
    if (teacher.gameObject.tag=="TeacherCollider"){
        if (teacher.gameObject.name=="TeacherColliderOne"){
        inTrigger1 = false;}
        if (teacher.gameObject.name=="TeacherColliderTwo"){
        inTrigger2 = false;}
    }
    }
        
    void FixedUpdate () {
    if(inTrigger1 && Input.GetKeyDown("e")){
        //Debug.Log("You Started The First MiniGame!");
        miniTest1.gameObject.SetActive (true);}
    if(inTrigger2 && Input.GetKeyDown("e")){
    //Debug.Log("You Started The Second MiniGame!");
    miniTest2.gameObject.SetActive (true);}

    // Doesn't need to be next to teacher to exit minigame as movement not locked during quizz.    
    if(Input.GetKeyDown("space")){
        //Debug.Log("You Left The MiniGame!");
        miniTest1.gameObject.SetActive (false);
        miniTest2.gameObject.SetActive (false);}
    }

}