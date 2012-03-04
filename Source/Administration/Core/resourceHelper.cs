using System.Drawing;
using System.IO;
using System.Reflection;

namespace updateSystemDotNet.Administration.Core {
	internal static class resourceHelper {
		public static Image getImage(string imageName) {
			using (
				Stream sImage =
					Assembly.GetExecutingAssembly().GetManifestResourceStream(
						string.Format("updateSystemDotNet.Administration.Images.{0}", imageName))) {
				return Image.FromStream(sImage);
			}
		}

		public static Image getImage(string imageName, string additionalNamespace) {
			return getImage(string.Format("{0}.{1}", additionalNamespace, imageName));
		}
	}
}