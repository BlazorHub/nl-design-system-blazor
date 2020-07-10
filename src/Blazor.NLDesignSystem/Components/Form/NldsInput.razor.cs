﻿using Blazor.NLDesignSystem.Extensions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Blazor.NLDesignSystem.Components.Form
{
    public partial class NldsInput
    {
        /// <summary>
        /// Optional; overrides the default value; if the input contains a hint the value "hint_" + Id will be used by default
        /// </summary>
        [Parameter]
        public string AriaDescribedBy { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public bool IsDisabled { get; set; }
        [Parameter]
        public bool IsRequired { get; set; }
        [Parameter]
        public LabelAlignment LabelAlignment { get; set; }
        [Parameter]
        public InputSize Size { get; set; }
        [Parameter]
        public InputType Type { get; set; }

        [Parameter]
        public RenderFragment Label { get; set; }
        [Parameter]
        public RenderFragment Hint { get; set; }
        [Parameter]
        public RenderFragment Error { get; set; }

        //2-way binding
        private string _value;

        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        private bool IsInvalid => Error != null;

        private string LabelAlignmentStyle => LabelAlignment.GetDescription<StyleAttribute>();
        private string SizeAppendix => Size.GetDescription<StyleAttribute>();
        private string DisplayType => Type.GetDescription<StyleAttribute>();

        private IDictionary<string, object> GetAttributes()
        {
            var attributes = new Dictionary<string, object>();

            var tagAriaDescribedby = AriaDescribedBy ?? (Hint != null && !string.IsNullOrWhiteSpace(Id) ? $"hint_{Id}" : null) ?? string.Empty;
            if (tagAriaDescribedby != string.Empty)
            {
                attributes["aria-describedby"] = tagAriaDescribedby;
            }

            return attributes;
        }
    }
}
