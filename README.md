# Export-SfCartesianChart-as-an-Image-in-.NET-MAUI
This article provides a detailed walkthrough on how to export the chart as an image in a [.NET MAUI Cartesian Chart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts).

You can export the chart view as an image in the desired file format using the [SaveAsImage](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartBase.html#Syncfusion_Maui_Charts_ChartBase_SaveAsImage_System_String_) method of the [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html) class. The supported image formats are **JPEG and PNG**. By default, if you don’t specify the image format with the filename, the chart will be exported as a PNG image.

**Important Notes**
* The chart must be added to the visual tree (i.e., the page must be rendered) before you can export it as an image.
* Ensure that the necessary file permissions are set on each platform to save the image to the appropriate location.

Learn step-by-step instructions and gain insights to export the cartesian chart as an image

**Step 1:** The layout is created using a Grid with two columns

**XAML**
 ```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"></ColumnDefinition>
        <ColumnDefinition Width="200"></ColumnDefinition>
    </Grid.ColumnDefinitions>
</Grid> 
 ```
 
**C#**
 
 ```csharp
var grid = new Grid();

grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
 
 ```

**Step 2:** In first column of grid layout, initialize the SfCartesianChart and add the series to the SfCartesianChart as shown below. For more details, refer to the [User Guide](https://help.syncfusion.com/maui/cartesian-charts/getting-started).

**XAML**
 
 ```xml
<chart:SfCartesianChart Grid.Column="0" x:Name="chart" Background="White">
    ....
    <chart:ColumnSeries ItemsSource="{Binding CartesianData}"
                    XBindingPath="Name" 
                    YBindingPath="Height"
                    ShowDataLabels="True"
                    Label="Height"
                    LegendIcon="SeriesType">
    </chart:ColumnSeries>
    <chart:ColumnSeries ItemsSource="{Binding CartesianData}"
                    XBindingPath="Name" 
                    YBindingPath="Weight"
                    ShowDataLabels="True"
                    Label="Weight"
                    YAxisName="series_YAxis"
                    LegendIcon="SeriesType">
    </chart:ColumnSeries>
</chart:SfCartesianChart> 
 ```
 
**C#**
 
 ```csharp
var chart = new SfCartesianChart
 {
     BackgroundColor = Colors.White
 };

......

 var heightSeries = new ColumnSeries
 {
     ItemsSource = viewModel.CartesianData,
     XBindingPath = "Name",
     YBindingPath = "Height",
     EnableTooltip = true,
     ShowDataLabels = true,
     Label = "Height",
     LegendIcon = ChartLegendIconType.SeriesType
 };
 chart.Series.Add(heightSeries);

 var weightSeries = new ColumnSeries
 {
     ItemsSource = viewModel.CartesianData,
     XBindingPath = "Name",
     YBindingPath = "Weight",
     EnableTooltip = true,
     ShowDataLabels = true,
     Label = "Weight",
     YAxisName = "series_YAxis",
     LegendIcon = ChartLegendIconType.SeriesType
 };
 chart.Series.Add(weightSeries);

 Grid.SetColumn(chart, 0);
 grid.Children.Add(chart); 
 ```
 

**Step 3:** In second column of grid layout contains vertical stacklayout with two buttons that allow the user to export the chart as either a **JPEG** or **PNG** image.

**XAML**
 
 ```xml
<VerticalStackLayout Grid.Column="1" Spacing="5">
    <Label Text="Image Formats" FontSize="15" FontAttributes="Bold"/>
    <Button Text="JPEG" Clicked="Button_Clicked_JPEG"/>
    <Button Text="PNG" Clicked="Button_Clicked_PNG"/>
</VerticalStackLayout> 
 ```
 
**C#**

 
 ```csharp
var stackLayout = new VerticalStackLayout
{
    Spacing = 5
};

var label = new Label
{
    Text = "Image Formats",
    FontSize = 15,
    FontAttributes = FontAttributes.Bold
};

stackLayout.Children.Add(label);

var jpegButton = new Button
{
    Text = "JPEG"
};
jpegButton.Clicked += Button_Clicked_JPEG;
stackLayout.Children.Add(jpegButton);

var pngButton = new Button
{
    Text = "PNG"
};
pngButton.Clicked += Button_Clicked_PNG;
stackLayout.Children.Add(pngButton);

Grid.SetColumn(stackLayout, 1);
grid.Children.Add(stackLayout);

Content = grid; 
 ```

**Step 4:** In the code-behind file, implement the [SaveAsImage method](https://help.syncfusion.com/maui/cartesian-charts/exporting#export-as-an-image) for exporting the chart as an image when the user clicks the buttons for respective file formats.

**C#**
 
 ```csharp
private void Button_Clicked_JPEG(object sender, EventArgs e)
{
    chart.SaveAsImage("CartesianChart1.jpeg");
}
private void Button_Clicked_PNG(object sender, EventArgs e)
{
    chart.SaveAsImage("CartesianChart2.png");
} 
 ```
 
**Platform-Specific Details:**

**Windows and macOS**
* File Path: By default, the exported image will be saved in the Pictures directory.
* Permission: To save the image, you must enable file writing permissions on the device storage.

**Android**
* File Path: The exported image will be saved inside the Pictures directory on the device’s file system.
* Permissions: To save the image on, you must enable file writing permissions on the device storage.

**iOS**
* File Path: The exported image will be saved inside the Photos/Album directory.
* Permissions: You need to enable Photos Library access in your Info.plist file to save the image in the photo album.
* Add the following to Info.plist
 
 ```xml
<dict>
    <key>NSPhotoLibraryUsageDescription</key>    
    <string>This App needs permission to access the Photos</string>    
    <key>NSPhotoLibraryAddUsageDescription</key>    
    <string>This App needs permission to access the Photos</string> 
</dict> 
 ```

**Output:**

Chart output
![Screenshot 2024-12-10 155037](https://github.com/user-attachments/assets/c34a6726-85df-4d53-ab1c-e2760bc5ff01)

Exported Chart Image
![CartesianChart2](https://github.com/user-attachments/assets/22c05edd-be10-456a-8c82-a33ba6b0db52)

