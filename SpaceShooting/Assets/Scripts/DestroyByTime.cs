/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 按指定时间销毁游戏对象
 * 
 * Description:
 *      具体作用：
 *      1、按指定时间销毁游戏对象
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float floDestroyTime = 4f;
    private float _floCurrentTime;

    void Update()
    {
        _floCurrentTime += Time.deltaTime;
        if (_floCurrentTime >= floDestroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
