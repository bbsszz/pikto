using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pikto.Utils;
using System.Windows.Input;
using Pikto.View;
using Pikto.Database;
using Pikto.PictoModel;
using Emgu.CV;
using System.Drawing;
using System.Windows.Media.Imaging;
using Emgu.CV.Structure;
using Pikto.Command;

namespace Pikto.ViewModel.WizardViewModel
{
    class PictogramsManagementPathViewModel : WizardBaseViewModel
	{
        //private List<category> categories;

        //public List<string> Categories
        //{
        //    get { return categories.Select(x => x.name.ToString()).ToList(); }
        //}


        public List<CategoryType> CategoriesList { get; private set; }

        
        public List<PictogramType> Piktograms
        {
            get { return db.GetAllPiktograms().Select(x => new PictogramType(x)).ToList(); }
        }

        public PictogramType Piktogram { get; private set; }

        private MediaTypeEnum mediaType;

        public MediaTypeEnum MediaType
        {
            get { return mediaType; }
            set
            {
                if (mediaType != value)
                {
                    mediaType = value;
                    OnPropertyChanged("MediaType");
                }
            }
        }

        private ChooseEnum action;

		public ChooseEnum Action
		{
			get { return action; }
			set
			{
				if (action != value)
				{
					action = value;
					OnPropertyChanged("Action");
				}
			}
		}

        private ActionEnum editAction;
        public ActionEnum EditAction
        {
            get { return editAction; }
            set
            {
                if (editAction != value)
                {
                    editAction = value;
                    OnPropertyChanged("EditAction");
                }
            }
        }

		private DatabaseService db;

        public int SelectedIndex
        {
            get;
            set;
        }

        public CategoryType ChosenCategory
        {
            get
            {
                if (SelectedIndex >= 0)
                {
                    return CategoriesList[SelectedIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public PictogramType ChosenPictogram
        {
            get
            {
                if (SelectedIndex >= 0)
                {
                    return Piktograms[SelectedIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool NewPictogram { get; set; }

        public string ObjectName { get; set; }

        public string PictoName { get; set; }

		public PictogramsManagementPathViewModel()
		{
			db = new DatabaseService();
            SelectedIndex = -1;
		}

		public override void Loaded()
		{
			base.Loaded();
			Action = ChooseEnum.New;
		}

		public double ViewWidth { get { return 636.0; } }
		public double ViewHeight { get { return 478.0; } }

        internal void HandleCategories()
        {
            CategoriesList = db.GetAllCategories().Select(x => new CategoryType(x.name)).ToList();
            OnPropertyChanged("CategoriesList");
        }

        public BitmapSource LifeImage { get; set; }

        public BitmapSource CutImage { get; set; }

        Camera camera;

        MDetector md;

        public string Info { get; set; }

        internal void HandleCamera()
        {
            camera = new Camera();
            camera.TimeElapsed += new EventHandler<CameraEventArgs>(displayImage);
            md = new MDetector();
            SaveImageCmd = new BasicCommand(p => {
                Piktogram.Image = CutImage;
                Info = "Zapisano";
                StopHandlingCamera();
                OnPropertyChanged("Info");
            });
        }

        internal void StopHandlingCamera()
        {
            camera.TimeElapsed -= new EventHandler<CameraEventArgs>(displayImage);
        }

        public void PreparePictogram()
        {
            Piktogram = new PictogramType();
        }

        public void PreparePictogramToEdit()
        {
            Piktogram = ChosenPictogram;
            PictoName = Piktogram.Name;
            OnPropertyChanged("PictoName");
        }

        public void SetAsNew()
        {
            NewPictogram = true;
            OnPropertyChanged("NewPictogram");
        }

        public void SetAsOld()
        {
            NewPictogram = false;
            OnPropertyChanged("NewPictogram");
        }

        public void PutName()
        {
            Piktogram.Name = PictoName;
        }

        public void PutCategory()
        {
            Piktogram.Categories = ChosenCategory;
        }

        internal void PutObject()
        {
            Piktogram.Medium = ObjectName;
            Piktogram.MediumType = MediaType;
        }


        internal void AddPiktogram()
        {
            db.AddPiktogram(Piktogram.Name, Piktogram.MediumType, Piktogram.Medium, Piktogram.Categories.Name, Piktogram.Image);
            OnPropertyChanged("Piktograms");
        }

        public ICommand SaveImageCmd { get; set; }


        bool pictoRecognized = false;
        private void displayImage(object s, CameraEventArgs e)
        {

            LifeImage = Camera.ToBitmapSource(e.Image);
            OnPropertyChanged("LifeImage");

            md.findMarkers(e.Image.Convert<Gray, Byte>());
            if (md.isMarker())
            {
                CutImage = Camera.ToBitmapSource(md.threshold(md.markers[0].getSymbolImage(), 150, 255));
                pictoRecognized = true;
            }
            else if (!pictoRecognized)
            {
                CutImage = Camera.ToBitmapSource(Properties.Resources.noImage);
            }
            OnPropertyChanged("CutImage");
        }



        internal void DeletePictogram()
        {
            db.DeletePiktogram((int)db.GetPiktogram(ChosenPictogram.Name).id);
            OnPropertyChanged("Piktograms");
        }

        internal void EditPictogram()
        {
            db.EditPiktogram(Piktogram.Name, Piktogram.MediumType, Piktogram.Medium, Piktogram.Categories.Name, Piktogram.Image);
            OnPropertyChanged("Piktograms");
        }
    }
}
