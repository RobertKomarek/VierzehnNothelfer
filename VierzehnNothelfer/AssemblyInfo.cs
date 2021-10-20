using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "FA-R")]
[assembly: ExportFont("FontAwesome5Brands.otf", Alias = "FA-B")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "FA-S")]
//Beispiel
//<Label Text="&#xf654;" FontSize="Large" FontFamily="FA-S" TextColor="White"/>

//Eigenschaft:Embedded resource in Namespace\Resources. In XAML: FontFamily="Schwabacher" 
//[assembly: ExportFont("OldStandardBold.ttf", Alias = "OS-B")]
