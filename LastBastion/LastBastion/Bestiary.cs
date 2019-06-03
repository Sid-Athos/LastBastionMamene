using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class Bestiary
    {
        readonly Dictionary<string, Dictionary<string, string>> _bestiary;

        internal Bestiary()
        {
            _bestiary = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> _ignite = new Dictionary<string, string>();
            _ignite.Add("Nom", "Gobelin");
            _ignite.Add("Description", "Une créature courte sur patte, qui compense par sa hargne.");
            _ignite.Add("Dégâts", "5");
            _ignite.Add("Armure", "1");
            _ignite.Add("Cooldown", "2");
            _ignite.Add("Vie", "75");
            _ignite.Add("Vitesse", "0.002");
            _ignite.Add("Capacité", "0");
            _ignite.Add("Type", "Monstre");
            _ignite.Add("Faction", "Sbire de Dracula");
            _ignite.Add("Range", "10.0");
            _bestiary.Add("Gobelin", _ignite);
            Dictionary<string, string> _paralyse = new Dictionary<string, string>();
            _paralyse.Add("Nom", "Mage");
            _paralyse.Add("Description", "Un habile magicien, capable de blesser rapidement vos troupes et à la défense améliorée par la magie. Garde à vous.");
            _paralyse.Add("Dégâts", "4");
            _paralyse.Add("Armure", "2");
            _paralyse.Add("Cooldown", "2");
            _paralyse.Add("Vie", "100");
            _paralyse.Add("Vitesse", "0.02");
            _paralyse.Add("Capacité", "Ignite");
            _paralyse.Add("Type", "Monstre");
            _paralyse.Add("Faction", "Sbire de Dracula");
            _paralyse.Add("Range", "30");
            _bestiary.Add("Mage", _paralyse);
            Dictionary<string, string> _drainLife = new Dictionary<string, string>();
            _drainLife.Add("Nom", "Géant");
            _paralyse.Add("Description", "Il se fera une joie d'essayer de vous écraser...");
            _paralyse.Add("Dégâts", "11");
            _paralyse.Add("Armure", "2");
            _paralyse.Add("Cooldown", "3");
            _paralyse.Add("Vie", "150");
            _paralyse.Add("Vitesse", "0.02");
            _paralyse.Add("Capacité", "Smash");
            _paralyse.Add("Type", "Monstre");
            _paralyse.Add("Faction", "Sbire de Dracula");
            _paralyse.Add("Range", "15");
            _bestiary.Add("Giant", _drainLife);
        }

        public Dictionary<string, Dictionary<string, string>> Beasts=> _bestiary;
    }
}
