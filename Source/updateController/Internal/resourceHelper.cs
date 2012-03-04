using System.Drawing;
using System.IO;
using System.Reflection;

namespace updateSystemDotNet.Internal {
	internal static class resourceHelper {
		public static Image getResourceImage(string imagename) {
			using (
				Stream strImage =
					Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("updateSystemDotNet.Images.{0}", imagename))
				) {
				return Image.FromStream(strImage);
			}
		}
	}
}