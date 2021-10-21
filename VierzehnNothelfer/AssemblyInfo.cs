using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "FA-R")]
[assembly: ExportFont("FontAwesome5Brands.otf", Alias = "FA-B")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "FA-S")]
//Beispiel
//<Label Text="&#xf654;" FontSize="Large" FontFamily="FA-S" TextColor="White"/>

//Eigenschaft:Embedded resource in Namespace\Resources. In XAML: FontFamily="Schwabacher" 
[assembly: ExportFont("OldStandardBold.ttf", Alias = "OS-B")]
[assembly: ExportFont("AlbertText-Bold.ttf", Alias = "AT-B")]
[assembly: ExportFont("SansitaOne.ttf", Alias = "SO")]
[assembly: ExportFont("LibreBaskerville-Bold.ttf", Alias = "LB-B")]
[assembly: ExportFont("LibreBaskerville-Italic.ttf", Alias = "LB-I")]
[assembly: ExportFont("LibreBaskerville-Regular.ttf", Alias = "LB-R")]
