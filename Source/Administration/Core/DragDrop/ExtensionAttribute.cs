//HACK: this is to support a .NET language 3.5 feature in .NET 2.0
//see, http://www.danielmoth.com/Blog/2007/05/using-extension-methods-in-fx-20.html
namespace System.Runtime.CompilerServices {
	public class ExtensionAttribute : Attribute {
	}
}