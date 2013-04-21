using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Pikto
{
    interface IDatabaseService
    {
        #region piktogramy
        List<piktogramy> GetAllPiktograms();
        piktogramy GetPiktogram(int id);

        void AddPiktogram(string name, medium obj);
        void AddPiktogram(string name, medium obj, string categoryName);

        piktogramy EditPiktogram(int id, string name = null, medium obj = null, string categoryName = null);

        void DeletePiktogram(int id);

        #endregion

        #region media
        medium GetMedium(int id);
        void AddMedium(string name, object obj);

        medium EditMedium(int id, string name, object obj);

        void DeleteMedium(int id);
        #endregion

        #region kategorie
        category GetCategory(int id);

        void AddCategory(string name);

        category EditCategory(int id, string name = null);

        void DeleteCategory(int id);
        #endregion

        #region mapowanie

        map GetMap(int id);

        void GeneratePrimaryMaps();
        void AddMap(int? new_id = null);

        map EditMap(int id, int? new_id = null);

        #endregion

        #region klaster_bottom_top

        cluster_bt GetClusterBT(int id);

        void AddClusterBT(int classs, float weight);

        void EditClusterBT(int id, int? classs = null, float? weight = null);

        void DeleteClusterBT(int id);

        #endregion

        #region klaster_top_bottom

        cluster_tb GetClusterTB(int id);

        void AddClusterTB(int classs, bool weight);

        void EditClusterTB(int id, int? classs = null, bool? weight = null);

        void DeleteClusterTB(int id);

        #endregion


    }
}
