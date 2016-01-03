using System;

namespace Tetris
{

    public static class PartDefinitions
    {
        public static Random R = new Random();
        public enum Definition { ODetail, Detail, JDetail, LDetail, SDetail, ZDetail, T_Detail };
        public static SimpleCube[] GetPartDefinition(Definition name)
        {
            //initializetion probl ** Graph
            SimpleCube[] tetraPart = new SimpleCube[4];
            for (int i = 1; i < 4; i++)
            {
                tetraPart[i] = new SimpleCube();
            }
            tetraPart[0] = new SimpleCube(0, 0);
            switch (name)
            {
                case Definition.ODetail:
                    tetraPart[0].SetConj(null, null, tetraPart[1]);
                    tetraPart[1].SetConj(null, null, null, tetraPart[2]);
                    tetraPart[2].SetConj(tetraPart[3]);
                    break;
                case Definition.Detail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[2].SetConj(null, null, tetraPart[3]);
                    break;
                case Definition.T_Detail:
                    tetraPart[0].SetConj(tetraPart[1], tetraPart[2], tetraPart[3]);
                    break;
                case Definition.JDetail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[1].SetConj(null, tetraPart[3]);
                    break;
                case Definition.LDetail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[2].SetConj(null, tetraPart[3]);
                    break;
                case Definition.SDetail:
                    tetraPart[0].SetConj(tetraPart[1], tetraPart[2]);
                    tetraPart[2].SetConj(null, null, tetraPart[3]);
                    break;
                case Definition.ZDetail:
                    tetraPart[0].SetConj(null, tetraPart[1], tetraPart[2]);
                    tetraPart[1].SetConj(tetraPart[3]);
                    break;
                default:
                    return null;
            }
            return tetraPart;
        }
        public static Definition GerDefinedRandomPart()
        {
            int range = Enum.GetValues(typeof(Definition)).Length;
            int ind = R.Next(range);
            return (Definition)ind;
        }

    }


}
