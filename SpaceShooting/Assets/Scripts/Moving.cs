/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 物体移动
 * 
 * Description:
 *      具体作用：
 *      1、负责特定道具(子弹、陨石、敌人)的移动控制
 *      2、在规定时间内，如果没有触发销毁则自动销毁
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 5f;
    public float floDestroyTime = 2f;
    private float _floCurrentTime;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }

    void Update()
    {
        _floCurrentTime += Time.deltaTime;
        if (_floCurrentTime >= floDestroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
