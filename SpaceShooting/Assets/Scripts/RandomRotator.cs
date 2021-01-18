/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 随机翻滚
 * 
 * Description:
 *      具体作用：
 *      1、使道具进行随机翻滚
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble = 1f;       //滚动数值

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitCircle * tumble;
    }
}
