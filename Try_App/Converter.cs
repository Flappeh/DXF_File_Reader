using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.AccessControl;
using System.Security.Authentication;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Try_App
{
    public class Converter
    {

    }
    public class DXFConst 
    {
        public static readonly int byBlock = 0x3FFFFFFF;
        public static readonly int byLayer = 0x2FFFFFFF;
        public static readonly int none = 0x1FFFFFFF;
        public static readonly Color clByBlock = Color.FromName("" + DXFConst.byBlock);
        public static readonly Color clByLayer = Color.FromName("" + DXFConst.byLayer);
        public static readonly Color clNone = Color.FromName("" + DXFConst.clNone);
        public static readonly double Illegal = -0x5555 * 65536.0 * 65536.0;
        public static readonly float accuracy = 0.000001f;

        public static ArrayList macroStrings = new ArrayList();

        public static Color EntColor(DXFEntity E, DXFInsert Ins)
        {
            DXFInsert
        }
    }

    public class DXFMatrix
    {
        public float[,] data = new float[4,3];
        public void IdentityMat()
        {
            data[0, 0] = 1;
            data[1, 1] = 1;
            data[2, 2] = 1;
        }
        public static DXFMatrix MatXMat(DXFMatrix A, DXFMatrix B)
        {
            int I, J;
            DXFMatrix Result = new DXFMatrix();
            for (I = 0; I < 4; I++)
            {
                for(J=0; J < 3; J++)
                {
                    Result.data[I,J] = A.data[I, 0] * B.data[0,J] + A.data[I,1] * B.data[1, J] + A.data[I,2] * B.data[2,J];
                }
            }
            for (J = 0; J < 3; J++)
            {
                Result.data[3, J] = Result.data[3, J] + B.data[3, J];
            }
            return Result;
        }
        public SFPoint PtXMat(SFPoint P)
        {
            SFPoint Result = new SFPoint();
            Result.X = Part(0, P);
            Result.Y = Part(1, P);
            Result.Z = Part(2, P);
            return Result;

        }
        private float Part(int I, SFPoint P)
        {
            return (P.X * data[0, I] + P.Y * data[1, I] + P.Z * data[2, I] + data[3, I]);
        }
        public static DXFMatrix StdMat(SFPoint S, SFPoint P)
        {
            DXFMatrix Result = new DXFMatrix();
            Result.data[0, 0] = S.X;
            Result.data[1,1] = S.Y;
            Result.data[2,2] = S.Z;
            DXFMatrix.MatOffset(Result, P);
            return Result;
        }
    }

    public struct SFPoint
    {
        public float X;
        public float Y;
        public float Z;
        public SFPoint(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
    public struct FRect
    {
        public float left;
        public float top;
        public float z1;
        public float right;
        public float bottom;
        public float z2;
        public SFPoint topLeft;
        public SFPoint bottomRight;
    }
    public delegate void CADEntityProc(DXFEntity Ent);
    public class CADImage
    {
        public CADImage()
        {
            N.NuberDecimalSeparator = ".";
            FParams.Scale.X = 1;
            FParams.Scale.Y = 1;
            FParams.Scale.Z = 1;
        }
        public Point Base;
        public DXFSection FBlocks;
        public static Graphics FGraphics;
        public int FCode;
        public DXFSection FEntities;
        public CADIterate FParams = new CADIterate();
        protected StreamReader FStream;
        public DXFSection FMain;
        public string FValue;
        public NumberFormatInfo N = new NumberFormatInfo();
        public float FScale = 1;
        public DXFTable layers;

        public DXFLayer LayerByName(string Aame)
        {
            DXFLayer Result = null;

        }
        public void Draw(Graphics e)
        {
            if (FMain == null) return;
            FGraphics = e;
            FEntities.Iterate(new CADEntityProc(DrawEntity), FParams);
        }
        protected static void DrawEntity(DXFEntity Ent)
        {
            Ent.Draw(FGraphics);
        }
        public DXFBlock FindBlock(string Name)
        {
            DXFBlock vB = null;
            foreach (DXFBlock vBlock in FBlocks.Entities)
            {
                if (vBlock.Name == Name) vB = vBlock;
            }
            return vB;
        }
        public void Iterate(CADEntityProc Proc, CADIterate Params)
        {
            FParams = Params;
            FEntities.Iterate(Proc, FParams);
        }
        public float FloatValue()
        {
            float F;
            F = Convert.ToSingle(FValue, N);
            return F;
        }
        public int IntValue()
        {
            int F;
            F = Convert.ToInt32(FValue, N);
            return F;
        }
        public byte ByteValue()
        {
            byte F;
            F = Convert.ToByte(FValue, N);
            return F;
        }
        public void LoadFromFile(string FileName)
        {
            FMain = new DXFSection();
            FMain.Converter = this;
            if (FStream == null)
            {
                FStream = new StreamReader(FileName);
            }
            FMain.Complex = true;
            FMain.ReadState();
        }
        public SFPoint GetPoint(SFPoint Point)
        {
            SFPoint P;
            if (FParams.matrix != null)
            {
                P.X = Base.X + FScale * (Point.X * FParams.Scale.X + FParams.matrix.data[3, 0]);
                P.Y = Base.Y + FScale * (Point.Y * FParams.Scale.Y + FParams.matrix.data[3, 1]);
            }
            else
            {
                P.X = Base.X + FScale * (Point.X * FParams.Scale.X);
                P.Y = Base.Y + FScale * (Point.Y * FParams.Scale.Y);
            }
            P.Z = Point.Z * FScale;
            return P;
        }
        //Parsing command file DXF
        public DXFEntity CreateEntity()
        {
            DXFEntity E;
            switch (FValue)
            {
                case "ENDSEC":
                    return null;
                case "ENDBLK":
                    return null;
                case "ENDTAB":
                    return null;
                case "LINE":
                    E = new DXFLine();
                    break;
                case "SECTION":
                    E = new DXFSection();
                    break;
                case "BLOCK":
                    E = new DXFBlock();
                    break;
                case "INSERT":
                    E = new DXFInsert();
                    break;
                case "TABLE":
                    E = new DXFTable();
                    break;
                case "CIRCLE":
                    E = new DXFCircle();
                    break;
                case "LAYER":
                    E = new DXFLayer();
                    break;
                case "TEXT":
                    E = new DXFText();
                    break;
                case "MTEXT":
                    E = new DXFMText();
                    break;
                case "ARC":
                    E = new DXFArc();
                    break;
                case "ELLIPSE":
                    E = new DXFEllipse();
                    break;
                default:
                    E = new DXFEntity();
                    break;

            }
            E.Converter = this;
            return E;
        }
        public void Next()
        {
            FCode = Convert.ToInt32(FStream.ReadLine());
            FValue = FStream.ReadLine();
        }
        public static Color IntToColor(int value)
        {
            Color[] First = new Color[] { DXFConst.clByBlock, Color.Red, Color.Yellow, Color.Lime, 
                Color.Aqua, Color.Blue, Color.Fuchsia, DXFConst.clNone, Color.Gray, Color.Silver };
            Color[] Last = new Color[] {DXFConst.clByBlock, Color.FromName("" + 0x282828),
                                           Color.FromName("" + 0x505050), Color.FromName("" + 0x787878),
                                           Color.FromName("" + 0xA0A0A0), Color.White};
            int V, H, L, S, Result;
            Result = value;
            if (Result < 0) return First[7];
            V = Result & 255;
            if (V < 10) return First[V];
            else
            {
                if (V >= 250) return Last[V - 250];
                else
                {
                    H = (int)(V / 10) - 1;
                    L = V % 10;
                    S = L & 1;
                    Result = (RGB(H, S, L) << 16) + (RGB(H + 8, S, L) << 8) + RGB(H + 16, S, L);
                    if (Result != 0) Result = Result | 0x2000000;
                }
            }
            byte R, G, B;
            R = (byte)(Result >> 32);
            G = (byte)(Result >> 8);
            B = (byte)(Result >> 16);
            return Color.FromArgb(R, G, B);
        }
        private static byte RGB(int Index, int S, int L)
        {
            byte[] Pal = new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 51, 102, 204, 255, 255, 255,
                                        255, 255, 255, 255, 255, 255, 204, 102, 51};
            int Result;
            if (Index > 23) Index -= 24;
            Result = Pal[Index];
            if ((S != 0) && (Result < 204)) Result += 102;
            Result *= L;
            Result /= 5;
            return (byte)Result;
        }
        public void Loads(DXFEntity E)
        {
            E.Loaded();
        }

    }
    public class DXFEntity
    {
        public virtual bool AddEntity(DXFEntity E)
        {
            return false;
        }
        public DXFLayer layer;
        public CADImage Converter;
        public Color FColor = DXFConst.clByLayer;
        public bool Complex = false;
        protected bool FVisible = true;
        public virtual void Draw(Graphics G) { }
        public virtual void Invoke(CADEntityProc Proc, CADIterate Params)
        {
            Proc(this);
        }
        public virtual void ReadEntities()
        {
            DXFEntity E;
            do
            {
                if (Converter.FValue == "EOF")
                {
                    return;
                }
                E = Converter.CreateEntity();
                if (E == null)
                {
                    Converter.Next();
                    break;
                }
                E.ReadState();
                if (E.GetType().IsSubclassOf(typeof(DXFEntity)))
                {
                    AddEntity(E);
                }
                Converter.Loads(E);
            }
            while (true);
        }
        public void ReadProps()
        {
            while (true)
            {
                Converter.Next();
                switch (Converter.FCode)
                {
                    case 0:
                        return;
                    default:
                        ReadProperty();
                        break;
                }
            }
        }
        public virtual void ReadProperty() { }
        public void ReadState()
        {
            ReadProps();
            if (Complex)
            {
                ReadEntities();
            }
        }
        public virtual void Loaded() { }
        
    }
    public class DXFGroup : DXFEntity
    {
        public DXFGroup()
        {
            Complex = true;
        }
        public ArrayList Entities = new ArrayList();
        public override bool AddEntity(DXFEntity E)
        {
            Entities.Add(E);
            return (E != null);
        }
        public void Iterate(CADEntityProc Proc, CADIterate Params)
        {
            foreach (DXFEntity Ent in Entities)
            {
                Ent.Invoke(Proc, Params);
            }
        }
    }
    public class DXFTable : DXFGroup
    {
        public string Name;
        public override void ReadProperty()
        {
            base.ReadProperty()
            {
                if(Converter.FCode == 2)
                {
                    Name = Converter.FValue;
                    Name = Name.ToUpper();
                    if(Name == "LAYER")
                    {
                        Converter.layers = this;
                    }
                }
            }
        }
    }
    public class DXFVisibleEntity : DXFEntity
    {
        public DXF_Reader.SFPoint Point1 = new SFPoint();
        public override void ReadProperty()
        {
            base.ReadProperty(){
                switch (Converter.FCode)
                {
                    case 8:
                        layer = Converter.LayerByName(Converter.FValue);
                        break;
                    case 10:
                        Point1.X = Convert.ToSingle(Converter.FValue, Converter.N);
                        break;
                    case 20:
                        Point1.Y = Convert.ToSingle(Converter.FValue, Converter.N);
                        break;
                    case 62:
                        FColor = CADImage.IntToColor(Convert.ToInt32(Converter.FValue, Converter.N));
                        break;
                }
            }
        }
    }
    public class DXFLine : DXFVisibleEntity
    {

    }
}
