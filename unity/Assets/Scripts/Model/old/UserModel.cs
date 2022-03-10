using System;

[Serializable]
public class UserModel
{
    public string account;
    public NinjaDataModel[] ninjas;
    public ProfessionDataModel[] professions;
    public ItemDataModel[] items;
    public string citizens;
    public InventoryModel[] inventory;
    public AssetModel[] assets;
    public MaxNftDataModel[] nft_count;
    public ConfigDataModel config;
    public string drop;
    public SettlementsModel[] settlements;
    public string total_matCount;
    public Config_CraftComboModel[] craft_combos;
}