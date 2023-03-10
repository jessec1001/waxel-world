using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor;
public class SchoolShow : BaseView
{
    [Space]
    [Header("Button Manage")]
    public GameObject UpdateButton;
    [Space]
    [Header("BlendAction")]
    public GameObject ProfessionBlendingPanel;
    public GameObject TopBlendButton;
    // public GameObject BlendPanel;
    public RawImage BlendPanelImage;
    public GameObject BlendButton;
    public TMP_Text BlendingInfoText;
    public TMP_Text BlendingTypeText;
    public TMP_Text BlendingUsesText;
    public TMP_Text BlendingCitizenText;
    public TMP_Text BlendingBooksText;

    [Space]
    [Header("Profession's Info")]
    public TMP_Text miner_count;
    public TMP_Text lumberjack_count;
    public TMP_Text farmer_count;
    public TMP_Text blacksmith_count;
    public TMP_Text carpenter_count;
    public TMP_Text tailor_count;
    public TMP_Text engineer_count;
    public GameObject ProfessionInfoPanel;
    public GameObject ProfessionShowPanel;
    public Transform ActionsPanel;
    public GameObject OneProfessionPrefab;
    public TMP_Text CountInfoText;
    public GameObject ProfessionEmptyPanel;
    public TMP_Text EmptyInfoText;
    [Space]
    [Header("Gatherer's Action")]
    public GameObject WorkSuccessPopup;
    public TMP_Text WorkTitle;
    public TMP_Text WorkResultText;
    public RawImage WorkResultImage;
    [Space]
    [Header("Gatherer's Item")]
    public GameObject ItemsPopup;
    public Transform ItemParent;
    public GameObject ProfessionItemPrefab;
    public GameObject EquipItemPopup;
    public Transform EquipableItemParent;
    public GameObject EquipItemPrefab;
    public GameObject PopupEquipButtonActive;
    public GameObject PopupEquipButtonInactive;

    public GameObject EmptyEquipItemPopup;
    [Space]
    [Header("Refiner Action")]
    public GameObject RefinePanel;
    public Transform RefineParent;
    public GameObject RefineMaterialPrefab;
    public GameObject RefineHelloInfo;
    public GameObject RefineActionInfo;
    public RawImage RefineMaterialImage;
    public RawImage RefinedMaterialImage;
    public TMP_Text RefineMaterialText;
    public TMP_Text RefinedMaterialText;
    public GameObject PopupRefineButton;
    public RefineDataModel[] refineData;
    [Space]
    [Header("Crafter Action")]
    public GameObject CraftPanel;
    public GameObject CraftBlackActionTop;
    public GameObject CraftEngineerActionTop;
    public GameObject CraftHelloInfo;
    public GameObject CraftActionSeries;
    public GameObject CraftActionInfo;
    public GameObject PopupCraftButton;
    public GameObject CraftMaterialPrefab;
    [Space]
    [Header("Upgrade Action")]
    public GameObject ProfessionPanelParent;
    public GameObject SettlementEmptyPopup;
    public TMP_Text SettlementEmptyTitleText;

    public TMP_Text SettlementEmptyInfoText;
    public GameObject OneSettlementPrefab;

    public TMP_Text profession_text;
    public TMP_Text details_text;
    public TMP_Text types_text;
    public TMP_Text citizens_text;
    public TMP_Text uses_text;
    public TMP_Text books_text;
    public TMP_Text name_text;

    public TMP_Text text_permission;
    public TMP_Text done_panel_text;

    public GameObject SettlementParentPanel;
    public GameObject SettlementChildPanel;
    public GameObject UnregisteredSettlementChildPanel;
    public GameObject SettlementTextPanel;
    public GameObject SettlementBuyBtn;
    public GameObject SettlementDeregButton;
    public GameObject RegisteredSettlementChildPanel;
    public GameObject NoForest_Text;
    public GameObject PermissionPanel;
    public GameObject DonePanel;

    public RawImage BlendingPanel_img;
    public RawImage done_panel_img;

    [Space]
    [Header("Data Models and Scripts")]
    public List<BlendingModel> BlendingData = new List<BlendingModel>();
    public ImgObjectView[] images;
    public AbbreviationsHelper helper;

    private List<ProfessionDataModel> Engineer = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> Miners = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> Farmers = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> Tailor = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> Carpenter = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> LumberJack = new List<ProfessionDataModel>();
    private List<ProfessionDataModel> Blacksmith = new List<ProfessionDataModel>();
    private List<SettlementsModel> Mine = new List<SettlementsModel>();
    private List<SettlementsModel> Forest = new List<SettlementsModel>();
    private List<SettlementsModel> Field = new List<SettlementsModel>();

    // setting the header
    public delegate void SetHeader();
    public static SetHeader onSetHeaderElements;

