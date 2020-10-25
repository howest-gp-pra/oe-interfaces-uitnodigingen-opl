using System;
using System.Collections.Generic;
using System.Text;
using Pra.Uitnodigingen.Core.Enumerations;
using Pra.Uitnodigingen.Core.Interfaces;

namespace Pra.Uitnodigingen.Core.Entities
{
    public class Customer : Person, IBusinessInvitation
    {
        public Language Language { get; set; }
        public Customer(string firstName, string lastName, string address, string town, Gender gender, Language language) : base(firstName, lastName, address, town, gender)
        {
            Language = language;
        }
        public override string ShowInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName}");
            sb.AppendLine($"Taal = {Language}");
            sb.AppendLine($"{Address}");
            sb.AppendLine($"{Town}");
            return sb.ToString();
        }
        public string MakeInvitation(string invitationContent)
        {
            StringBuilder sb = new StringBuilder();
            string prefix1 = "";
            string prefix2 = "Geachte";
            if (Language == Language.Nederlands && Gender == Gender.Male) prefix1 = "Dhr";
            if (Language == Language.Nederlands && Gender == Gender.Female) prefix1 = "Mevr";
            if (Language == Language.Français && Gender == Gender.Male) prefix1 = "M.";
            if (Language == Language.Français && Gender == Gender.Female) prefix1 = "Mme";
            if (Language == Language.English && Gender == Gender.Male) prefix1 = "Mr";
            if (Language == Language.English && Gender == Gender.Female) prefix1 = "Ms";
            if (Language == Language.Français) prefix2 = "Cher";
            if (Language == Language.English) prefix2 = "Dear";

            sb.Append($"{prefix1} {FirstName} {LastName}\n");
            sb.Append($"{Address}\n");
            sb.Append($"{Town}\n");
            sb.Append($"\n\n");
            sb.Append($"{prefix2} {FirstName} {LastName} \n\n");
            sb.Append(invitationContent);
            sb.Append($"\n\n\n");
            return sb.ToString();
        }
    }
}
