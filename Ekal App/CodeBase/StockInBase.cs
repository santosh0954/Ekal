using Ekal_App.Data;
using EkalEntities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekal_App.CodeBase
{
    public class StockInBase : ComponentBase
    {
        [Inject]
        public ItemStockService itemStockService { get; set; }
        [Inject]
        public ItemsService itemService { get; set; }
        [Inject]
        public ItemProviderService itemProviderService { get; set; }

        [Inject]
        public EkaiService ekaiService { get; set; }


        protected int itemID;
        protected int ItemProviderID;
        protected int EkaiID;
        protected decimal Qty;
        protected decimal Rate;
        protected decimal Amount;
       
        int selectedItemID = 0;
        int selectedProviderID = 0;
        string itemStatus = string.Empty;
        string selectedEkaiType = string.Empty;

        protected int selectedEkaiID = 0;
        protected string selectedEkai = string.Empty;

        string selectedProviderType = string.Empty;

        protected int totalRecords = 0;

        protected List<MstItems> items;

        protected TxnItemStock itemStock = new TxnItemStock();

        protected List<VItemStock> entities = null;
        protected List<VItemProvider> itemProviders = null;

        protected List<MstEkai> prabhags = new List<MstEkai>();
        protected List<MstEkai> sambhags = new List<MstEkai>();
        protected List<MstEkai> bhags = new List<MstEkai>();
        protected List<MstEkai> anchals = new List<MstEkai>();
        protected List<MstEkai> sanchs = new List<MstEkai>();
        protected List<MstEkai> gramSangathan = new List<MstEkai>();


        protected int selectedPrabhagID = 0;
        protected int selectedSambhagID = 0;
        protected int selectedBhagID = 0;
        protected int selectedAnchalID = 0;
        protected int selectedSanchID = 0;
        protected int selectedGramID = 0;

        protected bool DisablePrabhag = true;
        protected bool DisableSambhag = true;
        protected bool DisableBhag = true;
        protected bool DisableAnchal = true;
        protected bool DisableSanch = true;
        protected bool DisableGram = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
            await LoadItemsAsync();
            await LoadPrabhagsAsync();
            await LoadItemProvider();
        }

        protected async Task LoadAsync()
        {
            entities = await itemStockService.GetAsync();
            totalRecords = entities.Count();
        }

        protected async Task LoadItemsAsync()
        {
            items = await itemService.GetAsync();
            items.Insert(0, new MstItems { ItemId = 0, ItemName = "SELECT" });
        }

        protected async Task LoadItemProvider()
        {
            var allData = await itemProviderService.GetAsync();
            if (!string.IsNullOrEmpty(selectedProviderType))
            {
                itemProviders = allData.Where(x => x.ProviderType == selectedProviderType).ToList();
            }
            StateHasChanged();
        }

        protected async Task LoadPrabhagsAsync()
        {
            var allData = await ekaiService.GetAsync();
            prabhags = allData.Where(x => x.EkaiTypeId == 1).ToList();
            StateHasChanged();
        }

        protected async Task LoadSamabhagsAsync(int prabhagID)
        {
            var allData = await ekaiService.GetAsync();
            sambhags = allData.Where(x => x.ParentEkaiId == prabhagID && x.EkaiTypeId == 2).ToList();

            StateHasChanged();
        }

        protected async Task LoadBhagsAsync(int sambhagID)
        {
            var allData = await ekaiService.GetAsync();
            bhags = allData.Where(x => x.ParentEkaiId == sambhagID && x.EkaiTypeId == 3).ToList();

            StateHasChanged();
        }

        protected async Task LoadAnchalsAsync(int bhagID)
        {
            var allData = await ekaiService.GetAsync();
            anchals = allData.Where(x => x.ParentEkaiId == bhagID && x.EkaiTypeId == 4).ToList();

            StateHasChanged();
        }

        protected async Task LoadSanchsAsync(int anchalID)
        {
            var allData = await ekaiService.GetAsync();
            sanchs = allData.Where(x => x.ParentEkaiId == anchalID && x.EkaiTypeId == 5).ToList();

            StateHasChanged();
        }

        protected async Task LoadGramSangathansAsync(int sanchID)
        {
            var allData = await ekaiService.GetAsync();
            gramSangathan = allData.Where(x => x.ParentEkaiId == sanchID && x.EkaiTypeId == 6).ToList();
            StateHasChanged();
        }

        protected async Task Save()
        {
            TxnItemStock entity = new TxnItemStock();
            entity.ItemId = selectedItemID;
            entity.Qty = Qty;
            entity.Rate = Rate;
            entity.TotalAmount = Amount;
            entity.ItemProviderId = selectedProviderID;
            entity.Status = itemStatus;
            entity.EkaiId = selectedEkaiID;

            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = Common.UserProfileID;

            var response = await itemStockService.AddAsync(entity);
            if (response)
            {
                await LoadAsync();
                ResetFields();
            }
        }

        protected void ResetFields()
        {
            itemID = 0;
            Qty = 0;
        }

        #region Events

        protected async void rbtnEkai_OnCheckedValueChanged(string value)
        {
            selectedEkai = value;
            DisablePrabhag = true;
            DisableSambhag = true;
            DisableBhag = true;
            DisableAnchal = true;
            DisableSanch = true;
            DisableGram = true;

            switch (Convert.ToInt16(value))
            {
                case 1:
                    DisablePrabhag = false;
                    await LoadPrabhagsAsync();
                    break;
                case 2:
                    DisablePrabhag = false;
                    DisableSambhag = false;
                    break;
                case 3:
                    DisablePrabhag = false;
                    DisableSambhag = false;
                    DisableBhag = false;
                    break;
                case 4:
                    DisablePrabhag = false;
                    DisableSambhag = false;
                    DisableBhag = false;
                    DisableAnchal = false;
                    break;
                case 5:
                    DisablePrabhag = false;
                    DisableSambhag = false;
                    DisableBhag = false;
                    DisableAnchal = false;
                    DisableSanch = false;
                    break;
                case 6:
                    DisablePrabhag = false;
                    DisableSambhag = false;
                    DisableBhag = false;
                    DisableAnchal = false;
                    DisableSanch = false;
                    DisableGram = false;
                    break;

            }
        }

        protected async void rbtnStockSource_OnCheckedValueChanged(string value)
        {
            selectedProviderType = value;
            await LoadItemProvider();

        }

        protected void ddlItems_SelectedIndexChanged(ChangeEventArgs e)
        {
            selectedItemID = Convert.ToInt32(e.Value);
        }

        protected void ddlItemStatus_SelectedIndexChanged(ChangeEventArgs e)
        {
            itemStatus = Convert.ToString(e.Value);
        }

        protected void ddlProviders_SelectedIndexChanged(ChangeEventArgs e)
        {
            selectedProviderID = Convert.ToInt32(e.Value);
        }

        

        protected async void PrabhagStateHasChanged(int value)
        {
            selectedPrabhagID = value;
            if (selectedPrabhagID > 0)
            {
                selectedEkaiID = selectedPrabhagID;
                await LoadSamabhagsAsync(selectedPrabhagID);
            }
        }

        protected async void SambhagStateHasChanged(int value)
        {
            selectedSambhagID = value;
            if (selectedSambhagID > 0)
            {
                selectedEkaiID = selectedSambhagID;
                await LoadBhagsAsync(selectedSambhagID);
            }
        }

        protected async void BhagStateHasChanged(int value)
        {
            selectedBhagID = value;
            if (selectedBhagID > 0)
            {
                selectedEkaiID = selectedBhagID;
                await LoadAnchalsAsync(selectedBhagID);
            }
        }

        protected async void AnchalStateHasChanged(int value)
        {
            selectedAnchalID = value;
            if (selectedAnchalID > 0)
            {
                selectedEkaiID = selectedAnchalID;
                await LoadSanchsAsync(selectedAnchalID);
            }
        }

        protected async void SanchStateHasChanged(int value)
        {
            selectedSanchID = value;
            if (selectedSanchID > 0)
            {
                selectedEkaiID = selectedSanchID;
                await LoadGramSangathansAsync(selectedSanchID);
            }
        }

        protected void GramStateHasChanged(int value)
        {
            selectedGramID = value;
            if (selectedGramID > 0)
            {
                selectedEkaiID = selectedGramID;
            }
        }

        #endregion
    }
}
