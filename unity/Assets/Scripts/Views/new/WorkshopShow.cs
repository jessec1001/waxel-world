using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkshopShow : BaseView
{
    [Space]
    [Header("MainPanel")]
    public GameObject MainItemPanel;
    public Transform ItemGroup;
    public GameObject ItemStatsPrefab;
    [Space]
    [Header("ItemDetailPopup")]
    public GameObject ItemDetailPopup;
    public RawImage ItemDetailImage;
    public TMP_Text ItemDetailToptext;
    public TMP_Text ItemDetailRarityText;
    public TMP_Text ItemDetailFunctionText;
    public TMP_Text ItemDetailDurablilityText;
    public TMP_Text ItemDetailUsedByText;
    public TMP_Text ItemDetailCraftedByText;
    public TMP_Text ItemDetailMaterialsNeededText;
    public TMP_Text ItemDetailBottomTopText;
    public Transform ItemDetailBottomParent;
    public GameObject OneItemPrefab;
    [Space]
    [Header("Burning Action")]
    public GameObject BurnPopupAlarm;
    public TMP_Text BurnPopupAlarmInfo;
    public GameObject BurnResultPopup;


    [Space]
    [Header("Variables")]
    public WorkshopDataModel[] ItemSchema;
    private List<ItemDataModel> CHammer = new List<ItemDataModel>();
    private List<ItemDataModel> CSaw = new List<ItemDataModel>();
    private List<ItemDataModel> CSickle = new List<ItemDataModel>();
    private List<ItemDataModel> CPickAxe = new List<ItemDataModel>();
    private List<ItemDataModel> CAxe = new List<ItemDataModel>();
    private List<ItemDataModel> CHoe = new List<ItemDataModel>();
    private List<ItemDataModel> BCart = new List<ItemDataModel>();
    private List<ItemDataModel> BWheelbarrow = new List<ItemDataModel>();
    private List<ItemDataModel> BWagon = new List<ItemDataModel>();

    private List<ItemDataModel> THammer = new List<ItemDataModel>();
    private List<ItemDataModel> TSaw = new List<ItemDataModel>();
    private List<ItemDataModel> TSickle = new List<ItemDataModel>();
    private List<ItemDataModel> TPickAxe = new List<ItemDataModel>();
    private List<ItemDataModel> TAxe = new List<ItemDataModel>();
    private List<ItemDataModel> THoe = new List<ItemDataModel>();
    private List<ItemDataModel> OCart = new List<ItemDataModel>();
    private List<ItemDataModel> OWheelBarrow = new List<ItemDataModel>();
    private List<ItemDataModel> OWagon = new List<ItemDataModel>();

    private List<ItemDataModel> IHammer = new List<ItemDataModel>();
    private List<ItemDataModel> ISaw = new List<ItemDataModel>();
    private List<ItemDataModel> ISickle = new List<ItemDataModel>();
    private List<ItemDataModel> IPickAxe = new List<ItemDataModel>();
    private List<ItemDataModel> IAxe = new List<ItemDataModel>();
    private List<ItemDataModel> IHoe = new List<ItemDataModel>();
    private List<ItemDataModel> TCart = new List<ItemDataModel>();
    private List<ItemDataModel> TWheelBarrow = new List<ItemDataModel>();
    private List<ItemDataModel> TWagon = new List<ItemDataModel>();

    public WorkshopDataModel[] wdata;
    public GameObject workshop_prefab;
    public GameObject items_panel;
    public GameObject items_panel2;
    public GameObject no_asset_panel;
    public GameObject title_panel;
    public GameObject asset_display_panel;
    public GameObject item_select_prefab;
    public GameObject permission_panel;
    public GameObject donePanel;
    public TMP_Text rarity_text;
    public TMP_Text function_text;
    public TMP_Text durability_text;
    public TMP_Text used_by_text;
    public TMP_Text material_text;
    public TMP_Text crafted_by_text;
    public TMP_Text item_name_text;
    public TMP_Text description1_text;
    public TMP_Text craft_text;
    public TMP_Text infotext1_text;
    public TMP_Text permission_panel_text;
    public TMP_Text done_panel_text;
    public Image item_img;
    public RawImage done_panel_img;
    public Transform parent_object;
    public TMP_Text username;
    public TMP_Text citizens;
    public TMP_Text professions;
    public TMP_Text materials;
    public TMP_Text ninjas;
    public ImgObjectView[] image;
    public AbbreviationsHelper helper;
    public Button YesBtn;

    protected override void Start()
    {
        base.Start();
        SetItemData(MessageHandler.userModel.items);
        SetItems();
        MessageHandler.OnCallBackData += OnCallBackData;
        MessageHandler.OnTransactionData += OnTransactionData;
        MessageHandler.OnItemData += OnItemData;
        MessageHandler.OnInventoryData += OnInventoryData;
        MessageHandler.OnProfessionData += OnProfessionData;
    }
    public void SetItems()
    { 
        if (ItemGroup.childCount >= 1)
        {
            foreach (Transform child in ItemGroup)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        foreach (WorkshopDataModel i in ItemSchema)
        {
            var ins = Instantiate(ItemStatsPrefab);
            ins.transform.SetParent(ItemGroup);
            ins.transform.localScale = new Vector3(1, 1, 1);
            var child = ins.gameObject.GetComponent<OneItemStatus>();
            child.image.texture = i.image;
            // child.type = i.name;
            
            // child.end_product = m.end_product;
            switch (i.name)
            {
                case "CHammer":
                    child.CountText.text = "x" + CHammer.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CHammer, i); });
                    break;
                case "CPickAxe":
                    child.CountText.text = "x" + CPickAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CPickAxe, i); });

                    break;
                case "CSaw":
                    child.CountText.text = "x" + CSaw.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CSaw, i); });

                    break;
                case "CAxe":
                    child.CountText.text = "x" + CAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CAxe, i); });

                    break;
                case "CSickle":
                    child.CountText.text = "x" + CSickle.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CSickle, i); });

                    break;
                case "CHoe":
                    child.CountText.text = "x" + CHoe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(CHoe, i); });

                    break;
                case "BWagon":
                    child.CountText.text = "x" + BWagon.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(BWagon, i); });

                    break;
                case "OWagon":
                    child.CountText.text = "x" + OWagon.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(OWagon, i); });

                    break;
                case "TWagon":
                    child.CountText.text = "x" + TWagon.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TWagon, i); });

                    break;
                case "IHoe":
                    child.CountText.text = "x" + IHoe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(IHoe, i); });

                    break;
                case "THoe":
                    child.CountText.text = "x" + THoe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(THoe, i); });

                    break;
                case "ISickle":
                    child.CountText.text = "x" + ISickle.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(ISickle, i); });

                    break;
                case "TSickle":
                    child.CountText.text = "x" + TSickle.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TSickle, i); });

                    break;
                case "TWheelBarrow":
                    child.CountText.text = "x" + TWheelBarrow.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TWheelBarrow, i); });

                    break;
                case "OWheelBarrow":
                    child.CountText.text = "x" + OWheelBarrow.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(OWheelBarrow, i); });

                    break;
                case "BWheelbarrow":
                    child.CountText.text = "x" + BWheelbarrow.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(BWheelbarrow, i); });

                    break;
                case "IAxe":
                    child.CountText.text = "x" + IAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(IAxe, i); });

                    break;
                case "TAxe":
                    child.CountText.text = "x" + TAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TAxe, i); });

                    break;
                case "ISaw":
                    child.CountText.text = "x" + ISaw.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(ISaw, i); });

                    break;
                case "TSaw":
                    child.CountText.text = "x" + TSaw.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TSaw, i); });

                    break;
                case "TCart":
                    child.CountText.text = "x" + TCart.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TCart, i); });

                    break;
                case "OCart":
                    child.CountText.text = "x" + OCart.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(OCart, i); });

                    break;
                case "BCart":
                    child.CountText.text = "x" + BCart.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(BCart, i); });

                    break;
                case "IPickAxe":
                    child.CountText.text = "x" + IPickAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(IPickAxe, i); });

                    break;
                case "TPickAxe":
                    child.CountText.text = "x" + TPickAxe.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(TPickAxe, i); });
                    
                    break;
                case "IHammer":
                    child.CountText.text = "x" + IHammer.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(IHammer, i); });
                    
                    break;
                case "THammer":
                    child.CountText.text = "x" + THammer.Count.ToString();
                    child.DetailButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { DetailButtonClick(THammer, i); });

                    break;
                default:
                    break;
            }
        
            
        }
        
    }
    public void DetailButtonClick(List<ItemDataModel> my_items, WorkshopDataModel selected_schema)
    {
        ItemDetailPopup.SetActive(true);
        ItemDetailImage.texture = selected_schema.image;
        ItemDetailToptext.text = "The '" + selected_schema.fullname + "' is 1 of 3 different items that can be equipped by the '"
                                + selected_schema.profession_type + "' profession to boost the gathering efficiency. Depending on the rarity value of the item, the profession will have a higher chance of finding more rare materials." ;
        ItemDetailRarityText.text = selected_schema.rarity;
        ItemDetailFunctionText.text = selected_schema.function;
        ItemDetailDurablilityText.text = selected_schema.durability;
        ItemDetailUsedByText.text = selected_schema.profession_type;
        ItemDetailCraftedByText.text = selected_schema.crafter;
        ItemDetailMaterialsNeededText.text = selected_schema.mat_need;
        ItemDetailBottomTopText.text = selected_schema.fullname + " "+ my_items.Count.ToString();
        if (ItemDetailBottomParent.childCount >= 1)
        {
            foreach (Transform child in ItemDetailBottomParent)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        if (my_items.Count > 0)
        {
            for (int i = 0; i < my_items.Count; i++)
            {
                var ins = Instantiate(OneItemPrefab);
                ins.transform.SetParent(ItemDetailBottomParent);
                ins.transform.localScale = new Vector3(1, 1, 1);
                var child = ins.gameObject.GetComponent<ItemStatus>();
                child.image.texture = selected_schema.image;
                child.AssetIdText.text = "#" + my_items[i].asset_id.ToString();
                child.UseLeftText.text = my_items[i].uses_left;

                child.asset_id = my_items[i].asset_id;
                child.mat_name = my_items[i].name;
                if (my_items[i].equipped == "1")
                {
                    child.EquipButton.SetActive(false);
                    child.UnEquipButton.SetActive(true);
                    child.BurnButton.gameObject.GetComponent<Button>().interactable = false;
                    child.SellButton.gameObject.GetComponent<Button>().interactable = false;
                    child.p_id = my_items[i].profession;
                    // YesBtn.onClick.RemoveAllListeners();
                    // YesBtn.onClick.AddListener(delegate { child.BurnBtn(); });
                }
                else if (my_items[i].equipped == "0")
                {
                    child.EquipButton.SetActive(true);
                    // string item_name = idata[i].name;
                    if(my_items[i].uses_left == "0")
                    {
                        child.EquipButton.gameObject.GetComponent<Button>().interactable = false;
                        child.SellButton.gameObject.GetComponent<Button>().interactable = false;
                        child.BurnButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate {BurnButtonClick(my_items[i].asset_id, my_items[i].name);});
                    }
                }
            }
        }
    }

    public void BurnButtonClick(string assetId, string matName)
    {
        BurnPopupAlarm.SetActive(true);
        BurnPopupAlarm.GetComponent<BurnItemPopupProperty>().itemId = assetId;
        BurnPopupAlarm.GetComponent<BurnItemPopupProperty>().matName = matName;


        BurnPopupAlarmInfo.text = "Do you really want to burn your item with id ''" + "#" + BurnPopupAlarm.GetComponent<BurnItemPopupProperty>().itemId + "''?";
    }
    public void BurnPopupYesButtonClick()
    {
        BurnItemPopupProperty burnPopupPropery = BurnPopupAlarm.GetComponent<BurnItemPopupProperty>();
        if (!string.IsNullOrEmpty(burnPopupPropery.itemId))
        {
            // LoadingPanel.SetActive(true);
            MessageHandler.Server_BurnItem(burnPopupPropery.matName, burnPopupPropery.itemId);
        }
        else
        {
            SSTools.ShowMessage("Asset ID is null", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        MessageHandler.OnCallBackData -= OnCallBackData;
        MessageHandler.OnTransactionData -= OnTransactionData;
        MessageHandler.OnItemData -= OnItemData;
        MessageHandler.OnInventoryData -= OnInventoryData;
        MessageHandler.OnProfessionData -= OnProfessionData;
    }

    public void SetItemData(ItemDataModel[] items)
    {
        foreach(ItemDataModel idata in items)
        {
            switch (idata.name)
            {
                case "Copper Hammer and Chisel":
                    CHammer.Add(idata);
                    break;
                case "Copper Pickaxe":
                    CPickAxe.Add(idata);
                    break;
                case "Copper Saw":
                    CSaw.Add(idata);
                    break;
                case "Copper Axe":
                    CAxe.Add(idata);
                    break;
                case "Copper Sickle":
                    CSickle.Add(idata);
                    break;
                case "Copper Hoe":
                    CHoe.Add(idata);
                    break;
                case "Birch Wagon":
                    BWagon.Add(idata);
                    break;
                case "Oak Wagon":
                    OWagon.Add(idata);
                    break;
                case "Teak Wagon":
                    TWagon.Add(idata);
                    break;
                case "Iron Hoe":
                    IHoe.Add(idata);
                    break;
                case "Tin Hoe":
                    THoe.Add(idata);
                    break;
                case "Iron Sickle":
                    ISickle.Add(idata);
                    break;
                case "Tin Sickle":
                    TSickle.Add(idata);
                    break;
                case "Teak Wheelbarrow":
                    TWheelBarrow.Add(idata);
                    break;
                case "Oak Wheelbarrow":
                    OWheelBarrow.Add(idata);
                    break;
                case "Birch Wheelbarrow":
                    BWheelbarrow.Add(idata);
                    break;
                case "Iron Axe":
                    IAxe.Add(idata);
                    break;
                case "Tin Axe":
                    TAxe.Add(idata);
                    break;
                case "Iron Saw":
                    ISaw.Add(idata);
                    break;
                case "Tin Saw":
                    TSaw.Add(idata);
                    break;
                case "Teak Mining Cart":
                    TCart.Add(idata);
                    break;
                case "Oak Mining Cart":
                    OCart.Add(idata);
                    break;
                case "Birch Mining Cart":
                    BCart.Add(idata);
                    break;
                case "Iron Pickaxe":
                    IPickAxe.Add(idata);
                    break;
                case "Tin Pickaxe":
                    TPickAxe.Add(idata);
                    break;
                case "Iron Hammer and Chisel":
                    IHammer.Add(idata);
                    break;
                case "Tin Hammer and Chisel":
                    THammer.Add(idata);
                    break;
                default:
                    break;
            }
        }
    }

    public void Display_No_Asset(WorkshopDataModel wdata,string name)
    {
        foreach (Transform child in parent_object.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        items_panel.SetActive(false);
        items_panel2.SetActive(true);
        title_panel.SetActive(true);
        no_asset_panel.SetActive(true);
        item_img.sprite = wdata.img.sprite;
        infotext1_text.text = "The " + name + " is 1 of 3 different items that can be equipped by the " + wdata.profession_type + " profession to boost the gathering process";
        item_name_text.text = name;
        function_text.text = wdata.function;
        material_text.text = wdata.mat_need;
        rarity_text.text = wdata.rarity;
        durability_text.text = wdata.durability;
        used_by_text.text = wdata.profession_type;
        crafted_by_text.text = wdata.crafter;
        craft_text.text = "~ Unfortunately you don't have any " + name;
    }

    public void Display_Asset(List<ItemDataModel> idata,WorkshopDataModel wdata)
    {
        foreach (Transform child in parent_object.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        items_panel.SetActive(false);
        items_panel2.SetActive(true);
        title_panel.SetActive(true);
        asset_display_panel.SetActive(true);
        item_img.sprite = wdata.img.sprite;
        infotext1_text.text = "The " + idata[0].name + " is 1 of 3 different items that can be equipped by the " + wdata.profession_type + " profession to boost the gathering process";
        item_name_text.text = idata[0].name;
        function_text.text = wdata.function;
        material_text.text = wdata.mat_need;
        rarity_text.text = wdata.rarity;
        durability_text.text = wdata.durability;
        used_by_text.text = wdata.profession_type;
        crafted_by_text.text = wdata.crafter;

        for (int i = 0; i < idata.Count; i++)
        {
            var ins = Instantiate(workshop_prefab);
            ins.transform.SetParent(parent_object);
            ins.transform.localScale = new Vector3(1, 1, 1);
            var child = ins.gameObject.GetComponent<ItemCall>();
            child.asset_ids.text = idata[i].asset_id.ToString();
            child.asset_id = idata[i].asset_id;
            child.LoadingPanel = LoadingPanel;
            child.durability.text = "Durability : " + idata[i].uses_left + "/60";
            child.img.sprite = wdata.img.sprite;
            child.mat_name = idata[i].name;
            if (idata[i].equipped == "1")
            {
                child.unequip.SetActive(true);
                child.burn.gameObject.GetComponent<Button>().interactable = false;
                child.sell.gameObject.GetComponent<Button>().interactable = false;
                child.p_id = idata[i].profession;
                YesBtn.onClick.RemoveAllListeners();
                YesBtn.onClick.AddListener(delegate { child.BurnBtn(); });
            }
            else if (idata[i].equipped == "0")
            {
                child.equip.SetActive(true);
                string item_name = idata[i].name;
                child.equip.gameObject.GetComponent<Button>().onClick.AddListener(delegate { EquipItem(item_name); });
                if(idata[i].uses_left == "0")
                {
                    child.equip.gameObject.GetComponent<Button>().interactable = false;
                    child.sell.gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }

    }

    public void returnToItems()
    {
        items_panel.SetActive(true);
        items_panel2.SetActive(false);
        title_panel.SetActive(false);
        asset_display_panel.SetActive(false);
        no_asset_panel.SetActive(false);
        SetItems();
    }

    public void OnItemData()
    {
        CHammer.Clear();
        CSaw.Clear();
        CSickle.Clear();
        CPickAxe.Clear();
        CAxe.Clear();
        CHoe.Clear();
        BCart.Clear();
        BWheelbarrow.Clear();
        THammer.Clear();
        TSaw.Clear();
        TSickle.Clear();
        TPickAxe.Clear();
        TAxe.Clear();
        THoe.Clear();
        OCart.Clear();
        OWheelBarrow.Clear();
        OWagon.Clear();
        IHammer.Clear();
        ISaw.Clear();
        ISickle.Clear();
        IPickAxe.Clear();
        IAxe.Clear();
        IHoe.Clear();
        TCart.Clear();
        TWheelBarrow.Clear();
        TWagon.Clear();
        SetItemData(MessageHandler.userModel.items);
    }

    public void OnTransactionData()
    {
        if (MessageHandler.transactionModel.transactionid != "")
        {
            LoadingPanel.SetActive(false);
            WorkshopDataModel item_data = new WorkshopDataModel();
            string item_name = "";
            switch (MessageHandler.transactionModel.transactionid)
            {
                case "Copper Hammer and Chisel":
                    item_name = "CHammer";
                    break;
                case "Copper Pickaxe":
                    item_name = "CPickAxe";
                    break;
                case "Copper Saw":
                    item_name = "CSaw";
                    break;
                case "Copper Axe":
                    item_name = "CAxe";
                    break;
                case "Copper Sickle":
                    item_name = "CSickle";
                    break;
                case "Copper Hoe":
                    item_name = "CHoe";
                    break;
                case "Birch Wagon":
                    item_name = "BWagon";
                    break;
                case "Oak Wagon":
                    item_name = "OWagon";
                    break;
                case "Teak Wagon":
                    item_name = "TWagon";
                    break;
                case "Iron Hoe":
                    item_name = "IHoe";
                    break;
                case "Tin Hoe":
                    item_name = "THoe";
                    break;
                case "Iron Sickle":
                    item_name = "ISickle";
                    break;
                case "Tin Sickle":
                    item_name = "TSickle";
                    break;
                case "Teak Wheelbarrow":
                    item_name = "TWheelBarrow";
                    break;
                case "Oak Wheelbarrow":
                    item_name = "OWheelBarrow";
                    break;
                case "Birch Wheelbarrow":
                    item_name = "BWheelbarrow";
                    break;
                case "Iron Axe":
                    item_name = "IAxe";
                    break;
                case "Tin Axe":
                    item_name = "TAxe";
                    break;
                case "Iron Saw":
                    item_name = "ISaw";
                    break;
                case "Tin Saw":
                    item_name = "TSaw";
                    break;
                case "Teak Mining Cart":
                    item_name = "TCart";
                    break;
                case "Oak Mining Cart":
                    item_name = "OCart";
                    break;
                case "Birch Mining Cart":
                    item_name = "BCart";
                    break;
                case "Iron Pickaxe":
                    item_name = "IPickAxe";
                    break;
                case "Tin Pickaxe":
                    item_name = "TPickAxe";
                    break;
                case "Iron Hammer and Chisel":
                    item_name = "IHammer";
                    break;
                case "Tin Hammer and Chisel":
                    item_name = "THammer";
                    break;
                default:
                    break;
            }
            foreach (WorkshopDataModel w_data in wdata)
            {
                if (w_data.name == item_name)
                {
                    item_data = w_data;
                    break;
                }
            }
            switch (item_name)
            {
                case "CHammer":
                    if (CHammer.Count > 0)
                        Display_Asset(CHammer, item_data);
                    else
                        Display_No_Asset(item_data, "Copper Hammer and Chisel");
                    break;
                case "CPickAxe":
                    if (CPickAxe.Count > 0)
                        Display_Asset(CPickAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Copper PickAxe");
                    break;
                case "CSaw":
                    if (CSaw.Count > 0)
                        Display_Asset(CSaw, item_data);
                    else
                        Display_No_Asset(item_data, "Copper Saw");
                    break;
                case "CAxe":
                    if (CAxe.Count > 0)
                        Display_Asset(CAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Copper Axe");
                    break;
                case "CSickle":
                    if (CSickle.Count > 0)
                        Display_Asset(CSickle, item_data);
                    else
                        Display_No_Asset(item_data, "Copper Sickle");
                    break;
                case "CHoe":
                    if (CHoe.Count > 0)
                        Display_Asset(CHoe, item_data);
                    else
                        Display_No_Asset(item_data, "Copper Hoe");
                    break;
                case "BWagon":
                    if (BWagon.Count > 0)
                        Display_Asset(BWagon, item_data);
                    else
                        Display_No_Asset(item_data, "Birch Wagon");
                    break;
                case "OWagon":
                    if (OWagon.Count > 0)
                        Display_Asset(OWagon, item_data);
                    else
                        Display_No_Asset(item_data, "Oak Wagon");
                    break;
                case "TWagon":
                    if (TWagon.Count > 0)
                        Display_Asset(TWagon, item_data);
                    else
                        Display_No_Asset(item_data, "Teak Wagon");
                    break;
                case "IHoe":
                    if (IHoe.Count > 0)
                        Display_Asset(IHoe, item_data);
                    else
                        Display_No_Asset(item_data, "Iron Hoe");
                    break;
                case "THoe":
                    if (THoe.Count > 0)
                        Display_Asset(THoe, item_data);
                    else
                        Display_No_Asset(item_data, "Tin Hoe");
                    break;
                case "ISickle":
                    if (ISickle.Count > 0)
                        Display_Asset(ISickle, item_data);
                    else
                        Display_No_Asset(item_data, "Iron Sickle");
                    break;
                case "TSickle":
                    if (TSickle.Count > 0)
                        Display_Asset(TSickle, item_data);
                    else
                        Display_No_Asset(item_data, "Tin Sickle");
                    break;
                case "TWheelBarrow":
                    if (TWheelBarrow.Count > 0)
                        Display_Asset(TWheelBarrow, item_data);
                    else
                        Display_No_Asset(item_data, "Teak WheelBarrow");
                    break;
                case "OWheelBarrow":
                    if (OWheelBarrow.Count > 0)
                        Display_Asset(OWheelBarrow, item_data);
                    else
                        Display_No_Asset(item_data, "Oak WheelBarrow");
                    break;
                case "BWheelbarrow":
                    if (BWheelbarrow.Count > 0)
                        Display_Asset(BWheelbarrow, item_data);
                    else
                        Display_No_Asset(item_data, "Birch WheelBarrow");
                    break;
                case "IAxe":
                    if (IAxe.Count > 0)
                        Display_Asset(IAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Iron Axe");
                    break;
                case "TAxe":
                    if (TAxe.Count > 0)
                        Display_Asset(TAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Tin Axe");
                    break;
                case "ISaw":
                    if (ISaw.Count > 0)
                        Display_Asset(TSaw, item_data);
                    else
                        Display_No_Asset(item_data, "Iron Saw");
                    break;
                case "TSaw":
                    if (TSaw.Count > 0)
                        Display_Asset(TSaw, item_data);
                    else
                        Display_No_Asset(item_data, "Tin Saw");
                    break;
                case "TCart":
                    if (TCart.Count > 0)
                        Display_Asset(TCart, item_data);
                    else
                        Display_No_Asset(item_data, "Teak MiningCart");
                    break;
                case "OCart":
                    if (OCart.Count > 0)
                        Display_Asset(OCart, item_data);
                    else
                        Display_No_Asset(item_data, "Oak Mining Cart");
                    break;
                case "BCart":
                    if (BCart.Count > 0)
                        Display_Asset(BCart, item_data);
                    else
                        Display_No_Asset(item_data, "Birch Mining Cart");
                    break;
                case "IPickAxe":
                    if (IPickAxe.Count > 0)
                        Display_Asset(IPickAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Iron PickAxe");
                    break;
                case "TPickAxe":
                    if (TPickAxe.Count > 0)
                        Display_Asset(TPickAxe, item_data);
                    else
                        Display_No_Asset(item_data, "Tin PickAxe");
                    break;
                case "IHammer":
                    if (IHammer.Count > 0)
                        Display_Asset(IHammer, item_data);
                    else
                        Display_No_Asset(item_data, "Iron Hammer");
                    break;
                case "THammer":
                    if (THammer.Count > 0)
                        Display_Asset(THammer, item_data);
                    else
                        Display_No_Asset(item_data, "Tin Hammer");
                    break;
                default:
                    break;
            }
        }
    }

    public void OnCallBackData(CallBackDataModel[] callback)
    {
        CallBackDataModel callBack = callback[0];
        switch (callBack.status)
        {
            case ("De-Equiped Successfully"):
                SSTools.ShowMessage("Item De-Equiped Successful !", SSTools.Position.bottom, SSTools.Time.twoSecond);
                break;
            default:
                break;
        }
    }

    public void EquipItem(string item_name)
    {
        var ins = Instantiate(item_select_prefab);
        var child = ins.gameObject.GetComponent<ItemSelectedModel>();
        child.item_selected = item_name;
        LoadingPanel.SetActive(true);
        SceneManager.LoadScene("ProfessionScene");
    }

    public void Show_BurnPanel(string item_name)
    {
        permission_panel.SetActive(true);
        permission_panel_text.text = "Do you really want to burn your " + item_name + "? If yes, you will have a some chance to get back 1 random material that was used for crafting it";
    }

    private void OnInventoryData(InventoryModel[] inventoryData)
    {
        InventoryModel inventory = inventoryData[0];
        // LoadingPanel.SetActive(false);
        // permission_panel.SetActive(false);
        // donePanel.SetActive(true);
        if (inventory.name == "null")
        {
            done_panel_text.text = "No material could be extracted";
            // done_panel_img.gameObject.SetActive(false);
        }
        else 
        {
            BurnResultPopup.SetActive(true);
            // done_panel_img.gameObject.SetActive(true);
            // string item_name = helper.mat_abv[inventory.name];
            // foreach(ImgObjectView img in image)
            // {
            //     if(img.name == item_name)
            //     {
            //         done_panel_img.texture = img.img;
            //     }
            // }
            // done_panel_text.text = inventory.count + " " + item_name + " was extracted!";
        }

    }

    public void NoBtn()
    {
        permission_panel.SetActive(false);
        donePanel.SetActive(false);
    }

    public void OnProfessionData(ProfessionDataModel[] pr) { }
}
