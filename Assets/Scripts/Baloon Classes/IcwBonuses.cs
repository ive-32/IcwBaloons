using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace IcwBaloons
{


    public class IcwBonuses 
    {
        enum BonusType {SpeedDown, AddScores, RestoreLive, SpeedUp}
        const int bonustypecount = 4;
        float ttl;
        BonusType bonus;
        public IcwBonuses()
        {
            bonus = (BonusType)Random.Range(0, bonustypecount);
        }

        public string GetBonusText()
        {
            string[,] bonustext =
                { 
                    {"Slo-o-w Mo!", "Matrix like!!" , "Zen with U"},
                    {"Christmas", "!Scores!", "+100" },
                    {"Take it Dude", "Clear Again", "Take u time" },
                    {"!!!F1!!!", "SpeedUp" , "Hurricane" } 
                };
            int bonusnumber = (int)bonus;
            return bonustext[bonusnumber, Random.Range(0,3)];
        }

        public string GetBonusDescribe()
        {
            string[] bonustext =
                {
                "Speed Down", "Add scores", "Reset lost", "Speed Up"
                };
            int bonusnumber = (int)bonus;
            return bonustext[bonusnumber];
        }
        public void BonusAction()
        {
            switch (bonus)
            {
                case BonusType.SpeedDown: IcwGame.instance.SetGameSpeed(0.5f); break;
                case BonusType.SpeedUp: IcwGame.instance.SetGameSpeed(1.5f); break;
                case BonusType.AddScores: IcwScores.instance.AddScores(200); break;
                case BonusType.RestoreLive: IcwGame.instance.lostballs = 0; break;
            }
        }
    }
}
