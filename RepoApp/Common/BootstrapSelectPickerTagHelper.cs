using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RepoApp.Common
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;select&gt; elements with <c>asp-for</c> and/or
    /// <c>asp-items</c> attribute(s).
    /// </summary>
    [HtmlTargetElement("select", Attributes = AspForAttributeName)]
    public class BootstrapSelectPickerTagHelper : TagHelper
    {
        private const string dataStyleAttributeName = "data-style";
        private const string dataSizeAttributeName = "data-size";
        private const string dataMaxOptionsAttributeName = "data-max-options";
        private const string dataLiveSearchAttributeName = "data-live-search";
        private const string dataSelectedTextFormatAttributeName = "data-selected-text-format";

        private const string AspForAttributeName = "asp-for";
        private const string AspDataStyleAttributeName = "asp-" + dataStyleAttributeName;
        private const string AspDataSizeAttributeName = "asp-" + dataSizeAttributeName;
        private const string AspDataMaxOptionsAttributeName = "asp-" + dataMaxOptionsAttributeName;
        private const string AspDataLiveSearchAttributeName = "asp-" + dataLiveSearchAttributeName;
        private const string AspDataSelectedTextFormatAttributeName = "asp-" + dataSelectedTextFormatAttributeName;

        public override int Order { get; } = int.MaxValue;

        [HtmlAttributeName(AspForAttributeName)]
        public ModelExpression For { get; set; }

        /// <summary>
        /// Gets or sets the style for the select button.
        /// </summary>
        [HtmlAttributeName(AspDataStyleAttributeName)]
        public string DataStyle { get; set; }

        /// <summary>
        /// Gets or sets the size of the dropdown menu.
        /// The menu will show the given number of items, even if the dropdown is cut off.
        /// </summary>
        [HtmlAttributeName(AspDataSizeAttributeName)]
        public int DataSize { get; set; }

        /// <summary>
        /// Gets or sets the data maximum options.
        /// When set in a multi-select, the number of 
        /// selected options cannot exceed the given value.
        /// </summary>
        [HtmlAttributeName(AspDataMaxOptionsAttributeName)]
        public int DataMaxOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether should be add a search box to the top 
        /// of the selectpicker dropdown.
        /// </summary>
        [HtmlAttributeName(AspDataLiveSearchAttributeName)]
        public bool? DataLiveSearch { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies how the selection is displayed with a multiple select.
        /// </summary>
        [HtmlAttributeName(AspDataSelectedTextFormatAttributeName)]
        public string DataSelectedTextFormatAttributeName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrWhiteSpace(this.DataStyle) && !context.AllAttributes.ContainsName(dataStyleAttributeName))
            {
                output.Attributes.Add(dataStyleAttributeName, this.DataStyle);
            }

            if (!context.AllAttributes.ContainsName(dataSizeAttributeName))
            {
                output.Attributes.Add(dataSizeAttributeName, this.DataSize);
            }

            if (!context.AllAttributes.ContainsName(dataMaxOptionsAttributeName))
            {
                output.Attributes.Add(dataMaxOptionsAttributeName, this.DataMaxOptions);
            }

            if (this.DataLiveSearch.HasValue && !context.AllAttributes.ContainsName(dataLiveSearchAttributeName))
            {
                output.Attributes.Add(dataLiveSearchAttributeName, this.DataLiveSearch.Value);
            }

            if (!context.AllAttributes.ContainsName(dataSelectedTextFormatAttributeName))
            {
                output.Attributes.Add(dataSelectedTextFormatAttributeName, this.DataSelectedTextFormatAttributeName);
            }
        }
    }
}