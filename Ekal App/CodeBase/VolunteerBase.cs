using Ekal_App.Data;
using EkalEntities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ekal_App.CodeBase
{
    public class VolunteerBase : ComponentBase
    {

        [Inject]
        public VolunteerService volunteerService { get; set; }
        [Inject]
        EkaiService ekaiService { get; set; }
        [Inject]
        StateService stateService { get; set; }
        [Inject]
        DistrictService districtService { get; set; }
        [Inject]
        VolunteerTypeService volunteerTypeService { get; set; }

        protected short volunteerTypeID = 0;
        protected string stateCode = "00";
        protected string GenderMale = string.Empty;
        protected string GenderFemale = string.Empty;

        protected string selectedEkai = string.Empty;

        protected int selectedEkaiID = 0;

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

        protected TxnVolunteer volunteer = new TxnVolunteer();

        protected List<MstVolunteerType> volunteerTypes = new List<MstVolunteerType>();
        protected List<MstStates> states = null;
        protected List<MstDistricts> districts = null;

        protected List<MstEkai> prabhags = new List<MstEkai>();
        protected List<MstEkai> sambhags = new List<MstEkai>();
        protected List<MstEkai> bhags = new List<MstEkai>();
        protected List<MstEkai> anchals = new List<MstEkai>();
        protected List<MstEkai> sanchs = new List<MstEkai>();
        protected List<MstEkai> gramSangathan = new List<MstEkai>();


        protected override async Task OnInitializedAsync()
        {
            await LoadStatesAsync();
            await LoadVolunteerTypesAsync();
            await LoadPrabhagsAsync();
        }

        protected async Task LoadVolunteerTypesAsync()
        {
            volunteerTypes = await volunteerTypeService.GetAsync();
        }

        protected void VolunteerTypeHasChanged(short value)
        {
            volunteerTypeID = value;
        }

        protected async Task StateHasChanged(string value)
        {
            stateCode = value;
            if (value == "00")
                districts.Clear();
            else
            {
                volunteer.StateCode = value;
                await LoadDistrictsAsync(value);
            }
        }

        protected async Task LoadStatesAsync()
        {
            states = await stateService.GetAsync();
        }

        protected async Task LoadDistrictsAsync(string stateCode)
        {
            districts = await districtService.GetDistrictByStateCodeAsync(stateCode);
        }

        protected async Task LoadPrabhagsAsync()
        {
            var allData = await ekaiService.GetAsync();
            prabhags = allData.Where(x => x.EkaiTypeId == (int)EkaiTypes.Prabhag).ToList();
            StateHasChanged();
        }

        protected async Task LoadSamabhagsAsync(int prabhagID)
        {
            var allData = await ekaiService.GetAsync();
            sambhags = allData.Where(x => x.ParentEkaiId == prabhagID && x.EkaiTypeId == (int)EkaiTypes.Sambhag).ToList();

            StateHasChanged();
        }

        protected async Task LoadBhagsAsync(int sambhagID)
        {
            var allData = await ekaiService.GetAsync();
            bhags = allData.Where(x => x.ParentEkaiId == sambhagID && x.EkaiTypeId == (int)EkaiTypes.Bhag).ToList();

            StateHasChanged();
        }

        protected async Task LoadAnchalsAsync(int bhagID)
        {
            var allData = await ekaiService.GetAsync();
            anchals = allData.Where(x => x.ParentEkaiId == bhagID && x.EkaiTypeId == (int)EkaiTypes.Anchal).ToList();

            StateHasChanged();
        }

        protected async Task LoadSanchsAsync(int anchalID)
        {
            var allData = await ekaiService.GetAsync();
            sanchs = allData.Where(x => x.ParentEkaiId == anchalID && x.EkaiTypeId == (int)EkaiTypes.Sanch).ToList();

            StateHasChanged();
        }

        protected async Task LoadGramSangathansAsync(int sanchID)
        {
            var allData = await ekaiService.GetAsync();
            gramSangathan = allData.Where(x => x.ParentEkaiId == sanchID && x.EkaiTypeId == (int)EkaiTypes.Gram).ToList();
            StateHasChanged();
        }

        public async Task Save()
        {

            if (!string.IsNullOrEmpty(GenderMale))
                volunteer.Gender = "M";
            else
                volunteer.Gender = "F";

            volunteer.EkaiId = selectedEkaiID;

            var response = await volunteerService.AddAsync(volunteer);
            if (response)
            {
                ResetFields();
            }
        }

        private void ResetFields()
        {
            volunteer.FirstName = string.Empty;
            volunteer.MiddleName = string.Empty;
            volunteer.LastName = string.Empty;
            volunteer.MobileNo = string.Empty;
            volunteer.AltMobileNo = string.Empty;
            volunteer.AadhaarNo = string.Empty;
            stateCode = "00";
            volunteer.StateCode = "00";
            volunteer.DistrictCode = "0000";
            volunteer.AddressLine1 = string.Empty;
            volunteer.AddressLine2 = string.Empty;
            volunteer.AddressLine3 = string.Empty;
            volunteer.Pincode = string.Empty;
        }

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
    }
}
