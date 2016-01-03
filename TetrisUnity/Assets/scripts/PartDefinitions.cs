namespace Tetris
{

    public static class PartDefinitions
    {
        public enum Definition { O_Detail, I_Detail, J_Detail, L_Detail, S_Detail, Z_Detail, T_Detail };

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
                case Definition.O_Detail:
                    tetraPart[0].SetConj(null, null, tetraPart[1]);
                    tetraPart[1].SetConj(null, null, null, tetraPart[2]);
                    tetraPart[2].SetConj(tetraPart[3]);
                    break;
                case Definition.I_Detail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[2].SetConj(null, null, tetraPart[3]);
                    break;
                case Definition.T_Detail:
                    tetraPart[0].SetConj(tetraPart[1], tetraPart[2], tetraPart[3]);
                    break;
                case Definition.J_Detail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[1].SetConj(null, tetraPart[3]);
                    break;
                case Definition.L_Detail:
                    tetraPart[0].SetConj(tetraPart[1], null, tetraPart[2]);
                    tetraPart[2].SetConj(null, tetraPart[3]);
                    break;
                case Definition.S_Detail:
                    tetraPart[0].SetConj(tetraPart[1], tetraPart[2]);
                    tetraPart[2].SetConj(null, null, tetraPart[3]);
                    break;
                case Definition.Z_Detail:
                    tetraPart[0].SetConj(null, tetraPart[1], tetraPart[2]);
                    tetraPart[1].SetConj(tetraPart[3]);
                    break;
                default:
                    return null;
            }
            return tetraPart;
        }
        //public static Part GerDefinedRandomPart(int x, int y)
        // {
        //     Random r = new Random();

        //     int range = Enum.GetValues(typeof(Part.Definition)).Length;
        //    int ind = r.Next(range);

        //    string nameDetail = Enum.GetName(typeof(Part.Definition), ind);

        //    //Type Foo = Type.GetType("Part");
        //     Type Detail = Type.GetType("Tetris."+nameDetail);
        // //   string AssName = Detail.AssemblyQualifiedName;

        //     Part p = (Part)Activator.CreateInstance(Detail, x,y);

        //  return p;
        // }

    }


}
