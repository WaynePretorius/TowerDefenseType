using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tags
{

    //Animation States
    public static string ANIM_DEATH = "Die";
    public static string ANIM_ISATTACKING = "IsAttacking";
    public static string ANIM_ISDEAD = "isDead";
    public static string ANIM_TRIGGER_JUMPING = "JumpTrigger";

    //Tags
    public static string TAGS_ENEMY = "Enemy";
    public static string TAGS_DEFENDER = "Defender";
    public static string TAGS_SCARECROW = "ScareCrow";

    //Scene
    public static string SCENE_GAME_OVER = "GameOver";
    public static string SCENE_START_MENU = "StartScreen";
    public static string SCENE_OPTIONS_MENU = "Options";

    //Player Prefs
    public static string MASTER_VOLUME_KEY = "Master Volume";
    public static string DIFFICULTY_KEY = "Difficulty";

    //GameObjects
    public static string GAMOBJ_DEFENDER = "Defenders";
    public static string GAMEOBJ_BULLETS = "Projectiles";
}
