using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        //ดึง component มาเก็บไว้ในตัวแปร agent
        agent = GetComponent<NavMeshAgent>();
        // ห้ามให้อกเจนต์หมุนตัว เพราะจะไปตีกับ code ตัวละครของเรา (ในเกม 2d เราจะเขียนให้หันซ้ายขวาเอง)
        agent.updateRotation = false;
        // ห้ามให้อกเจนต์หมุนตัวแกนตั้ง ง่ายๆคือมันจะทำให้ตัวละครหมุนจนกล้องมองไม่เห็น
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //สั่งให้ตัว agent/ตัวละคร เดินตามทางที่ Bake ไว้ไปยัง target
        agent.SetDestination(target.position);
    }
}
