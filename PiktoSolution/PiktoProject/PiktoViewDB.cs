using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Drawing;

namespace Pikto
{
    class PiktoViewDB
    {
        Database.DatabaseService db;
        Dictionary<int, string> idObjectType;
        Dictionary<int, Image<Gray, byte>> idImage;
        Dictionary<int, string> idMedia;
        string catagory;
        public PiktoViewDB(Database.DatabaseService db,string catagory = "none")
        {
            this.catagory = catagory;
            this.db=db;
            idMedia=new Dictionary<int,string>();
            idObjectType = new Dictionary<int,string>();
            idImage=new Dictionary<int,Image<Gray,byte>>();
            getDBInfo();
            int i = 0;
        }
        public void getDBInfo()
        {
            List<Database.piktogramy> piktoList;
            if (catagory == "none")
            {
                piktoList = db.GetAllPiktograms();
            }
            else
            {
                piktoList = db.GetAllPiktogramsWithCategory(catagory);
            }
            foreach (Database.piktogramy p in piktoList)
            {
                int id = (int)p.id;
                idObjectType[id] = p.medium.media_type.name;
                idImage[id] = byteArrayToImage(p.image).ThresholdBinary(new Gray(100), new Gray(255));
                idMedia[id] = byteArrayToStr(p.medium.@object);
            }
        }
        public string getMediaType(int id)
        {
            if (idObjectType.ContainsKey(id))
            {
                return idObjectType[id];
            }
            else 
            {
                return "null";
            }
        }
        public string getMediaName(int id)
        {
            if (idMedia.ContainsKey(id))
            {
                return idMedia[id];
            }
            else
            {
                return "null";
            }
        }
        public Dictionary<int, Image<Gray, byte>> getImageIdDic()
        {
            return idImage;
        }
        public Image<Gray, byte> byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image i = Image.FromStream(ms);
            Bitmap b = new Bitmap(i);
            return new Image<Gray, byte>(b);
        }
        public string byteArrayToStr(byte[] byteArrayIn)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            return ascii.GetString(byteArrayIn);
        }
    }
}
