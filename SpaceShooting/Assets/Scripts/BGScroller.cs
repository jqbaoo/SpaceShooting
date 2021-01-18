/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 背景卷轴
 * 
 * Description:
 *      具体作用：
 *      1、按照指定的速率进行移动,产生飞机移动效果
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float tileSize_Z = 1f;

    private Vector3 _startPosition;
	void Start () 
	{
        _startPosition = transform.position;
	}
	
	void Update () 
	{
        float tmp_NewPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize_Z);

        transform.position = _startPosition + Vector3.forward * tmp_NewPosition;
	}
}
