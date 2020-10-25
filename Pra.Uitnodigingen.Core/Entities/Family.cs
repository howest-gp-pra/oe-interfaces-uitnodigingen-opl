using System;
using System.Collections.Generic;
using System.Text;
using Pra.Uitnodigingen.Core.Enumerations;
using Pra.Uitnodigingen.Core.Interfaces;

namespace Pra.Uitnodigingen.Core.Entities
{
    public class Family : Person, IBirthdayInvitation, IBusinessInvitation
    {
        public string Title { get; set; }

        public Family(string title, string firstName, string lastName, string address, string town, Gender gender) : base(firstName, lastName, address, town, gender)
        {
            Title = title;
        }
        public override string ShowInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName}");
            sb.AppendLine($"{Title}");
            sb.AppendLine($"{Address}");
            sb.AppendLine($"{Town}");
            return sb.ToString();
        }
        public string MakeInvitation(string invitationContent)
        {
            StringBuilder sb = new StringBuilder();
            string prefix = "";
            if (Gender == Gender.Male) prefix = "Dhr";
            if (Gender == Gender.Female) prefix = "Mevr";
            sb.Append($"{prefix} {FirstName} {LastName}\n");
            sb.Append($"{Address}\n");
            sb.Append($"{Town}\n");
            sb.Append($"\n\n");
            sb.Append($"Beste {Title} \n\n");
            sb.Append(invitationContent);
            sb.Append($"\n\n\n");

            return sb.ToString();

        }
    }
}
