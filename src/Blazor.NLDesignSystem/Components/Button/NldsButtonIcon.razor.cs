﻿using Blazor.NLDesignSystem.Extensions;
using Microsoft.AspNetCore.Components;

namespace Blazor.NLDesignSystem.Components
{
    public partial class NldsButtonIcon
    {
        [Parameter]
        public Icon Icon { get; set; }
        [Parameter]
        public RelativePosition Position { get; set; }
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private string DisplayIcon => Icon.GetDescription<StyleAttribute>();
    }
}
