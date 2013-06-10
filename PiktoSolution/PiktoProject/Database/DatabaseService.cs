using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pikto.Database
{
    class DatabaseService : IDatabaseService
    {
        piktoDB db = new piktoDB();

        public List<piktogramy> GetAllPiktograms()
        {
            return db.piktogramies.ToList<piktogramy>();
        }

        public piktogramy GetPiktogram(int id)
        {
            return db.piktogramies.SingleOrDefault(x => x.id == id);
        }

        List<piktogramy> GetAllPiktogramsWithCategory(string categoryName)
        {
            category cat = GetAllCategories().FirstOrDefault(x=>x.name==categoryName);
            return db.piktogramies.Where(x => x.category == cat).ToList();
        }

        public void AddPiktogram(string name, medium obj)
        {
            var piktogram = db.CreateObject<piktogramy>();
            piktogram.name = name;
            piktogram.media_id = obj.id;
            db.piktogramies.AddObject(piktogram);
            db.SaveChanges();
        }

        public void AddPiktogram(string name, medium obj, string categoryName)
        {
            var piktogram = db.CreateObject<piktogramy>();
            piktogram.name = name;
            piktogram.media_id = obj.id;

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

        public piktogramy EditPiktogram(int id, string name = null, medium obj = null, string categoryName = null)
        {
            piktogramy pikt = GetPiktogram(id);
            pikt.name = name ?? pikt.name;
            pikt.media_id = obj.id;

            if (categoryName != null)
            {
                category cat = GetCategory(categoryName);
                pikt.category_id = cat.id;
            }

            db.SaveChanges();
            return pikt;
        }

        public void DeletePiktogram(int id)
        {
            piktogramy pikt = GetPiktogram(id);
            db.piktogramies.DeleteObject(pikt);
            db.SaveChanges();
        }


        public List<category> GetAllCategories()
        {
            return db.categories.ToList<category>();
        }

        public category GetCategory(int id)
        {
            return db.categories.SingleOrDefault(x => x.id == id);
        }

        public category GetCategory(string name)
        {
            return db.categories.FirstOrDefault(x => x.name == name);
        }

        public void AddCategory(string name)
        {
            var cat = db.CreateObject<category>();
            cat.name = name;

            db.categories.AddObject(cat);
            db.SaveChanges();
        }

        public category EditCategory(int id, string name = null)
        {
            category cat = GetCategory(id);
            cat.name = name ?? cat.name;
            db.SaveChanges();
            return cat;
        }

        public void DeleteCategory(int id)
        {
            category cat = GetCategory(id);
            db.categories.DeleteObject(cat);
        }

        public map GetMap(int id)
        {
            return db.maps.SingleOrDefault(x => x.@new == id);
        }

        public void GeneratePrimaryMaps()
        {
            throw new NotImplementedException();
        }

        public void AddMap(int? new_id = null)
        {
            var map = db.CreateObject<map>();
            map.@new = map.old = (long)new_id;
            db.maps.AddObject(map);
            db.SaveChanges();
        }

        public map EditMap(int id, int? new_id = null)
        {
            var map = db.maps.SingleOrDefault(x => x.@new == id);
            map.old = (long)new_id;
            db.SaveChanges();

            return map;
        }

        //ISet<float> - typeof danych

        public cluster_bt GetClusterBT(int id)
        {
            return db.cluster_bt.SingleOrDefault(x => x.id == id);

        }

        public void AddClusterBT(int classs, float weight)
        {
            var cluster = db.CreateObject<cluster_bt>();
            cluster.@class = classs;
            cluster.weight = weight;
            db.cluster_bt.AddObject(cluster);
            db.SaveChanges();
        }

        public void EditClusterBT(int id, int? classs = null, float? weight = null)
        {
            var cluster = db.cluster_bt.SingleOrDefault(x => x.id == id);
            cluster.@class = classs ?? cluster.@class;
            cluster.weight = weight ?? cluster.weight;
            db.SaveChanges();

        }

        public void DeleteClusterBT(int id)
        {
            cluster_bt cluster = GetClusterBT(id);
            db.cluster_bt.DeleteObject(cluster);
        }

        public cluster_tb GetClusterTB(int id)
        {
            return db.cluster_tb.SingleOrDefault(x => x.id == id);
        }

        public void AddClusterTB(int classs, bool weight)
        {
            var cluster = db.CreateObject<cluster_tb>();
            cluster.@class = classs;
            cluster.weight = weight;
            db.cluster_tb.AddObject(cluster);
            db.SaveChanges();
        }

        public void EditClusterTB(int id, int? classs = null, bool? weight = null)
        {
            var cluster = db.cluster_tb.SingleOrDefault(x => x.id == id);
            cluster.@class = classs ?? cluster.@class;
            cluster.weight = weight ?? cluster.weight;
            db.SaveChanges();
        }

        public void DeleteClusterTB(int id)
        {
            cluster_tb cluster = GetClusterTB(id);
            db.cluster_tb.DeleteObject(cluster);
        }

        public medium GetMedium(int id)
        {
            return db.media.SingleOrDefault(x => x.id == id);
        }

        public void AddMedium(string name, object obj)
        {
            var media = db.CreateObject<medium>();
            if (name == "image")
            {
                byte[] img;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(obj as BitmapSource));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    img = ms.ToArray();
                }
                media.media_type_id = 1;
                media.@object = img;
            }
            else if (name == "video")
            {
                media.media_type_id = 2;
                media.@object = System.Text.Encoding.UTF8.GetBytes(obj as string);
            }
            else
            {
                media.media_type_id = 3;
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, obj);
                media.@object = ms.ToArray();
            }
            
        }

        public medium EditMedium(int id, string name, object obj)
        {
            medium media = GetMedium(id);
            if (name == "image")
            {
                byte[] img;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(obj as BitmapSource));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    img = ms.ToArray();
                }
                media.media_type_id = 1;
                media.@object = img;
            }
            else if (name == "video")
            {
                media.media_type_id = 2;
                media.@object = System.Text.Encoding.UTF8.GetBytes(obj as string);
            }
            else
            {
                media.media_type_id = 3;
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, obj);
                media.@object = ms.ToArray();
            }
            return media;
        }

        public void DeleteMedium(int id)
        {
            medium media = GetMedium(id);
            db.media.DeleteObject(media);
        }
    }
}
