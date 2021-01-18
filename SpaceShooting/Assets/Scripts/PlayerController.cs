/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 玩家控制
 * 
 * Description:
 *      具体作用：
 *      1、控制飞船移动
 *      2、发射子弹
 *      
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Boundary boundary;       
    public float tilt = 5f;         //旋转角度

    private Rigidbody _rb;
    private float _vertical;
    private float _horizontal;

    private float _nextFire = 0f;
    public float floFireRate = 0.5f;
    public GameObject BultPrefab;
    public Transform bultPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");


        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + floFireRate;
            Instantiate(BultPrefab, bultPosition.position, bultPosition.rotation);

            AudioManager.PlayAudioEffectB("weapon_player");
        }
    }

    void FixedUpdate()
    {
        Vector3 tmp_Move = new Vector3(_horizontal, 0, _vertical);
        if (_rb != null)
        {
            _rb.velocity = tmp_Move * moveSpeed;
            //限制刚体范围
            _rb.position = new Vector3(Mathf.Clamp(_rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(_rb.position.z, boundary.zMin, boundary.zMax));
            _rb.rotation = Quaternion.Euler(0.0f, 0.0f, -_rb.velocity.x * tilt);
        }
    }
}
