using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        player.playerAnimator.SetBool("isLeftWall", player.isLeftWall);
    }
    public void setJumpTrigger()
    {
        player.playerAnimator.SetTrigger("jump");
    }
}
