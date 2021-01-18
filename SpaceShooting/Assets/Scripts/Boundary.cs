/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 边界控制
 * 
 * Description:
 *      具体作用：约束玩家飞机一直在可视范围内移动
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
}
