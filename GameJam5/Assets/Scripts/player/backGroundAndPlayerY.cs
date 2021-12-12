using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundAndPlayerY : MonoBehaviour
{
    public GameObject player, backGroudn;
    private void Update()
    {
        backGroudn.transform.position = new Vector3(backGroudn.transform.position.x, player.transform.position.y, backGroudn.transform.position.z);
    }
}
