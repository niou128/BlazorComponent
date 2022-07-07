using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace BlazorNInput
{
    public class ValidationBase : ComponentBase
    {
        [Parameter]
        public string LabelError { get; set; } = "Le champ n'est pas correct";

        public string StyleError { get; set; } = "display: none";

        public void Validation(string value, string pattern)
        {
            Match match = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                StyleError = "display: block";
                StateHasChanged();
            }
            else
            {
                StyleError = "display: none";
                StateHasChanged();
            }
        }
    }
}
