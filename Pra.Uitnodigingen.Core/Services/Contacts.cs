using System;
using System.Collections.Generic;
using System.Text;
using Pra.Uitnodigingen.Core.Entities;
using Pra.Uitnodigingen.Core.Enumerations;

namespace Pra.Uitnodigingen.Core.Services
{
    public class Contacts
    {
        public List<Person> MyContacts { get; }

        public Contacts()
        {
            MyContacts = new List<Person>();
            MyContacts.Add(new Family("nonkel", "Marc", "Neyt", "Bulskampveld 1", "8320 Beernem", Gender.Male));
            MyContacts.Add(new Family("tante", "Els", "Vansever", "Bulskampveld 1", "8320 Beernem", Gender.Female));
            MyContacts.Add(new Family("oma", "Maria", "Laisnez", "Pastorieweg 5", "8000 Brugge", Gender.Female));
            MyContacts.Add(new Friend("William", "Schokkele", "Klein straatje 5", "8000 Brugge", Gender.Male));
            MyContacts.Add(new Friend("Dries", "Deboosere", "Smal straatje 5", "8000 Brugge", Gender.Male));
            MyContacts.Add(new Friend("Siegfried", "Derdeyn", "Eng straatje 5", "8000 Brugge", Gender.Male));
            MyContacts.Add(new Customer("Willhelmina", "Raap", "Breed straatje 5", "8000 Brugge", Gender.Female, Language.Nederlands));
            MyContacts.Add(new Customer("Guillaume", "Navet", "Grand rue 5", "1000 Brussel", Gender.Male, Language.Français));
            MyContacts.Add(new Customer("William", "Turnip", "Tossers Alley", "BA123 Bath, UK", Gender.Male, Language.English));
        }
    }
}
