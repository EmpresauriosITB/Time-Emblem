using UnityEngine;

public static class MenuManager
{

    public static bool IsInitialised { get; private set; }
    public static GameObject startMenu, settingsMenu, gameMenu, statsMenu, actionsMenu, dragMenu;
    private static GameObject character;
    private static BattleManager bm;


    public static void MoveClicked() {
        character.GetComponent<Unit>().MoveNextTile();
    }

    public static void Init() {
        GameObject canva = GameObject.Find("MenuCanvas");
        startMenu = canva.transform.Find("MainMenu").gameObject;
        settingsMenu = canva.transform.Find("SettingMenu").gameObject;
        gameMenu = canva.transform.Find("GameMenu").gameObject;
        statsMenu = canva.transform.Find("StatsMenu").gameObject;
        actionsMenu = canva.transform.Find("ActionsMenu").gameObject;
        dragMenu = canva.transform.Find("Drag&Drop").gameObject;
        IsInitialised = true;
    }

    public static void SetBattleManager(BattleManager battle)
    {
        bm = battle;
    }

    public static BattleManager GetBattle()
    {
        return bm;
    }

    public static void OpenMenu (Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
        {
            Init();
        }
        switch (menu)
        {
            case Menu.Start_Menu:
                startMenu.SetActive(true);
                break;
            case Menu.Setting_Menu:
                settingsMenu.SetActive(true);
                break;
            case Menu.Game_Menu:
                gameMenu.SetActive(true);
                break;
            case Menu.Stats_Menu:
                statsMenu.SetActive(true);
                break;
            case Menu.Actions_Menu:
                actionsMenu.SetActive(true);
                actionsMenu.GetComponent<ActionsMenu>().bm = bm;
                break;
            case Menu.Deactivate_Menus:
                if (actionsMenu.GetComponent<ActionsMenu>().textController.DestroyTextHasSucribedEvents()) {
                    actionsMenu.GetComponent<ActionsMenu>().textController.DeleteTextItems();
                }
                startMenu.SetActive(false);
                settingsMenu.SetActive(false);
                gameMenu.SetActive(false);
                statsMenu.SetActive(false);
                actionsMenu.SetActive(false);
                dragMenu.SetActive(false);
                break;
            case Menu.Drag_Menu:
                dragMenu.SetActive(true);
                break;
        }
        if (callingMenu != null) callingMenu.SetActive(false);
    }
  

    public static void setCharacter(GameObject c)
    {
        character = c;
    }
    public static GameObject getCharacter()
    {
        return character;
    }




}
