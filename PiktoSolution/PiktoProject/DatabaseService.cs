using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikto
{
    class DatabaseService : IDatabaseService
    {


        public piktogramy GetPiktogram(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPiktogram(string name, System.Windows.Media.Imaging.BitmapSource image)
        {
            throw new NotImplementedException();
        }

        public void AddPiktogram(string name, System.Windows.Media.Imaging.BitmapSource image, string categoryName)
        {
            throw new NotImplementedException();
        }

        public piktogramy EditPiktogram(int id, string name = null, System.Windows.Media.Imaging.BitmapSource image = null, string categoryName = null)
        {
            throw new NotImplementedException();
        }

        public void DeletePiktogram(int id)
        {
            throw new NotImplementedException();
        }

        public category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(string name)
        {
            throw new NotImplementedException();
        }

        public category EditCategory(int id, string name = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public map GetMap(int id)
        {
            throw new NotImplementedException();
        }

        public void GeneratePrimaryMaps()
        {
            throw new NotImplementedException();
        }

        public void AddMap(int? new_id = null)
        {
            throw new NotImplementedException();
        }

        public map EditMap(int id, int? new_id = null)
        {
            throw new NotImplementedException();
        }

        public cluster_bt GetClusterBT(int id)
        {
            throw new NotImplementedException();
        }

        public void AddClusterBT(int classs, float weight)
        {
            throw new NotImplementedException();
        }

        public void EditClusterBT(int id, int? classs = null, float? weight = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteClusterBT(int id)
        {
            throw new NotImplementedException();
        }

        public cluster_tb GetClusterTB(int id)
        {
            throw new NotImplementedException();
        }

        public void AddClusterTB(int classs, bool weight)
        {
            throw new NotImplementedException();
        }

        public void EditClusterTB(int id, int? classs = null, bool? weight = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteClusterTB(int id)
        {
            throw new NotImplementedException();
        }
    }
}
