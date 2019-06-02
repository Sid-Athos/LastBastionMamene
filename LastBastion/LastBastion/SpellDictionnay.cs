using System;
using System.Collections.Generic;
using System.Text;

namespace LastBastion
{
    internal class SpellBook
    {
        readonly Dictionary<string, Dictionary<string, string>> _spellBook;

        internal SpellBook()
        {
            _spellBook = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> _ignite = new Dictionary<string, string>();
            _ignite.Add("Nom", "Embrasement");
            _ignite.Add("Description", "Un puissant sort qui brûle vos adversaires, inflige des dégâts sur la durée.");
            _ignite.Add("Dégâts", "15");
            _ignite.Add("CastTime", "0");
            _ignite.Add("Soins", "0");
            _ignite.Add("Fréquence", "3");
            _ignite.Add("Durée", "30");
            _ignite.Add("Cooldown", "10");
            _ignite.Add("Type", "Magique");
            _ignite.Add("École", "Feu");
            _ignite.Add("Range", "30");
            _ignite.Add("Zone d'effet", "0");
            _spellBook.Add("Ignite", _ignite);
            Dictionary<string, string> _paralyse = new Dictionary<string, string>();
            _paralyse.Add("Nom", "Choc électrique");
            _paralyse.Add("Description", "Un sort de contrôle des foules, paralyse une cible pendant 15 secondes.");
            _paralyse.Add("Dégâts", "0");
            _paralyse.Add("CastTime", "0");
            _paralyse.Add("Soins", "0");
            _paralyse.Add("Fréquence", "0");
            _paralyse.Add("Durée", "15");
            _paralyse.Add("Cooldown", "10");      //Tous les cooldwns sont exprimés en secondes.
            _paralyse.Add("Type", "Magique");
            _paralyse.Add("École", "Foudre");
            _paralyse.Add("Range", "30");
            _paralyse.Add("Zone d'effet", "0");
            _spellBook.Add("ThunderWave", _paralyse);
            Dictionary<string, string> _drainLife = new Dictionary<string, string>();
            _drainLife.Add("Nom", "Drain de vie");
            _drainLife.Add("Description", "Inflige des dégâts et soigne l'utilisateur de la motié des dégâts infligés.");
            _drainLife.Add("Dégâts", "30");
            _drainLife.Add("Soins", "15");
            _drainLife.Add("CastTime", "1");
            _drainLife.Add("Fréquence", "0");
            _drainLife.Add("Durée", "0");
            _drainLife.Add("Cooldown", "15");      //Tous les cooldwns sont exprimés en secondes.
            _drainLife.Add("Type", "Magique");
            _drainLife.Add("École", "Ombre");
            _drainLife.Add("Range", "30");
            _drainLife.Add("Zone d'effet", "10");
            _spellBook.Add("Drain Life", _drainLife);
        }

        internal Dictionary<string, Dictionary<string, string>> SpellList => _spellBook;
    }
}