using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace Pikto
{
    class DatabaseService : IDatabaseService
    {
        piktoDB db = new piktoDB();

        public  piktogramy GetPiktogram(int id)
        {
            return db.piktogramies.SingleOrDefault(x => x.id == id);
        }

        public  void AddPiktogram(string name, System.Windows.Media.Imaging.BitmapSource image)
        {
            var piktogram = db.CreateObject<piktogramy>();
            piktogram.name = name;
            byte[] img;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                img = ms.ToArray();
            }
            piktogram.image = img;
            db.piktogramies.AddObject(piktogram);
            db.SaveChanges();
        }

        public  void AddPiktogram(string name, System.Windows.Media.Imaging.BitmapSource image, string categoryName)
        {
            var piktogram = db.CreateObject<piktogramy>();
            piktogram.name = name;
            byte[] img;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                img = ms.ToArray();
            }
            piktogram.image = img;

            category cat = GetCategory(categoryName);
            if (cat == null)
            {
                AddCategory(categoryName);
                cat = GetCategory(categoryName);
            }
            piktogram.category_id = cat.id;

            db.piktogramies.AddObject(piktogram);
            db.SaveChanges();
        }

        public  piktogramy EditPiktogram(int id, string name = null, System.Windows.Media.Imaging.BitmapSource image = null, string categoryName = null)
        {
            piktogramy pikt = GetPiktogram(id);
            pikt.name = name ?? pikt.name;
            if (image != null)
            {
                byte[] img;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    img = ms.ToArray();
                }
                pikt.image = img;
            }

            if (categoryName!=null)
            {
                category cat = GetCategory(categoryName);
                pikt.category_id = cat.id;
            }

            db.SaveChanges();
            return pikt;
        }

        public  void DeletePiktogram(int id)
        {
            piktogramy pikt = GetPiktogram(id);
            db.piktogramies.DeleteObject(pikt);
            db.SaveChanges();
        }

        public  category GetCategory(int id)
        {
            return db.categories.SingleOrDefault(x => x.id == id);
        }

        public  category GetCategory(string name)
        {
            return db.categories.FirstOrDefault(x => x.name == name);
        }

        public  void AddCategory(string name)
        {
            var cat = db.CreateObject<category>();
            cat.name = name;

            db.categories.AddObject(cat);
            db.SaveChanges();
        }

        public  category EditCategory(int id, string name = null)
        {
            category cat = GetCategory(id);
            cat.name = name ?? cat.name;
            db.SaveChanges();
            return cat;
        }

        public  void DeleteCategory(int id)
        {
            category cat = GetCategory(id);
            db.categories.DeleteObject(cat);
        }

        public  map GetMap(int id)
        {
            return db.maps.SingleOrDefault(x => x.old == id);
        }

        public  void GeneratePrimaryMaps()
        {
            List<long> ids = new List<long>();
            ids = db.piktogramies.Select(x => x.id).ToList();

            foreach (long id in ids)
            {
                var map = db.CreateObject<map>();
                map.old = id;
                map.@new = id;
                db.maps.AddObject(map);
            }
            db.SaveChanges();

        }

        public  void AddMap(int? new_id = null)
        {
            throw new NotImplementedException();
        }

        public  map EditMap(int id, int? new_id = null)
        {
            throw new NotImplementedException();
        }

        public  cluster_bt GetClusterBT(int id)
        {
            throw new NotImplementedException();
        }

        public  void AddClusterBT(int classs, float weight)
        {
            throw new NotImplementedException();
        }

        public  void EditClusterBT(int id, int? classs = null, float? weight = null)
        {
            throw new NotImplementedException();
        }

        public  void DeleteClusterBT(int id)
        {
            throw new NotImplementedException();
        }

        public  cluster_tb GetClusterTB(int id)
        {
            throw new NotImplementedException();
        }

        public  void AddClusterTB(int classs, bool weight)
        {
            throw new NotImplementedException();
        }

        public  void EditClusterTB(int id, int? classs = null, bool? weight = null)
        {
            throw new NotImplementedException();
        }

        public  void DeleteClusterTB(int id)
        {
            throw new NotImplementedException();
        }
    }
}
