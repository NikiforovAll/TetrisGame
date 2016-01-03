using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tetris
{
   // partial class Part
    //{
       public static   class PartDefinitions
        {

            public static SimpleCube[] GetPartDefinition(Part.Definition name)
            {
                //initializetion probl ** Graph
                SimpleCube[] TetraPart = new SimpleCube[4];
                for (int i = 1; i < 4; i++)
                {
                    TetraPart[i] = new SimpleCube();
                }
                TetraPart[0] = new SimpleCube(0, 0); 
                switch (name)
                {
                    case Part.Definition.O_Detail:       
                        TetraPart[0].SetConj(null, null, TetraPart[1]);
                        TetraPart[1].SetConj(null, null, null, TetraPart[2]);
                        TetraPart[2].SetConj(TetraPart[3]);
                        break;
                    case Part.Definition.I_Detail:                                             
                        TetraPart[0].SetConj(TetraPart[1], null, TetraPart[2]);
                        TetraPart[2].SetConj(null, null, TetraPart[3]);  
                        break;
                    case Part.Definition.T_Detail:
                        TetraPart[0].SetConj(TetraPart[1], TetraPart[2], TetraPart[3]);
                        break;
                    case Part.Definition.J_Detail:                        
                        TetraPart[0].SetConj(TetraPart[1], null, TetraPart[2]);
                        TetraPart[1].SetConj(null, TetraPart[3]);
                        break;
                    case Part.Definition.L_Detail:                     
                        TetraPart[0].SetConj(TetraPart[1], null, TetraPart[2]);
                        TetraPart[2].SetConj(null, TetraPart[3]);
                        break;
                    case Part.Definition.S_Detail:
                        TetraPart[0].SetConj(TetraPart[1], TetraPart[2]);
                        TetraPart[2].SetConj(null, null, TetraPart[3]);
                        break;
                    case Part.Definition.Z_Detail:
                        TetraPart[0].SetConj(null, TetraPart[1], TetraPart[2]);
                        TetraPart[1].SetConj(TetraPart[3]);
                        break;
                    default:
                        return null;
                }
                return TetraPart;
            }
           public static Part GerDefinedRandomPart(int x, int y)
            {
                Random r = new Random();

                int range = Enum.GetValues(typeof(Part.Definition)).Length;
               int ind = r.Next(range);

               string nameDetail = Enum.GetName(typeof(Part.Definition), ind);
              
               //Type Foo = Type.GetType("Part");
                Type Detail = Type.GetType("Tetris."+nameDetail);
            //   string AssName = Detail.AssemblyQualifiedName;
                
                Part p = (Part)Activator.CreateInstance(Detail, x,y);
                
             return p;
            }

        }
   // }
    
}
