using System.Windows.Media.Imaging;
using Pikto.Utils;

namespace Pikto.PictoModel
{
	class PictogramType
	{
		public string Name { get; set; }
        public CategoryType Categories { get; set; }
        public BitmapSource Image { get; set; }
        public string Medium { get; set; }
        public MediaTypeEnum MediumType { get; set; }
	}
}
