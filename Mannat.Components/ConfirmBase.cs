using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mannat.Components
{
    public class ConfirmBase: ComponentBase
    {
        protected bool ShowConfirmation { get; set; }


        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

    }
}
