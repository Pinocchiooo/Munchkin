using System;
using System.Collections.Generic;
using System.Text;

namespace KonsolenKampfspiel
{       
    public class Player
    {
        public Player(String name = "Munchkin", Gender gender = Gender.male)
        {
            this.name = name;
            this.gender = gender;
            category = Category.Mensch;
            race = Race.Mensch;
            level = 1;
            hands = new Equipment[2];
            others = new Equipment[10];
        }

        string name;
        Gender gender;

        Category category;
        Race race;

        int strenght
        {
            get
            {
                return level; //TODO: and equipmentpoints
            }
        }
        int level;

        Equipment headgear;
        Equipment footwear;
        Equipment[] hands;
        Equipment suit;
        Equipment[] others;



    }
}
