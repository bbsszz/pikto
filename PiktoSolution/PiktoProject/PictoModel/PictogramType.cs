using System.Windows.Media.Imaging;
using Pikto.Utils;
using Pikto.Database;
using System.IO;
using System;

namespace Pikto.PictoModel
{
	class PictogramType
	{
		public string Name { get; set; }
        public CategoryType Categories { get; set; }
        public BitmapSource Image { get; set; }
        public string Medium { get; set; }
        public MediaTypeEnum MediumType { get; set; }

        public PictogramType()
        {
        }

        public PictogramType(piktogramy pikt)
        {
            Name = pikt.name;
            try
            {
                Categories = new CategoryType(pikt.category.name);
            }
            catch (Exception e)
            {
            }
            using (var stream = new MemoryStream(pikt.image))
            {
                JpegBitmapDecoder decoder = new JpegBitmapDecoder(stream,
                                                BitmapCreateOptions.PreservePixelFormat,
                                                BitmapCacheOption.OnLoad);
                BitmapSource bitmapSource = decoder.Frames[0];
                bitmapSource.Freeze();
                Image = bitmapSource;
            }
            Medium = System.Text.Encoding.ASCII.GetString(pikt.medium.@object);
            MediumType = (MediaTypeEnum)pikt.media_id;
        }
	}
}
