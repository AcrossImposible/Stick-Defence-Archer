using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventsHolder
{

    public class PlayerSpawned : UnityEvent<Player> { }

    public static PlayerSpawned playerSpawnedMine = new PlayerSpawned();

    //-----------------------------------------------------------------------

    public class StickmanDestroyed : UnityEvent<Player> { }

    public static StickmanDestroyed onStickmanDestroyed = new StickmanDestroyed();

    //-----------------------------------------------------------------------

    public class BodyPartCollicion : UnityEvent<CollisionHandler, Collision2D> { }

    public static BodyPartCollicion onBodyPartCollicion = new BodyPartCollicion();

    //-----------------------------------------------------------------------
    public class BlockConnected : UnityEvent<GameObject> { }

    public static BlockConnected onBlockConnected = new BlockConnected();

    //-----------------------------------------------------------------------

    public class MissionComplete : UnityEvent { }

    public static MissionComplete onMissionComplete = new MissionComplete();

    //-----------------------------------------------------------------------

    public class MissionDefeat : UnityEvent { }

    public static MissionDefeat onMissionDefeat = new MissionDefeat();

    //-----------------------------------------------------------------------


    public class TileMined : UnityEvent<Mineable> { }

    public static TileMined onTileMined = new TileMined();

    //-----------------------------------------------------------------------

    public class PlayerSpawnedAny : UnityEvent<Player> { }

    public static PlayerSpawnedAny playerSpawnedAny = new PlayerSpawnedAny();

    //-----------------------------------------------------------------------

    public class LeftJoystickMoved : UnityEvent<Vector2> { }

    public static LeftJoystickMoved leftJoystickMoved = new LeftJoystickMoved();

    //-----------------------------------------------------------------------

    public class LeftJoystickUp : UnityEvent { }

    public static LeftJoystickUp onLeftJoystickUp = new LeftJoystickUp();

    //-----------------------------------------------------------------------

    #region    ============== GAME LOGIC ===================
    //         =============================================
    public class PlayerLayerChanged : UnityEvent<int> { }

    public static PlayerLayerChanged onPlayerLayerChanged = new PlayerLayerChanged();

    //-----------------------------------------------------------------------
    #endregion =============================================
    public class RightJoystickMoved : UnityEvent<Vector2> { }

    public static RightJoystickMoved rightJoystickMoved = new RightJoystickMoved();

    //-----------------------------------------------------------------------

    public class RightJoystickUp : UnityEvent { }

    public static RightJoystickUp rightJoystickUp = new RightJoystickUp();

    //-----------------------------------------------------------------------

    public class JumpClicked : UnityEvent { }

    public static JumpClicked jumpClicked = new JumpClicked();

    //-----------------------------------------------------------------------

    public class PunchClicked : UnityEvent { }

    public static PunchClicked onPunchClicked = new PunchClicked();

    //-----------------------------------------------------------------------


    public class WeaponPicked : UnityEvent<Player, Weapon> { }

    public static WeaponPicked weaponPicked = new WeaponPicked();

    //-----------------------------------------------------------------------

    public class WeaponThrowed : UnityEvent<Player, Weapon> { }

    public static WeaponThrowed weaponThrowed = new WeaponThrowed();

    //-----------------------------------------------------------------------

    public class WeaponTriggered : UnityEvent<Player, Weapon> { }

    public static WeaponTriggered weaponTriggered = new WeaponTriggered();

    //-----------------------------------------------------------------------

    public class WeaponTriggerExit : UnityEvent<Player, Weapon> { }

    public static WeaponTriggerExit weaponTriggerExit = new WeaponTriggerExit();

    //-----------------------------------------------------------------------

    public class PlayerKeepItem : UnityEvent<GameObject> { }

    public static PlayerKeepItem onPlayerKeepItem = new PlayerKeepItem();

    //-----------------------------------------------------------------------

    public class PlayerDropItem : UnityEvent { }

    public static PlayerDropItem onPlayerDropItem = new PlayerDropItem();

    //-----------------------------------------------------------------------

    public class MeleeStucked : UnityEvent<Melee> { }

    public static MeleeStucked onMeleeStucked = new MeleeStucked();

    //-----------------------------------------------------------------------

    public class WeaponSetInited : UnityEvent<WeaponSet> { }

    public static WeaponSetInited weaponSetInited = new WeaponSetInited();

    //-----------------------------------------------------------------------
    public class ObjectSpawned : UnityEvent<GameObject> { }

    public static ObjectSpawned onObjectSpawned = new ObjectSpawned();

    //-----------------------------------------------------------------------

    public class CritPunch : UnityEvent<Player> { }

    public static CritPunch onCritPunch = new CritPunch();

    //-----------------------------------------------------------------------

    public class MineModeSwitch : UnityEvent<bool> { }

    public static MineModeSwitch onMineModeSwitch = new MineModeSwitch();

    //-----------------------------------------------------------------------

    public class LeftControl : UnityEvent { }

    public static LeftControl onLeftControl = new LeftControl();

    //         =============================================
    

    //========================= UI ============================

    public class TileViewClick : UnityEvent<int> { }

    public static TileViewClick onTileViewClick = new TileViewClick();

    //-----------------------------------------------------------------------
    public class BuildEditorMode : UnityEvent<bool> { }

    public static BuildEditorMode onBuildEditorMode = new BuildEditorMode();

    //-----------------------------------------------------------------------

    public class BtnCamClicked : UnityEvent { }

    public static BtnCamClicked onBtnCamClicked = new BtnCamClicked();

    //-----------------------------------------------------------------------

    public class BtnNextLayer : UnityEvent { }

    public static BtnNextLayer onBtnNextLayer = new BtnNextLayer();

    //-----------------------------------------------------------------------

    public class BtnPrevLayer : UnityEvent { }

    public static BtnPrevLayer onBtnPrevLayer = new BtnPrevLayer();

    //-----------------------------------------------------------------------

    public class BtnShowPrevLayer : UnityEvent { }

    public static BtnShowPrevLayer onShowPrevLayer = new BtnShowPrevLayer();

    //-----------------------------------------------------------------------

}
