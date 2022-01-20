## Sample showing a ControlTemplate within a CollectionView ItemTemplate failing to update templated UI when  a TemplateBinding changes value

Running the app on Windows desktop is fine. Android is not.

- CollectionView
  - ItemTemplate
    - CollectionViewItem (derived from ContentView)
      - ControlTemplate
        - StackLayout with a **TemplateBinding** on the Padding property
        - ContentPresenter
      - Content

The StackLayout has a TemplateBinding that affects its left margin.   
On Windows, when modifying the source of the TemplateBinding (after the view has been rendered), 
 the Padding of the StackLayout is updated, as expected.  
**On Android, the ControlTemplate does not update its layout.**
  

This causes Android problems when the CollectionView recycles Views because the ControlTemplate 
is not updated for items that are contained within the recycled view.  

**Snippet showing the TemplateBinding in the ControlTemplate**

```xml
<StackLayout 
    Orientation="Horizontal"
    Padding="{TemplateBinding BindingContext.Offset, Converter={StaticResource PaddingConverter},  Mode=OneWay}"
>
    <ContentPresenter />
</StackLayout>
```

The PaddingConverter simply does this:
```csharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
    return new Thickness((double)value, 0, 0, 0);
}
```

The `BindingContext.Offset` has been attached to a Sine wave for demonstration purposes only. My real-world use 
is for the ControlTemplate to set the *indent* of items in a TreeView item.  
The TreeView is built around a CollectionView and works fine on Windows desktop.  
**On Android, when the CollectionView recycles containers, this indent is not updated when the BindingContext changes.**  
This leads my Android TreeView to have odd indents when expanding/collapsing nodes.  

Can you fix it? :)