    protected override void Start()
    {
        base.Start();
        SetModels(MessageHandler.userModel.professions);
        SetSettlementsModel(MessageHandler.userModel.settlements);
        SetUIElements();
        MessageHandler.OnProfessionData += OnProfessionData;
        MessageHandler.OnCallBackData += OnCallBackData;
        MessageHandler.OnSettlementData += OnSettlementData;
        MessageHandler.OnTransactionData += OnTransactionData;
        MessageHandler.OnItemData += OnItemData;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        MessageHandler.OnProfessionData -= OnProfessionData;
        MessageHandler.OnCallBackData -= OnCallBackData;
        MessageHandler.OnSettlementData -= OnSettlementData;
        MessageHandler.OnTransactionData -= OnTransactionData;
        MessageHandler.OnItemData -= OnItemData;
    }

    private void SetModels(ProfessionDataModel[] professions)
    {
        foreach (ProfessionDataModel profess in professions)
        {
            if (profess.name == "Engineer")
            {
                Engineer.Add(profess);
            }
            else if(profess.name == "Tailor")
            {
                Tailor.Add(profess);
            }
            else if (profess.name == "Miner")
            {
                Miners.Add(profess);
            }
            else if (profess.name == "Blacksmith")
            {
                Blacksmith.Add(profess);
            }
            else if (profess.name == "Lumberjack")
            {
                LumberJack.Add(profess);
            }
            else if (profess.name == "Farmer")
            {
                Farmers.Add(profess);
            }
            else if (profess.name == "Carpenter")
            {
                Carpenter.Add(profess);
            }
        }
    }

