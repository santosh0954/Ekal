using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mannat.Components
{
    public class AlertBase:ComponentBase
    {
        protected string Message { get; set; }

        protected bool ShowAlert { get; set; }


        public void Show()
        {
            ShowAlert = true;
            StateHasChanged();
        }

        public void Show(string message)
        {
            Message = message;
            ShowAlert = true;
            StateHasChanged();
        }

    }
}
