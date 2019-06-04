using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    public class Bestiary
    {
        readonly Dictionary<string, Dictionary<string, string>> _bestiary;

        public Bestiary()
        {
            _bestiary = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> _ignite = new Dictionary<string, string>();
            _ignite.Add("Nom", "Gobelin");
            _ignite.Add("Description", "Une créature courte sur patte, qui compense par sa hargne.");
            _ignite.Add("Dégâts", "5");
            _ignite.Add("Armure", "1");
            _ignite.Add("Cooldown", "2");
            _ignite.Add("Vie", "75");
            _ignite.Add("Vitesse", "0,002");
            _ignite.Add("Capacité", "0");
            _ignite.Add("Type", "Monstre");
            _ignite.Add("Faction", "Sbire de Dracula");
            _ignite.Add("Range", "10,0");
            _bestiary.Add("Gobelin", _ignite);
            Dictionary<string, string> _paralyse = new Dictionary<string, string>();
            _paralyse.Add("Nom", "Mage");
            _paralyse.Add("Description", "Un habile magicien, capable de blesser rapidement vos troupes et à la défense améliorée par la magie. Garde à vous.");
            _paralyse.Add("Dégâts", "4");
            _paralyse.Add("Armure", "3");
            _paralyse.Add("Cooldown", "2");
            _paralyse.Add("Vie", "100");
            _paralyse.Add("Vitesse", "0,02");
            _paralyse.Add("Capacité", "Ignite");
            _paralyse.Add("Type", "Monstre");
            _paralyse.Add("Faction", "Sbire de Dracula");
            _paralyse.Add("Range", "30");
            _bestiary.Add("Mage", _paralyse);
            Dictionary<string, string> _drainLife = new Dictionary<string, string>();
            _drainLife.Add("Nom", "Géant");
            _drainLife.Add("Description", "Il se fera une joie d'essayer de vous écraser...");
            _drainLife.Add("Dégâts", "11");
            _drainLife.Add("Armure", "2");
            _drainLife.Add("Cooldown", "3");
            _drainLife.Add("Vie", "250");
            _drainLife.Add("Vitesse", "0.02");
            _drainLife.Add("Capacité", "Smash");
            _drainLife.Add("Type", "Monstre");
            _drainLife.Add("Faction", "Sbire de Dracula");
            _drainLife.Add("Range", "15");
            _bestiary.Add("Géant", _drainLife);
            Dictionary<string, string> _gargoyle = new Dictionary<string, string>();
            _gargoyle.Add("Nom", "Gargouille");
            _gargoyle.Add("Description", "La menace vient d'en haut...");
            _gargoyle.Add("Dégâts", "9");
            _gargoyle.Add("Armure", "2");
            _gargoyle.Add("Cooldown", "2");
            _gargoyle.Add("Vie", "150");
            _gargoyle.Add("Vitesse", "0.02");
            _gargoyle.Add("Capacité", "Howl");
            _gargoyle.Add("Type", "Monstre");
            _gargoyle.Add("Faction", "Sbire de Dracula");
            _gargoyle.Add("Range", "15");
            _bestiary.Add("Gargouille", _gargoyle);
            Dictionary<string, string> _dracula = new Dictionary<string, string>();
            _dracula.Add("Nom", "Prince des vampires");
            _dracula.Add("Description", "Une entité démoniaque légendaire");
            _dracula.Add("Dégâts", "150");
            _dracula.Add("Armure", "4");
            _dracula.Add("Cooldown", "1");
            _dracula.Add("Vie", "1050");
            _dracula.Add("Vitesse", "0.01");
            _dracula.Add("Capacité", "Dran de vie");
            _dracula.Add("Type", "Monstre");
            _dracula.Add("Faction", "Sbire de Dracula");
            _dracula.Add("Range", "25");
            _bestiary.Add("Dracula", _dracula);
            Dictionary<string, string> _archer = new Dictionary<string, string>();
            _archer.Add("Nom", "Archer");
            _archer.Add("Description", "votre soldat le plus loyal.");
            _archer.Add("Dégâts", "7");
            _archer.Add("Armure", "1");
            _archer.Add("Cooldown", "2");
            _archer.Add("Vie", "150");
            _archer.Add("Vitesse", "0,01");
            _archer.Add("Capacité", "Dran de vie");
            _archer.Add("Type", "Soldat");
            _archer.Add("Faction", "Royaume Perdu");
            _archer.Add("Range", "30");
            _bestiary.Add("Archer", _archer);
        }

        internal Dictionary<string, Dictionary<string, string>> Beasts=> _bestiary;
    }
}
