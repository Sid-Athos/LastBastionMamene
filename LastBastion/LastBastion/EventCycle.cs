using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace LastBastion
{
    class EventCycle
    {
        Game _game;
        string _event;
        int _currentCycle;
        int g;
        int b;
        //Comet Event
        int _lastPing;
        bool _isCometFall;
        Vectors _start;
        Vectors _target;
        //Description
        string _desc;
        //Constructor
        public EventCycle(Game game)
        {
            _game = game;
            _event = "";
            _currentCycle = 1;
            _lastPing = 1;
            g = 0;
            b = 0;
            _desc = "";
            UpdateDescription();
        }
        public void Update()
        {
            if (_game.GetTimer == 1)
            {
                _lastPing = 1;
            }
            if (_game.Cycle != _currentCycle)
            {
                //Reset Condition
                _currentCycle = _game.Cycle;
                //Select Event
                _event = SelectEvent();
                UpdateDescription();
            }
            if (_event == "RainOfFire" && _game.GetTimer != _lastPing && _game.GetTimer % 5 == 0)
            {
                //Reset Condition
                _lastPing = _game.GetTimer;
                //Call Comet Fonction
                _isCometFall = true;
                Vector2f i = RandomHutPosition();
                _target = new Vectors(i.X, i.Y);
                _start = new Vectors(_target.X + 30, _target.Y - 45);
            }
            if (_isCometFall)
            {
                CometFall();
            }
        }
        // Getter And Setter Event from extern class
        public string Event
        {
            get { return _event; }
            set { _event = value; }
        }
        // Getter And Setter Event Description from extern class
        public string EventDescription
        {
            get { return _desc; }
            set { _desc = value; }
        }
        // Return Random Hut Position
        public Vector2f RandomHutPosition()
        {
            List<Vector2f> list = new List<Vector2f>();
            foreach (var item in _game.GetGrid)
            {
                list.Add(item.Value.GetVec2F);
            }
            int rdm = _game.RandomNumber(0, list.Count - 1);
            return list[rdm];
        }
        // Set The new Event
        public string SelectEvent()
        {
            if (_game.Cycle % 5 == 0)
            {
                return "RainOfFire";
            }
            else
            {
                if (g > b + 2)
                {
                    int rdm = _game.RandomNumber(1, 3);
                    if (rdm == 1)
                    {
                        b++;
                        return "PWood";
                    }
                    else if (rdm == 2)
                    {
                        b++;
                        return "PStone";
                    }
                    else
                    {
                        b++;
                        return "PFood";
                    }
                }
                else if (b > g + 2)
                {
                    int rdm = _game.RandomNumber(1, 3);
                    if (rdm == 1)
                    {
                        g++;
                        return "AWood";
                    }
                    else if (rdm == 2)
                    {
                        g++;
                        return "AStone";
                    }
                    else
                    {
                        g++;
                        return "AFood";
                    }
                }
                else
                {
                    int rdm = _game.RandomNumber(1, 6);
                    if (rdm == 1)
                    {
                        g++;
                        return "AWood";
                    }
                    else if (rdm == 2)
                    {
                        g++;
                        return "AStone";
                    }
                    else if (rdm == 3)
                    {
                        g++;
                        return "AFood";
                    }
                    else if (rdm == 4)
                    {
                        b++;
                        return "PStone";
                    }
                    else if (rdm == 5)
                    {
                        b++;
                        return "PWood";
                    }
                    else
                    {
                        b++;
                        return "PFood";
                    }
                }
            }
        }
        //Event Description
        public void UpdateDescription()
        {
            if (_event == "AStone")
            {
                _desc = "The weather is nice and the birds are singing.\n This year the harvest of stone will be \n abundant.\n Enjoy it, next day could be less auspicious.\n Recolt of stone are improve by 15%.";
            }
            else if (_event == "AWood")
            {
                _desc = "The weather is nice and the birds are singing.\n This year the harvest of wood will be \n abundant.\n Enjoy it, next day could be less auspicious.\n Recolt of wood are improve by 15%.";
            }
            else if (_event == "AFood")
            {
                _desc = "The weather is nice and the birds are singing.\n This year the harvest of food will be \n abundant.\n Enjoy it, next day could be less auspicious.\n Recolt of food are improve by 15%.";
            }
            else if (_event == "PStone")
            {
                _desc = "Times are hard.\n For this year the harvests are very poor in stone.\n It will be necessary to pay attention \n to the expenses of the kingdoms.\n Recolt of stone are lower by 15%.";
            }
            else if (_event == "PFood")
            {
                _desc = "Times are hard.\n For this year the harvests are very poor in food.\n It will be necessary to pay attention \n to the expenses of the kingdoms.\n Recolt of food are lower by 15%.";
            }
            else if (_event == "PWood")
            {
                _desc = "Times are hard.\n For this year the harvests are very poor in wood.\n It will be necessary to pay attention \n to the expenses of the kingdoms.\n Recolt of wood are lower by 15%.";
            }
            else if (_event == "RainOfFire")
            {
                _desc = "Dracula to use his magic against us.\n We must expect terrible news.\n Comets fall from the sky.";
            }
            else
            {
                _desc = "The times are calm,\n we must wait for darker days.\n Nothing special will happen this year.";
            }
        }
        // Fall a Comet
        public void CometFall()
        {
            if (_start.IsInRange(_start,_target,3.0f))
            {
                _isCometFall = false;
                ShockDamage();
            }
            else
            {
                _start = _start.Movement(_start, _target, 1, 0.03f, 1.0f);
                _game.Sprites.GetSprite("Comet").Position = new Vector2f(_start.X,_start.Y);
                _game.GetWindow.Render.Draw(_game.Sprites.GetSprite("Comet"));
            }
        }
        public void ShockDamage()
        {
            foreach (var item in _game.GetGrid)
            {
                if (item.Value.GetVec2F == new Vector2f(_target.X,_target.Y))
                {
                    //Main Shock
                    if (item.Value.Building != null)
                    {
                        item.Value.Building.Life -= 100;
                    }
                    //Other
                    if (_game.GetGrid.ContainsKey(new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y - 1)))
                    {
                        if (_game.GetGrid[new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y - 1)].Building != null)
                        {
                            _game.GetGrid[new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y - 1)].Building.Life -= 75;
                        }
                    }
                    if (_game.GetGrid.ContainsKey(new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y + 1)))
                    {
                        if (_game.GetGrid[new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y + 1)].Building != null)
                        {
                            _game.GetGrid[new Vector2i(item.Value.GetVec2I.X, item.Value.GetVec2I.Y + 1)].Building.Life -= 75;
                        }
                    }
                    if (_game.GetGrid.ContainsKey(new Vector2i(item.Value.GetVec2I.X - 1, item.Value.GetVec2I.Y)))
                    {
                        if (_game.GetGrid[new Vector2i(item.Value.GetVec2I.X - 1, item.Value.GetVec2I.Y)].Building != null)
                        {
                            _game.GetGrid[new Vector2i(item.Value.GetVec2I.X - 1, item.Value.GetVec2I.Y)].Building.Life -= 75;
                        }
                    }
                    if (_game.GetGrid.ContainsKey(new Vector2i(item.Value.GetVec2I.X + 1, item.Value.GetVec2I.Y)))
                    {
                        if (_game.GetGrid[new Vector2i(item.Value.GetVec2I.X + 1, item.Value.GetVec2I.Y)].Building != null)
                        {
                            _game.GetGrid[new Vector2i(item.Value.GetVec2I.X + 1, item.Value.GetVec2I.Y)].Building.Life -= 75;
                        }
                    }
                }
            }
        }
    }
}