    private void SetSettlementsModel(SettlementsModel[] settlements)
    {
        Mine.Clear();
        Forest.Clear();
        Field.Clear();

        foreach (SettlementsModel data in settlements)
        {
            switch (data.name)
            {
                case ("Mine"):
                    Mine.Add(data);
                    break;
                case ("Forest"):
                    Forest.Add(data);
                    break;
                case ("Field"):
                    Field.Add(data);
                    break;
                default:
                    break;
            }
        }
    }
    private void SetUIElements()
    {
        if (MessageHandler.userModel.account != null)
        {
            miner_count.text = "x" + Miners.Count.ToString();
            lumberjack_count.text = "x" + LumberJack.Count.ToString();
            farmer_count.text = "x" + Farmers.Count.ToString();
            blacksmith_count.text = "x" +Blacksmith.Count.ToString();
            carpenter_count.text = "x" + Carpenter.Count.ToString();
            tailor_count.text = "x" + Tailor.Count.ToString();
            engineer_count.text = "x" + Engineer.Count.ToString();
            // var obj = GameObject.Find("Selected_Item_GB(Clone)");
            // if (obj != null)
            // {
            //     helper.add_items();
            //     string item_name = obj.gameObject.GetComponent<ItemSelectedModel>().item_selected;
            //     ProfessionNftBtn(helper.equip_items_abv[item_name]);
            //     Destroy(obj); 
            // }
        }
    }
    public void TopBlendButtonClick(string type)
    {
        ProfessionInfoPanel.SetActive(false);
        ProfessionShowPanel.SetActive(false);
        ProfessionEmptyPanel.SetActive(false);
        ProfessionBlendingPanel.SetActive(true);
        for (int j = 0; j < images.Length; j++)
        {
            if (images[j].name == type)
            {
                BlendPanelImage.texture = images[j].img;  
                break;
            }
        }
        foreach (BlendingModel m in BlendingData)
        {
            if(m.profession == type)
            {
                BlendingInfoText.text = m.info;
                BlendingTypeText.text = m.types;
                BlendingUsesText.text = m.uses;
                BlendingCitizenText.text = m.citizens;
                BlendingBooksText.text = m.books;
                break;
            }
        }
        BlendButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { BlendButtonClick(type); });

    }
    public void BlendButtonClick(string type)
    {

    }
    public void ProfessionButtonClick(string type)
    {
        ProfessionInfoPanel.SetActive(false);
        ProfessionBlendingPanel.SetActive(false);
        ProfessionPanelParent.GetComponent<ProfessionUpgradeIndex>().upgrade_indexer = type;
        TopBlendButton.SetActive(true);
        TopBlendButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { TopBlendButtonClick(type); });
        switch (type)
        {
            case "Miner":
                UpdateButton.SetActive(true);
                SetProfessions(Miners, type);
                break;
            case "Lumberjack":
                UpdateButton.SetActive(true);
                SetProfessions(LumberJack, type);
                break;
            case "Farmer":
                UpdateButton.SetActive(true);
                SetProfessions(Farmers, type);
                break;
            case "Engineer":
                SetProfessions(Engineer, type);
                UpdateButton.SetActive(false);
                break;
            case "Carpenter":
                UpdateButton.SetActive(false);
                SetProfessions(Carpenter, type);
                break;
            case "Tailor":
                UpdateButton.SetActive(false);
                SetProfessions(Tailor, type);
                break;
            case "Blacksmith":
                UpdateButton.SetActive(false);
                SetProfessions(Blacksmith, type);
                break;
            default:
                break;
        }
    }
    public void SetBlendingData(List<BlendingModel> blendingModel,string name)
    {
        var obj = GameObject.Find("ProfessionAsset(Clone)");
        if (obj != null)
        {
            Destroy(obj);
        }
        string maxCount = "";
        foreach (MaxNftDataModel nftData in MessageHandler.userModel.nft_count)
        {
            if (nftData.name == name)
            {
                maxCount = nftData.count;
                break;
            }
        }
        if(!string.IsNullOrEmpty(maxCount))
            profession_text.text = name + "   " + "0" + "/" + maxCount;
        else 
            profession_text.text = name + "   " + "0" + "/" + "10";
        foreach (BlendingModel bmodel in blendingModel)
        {
            if(bmodel.profession == name)
            {
                int temp = 0;
                for (int j = 0; j < images.Length; j++)
                {
                    if (images[j].name == name)
                    {
                        temp = j;
                        break;
                    }
                }
                BlendingPanel_img.texture = images[temp].img;
                name_text.text = name;
                details_text.text = "Every couple of hours you will be able to refine raw materials like \"Copper Ore\" (common), \"Tin Ore\" (uncommon) and \"Iron Ore\" (rare) and craft items. You will then be able to either trade, sell or refine these raw materials.";
                uses_text.text = bmodel.uses;
                types_text.text = bmodel.types;
                citizens_text.text = bmodel.citizens;
                books_text.text = bmodel.books;
                break;
            }
        }
    }
    public void WorkButtonClick(string assetId, string type)
    {
        MessageHandler.Server_SearchCitizen(assetId, "1", type);
    }
    public void SetWorkResult(string title, string result, Texture image){
        WorkSuccessPopup.SetActive(true);
        WorkTitle.text = title;
        WorkResultImage.texture = image;
        WorkResultText.text = result;
    }
    public void SetProfessions(List<ProfessionDataModel> professionModel, string type)
    {
        string maxCount = "5";
        int registeredCount = 0;
        foreach (MaxNftDataModel nftData in MessageHandler.userModel.nft_count)
        {
            if (nftData.name == type)
            {
                maxCount = nftData.count;
                break;
            }
        }
        if (professionModel.Count < 1)
        {
            ProfessionShowPanel.SetActive(false);
            ProfessionEmptyPanel.SetActive(true);
            EmptyInfoText.text = "Unfortunately you don't have any \"" + type + "s\".";
        }
        else
        {
            ProfessionEmptyPanel.SetActive(false);
            ProfessionShowPanel.SetActive(true);
            if (ActionsPanel.childCount >= 1)
            {
                foreach (Transform child in ActionsPanel)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            for (int i = 0; i < professionModel.Count; i++)
            {
                var ins = Instantiate(OneProfessionPrefab);
                ins.transform.SetParent(ActionsPanel);
                ins.transform.localScale = new Vector3(1, 1, 1);
                var child = ins.gameObject.GetComponent<OneProfessionStatus>();
                child.assetId = professionModel[i].asset_id;
                child.AssetIdText.text = "#" + professionModel[i].asset_id.ToString();
                child.type = professionModel[i].name;
                for (int j = 0; j < images.Length; j++)
                {
                    if (images[j].name == child.type)
                    {
                        child.img.texture = images[j].img;
                        break;
                    }
                }
                // TODO - Commented out as the uses left should always have the actual value of left uses no matter if registered or not
                // if (string.IsNullOrEmpty(professionModel[i].uses_left))
                // {
                //     if (child.type == "Farmer" || child.type == "Miner" || child.type =="Lumberjack"){
                //         child.UseLeftCount.text = "60";
                //     } else if (child.type == "Carpenter"|| child.type == "Tailor" || child.type == "Blacksmith"){
                //         child.UseLeftCount.text = "180";

                //         // child.ItemInfo.text = "Craft";
                //         // child.action_text.text = "Refine";
                //     } else {
                //         // child.action_text.text = "Craft";
                //     }
                // }
                // else
                // {
                    child.UseLeftCount.text = professionModel[i].uses_left.ToString();
                // }
                if (professionModel[i].reg == "0")
                {
                    child.Register.SetActive(true);
                    child.Seller.SetActive(true);
                }
                else if (professionModel[i].reg == "1")
                {
                    registeredCount += 1;
                    if (child.type == "Farmer" || child.type == "Miner" || child.type =="Lumberjack"){
                        child.ItemInfo.text = "Item : " + professionModel[i].items.Length.ToString();
                        child.action_text.text = "Work";
                    } else if (child.type == "Carpenter"|| child.type == "Tailor" || child.type == "Blacksmith"){
                        child.ItemInfo.text = "Craft";
                        child.action_text.text = "Refine";
                    } else {
                        child.action_text.text = "Craft";
                    }
                    if (professionModel[i].status == "Idle " || professionModel[i].last_material_search == "1970-01-01T00:00:00")
                    {
                        child.Check.SetActive(false);
                        child.Registered.SetActive(true);
                        if (child.type == "Farmer" || child.type == "Miner" || child.type =="Lumberjack"){
                            child.ItemSeller.SetActive(true);
                            string[] items = professionModel[i].items;
                            child.ActionBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { WorkButtonClick(child.assetId, child.type);});
                            child.ItemBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ItemButtonClick(items, child.type, child.assetId); }); 
                        } else if (child.type == "Blacksmith"){
                            child.ItemSeller.SetActive(true);
                            child.ActionBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { RefineButtonClick(child.assetId, child.type);});
                            child.ItemBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { CraftButtonClick(child.assetId, child.type); });
                        }
                        else if (child.type == "Carpenter"|| child.type == "Tailor")
                        {
                            child.Seller.SetActive(true);
                            child.ActionBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { RefineButtonClick(child.assetId , child.type); });
                        }
                        else
                        {
                            child.Seller.SetActive(true);
                            child.ActionBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { CraftButtonClick(child.assetId, child.type); });
                        }
                    }
                    else
                    {
                        child.Timer.SetActive(true);
                        if (child.type != "Engineer")
                        {
                            child.ItemSeller.SetActive(true);
                            child.ItemBtn.gameObject.GetComponent<Button>().interactable = false;
                            child.StartTimer(professionModel[i].last_material_search, 100);
                        }
                        else
                        {
                            child.Seller.SetActive(true);
                            child.Seller.gameObject.GetComponent<Button>().interactable = false;
                            child.StartTimer(professionModel[i].last_material_search,100);
                        }
                    }
                }
            }
        }
        // setting the header of panel
        if (type == "Farmer" || type == "Miner" || type =="Lumberjack"){
            CountInfoText.text = type + "   " + registeredCount.ToString() + "/" + maxCount;
        } else {
            CountInfoText.text = type + "   " + registeredCount.ToString();
        }
    }
    public void Show_BurnPanel(string p_name)
    {
        PermissionPanel.SetActive(true);
        text_permission.text = "Do you really want to burn your \"" + p_name + "\"? If yes, you will have a 10% chance to get back 1 \"Citizen\".";
    }

    public void ItemButtonClick(string[] item_ids,string profession_name,string profession_id)
    {
        ItemsPopup.SetActive(true);
        if (ItemParent.childCount >= 1)
        {
            foreach (Transform p in ItemParent)
            {
                GameObject.Destroy(p.gameObject);
            }
        }
        var ins = Instantiate(ProfessionItemPrefab);
        ins.transform.SetParent(ItemParent);
        ins.transform.localScale = new Vector3(1, 1, 1);
        // make the prefab's ui correct
        var child = ins.gameObject.GetComponent<ProfessionItemStatus>();
        child.professionName = profession_name;
        child.prefessionId.text = " #" + profession_id;
        foreach(ProfessionItemSelect t in child.EachItems)
        {
            foreach(ImgObjectView b in images)
            {
                if(b.name == profession_name + "Default" + t.type)
                {
                    t.tool_img.texture = b.img;
                }
            }
            t.EquipButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { EquipButtonClick(t.type, profession_id, child.professionName); });

        }
        foreach (ImgObjectView data in images)
        {
            if (profession_name == data.name)
            {
                child.image.texture = data.img;
                break;
            }
        }
        // item_ids: ids of item in the contract
        for (int i = 0; i < item_ids.Length; i++)
        {
            foreach (ItemDataModel m in MessageHandler.userModel.items)
            {
                if(m.asset_id == item_ids[i])
                {
                    foreach(ImgObjectView data in images)
                    {
                        if(m.name == data.name)
                        {
                            foreach(ProfessionItemSelect r in child.EachItems)
                            {
                                if(r.type == m.function_name)
                                {
                                    r.tool_img.texture = data.img;
                                    r.EquipButton.SetActive(false);
                                    r.UnequipButton.SetActive(true);
                                    r.UnequipButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { UnequipButtonClick(m.asset_id, m.name, profession_id); });
                                    r.UseLeftText.text = m.uses_left;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
    public void EquipButtonClick(string selectedItemType, string profession_id, string professionName)
    {
        PopupEquipButtonInactive.SetActive(true);
        PopupEquipButtonActive.SetActive(false);
        // selectedItemType: Rare || Double || Extra
        EquipItemPopup.SetActive(true);
        if (EquipableItemParent.childCount >= 1)
        {
            foreach (Transform c in EquipableItemParent)
            {
                GameObject.Destroy(c.gameObject);
            }
        }
        Debug.Log(selectedItemType);
        string[] item_names = helper.profession_equip_items[professionName];// get available items for profession of kind
        foreach (string n in item_names)
        {
            foreach (ItemDataModel t in MessageHandler.userModel.items)
            {
                if (t.equipped == "0" && n == t.name && t.function_name == selectedItemType)
                {
                    var ins = Instantiate(EquipItemPrefab);
                    ins.transform.SetParent(EquipableItemParent);
                    ins.transform.localScale = new Vector3(1, 1, 1);
                    var child = ins.gameObject.GetComponent<EquipItemStatus>();
                    child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ItemImageClick(t.asset_id, profession_id); });
                    child.UseLeftCount.text = "x" + t.uses_left;
                    foreach (ImgObjectView m in images)
                    {
                        if (t.name == m.name)
                        {
                            child.image.texture = m.img; 
                            break;
                        }
                    }
                }
            }
        }
        if (EquipableItemParent.childCount < 1)
        {
            EquipItemPopup.SetActive(false);
            EmptyEquipItemPopup.SetActive(true);
        }
    }
    public void ItemImageClick(string assetId, string professionId)
    {
        // Debug.Log("ItemImageClick");
        // PopupEquipButton.gameObject.GetComponent<Button>().interactable = true;
        PopupEquipButtonInactive.SetActive(false);
        PopupEquipButtonActive.SetActive(true);
        PopupEquipButtonActive.gameObject.GetComponent<Button>().onClick.AddListener(delegate { PopupEquipButtonClick(assetId, professionId); });
        // equipableItemsPopup.equip_id = id;
    }
    public void PopupEquipButtonClick(string assetId, string professionId)
    {
        // Debug.Log(assetId);
        // Debug.Log(professionId);
        // // Debug.Log("PopupEquipButtonClick");
        // // Debug.Log(p_id);
        if (!string.IsNullOrEmpty(assetId))
        {
            // loadingPanel.SetActive(true);
            MessageHandler.Server_EquipItems(professionId, assetId);
        }
        else
            SSTools.ShowMessage("No item was selected to equip.", SSTools.Position.bottom, SSTools.Time.twoSecond);
    }
    public void UnequipButtonClick(string item_id, string item_name, string profession_id)
    {
        Debug.Log("UnequipButtonClick(ProfessionItemSelect type, string profession_id)");
        if (!string.IsNullOrEmpty(item_id))
        {
            MessageHandler.Server_UnequipItems(item_id, item_name, profession_id);
        }
        else
            SSTools.ShowMessage("No item was selected to unequip.", SSTools.Position.bottom, SSTools.Time.twoSecond);
    }

    public void OnProfessionData(ProfessionDataModel[] profession)
    {
        Engineer.Clear();
        Miners.Clear();
        LumberJack.Clear();
        Tailor.Clear();
        Farmers.Clear();
        Carpenter.Clear();
        Blacksmith.Clear();
        SetModels(profession);
    }

    public void OnCallBackData(CallBackDataModel[] callback)
    {
        CallBackDataModel callBack = callback[0];
        switch (callBack.name)
        {
            case "Miner":
                    SetProfessions(Miners, callBack.name);
                break;
            case "Farmer":
                    SetProfessions(Farmers, callBack.name);
                break;
            case "Engineer":
                    SetProfessions(Engineer, callBack.name);
                break;
            case "Carpenter":
                    SetProfessions(Carpenter, callBack.name);
                break;
            case "Tailor":
                    SetProfessions(Tailor, callBack.name);
                break;
            case "Blacksmith":
                    SetProfessions(Blacksmith, callBack.name);
                break;
            case "Lumberjack":
                    SetProfessions(LumberJack, callBack.name);
                break;
            case ("Mine"):
                ShowSettlements(Mine, callBack.name);
                break;
            case ("Forest"):
                ShowSettlements(Forest, callBack.name);
                break;
            case ("Field"):
                ShowSettlements(Field, callBack.name);
                break;
            default:
                break;
        }
        // SSTools toast
        switch (callBack.status)
        {
            case ("Registered Successfully"):
                SSTools.ShowMessage("NFT was successfully registered.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            case ("De-Registered Successfully"):
                SSTools.ShowMessage("NFT was successfully unrgeistered.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            case ("Item Equipped"):
                SSTools.ShowMessage("Item was successfully equipped.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            case ("De-Equiped"):
                SSTools.ShowMessage("Item successfully unequiped.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            case ("Refining Started"):
                SSTools.ShowMessage("Refining process started.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                // Okbtn();
                break;
            case ("Crafting Started"):
                SSTools.ShowMessage("Crafting started.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                // Okbtn();
                break;
            case ("RNG Failed !"):
                SSTools.ShowMessage("RNG failed!", SSTools.Position.bottom, SSTools.Time.twoSecond);
                // Okbtn();
                break;
            case ("Burnt Successfully"):
                SSTools.ShowMessage("NFT was successfully burned.", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            default:
                break;
        }

        if (!string.IsNullOrEmpty(callBack.matFound) && callBack.matFound == "true" && !string.IsNullOrEmpty(callBack.matRefined) && callBack.matRefined == "false")
        {
            if (!string.IsNullOrEmpty(callBack.matName) || !string.IsNullOrEmpty(callBack.matCount))
            {
                MessageHandler.userModel.total_matCount = callBack.totalMatCount;
                onSetHeaderElements();
                string title = "Work Result";
                Texture b = null;
                string result = "";
                foreach(ImgObjectView data in images)
                {
                    if(data.name == callBack.matName)
                    {
                        b = data.img;
                        decimal matCount =  Math.Round(System.Convert.ToDecimal(callBack.matCount), 2);
                        result = "You found " + matCount.ToString() + "x \"" + helper.mat_abv[callBack.matName] + "\"!";
                        break;
                    }
                }
                SetWorkResult(title, result, b);
            }
        }
        else if (!string.IsNullOrEmpty(callBack.matFound) && !string.IsNullOrEmpty(callBack.matRefined) && callBack.matFound == "false" && callBack.matRefined == "true")
        {
            if (!string.IsNullOrEmpty(callBack.matName))
            {
                MessageHandler.userModel.total_matCount = callBack.totalMatCount;
                onSetHeaderElements();
                string title = "Refine Result";
                Texture b = null;
                string result = "";
                string refined_mat = helper.mat_abv[callBack.matName];
                foreach (RefineDataModel refine_mat in refineData)
                {
                    if (refine_mat.name == refined_mat)
                    {
                        b = refine_mat.refined_product_img;
                        result = "You successfully refined 3x \""+ refine_mat.name + "\" " + "into 1x \"" + refine_mat.refined_product +"\".";
                        break;
                    }
                }
                SetWorkResult(title, result, b);
            }
        }
        else if (!string.IsNullOrEmpty(callBack.matFound) && !string.IsNullOrEmpty(callBack.matRefined) && !string.IsNullOrEmpty(callBack.matCrafted) && callBack.matFound == "false" && callBack.matRefined == "false" && callBack.matCrafted == "true")
        {

            if (!string.IsNullOrEmpty(callBack.matName))
            {
                MessageHandler.userModel.total_matCount = callBack.totalMatCount;
                onSetHeaderElements();
                string title = "Craft Result";
                Texture b = null;
                string result = "";
                foreach(ImgObjectView img in images)
                {
                    if(img.name == callBack.matName)
                    {
                        b = img.img;
                        result = "You successfully crafted \"" + callBack.matName + "\".";
                        break;
                    }
                }
                SetWorkResult(title, result, b);
            }
        }
        else if(!string.IsNullOrEmpty(callBack.matFound) && !string.IsNullOrEmpty(callBack.matRefined) && callBack.matFound == "false" && callBack.matRefined == "false" && callBack.equipped == "1")
        {
            ItemButtonClick(callBack.items_ids,callBack.name,callBack.asset_id);
        }

        else if (!string.IsNullOrEmpty(callBack.matFound) && !string.IsNullOrEmpty(callBack.matRefined) && callBack.matFound == "false" && callBack.matRefined == "false" && callBack.equipped == "0")
        {

            ItemButtonClick(callBack.items_ids, callBack.name, callBack.asset_id);
        }
    }

    public void RefineButtonClick(string profession_id, string profession)
    {
        RefinePanel.SetActive(true);
        RefineActionInfo.SetActive(false);
        RefineHelloInfo.SetActive(true);
        PopupRefineButton.gameObject.GetComponent<Button>().interactable = false;
        if (RefineParent.childCount >= 1)
        {
            foreach (Transform child in RefineParent)
            {
                Destroy(child.gameObject);
            }
        }
        foreach (RefineDataModel refine_mat in refineData)
        {
            if(refine_mat.profession == profession)
            {
                var ins = Instantiate(RefineMaterialPrefab);
                ins.transform.SetParent(RefineParent);
                ins.transform.localScale = new Vector3(1, 1, 1);
                var child = ins.gameObject.GetComponent<RefineMaterialStatus>();
                child.image.texture = refine_mat.img;
                child.quantity.text = "x0";
                child.count = 0;
                string material_short_name = helper.mat_abv_rev[refine_mat.name];
                if (MessageHandler.userModel.inventory.Length > 0)
                {
                    foreach (InventoryModel data in MessageHandler.userModel.inventory)
                    {
                        if (data.name == material_short_name)
                        {
                            child.quantity.text = "x" + data.count;
                            child.count = int.Parse(data.count);
                            break;
                        }
                    }
                }
                child.gameObject.GetComponent<Button>().onClick.AddListener(delegate { RefineMaterialImageClick(refine_mat.name, profession_id, child.count); });
            }
        }
    }

    public void RefineMaterialImageClick(string mat_name, string profession_id, int count)
    {
        RefineHelloInfo.SetActive(false);
        RefineActionInfo.SetActive(true);
        PopupRefineButton.gameObject.GetComponent<Button>().interactable = false;
        foreach (RefineDataModel refine_mat in refineData)
        {
            if(refine_mat.name == mat_name)
            {
                RefineMaterialImage.texture = refine_mat.img;
                RefinedMaterialImage.texture = refine_mat.refined_product_img;
                RefineMaterialText.text = mat_name;
                RefinedMaterialText.text = refine_mat.refined_product;
                if (count > 2)
                {
                    string profession_name = refine_mat.profession;
                    foreach(DelayDataModel data in MessageHandler.userModel.config.rawmat_refined)
                    {
                        if(data.key == helper.mat_abv_rev[mat_name])
                        {
                            PopupRefineButton.gameObject.GetComponent<Button>().interactable = true;
                            PopupRefineButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { PopupRefineButtonClick(data.value, profession_id, profession_name); });
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
    public void PopupRefineButtonClick(string mat_name,string profession_id,string profession_name)
    {
        MessageHandler.Server_RefineMat(profession_id, mat_name, profession_name);
    }
    public void CraftButtonClick(string profession_id, string type)
    {
        CraftPanel.SetActive(true);
        PopupCraftButton.gameObject.GetComponent<Button>().interactable = false;
        if (type == "Blacksmith")
        {
            CraftEngineerActionTop.SetActive(false);
            CraftBlackActionTop.SetActive(true);
        }
        else
        {
            CraftBlackActionTop.SetActive(false);
            CraftEngineerActionTop.SetActive(true);
        }
        CraftPanel.GetComponent<CraftPanelIndices>().profession_id = profession_id;
    }
    public void ShowCraft_Rarity(CraftDataModel selected_item_group)
    {
        CraftHelloInfo.SetActive(false);
        CraftActionInfo.SetActive(false);
        CraftActionSeries.SetActive(true);
        PopupCraftButton.gameObject.GetComponent<Button>().interactable = false;
        // selected_item_group has two properties: one: crafte_name: Hoe || Sickle || hammer || ... two: profession_name: who is gonna craft Blacksmith || Engineer
        string mat_name = selected_item_group.craft_name;
        string type = selected_item_group.profession_name;
        CraftPanelIndices craftScript = CraftPanel.GetComponent<CraftPanelIndices>(); 
        foreach(RefineRarityIndex s in craftScript.Series)
        {
            foreach(Config_CraftComboModel data_model in MessageHandler.userModel.craft_combos)
            {
                if(data_model.item_name == mat_name && s.type == data_model.rarity)
                {
                    string craft_name = "";
                    if (type == "Engineer")
                    {
                        switch (data_model.rarity)
                        {
                            case ("Common"):
                                craft_name = "Birch " + mat_name;
                                break;
                            case ("Uncommon"):
                                craft_name = "Oak " + mat_name;
                                break;
                            case ("Rare"):
                                craft_name = "Teak " + mat_name;
                                break;
                        }
                    }
                    else
                    {
                        switch (data_model.rarity)
                        {
                            case ("Common"):
                                craft_name = "Copper " + mat_name;
                                break;
                            case ("Uncommon"):
                                craft_name = "Tin " + mat_name;
                                break;
                            case ("Rare"):
                                craft_name = "Iron " + mat_name;
                                break;
                        }
                    }
                    foreach(ImgObjectView img in images)
                    {
                        if(img.name == craft_name)
                        {
                            s.image.texture = img.img;
                            break;
                        }
                    }
                    s.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                    s.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ShowFinalCraftIngredients(mat_name, craft_name, data_model); });
                    break;
                }
            }
        }
    }

    public void ShowFinalCraftIngredients(string mat_name, string craft_name, Config_CraftComboModel c_data)
    {
        CraftPanelIndices craftScript = CraftPanel.GetComponent<CraftPanelIndices>();
        CraftActionInfo.SetActive(true);
        // if (!craftScript.ing_obj_parent.gameObject.activeInHierarchy) craftScript.ing_obj_parent.gameObject.SetActive(true);
        DelayDataModel[] ingredients_craft = new DelayDataModel[3];
        foreach (Config_CraftComboModel data_model in MessageHandler.userModel.craft_combos)
        {
            if (data_model.item_name == mat_name && data_model.rarity == c_data.rarity)
            {
                ingredients_craft = data_model.ingredients;
                break;
            }
        }
        int canCraft = 0;
        for (int i = 0; i < 3; i++)
        {
            foreach (ImgObjectView img in images)
            {
                if (img.name == ingredients_craft[i].key)
                {
                    TimeSpan t = TimeSpan.FromSeconds(Double.Parse(c_data.delay));
                    craftScript.product_durability.text = "The crafting process will take " + t.Hours + " hours";

                    craftScript.craft_img[i].texture = img.img;
                    craftScript.ing_name[i].text = helper.mat_abv[ingredients_craft[i].key];
                    craftScript.req_qty[i].text = ingredients_craft[i].value + "x";
                    craftScript.ing_qty[i].text = "x0";
                    if (MessageHandler.userModel.inventory.Length > 0)
                    {
                        foreach (InventoryModel inv_data in MessageHandler.userModel.inventory)
                        {
                            if (inv_data.name == ingredients_craft[i].key)
                            {
                                craftScript.ing_qty[i].text = "x" + inv_data.count;

                                if (Int64.Parse(inv_data.count) >= Int64.Parse(ingredients_craft[i].value))
                                {
                                    canCraft += 1;
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        // setting the result image
        // ss
        foreach (ImgObjectView img in images)
        {
            if(craft_name == img.name)
            {
                craftScript.end_product.texture = img.img;
                if (craft_name == "Copper Hammer & Chisel")
                {
                    craftScript.product_name.text = "Copper H.&C.";
                }
                else if(craft_name == "Tin Hammer & Chisel")
                {
                    craftScript.product_name.text = "Tin H.&C.";
                }
                else if(craft_name == "Iron Hammer & Chisel")
                {
                    craftScript.product_name.text = "Iron H.&C.";
                }
                else if(craft_name == "Copper Sickle")
                {
                    craftScript.product_name.text = "Copper S.";
                }
                else if(craft_name == "Copper Pickaxe")
                {
                    craftScript.product_name.text = "Copper P.";
                }
                else if(craft_name == "Birch Mining Cart")
                {
                    craftScript.product_name.text = "Birch M.C.";
                }
                else if(craft_name == "Oak Mining Cart")
                {
                    craftScript.product_name.text = "Oak M.C.";
                }
                else if(craft_name == "Teak Mining Cart")
                {
                    craftScript.product_name.text = "Teak M.C.";
                }
                else if(craft_name == "Birch Wheelbarrow")
                {
                    craftScript.product_name.text = "Birch W.";
                }
                else if(craft_name == "Oak Wheelbarrow")
                {
                    craftScript.product_name.text = "Oak W.";
                }
                else if(craft_name == "Teak Wheelbarrow")
                {
                    craftScript.product_name.text = "Teak W.";
                }
                else
                {
                    craftScript.product_name.text = craft_name;
                }
                break;
            }
        }
        if (canCraft == 3)
        {
            PopupCraftButton.gameObject.GetComponent<Button>().interactable = true;
            PopupCraftButton.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            PopupCraftButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { PopupCraftButtonClick(craftScript.profession_id, c_data.template_id, craftScript.profession_name); });
        }

    }
    public void PopupCraftButtonClick(string profession_id,string template,string profession_name)
    {
        Debug.Log("PopupCraftButtonClick");
        Debug.Log(profession_id);
        Debug.Log(template);
        Debug.Log(profession_name);
        CraftPanel.SetActive(false);
        // LoadingPanel.SetActive(true);
        MessageHandler.Server_CraftMat(profession_id, template, profession_name);
    }
    public void ShowSettlements(List<SettlementsModel> settlementsModels, string type)
    {
        // NoForest_Text.SetActive(false);
        if (settlementsModels.Count < 1)
        {
            SettlementEmptyPopup.SetActive(true);
            // ProfessionShowPanel.SetActive(false);
            SettlementEmptyTitleText.text = "No \"" + type + "\" NFT in wallet";
            SettlementEmptyInfoText.text = "Unfortunately you don't have any \"" + type + "\" NFT in your wallet and will need to obtain one first.";
        }
        else
        {
            string maxCount = settlementsModels.Count.ToString();
            int registeredCount = 0;
            foreach (SettlementsModel c in settlementsModels)
            {
                if (c.reg == "1")
                {
                    registeredCount += 1;
                }
            }
            CountInfoText.text = type + "   " + registeredCount.ToString() + "/" + maxCount;
            if (ActionsPanel.childCount >= 1)
            {
                foreach (Transform child in ActionsPanel)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            for (int i = 0; i < settlementsModels.Count; i++)
            {
                var ins = Instantiate(OneSettlementPrefab);
                ins.transform.SetParent(ActionsPanel);
                ins.transform.localScale = new Vector3(1, 1, 1);
                var child = ins.gameObject.GetComponent<OneSettlementStatus>();
                child.IdText.text = "#" + settlementsModels[i].asset_id.ToString();
                child.assetId = settlementsModels[i].asset_id;
                child.type = settlementsModels[i].name;
                for (int j = 0; j < images.Length; j++)
                {
                    if (images[j].name == child.type)
                    {
                        child.image.texture = images[j].img;
                        break;
                    }
                }
                if (settlementsModels[i].reg == "0")
                {
                    child.Register.SetActive(true);
                }
                else if (settlementsModels[i].reg == "1")
                {
                    child.Unregister.SetActive(true);
                    child.SellBtn.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void UpgradeButtonClick()
    {
        TopBlendButton.SetActive(false);
        string type = ProfessionPanelParent.GetComponent<ProfessionUpgradeIndex>().upgrade_indexer;
        switch (type)
        {
            case ("Miner"):
                ShowSettlements(Mine, "Mine");
                break;
            case ("Lumberjack"):
                ShowSettlements(Forest, "Forest");
                break;
            case ("Farmer"):
                ShowSettlements(Field, "Field");
                break;
            default:
                break;
        }
    }

    public void Register_Settlement(string asset_id)
    {
        LoadingPanel.SetActive(true);
        MessageHandler.Server_TransferAsset(asset_id, "regupgrade","Forest");
    }

    public void DeRegister_Settlement(string asset_id)
    {
        LoadingPanel.SetActive(true);
        MessageHandler.Server_WithdrawAsset(asset_id,"Forest");
    }

    public void OnSettlementData(SettlementsModel[] settlements)
    {
        SetSettlementsModel(settlements);
    }

    public void OnTransactionData()
    {

        if (MessageHandler.transactionModel.transactionid != "")
        {
            string[] new_string = MessageHandler.transactionModel.transactionid.Split('%');
            if(new_string.Length > 1)
            {
                LoadingPanel.SetActive(false);
                PermissionPanel.SetActive(false);
                DonePanel.SetActive(true);
                MessageHandler.userModel.citizens = MessageHandler.transactionModel.citizens;
                citizens_text.text = MessageHandler.userModel.citizens;
                string citizens_found = new_string[1];
                if (Int64.Parse(citizens_found) == 0)
                {
                    done_panel_img.gameObject.SetActive(false);
                    done_panel_text.text = "No Citizen Survived !";
                }
                else
                {
                    done_panel_img.gameObject.SetActive(true);
                    done_panel_text.text = "1 Citizen Survived !";
                }
            }
            onSetHeaderElements();
        }
    }

    public void OnItemData() { }
}
